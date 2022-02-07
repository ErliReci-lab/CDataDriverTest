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

Public Class CDataDriverClone
    Private _tables As Dictionary(Of String, CDataObject)
    Private _procedureTable As DataTable
    Public columnsFill As Boolean = False

    Public Sub setObjects(cdataObjects As Dictionary(Of String, CDataObject))
        _tables = cdataObjects
    End Sub

    Public Function getTableNames() As List(Of String)
        Return _tables.Keys.ToList()
    End Function

    Public Function getObjects() As Dictionary(Of String, CDataObject)
        Return _tables
    End Function

    Public Sub setProcedure(data As DataTable)
        _procedureTable = data
    End Sub

    Public Function getProcedure(procedureNames As String) As DataRow()
        Dim result() As DataRow = _procedureTable.Select($"ProcedureName = '{procedureNames}'")
        Return result
    End Function

    Public Function getProcedureNames() As List(Of String)
        Dim previous As String = ""
        Dim result As New List(Of String)
        For Each row In _procedureTable.Rows
            If previous <> row("ProcedureName") Then
                result.Add(row("ProcedureName"))
                previous = row("ProcedureName")
            End If
        Next
        Return result
    End Function

End Class

Module CDataDriver
    Public clone As New CDataDriverClone

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

                CDataDriver.driverClone(driver, connectionString)
            End Using

            Return True
        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
            Form1.changeStatus(Form1.StatusType.Connection, "Testing Failed")
            Return False
        End Try
    End Function

    Public Function driverClone(driver As String, connectionString As String)
        Try
            Dim factory = DbProviderFactories.GetFactory(driver)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionString & "Timeout=30;"
                connection.Open()
                Dim command As DbCommand = factory.CreateCommand()
                'command.CommandText = $"SELECT [sys_tablecolumns].*, [sys_tables].TableType FROM [sys_tablecolumns] INNER JOIN [sys_tables] ON [sys_tables].TableName = [sys_tablecolumns].TableName;"
                command.CommandText = $"SELECT * FROM [sys_tables];"
                command.Connection = connection
                Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                adapter.SelectCommand = command
                Dim table As DataTable = New DataTable()
                adapter.Fill(table)

                Dim results As New Dictionary(Of String, CDataObject)

                For Each row In table.Rows
                    Dim tableName As String = row("TableName").ToString()
                    If Not results.ContainsKey(tableName) Then
                        results.Add(tableName, New CDataObject(tableName, row("TableType")))
                    End If
                    'Dim newCol As New CDataColumn(row("ColumnName"), row("DataTypeName"))
                    'results(tableName).addRow(newCol)
                Next
                clone.setObjects(results)
                command.CommandText = "SELECT ProcedureName, ColumnName as Parameter, DataTypeName as DataType, IsRequired, Description, Values FROM sys_procedureparameters"
                command.Connection = connection
                Dim adapter1 As DbDataAdapter = factory.CreateDataAdapter()
                adapter1.SelectCommand = command
                Dim table1 As DataTable = New DataTable()
                adapter1.Fill(table1)
                clone.setProcedure(table1)
                Return clone
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
