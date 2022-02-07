Imports System.Data.Common

Public Class viewerTab
    Private allTables As Dictionary(Of String, CDataObject) = Nothing

    Private Sub viewerTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub fillObject()
        If allTables Is Nothing Then
            allTables = CDataDriver.clone.getObjects()
            If Not CDataDriver.clone.columnsFill Then
                Try
                    Dim factory = DbProviderFactories.GetFactory(Form1.driverField.Text)

                    Using connection As DbConnection = factory.CreateConnection()
                        connection.ConnectionString = Form1.connectionField.Text & "Timeout=30;"
                        connection.Open()
                        Dim command As DbCommand = factory.CreateCommand()
                        command.CommandText = $"SELECT [sys_tablecolumns].*, [sys_tables].TableType FROM [sys_tablecolumns] INNER JOIN [sys_tables] ON [sys_tables].TableName = [sys_tablecolumns].TableName;"
                        command.Connection = connection
                        Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                        adapter.SelectCommand = command
                        Dim table As DataTable = New DataTable()
                        adapter.Fill(table)

                        For Each row In table.Rows
                            Dim tableName As String = row("TableName").ToString()
                            allTables(tableName).addRow(New CDataColumn(row("ColumnName"), row("DataTypeName")))
                        Next
                        CDataDriver.clone.columnsFill = True
                    End Using

                Catch ex As Exception
                    UI.errorBox(ex.Message, ex.StackTrace)
                End Try
            End If
        End If
    End Sub

    Public Sub fullDB()
        fillObject()
        For Each table As KeyValuePair(Of String, CDataObject) In allTables
            Dim tableView = New TableComponent($"{table.Value.name()} ({table.Value.type()})")
            Me.Controls.Add(tableView)
            tableView.addColumns(table.Value.getColumns())
            tableView.Visible = True
        Next
    End Sub

    Public Sub specificDB(name As String)
        fillObject()
        Dim table As CDataObject = allTables(name)
        Dim tableView = New TableComponent($"{table.name()} ({table.type()})")
        Me.Controls.Add(tableView)
        tableView.addColumns(table.getColumns())
        tableView.Visible = True

    End Sub
End Class
