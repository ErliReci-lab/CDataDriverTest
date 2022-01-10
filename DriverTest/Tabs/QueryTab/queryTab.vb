Imports System.Data.Common
Imports PoorMansTSqlFormatterLib
Imports FastColoredTextBoxNS

Public Class queryTab
    Private queryEditor As FastColoredTextBox
    Private sqlFormatter As SqlFormattingManager = Nothing

    Private Sub queryTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.queryEditor = New FastColoredTextBox()
        queryEditor.BorderStyle = BorderStyle.None
        queryEditor.Dock = System.Windows.Forms.DockStyle.Fill
        queryEditor.Parent = queryHolder
        queryEditor.Paddings = New Padding(0)
        queryEditor.Margin = New Padding(0)
        queryEditor.BringToFront()
        queryEditor.Language = Language.SQL
        SplitContainer1.Orientation = My.Settings.SplitPos
    End Sub

    Public Sub rotateView()
        SplitContainer1.Orientation = IIf(SplitContainer1.Orientation = 0, 1, 0)
        My.Settings.SplitPos = SplitContainer1.Orientation
        My.Settings.Save()
    End Sub

    Public Sub insertQuery(query As String)
        Me.queryEditor.Text += query + vbNewLine
    End Sub

    Public Sub format()
        If sqlFormatter Is Nothing Then
            sqlFormatter = New SqlFormattingManager(New Formatters.TSqlStandardFormatter())
        End If
        queryEditor.Text = sqlFormatter.Format(queryEditor.Text)
    End Sub

    Public Sub execute()
        Try
            Form1.generateAuto()
            If queryEditor.Text.Trim() <> "" Then
                If My.Settings.FromatExecute Then
                    'format()
                End If
                Dim factory = DbProviderFactories.GetFactory(Form1.driverField.Text)
                Form1.changeStatus(Form1.StatusType.Query, "Conecting ...")
                Form1.changeStatus(Form1.StatusType.Connection, "Conecting ...")
                Using connection As DbConnection = factory.CreateConnection()
                    connection.ConnectionString = Form1.connectionField.Text
                    connection.Open()
                    Form1.changeStatus(Form1.StatusType.Connection, "Connected")
                    Dim queryToExecute = queryEditor.SelectedText
                    If queryToExecute Is Nothing Or queryToExecute = "" Or queryToExecute = " " Then
                        queryToExecute = queryEditor.Text
                    End If
                    queryToExecute = queryToExecute.Replace(vbNewLine, "")
                    Dim queries As String() = queryToExecute.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
                    Dim nrSelects = queries.Count(Function(x) x.ToLower().Contains("select"))
                    resultViewHolder.Controls.Clear()
                    resultViewHolder.RowStyles.Clear()
                    resultViewHolder.RowCount = 0
                    For Each query In queries
                        If query IsNot Nothing AndAlso query <> "" And query <> " " Then
                            Form1.changeStatus(Form1.StatusType.Query, "Querying ...")
                            Dim command As DbCommand = factory.CreateCommand()
                            command.CommandText = query
                            command.Connection = connection
                            If query.ToLower().Contains("select") Then
                                Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                                Dim a = factory.CreateCommandBuilder()
                                adapter.SelectCommand = command
                                Dim table As DataTable = New DataTable()
                                adapter.Fill(table)
                                Form1.changeStatus(Form1.StatusType.Query, "Filling ...")
                                resultViewHolder.RowStyles.Add(New RowStyle(SizeType.Percent, 100 / nrSelects))
                                Dim resultView As New DataGridView()
                                resultView.Dock = DockStyle.Fill
                                resultView.DataSource = table
                                resultView.AllowUserToAddRows = False
                                resultView.AllowUserToDeleteRows = False
                                resultView.ReadOnly = True
                                resultViewHolder.Controls.Add(resultView, 0, resultViewHolder.RowCount)
                                resultViewHolder.RowCount += 1
                            Else
                                command.ExecuteReader()
                            End If
                        End If
                    Next
                    Form1.changeStatus(Form1.StatusType.Query, "Done")
                End Using
                Form1.changeStatus(Form1.StatusType.Connection, "Done")
            End If
        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
            Form1.changeStatus(Form1.StatusType.Query, "Error")
            Form1.changeStatus(Form1.StatusType.Connection, "Error")
        End Try
    End Sub

    Private Sub resultView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class