Imports System.Data.Common

Module CDataDriver
    Public Sub testConnection(driver As String, connectionString As String)
        Form1.changeStatus(Form1.StatusType.Connection, "Testing ...")
        Try
            Dim factory = DbProviderFactories.GetFactory(driver)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionString
                connection.Open()
                Form1.changeStatus(Form1.StatusType.Connection, "Testing Successful")

                MsgBox("Connection Successful")
            End Using

        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
            Form1.changeStatus(Form1.StatusType.Connection, "Testing Failed")
        End Try
    End Sub

    Public Function getTables(driver As String, connectionString As String) As Dictionary(Of String, List(Of Tuple(Of String, String)))
        Try
            Dim factory = DbProviderFactories.GetFactory(driver)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionString
                connection.Open()
                Dim command As DbCommand = factory.CreateCommand()
                command.CommandText = $"SELECT TableName, ColumnName, DataTypeName FROM sys_tablecolumns"
                command.Connection = connection
                Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                adapter.SelectCommand = command
                Dim table As DataTable = New DataTable()
                adapter.Fill(table)

                Dim results As New Dictionary(Of String, List(Of Tuple(Of String, String)))

                For Each row In table.Rows
                    Dim tableName As String = row("TableName").ToString()
                    If Not results.ContainsKey(tableName) Then
                        results.Add(tableName, New List(Of Tuple(Of String, String)))
                    End If
                    results(tableName).Add(Tuple.Create(Of String, String)(row("ColumnName"), row("DataTypeName")))
                Next
                Return results
            End Using

        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
            Return Nothing
        End Try
    End Function

    Public Function generateConnectionString(driver As String, connectionGrid As DataGridView) As String
        Dim factory = DbProviderFactories.GetFactory(driver)
        Dim connectionField As String = ""
        For index = 0 To connectionGrid.Rows.Count - 1
            Dim key = connectionGrid.Rows(index).Cells(0).Value
            Dim val = connectionGrid.Rows(index).Cells(1).Value
            If val IsNot Nothing AndAlso val <> "" And val <> " " And val.ToString() <> factory.CreateConnectionStringBuilder().Item(key).ToString() Then
                connectionField += $"{key}={val};"
            End If
        Next
        Return connectionField
    End Function
End Module
