Public Class viewerTab
    Private allTables As Dictionary(Of String, CDataObject) = Nothing

    Private Sub viewerTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub fillObject()
        If allTables Is Nothing Then
            allTables = CDataDriver.getTables(Form1.driverField.Text, Form1.connectionField.Text)
        End If
    End Sub

    Public Sub fullDB()
        fillObject()
        For Each table As KeyValuePair(Of String, CDataObject) In allTables
            Dim tableView = New TableComponent($"{table.Value.name()}")
            Me.Controls.Add(tableView)
            tableView.addColumns(table.Value.getColumns())
            tableView.Visible = True
        Next
    End Sub

    Public Sub specificDB(name As String)
        fillObject()
        Dim table As CDataObject = allTables(name)
        Dim tableView = New TableComponent($"{table.name()}")
        Me.Controls.Add(tableView)
        tableView.addColumns(table.getColumns())
        tableView.Visible = True

    End Sub
End Class
