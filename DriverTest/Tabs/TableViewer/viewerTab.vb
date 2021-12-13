Public Class viewerTab
    Private Sub viewerTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim allTables As Dictionary(Of String, CDataObject) = CDataDriver.getTables(Form1.driverField.Text, Form1.connectionField.Text)

        For Each table As KeyValuePair(Of String, CDataObject) In allTables
            Dim tableView = New TableComponent($"{table.Value.name()} ({table.Value.type()})")
            Me.Controls.Add(tableView)
            tableView.addColumns(table.Value.getColumns())
            tableView.Visible = True
        Next

    End Sub
End Class
