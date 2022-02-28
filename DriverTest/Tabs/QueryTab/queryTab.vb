Imports System.Data.Common
Imports PoorMansTSqlFormatterLib
Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions

Public Class queryTab
    Private queryEditor As FastColoredTextBox
    Private sqlFormatter As SqlFormattingManager = Nothing
    Private syntaxStyle = New TextStyle(Brushes.Blue, Nothing, FontStyle.Bold)
    Private popupMenu As AutocompleteMenu

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

        AddHandler queryEditor.TextChanged, AddressOf text_change
        AddHandler queryEditor.KeyDown, AddressOf key_down

        popupMenu = New AutocompleteMenu(queryEditor)
        popupMenu.MinFragmentLength = 2
        popupMenu.Items.MaximumSize = New System.Drawing.Size(200, 300)
        popupMenu.Items.Width = 200
    End Sub

    Public Sub fill_autocomplete(elements As List(Of String))
        popupMenu.Items.SetAutocompleteItems(elements)
    End Sub

    Public Sub text_change(sender As Object, e As TextChangedEventArgs)
        e.ChangedRange.ClearStyle(syntaxStyle)
        'Dim SQLKeywordsRegex = New Regex($"\b(TEST|LIMIT)\b", RegexOptions.IgnoreCase)
        Dim SQLKeywordsRegex = New Regex($"\b(LIMIT)\b", RegexOptions.IgnoreCase)
        e.ChangedRange.SetStyle(syntaxStyle, SQLKeywordsRegex)
    End Sub

    Public Sub key_down(sender As Object, e As KeyEventArgs)
        If e.KeyData = (Keys.K Or Keys.Control) Then
            popupMenu.Show(True)
            e.Handled = True
        End If
    End Sub

    Public Sub rotateView()
        SplitContainer1.Orientation = IIf(SplitContainer1.Orientation = 0, 1, 0)
        My.Settings.SplitPos = SplitContainer1.Orientation
        My.Settings.Save()
    End Sub

    Public Function getQuery() As String
        Return queryEditor.Text
    End Function

    Public Sub insertQuery(query As String)
        Me.queryEditor.Text += format(query) + vbNewLine
    End Sub

    Public Function format(code As String) As String
        If sqlFormatter Is Nothing Then
            Dim formatEngine = New Formatters.TSqlStandardFormatter()
            formatEngine.UppercaseKeywords = True
            formatEngine.SpaceAfterExpandedComma = True
            sqlFormatter = New SqlFormattingManager(formatEngine)
        End If
        Return sqlFormatter.Format(code).Replace(vbCrLf, " " & vbCrLf).Trim()
    End Function

    Public Sub formatEditor()
        queryEditor.Text = format(queryEditor.Text)
    End Sub

    Public Sub execute()
        Try
            'Form1.generateAuto()
            If queryEditor.Text.Trim() <> "" Then
                Dim queryToExecute = queryEditor.SelectedText.Trim()
                If queryToExecute Is Nothing Or queryToExecute = "" Then
                    queryToExecute = queryEditor.Text
                    If My.Settings.FromatExecute Then
                        formatEditor()
                    End If
                End If

                queryToExecute = queryToExecute.Replace(vbNewLine, "")
                Dim queries As String() = queryToExecute.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
                Dim queryWithSelect = queries.Where(Function(x) x.ToLower().Contains("select"))
                Dim otherQueries = queries.Where(Function(x) Not x.ToLower().Contains("select"))
                resultViewHolder.Controls.Clear()
                resultViewHolder.RowStyles.Clear()
                resultViewHolder.RowCount = 0


                Dim results = Core.executeSelects(queryWithSelect.ToArray(), Form1.driverField.Text, Form1.connectionField.Text)

                For Each table In results
                    resultViewHolder.RowStyles.Add(New RowStyle(SizeType.Percent, 100 / queryWithSelect.Count() + queryWithSelect.Count()))
                    Dim resultView As New DataGridView()
                    resultView.Dock = DockStyle.Fill
                    resultView.DataSource = table
                    resultView.AllowUserToAddRows = False
                    resultView.AllowUserToDeleteRows = False
                    resultView.ReadOnly = True
                    resultViewHolder.Controls.Add(resultView, 0, resultViewHolder.RowCount)
                    resultViewHolder.RowCount += 1
                Next


                If otherQueries.Count() > 0 Then
                    resultViewHolder.RowStyles.Add(New RowStyle(SizeType.Percent, 100 / queryWithSelect.Count() + queryWithSelect.Count()))
                    Dim table = Core.executeQueries(otherQueries.ToArray(), Form1.driverField.Text, Form1.connectionField.Text)
                    Dim resultView As New DataGridView()
                    resultView.Dock = DockStyle.Fill
                    resultView.DataSource = table
                    resultView.AllowUserToAddRows = False
                    resultView.AllowUserToDeleteRows = False
                    resultView.ReadOnly = True
                    resultViewHolder.Controls.Add(resultView, 0, resultViewHolder.RowCount)
                    resultViewHolder.RowCount += 1
                End If

            End If
        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
        End Try
    End Sub
End Class