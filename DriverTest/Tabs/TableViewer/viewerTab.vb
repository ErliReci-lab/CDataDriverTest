Imports System.Data.Common

Public Class viewerTab

    Private Sub fillObject()

        Dim query As String() = {"SELECT [sys_tablecolumns].*, [sys_tables].TableType FROM [sys_tablecolumns] INNER JOIN [sys_tables] ON [sys_tables].TableName = [sys_tablecolumns].TableName;"}

        Form1.chache.getData(Form1.CacheKeys.TableViewColumns, Function()
                                                                   Return Core.executeSelects(query, Form1.driverField.Text, Form1.connectionField.Text)(0)
                                                               End Function)
    End Sub

    Public Sub fullDB()
        fillObject()
        Dim tablesViews As DataTable = Form1.chache.getData(Form1.CacheKeys.TableView)
        For Each tableName In tablesViews.Rows
            Try
                Dim table As DataTable = Form1.chache.getData(Form1.CacheKeys.TableViewColumns)
                Dim rows As IEnumerable(Of DataRow) = table.Select().Where(Function(x) x("TableName") = tableName("TableName"))
                Dim tableView = New TableComponent($"{tableName} ({rows(0)("TableType")})")
                Me.Controls.Add(tableView)
                tableView.addColumns(rows.ToArray())
                tableView.Visible = True
            Catch ex As Exception

            End Try
        Next

    End Sub

    Public Sub specificDB(name As String)
        Try
            fillObject()
            Dim table As DataTable = Form1.chache.getData(Form1.CacheKeys.TableViewColumns)
            Dim rows As IEnumerable(Of DataRow) = table.Select().Where(Function(x) x("TableName") = name)
            Dim tableView = New TableComponent($"{name} ({rows(0)("TableType")})")
            Me.Controls.Add(tableView)
            tableView.addColumns(rows.ToArray())
            tableView.Visible = True
        Catch ex As Exception

        End Try
    End Sub
End Class
