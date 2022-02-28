Imports System.Data.Common

Public Class dataTab

    Private Sub dataTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim tableNames As DataTable = Form1.chache.getData(Form1.CacheKeys.TableView, Function()
                                                                                              Return Core.getTablesViews(Form1.driverField.Text, Form1.connectionField.Text)
                                                                                          End Function)
            For Each tableRow In tableNames.Rows
                tableList.Items.Add(tableRow("TableName"))
            Next
        Catch ex1 As Exception

        End Try
    End Sub

    Private Sub tableList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tableList.SelectedIndexChanged
        Try
            resultView.DataSource = Nothing
            resultView.Refresh()

            Dim query As String() = {$"Select * from [{tableList.SelectedItem.ToString()}]"}
            resultView.DataSource = Core.executeSelects(query, Form1.driverField.Text, Form1.connectionField.Text)(0)
            resultView.ReadOnly = True
        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
        End Try
    End Sub
End Class
