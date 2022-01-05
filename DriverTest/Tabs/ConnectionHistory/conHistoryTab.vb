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
End Class
