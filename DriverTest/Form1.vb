﻿Imports System.Data.Common
Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class Form1

    Private queryEditor As FastColoredTextBox
    Private autoGenerated As Boolean = False

    Private Sub testConnection()
        connectionStatus.Text = "Connection Status: Testing ..."
        Try
            Dim factory = DbProviderFactories.GetFactory(driverField.Text)

            Using connection As DbConnection = factory.CreateConnection()
                connection.ConnectionString = connectionField.Text
                connection.Open()
                connectionStatus.Text = "Connection Status: Testing Successful"

                MsgBox("Connection Successful")
            End Using

            generateAuto()
        Catch ex As Exception
            MsgBox(ex.Message)
            connectionStatus.Text = "Connection Status: Testing Failed"
        End Try
    End Sub

    Private Sub autoSelect(sender As Object, e As EventArgs)
        Dim table = sender.Tag
        queryEditor.Text = $"Select * From ""{table}"""
    End Sub

    Private Sub generateAuto()
        clearGeneratedAuto()
        Try
            If Not autoGenerated Then
                Dim factory = DbProviderFactories.GetFactory(driverField.Text)

                Using connection As DbConnection = factory.CreateConnection()
                    connection.ConnectionString = connectionField.Text
                    connection.Open()

                    Dim command As DbCommand = factory.CreateCommand()
                    command.CommandText = $"Select * From sys_tables"
                    command.Connection = connection
                    Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                    adapter.SelectCommand = command
                    Dim table As DataTable = New DataTable()
                    adapter.Fill(table)
                    SelectToolStripMenuItem1.DropDownItems.Add(New ToolStripSeparator())
                    For Each row As DataRow In table.Rows
                        Dim name = row("TableName").ToString()
                        Dim type = row("TableType").ToString()
                        Dim item = New ToolStripMenuItem($"{name} ({type})", Nothing, AddressOf autoSelect)
                        item.Tag = name
                        SelectToolStripMenuItem1.DropDownItems.Add(item)
                    Next row

                    autoGenerated = True
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub clearGeneratedAuto()
        Try
            If autoGenerated Then
                If SelectToolStripMenuItem1.DropDownItems.Count > 1 Then
                    For index = SelectToolStripMenuItem1.DropDownItems.Count - 1 To 1 Step -1
                        SelectToolStripMenuItem1.DropDownItems.RemoveAt(index)
                    Next
                End If
                autoGenerated = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub execute()
        Try
            If Not autoGenerated Then
                generateAuto()
            End If
            If queryEditor.Text <> "" And queryEditor.Text <> " " Then
                Dim factory = DbProviderFactories.GetFactory(driverField.Text)
                queryStatus.Text = $"Query Status: Conecting ..."
                connectionStatus.Text = "Connection Status: Conecting ..."
                Using connection As DbConnection = factory.CreateConnection()
                    connection.ConnectionString = connectionField.Text
                    connection.Open()
                    queryStatus.Text = $"Query Status: Querying ..."
                    connectionStatus.Text = "Connection Status: Connected"
                    Dim command As DbCommand = factory.CreateCommand()
                    command.CommandText = queryEditor.Text
                    command.Connection = connection
                    Dim adapter As DbDataAdapter = factory.CreateDataAdapter()
                    adapter.SelectCommand = command
                    Dim table As DataTable = New DataTable()
                    adapter.Fill(table)
                    queryStatus.Text = $"Query Status: Filling ..."

                    DataGridView1.DataSource = table
                    queryStatus.Text = $"Query Status: Done"

                End Using
                connectionStatus.Text = "Connection Status: Done"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            queryStatus.Text = $"Query Status: Error"
            connectionStatus.Text = "Connection Status: Error"
        End Try
    End Sub

    Private Sub propertyConnectionString(prop As String, value As String)
        'Dim hasIt = New Regex($"{prop}=(.*?);")
        'If hasIt.IsMatch(connectionField.Text) Then
        '    connectionField.Text = Regex.Replace(connectionField.Text, $"{prop}=(.*?);", $"{prop}={value};")
        'Else
        '    connectionField.Text += $"{prop}={value};"
        'End If
        Dim factory = DbProviderFactories.GetFactory(driverField.Text)
        For index = 0 To connectionGrid.Rows.Count - 1
            Dim key = connectionGrid.Rows(index).Cells(0).Value
            If key = prop Then
                connectionGrid.Rows(index).Cells(1).Value = value
                Exit For
            End If
        Next
        generateConnectionString()
    End Sub

    Private Sub generateConnectionString()
        Dim factory = DbProviderFactories.GetFactory(driverField.Text)
        connectionField.Text = $""
        For index = 0 To connectionGrid.Rows.Count - 1
            Dim key = connectionGrid.Rows(index).Cells(0).Value
            Dim val = connectionGrid.Rows(index).Cells(1).Value
            If val <> "" And val <> " " And val.ToString() <> factory.CreateConnectionStringBuilder().Item(key).ToString() Then
                connectionField.Text += $"{key}={val};"
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.queryEditor = New FastColoredTextBox()
        'logView.BackColor = hexToColor("#252526")
        'logView.ForeColor = Color.White
        queryEditor.BorderStyle = BorderStyle.None
        'logView.IndentBackColor = hexToColor("#252526")
        queryEditor.Dock = System.Windows.Forms.DockStyle.Fill
        queryEditor.Parent = queryHolder
        queryEditor.Paddings = New Padding(0)
        queryEditor.Margin = New Padding(0)
        queryEditor.BringToFront()
        queryEditor.Language = Language.SQL
        SplitContainer1.Orientation = My.Settings.SplitPos

        Dim driversTable = DbProviderFactories.GetFactoryClasses()
        For Each row In driversTable.Rows
            If row("Name").ToString().Contains("CData") Then
                driverField.Items.Add(row("InvariantName"))
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        execute()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        testConnection()
    End Sub

    Private Sub AddProxyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddProxyToolStripMenuItem.Click
        propertyConnectionString("Proxy Port", "8888")
        propertyConnectionString("Proxy Server", "127.0.0.1")
        propertyConnectionString("Proxy Auto Detect", "True")
    End Sub

    Private Sub ChangeSplitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeSplitToolStripMenuItem.Click
        'If SplitContainer1.Orientation = Orientation.Horizontal Then
        '    SplitContainer1.Orientation = Orientation.Vertical
        '    My.Settings.SplitPos = "Vertical"
        'Else
        '    SplitContainer1.Orientation = Orientation.Horizontal
        '    My.Settings.SplitPos = "Horizontal"
        'End If
        SplitContainer1.Orientation = IIf(SplitContainer1.Orientation = 0, 1, 0)
        My.Settings.SplitPos = SplitContainer1.Orientation
        My.Settings.Save()
    End Sub

    Private Sub SystablesToolStripMenuItem1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        testConnection()
    End Sub

    Private Sub SystablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystablesToolStripMenuItem.Click
        queryEditor.Text = $"Select * From sys_tables"
    End Sub

    Private Sub SelectToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem1.Click
        execute()
    End Sub

    Private Sub GETANDREFRESHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GETANDREFRESHToolStripMenuItem.Click
        propertyConnectionString("Initiate OAuth", "GETANDREFRESH")
    End Sub

    Private Sub REFRESHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REFRESHToolStripMenuItem.Click
        propertyConnectionString("Initiate OAuth", "REFRESH")
    End Sub

    Private Sub driverField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles driverField.SelectedIndexChanged
        Try
            Dim factory = DbProviderFactories.GetFactory(driverField.Text)
            connectionGrid.Rows.Clear()
            connectionField.Clear()
            For Each key In factory.CreateConnectionStringBuilder().Keys
                Dim defaultVal = factory.CreateConnectionStringBuilder().Item(key)
                connectionGrid.Rows.Add(New String() {key, defaultVal})
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub connectionGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles connectionGrid.CellContentClick

    End Sub

    Private Sub connectionGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles connectionGrid.CellEndEdit
        generateConnectionString()
    End Sub
End Class
