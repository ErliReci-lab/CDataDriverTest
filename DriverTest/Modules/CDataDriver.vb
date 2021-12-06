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
            MsgBox(ex.Message)
            Form1.changeStatus(Form1.StatusType.Connection, "Testing Failed")
        End Try
    End Sub

    Public Function generateConnectionString(driver As String, connectionGrid As DataGridView) As String
        Dim factory = DbProviderFactories.GetFactory(driver)
        Dim connectionField As String = ""
        For index = 0 To connectionGrid.Rows.Count - 1
            Dim key = connectionGrid.Rows(index).Cells(0).Value
            Dim val = connectionGrid.Rows(index).Cells(1).Value
            If val <> "" And val <> " " And val.ToString() <> factory.CreateConnectionStringBuilder().Item(key).ToString() Then
                connectionField += $"{key}={val};"
            End If
        Next
        Return connectionField
    End Function
End Module
