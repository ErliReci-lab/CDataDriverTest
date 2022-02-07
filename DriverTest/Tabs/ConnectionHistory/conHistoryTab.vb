Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class conHistoryTab

    Private Sub conHistoryTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ConnectionHistory = JObject.Parse(My.Settings.ConnectionHistory)
        For Each pair As KeyValuePair(Of String, JToken) In ConnectionHistory
            historyGrid.Rows.Add(New String() {pair.Key, pair.Value.ToString()})
        Next
    End Sub

    Private Sub historyGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles historyGrid.CellContentClick

    End Sub

    Private Sub historyGrid_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles historyGrid.RowsRemoved
        Dim ConnectionHistory = New Dictionary(Of String, String)
        For index = 0 To historyGrid.Rows.Count - 1
            Dim key = historyGrid.Rows(index).Cells(0).Value
            Dim val = historyGrid.Rows(index).Cells(1).Value
            ConnectionHistory.Add(key, val)
        Next
        My.Settings.ConnectionHistory = JsonConvert.SerializeObject(ConnectionHistory)
        My.Settings.Save()
    End Sub

    Private Sub historyGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles historyGrid.CellEndEdit
        Dim ConnectionHistory = New Dictionary(Of String, String)
        For index = 0 To historyGrid.Rows.Count - 1
            Dim key = historyGrid.Rows(index).Cells(0).Value
            Dim val = historyGrid.Rows(index).Cells(1).Value
            ConnectionHistory.Add(key, val)
        Next
        My.Settings.ConnectionHistory = JsonConvert.SerializeObject(ConnectionHistory)
        My.Settings.Save()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        SaveFileDialog1.Filter = "CDataCon Files (*.concd*)|*.concd"
        SaveFileDialog1.FileName = "CDataCon"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            System.IO.File.WriteAllText(SaveFileDialog1.FileName, My.Settings.ConnectionHistory)
        End If
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        OpenFileDialog1.Filter = "CDataCon Files (*.concd*)|*.concd"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            Dim path As String = OpenFileDialog1.FileName
            Try
                Dim text As String = File.ReadAllText(path)
                Dim testJson = JObject.Parse(text)
                My.Settings.ConnectionHistory = text
                My.Settings.Save()
                For Each pair As KeyValuePair(Of String, JToken) In testJson
                    historyGrid.Rows.Add(New String() {pair.Key, pair.Value.ToString()})
                Next
            Catch ex As Exception
            End Try
        End If

    End Sub
End Class
