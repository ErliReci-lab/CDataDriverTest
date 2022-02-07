Imports System.Data.Common

Public Class dataTab

    Private Sub dataTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim tableNames = CDataDriver.clone.getTableNames()
            For Each tableName In tableNames
                tableList.Items.Add(tableName)
            Next
        Catch ex1 As Exception

        End Try
    End Sub

    Private Sub tableList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tableList.SelectedIndexChanged
        Try
            Dim factory = DbProviderFactories.GetFactory(Form1.driverField.Text)
            Form1.changeStatus(Form1.StatusType.Query, "Conecting ...")
            Form1.changeStatus(Form1.StatusType.Connection, "Conecting ...")
            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = Form1.connectionField.Text
                connection.Open()
                resultView.DataSource = Nothing
                resultView.Refresh()
                Form1.changeStatus(Form1.StatusType.Connection, "Connected")
                Form1.changeStatus(Form1.StatusType.Query, "Querying ...")
                Dim command As DbCommand = factory.CreateCommand()
                command.CommandText = $"Select * from [{tableList.SelectedItem.ToString()}]"
                command.Connection = connection
                Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                Dim a = factory.CreateCommandBuilder()
                adapter.SelectCommand = command
                Dim table As DataTable = New DataTable()
                adapter.Fill(table)
                Form1.changeStatus(Form1.StatusType.Query, "Filling ...")
                resultView.DataSource = table
                resultView.ReadOnly = True
                Form1.changeStatus(Form1.StatusType.Query, "Done")
            End Using
            Form1.changeStatus(Form1.StatusType.Connection, "Done")
        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
            Form1.changeStatus(Form1.StatusType.Query, "Error")
            Form1.changeStatus(Form1.StatusType.Connection, "Error")
        End Try
    End Sub
End Class
