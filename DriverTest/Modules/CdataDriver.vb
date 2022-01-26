Imports System.Data.Common
Imports Newtonsoft.Json.Linq

Public Class CDataColumn
    Private _name As String = ""
    Private _dataType As String = ""
    Private _isKey As Boolean = False
    Private _isNullable As Boolean = False

    Public Sub New(name As String, dataType As String)
        Me._name = name
        Me._dataType = dataType
    End Sub

    Public Function name() As String
        Return _name
    End Function

    Public Function dataType() As String
        Return _dataType
    End Function

    Public Property IsKey As Boolean
        Get
            Return _isKey
        End Get
        Set(value As Boolean)
            _isKey = value
        End Set
    End Property

    Public Property IsNullable As Boolean
        Get
            Return _isNullable
        End Get
        Set(value As Boolean)
            _isNullable = value
        End Set
    End Property
End Class

Public Class CDataObject
    Private _name As String = ""
    Private _type As String = ""
    Private _columns As New Dictionary(Of String, CDataColumn)
    Private _colNameCount As Integer = 2

    Public Sub New(name As String, type As String)
        Me._name = name
        Me._type = type
    End Sub

    Public Sub addRow(name As String, dataType As String)
        _columns.Add(name, New CDataColumn(name, dataType))
    End Sub

    Public Sub addRow(col As CDataColumn)
        If _columns.ContainsKey(col.name()) Then
            _columns.Add(col.name() & _colNameCount.ToString(), col)
            _colNameCount += 1
        Else
            _columns.Add(col.name(), col)
        End If
    End Sub

    Public Function name() As String
        Return _name
    End Function

    Public Function type() As String
        Return _type
    End Function

    Public Function getColumns() As Dictionary(Of String, CDataColumn)
        Return Me._columns
    End Function
End Class

Module CDataDriver

    Public Function testConnection(driver As String, connectionString As String) As Boolean
        Form1.changeStatus(Form1.StatusType.Connection, "Testing ...")
        Try
            Dim factory = DbProviderFactories.GetFactory(driver)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionString
                connection.Open()

                Dim command As DbCommand = factory.CreateCommand()
                command.CommandText = $"Select * From sys_tables"
                command.Connection = connection
                command.ExecuteReader()

                Form1.changeStatus(Form1.StatusType.Connection, "Testing Successful")
                MsgBox("Connection Successful")
                If connectionString.Trim() <> "" And Not driver.Contains("csv") And Not driver.Contains("json") Then
                    Dim ConnectionHistory = JToken.Parse(My.Settings.ConnectionHistory)
                    ConnectionHistory(driver) = connectionString
                    My.Settings.ConnectionHistory = ConnectionHistory.ToString()
                    My.Settings.Save()
                End If
            End Using

            Return True
        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
            Form1.changeStatus(Form1.StatusType.Connection, "Testing Failed")
            Return False
        End Try
    End Function

    Public Function getTables(driver As String, connectionString As String) As Dictionary(Of String, CDataObject)
        Try
            Dim factory = DbProviderFactories.GetFactory(driver)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionString
                connection.Open()
                Dim command As DbCommand = factory.CreateCommand()
                command.CommandText = $"SELECT * FROM sys_tablecolumns"
                command.Connection = connection
                Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                adapter.SelectCommand = command
                Dim table As DataTable = New DataTable()
                adapter.Fill(table)

                Dim results As New Dictionary(Of String, CDataObject)

                For Each row In table.Rows
                    Dim tableName As String = row("TableName").ToString()
                    If Not results.ContainsKey(tableName) Then
                        results.Add(tableName, New CDataObject(tableName, row("CatalogName")))
                    End If
                    Dim newCol As New CDataColumn(row("ColumnName"), row("DataTypeName"))
                    results(tableName).addRow(newCol)
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
            If val IsNot Nothing And Not IsDBNull(val) AndAlso (val <> "" And val <> " ") Then
                If factory.CreateConnectionStringBuilder()(key) IsNot Nothing Then
                    If val.ToString().ToLower() <> factory.CreateConnectionStringBuilder()(key).ToString().ToLower() Then
                        connectionField += $"{key}={val};"
                    End If
                End If
            End If
        Next
        Return connectionField
    End Function
End Module
