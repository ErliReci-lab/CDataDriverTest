Public Class viewerTab
    Private Sub viewerTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim allTables As Dictionary(Of String, List(Of Tuple(Of String, String))) = CDataDriver.getTables(Form1.driverField.Text, Form1.connectionField.Text)

        For Each table As KeyValuePair(Of String, List(Of Tuple(Of String, String))) In allTables
            Dim tableView = New TableComponent(table.Key)
            Me.Controls.Add(tableView)
            tableView.addColumns(table.Value)
            tableView.Visible = True
        Next

    End Sub
End Class
