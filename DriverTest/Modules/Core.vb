Imports System.Data.Common

Module Core
    Public Enum StatusType
        All = 0
        Query = 1
        Connection = 2
    End Enum

    Public Event status(ByVal type As StatusType, ByVal status As String)

    Public Function testConnection(driver As String, connectionString As String) As Boolean
        RaiseEvent status(StatusType.Connection, "Testing ...")
        Try
            Dim factory = DbProviderFactories.GetFactory(driver)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionString
                connection.Open()

                Dim command As DbCommand = factory.CreateCommand()
                command.CommandText = $"Select * From sys_tables"
                command.Connection = connection
                command.ExecuteReader()

                RaiseEvent status(StatusType.Connection, "Testing Successful")
            End Using

            Return True
        Catch ex As Exception
            RaiseEvent status(StatusType.Connection, "Testing Failed")
            Return False
        End Try
    End Function

    Public Function executeSelects(quieries As String(), driver As String, connectionString As String, Optional returnNull As Boolean = False) As List(Of DataTable)
        RaiseEvent status(StatusType.All, "Conecting ...")
        Try
            Dim factory = DbProviderFactories.GetFactory(driver)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionString
                connection.Open()

                Dim result As New List(Of DataTable)
                Dim errorTableUsed As Boolean = False
                Dim errorTable As DataTable = New DataTable()
                errorTable.Columns.Add("Query")
                errorTable.Columns.Add("Status")
                errorTable.Columns.Add("Message")

                RaiseEvent status(StatusType.Connection, "Connected")

                For Each query As String In quieries
                    RaiseEvent status(StatusType.Query, "Querying ...")
                    Try
                        Using command As DbCommand = factory.CreateCommand()
                            Dim table As DataTable = New DataTable()
                            command.CommandText = query
                            command.Connection = connection
                            Using adapter As DbDataAdapter = factory.CreateDataAdapter()
                                adapter.SelectCommand = command
                                RaiseEvent status(StatusType.Query, "Filling ...")
                                adapter.Fill(table)
                            End Using
                            result.Add(table)
                        End Using
                    Catch ex As Exception
                        errorTableUsed = True
                        If returnNull = False Then
                            errorTable.Rows.Add(New String() {query, "Failed", ex.Message.ToString()})
                        Else
                            errorTable = Nothing
                        End If
                    End Try
                Next

                RaiseEvent status(StatusType.All, "Done")

                If errorTableUsed Then
                    result.Add(errorTable)
                End If

                Return result
            End Using

        Catch ex As Exception
            RaiseEvent status(StatusType.All, "Failed")
            Return Nothing
        End Try
    End Function

    Public Function executeQueries(quieries As String(), driver As String, connectionString As String) As DataTable
        RaiseEvent status(StatusType.All, "Conecting ...")
        Try
            Dim factory = DbProviderFactories.GetFactory(driver)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionString
                connection.Open()

                Dim result As New DataTable()
                result.Columns.Add("Query")
                result.Columns.Add("Status")
                result.Columns.Add("Message")

                RaiseEvent status(StatusType.Connection, "Connected")

                For Each query As String In quieries
                    RaiseEvent status(StatusType.Query, "Querying ...")
                    Try
                        Using command As DbCommand = factory.CreateCommand()
                            command.CommandText = query
                            command.Connection = connection
                            Dim state = command.ExecuteScalar()

                            If state IsNot Nothing Then
                                result.Rows.Add(New String() {query, "Successful", ""})
                            Else
                                result.Rows.Add(New String() {query, "Failed", ""})
                            End If
                        End Using
                    Catch ex As Exception
                        result.Rows.Add(New String() {query, "Failed", ex.Message.ToString()})
                    End Try
                Next

                RaiseEvent status(StatusType.All, "Done")

                Return result
            End Using

        Catch ex As Exception
            RaiseEvent status(StatusType.All, "Failed")
            Return Nothing
        End Try
    End Function

    Public Function getTablesViews(driver As String, connectionString As String) As DataTable
        Dim query As String() = {"SELECT * FROM [sys_tables];"}
        Dim allTables As DataTable = executeSelects(query, driver, connectionString, True)(0)
        For Each table In New String() {"sys_tables", "sys_catalogs", "sys_schemas", "sys_tablecolumns", "sys_procedures", "sys_procedureparameters",
            "sys_keycolumns", "sys_indexes", "sys_connection_props", "sys_sqlinfo", "sys_identity"}
            allTables.Rows.Add(New Object() {"System", "System", table, "SYSTABLE", "", False})
        Next
        Return allTables
    End Function

    Public Function getStoreProcedures(driver As String, connectionString As String) As DataTable
        Dim query As String() = {"SELECT ProcedureName 
                                            , ColumnName AS Parameter 
                                            , DataTypeName AS DataType 
                                            , IsRequired 
                                            , Description 
                                            , CASE  
                                                WHEN VALUES IS NULL 
                                                    THEN False 
                                                ELSE True 
                                                END DefaultValue 
                                            , Values 
                                        FROM sys_procedureparameters".Replace(vbNewLine, " ")}
        Return executeSelects(query, driver, connectionString, True)(0)
    End Function

    Public Function getConnectionProperties(driver As String, connectionString As String) As DataTable
        Dim table As DataTable = New DataTable()
        table.Columns.Add("PropertyName")
        table.Columns.Add("Value")
        Try
            Dim query As String() = {"select 
                                        ,CASE 
                                            WHEN Visible = True
                                                And Category <> ''
                                                THEN Category
                                            WHEN Visible = True
                                                And Category = ''
                                                THEN 'Miscellaneous'
                                            WHEN Visible = False
                                                THEN 'ZZNotVisible'
                                            Else 'Other'
                                        End Category
                                        ,PropertyName
                                        ,DEFAULT Value
                                        From sys_connection_props
                                        Order By Category;".Replace(vbNewLine, " ")}

            Dim tableTemp As DataTable = New DataTable()
            tableTemp = executeSelects(query, driver, connectionString, True)(0)
            Dim category As String = ""
            For Each row As DataRow In tableTemp.Rows
                Dim propCategory = row("Category").ToString()
                Dim propName = row("PropertyName").ToString()
                Dim propVal = row("Value").ToString()
                If category <> propCategory Then
                    table.Rows.Add(New String() {$"# {propCategory.Replace("ZZ", "")}", ""})
                    category = propCategory
                End If
                table.Rows.Add(New String() {propName, propVal})
            Next
        Catch ex As Exception
            table.Rows.Add(New String() {$"# All", ""})
            Dim factory = DbProviderFactories.GetFactory(driver)
            For Each key In factory.CreateConnectionStringBuilder().Keys
                key = key.Replace(" ", "")
                Dim defaultVal = factory.CreateConnectionStringBuilder()(key)
                table.Rows.Add(New String() {key, defaultVal})
            Next
        End Try
        Return table
    End Function
End Module
