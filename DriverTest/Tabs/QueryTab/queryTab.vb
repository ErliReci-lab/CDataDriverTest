Imports System.Data.Common
Imports FastColoredTextBoxNS

Public Class queryTab
    Private queryEditor As FastColoredTextBox

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
        Me.queryEditor.Text = query
    End Sub

    Public Sub execute()
        Try
            Form1.generateAuto()
            If queryEditor.Text <> "" And queryEditor.Text <> " " Then
                Dim factory = DbProviderFactories.GetFactory(Form1.driverField.Text)
                Form1.changeStatus(Form1.StatusType.Query, "Conecting ...")
                Form1.changeStatus(Form1.StatusType.Connection, "Conecting ...")
                Using connection As DbConnection = factory.CreateConnection()
                    connection.ConnectionString = Form1.connectionField.Text
                    connection.Open()
                    Form1.changeStatus(Form1.StatusType.Query, "Querying ...")
                    Form1.changeStatus(Form1.StatusType.Connection, "Connected")
                    Dim command As DbCommand = factory.CreateCommand()
                    command.CommandText = queryEditor.Text
                    command.Connection = connection
                    Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                    adapter.SelectCommand = command
                    Dim table As DataTable = New DataTable()
                    adapter.Fill(table)
                    Form1.changeStatus(Form1.StatusType.Query, "Filling ...")

                    resultView.DataSource = table
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

    Private Sub resultView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles resultView.CellContentClick

    End Sub
End Class