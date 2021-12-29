﻿Imports System.Data.Common

Public Class Form1

    Private autoGenerated As Boolean = False
    Private viewerOpened As Boolean = False

#Region "View"
    Public Enum StatusType
        Query = 0
        Connection = 1
    End Enum

    Public Sub changeStatus(type As StatusType, status As String)
        If type = StatusType.Connection Then
            connectionStatus.Text = $"Connection Status: {status}"
        ElseIf type = StatusType.Query Then
            queryStatus.Text = $"Query Status: {status}"
        End If
    End Sub
#End Region

#Region "Tabs"
    Private tabCount As Integer = 1

    Private Function getSelected() As queryTab
        Return tabHolder.SelectedTab.Controls(0)
    End Function

    Private Sub addTab()
        Dim page = New TabPage()
        page.Text = $"Query {tabCount}"
        tabCount += 1
        page.Controls.Add(New queryTab With {.Visible = True, .Dock = DockStyle.Fill})
        tabHolder.TabPages.Add(page)
    End Sub

    Private Sub removeTab()
        tabHolder.TabPages.Remove(tabHolder.SelectedTab)
        tabCount -= 1
    End Sub
#End Region
    Private Sub autoSelect(sender As Object, e As EventArgs)
        Dim table = sender.Tag
        getSelected().insertQuery($"Select * From [{table}];")
    End Sub

    Public Sub generateAuto()
        Try
            If Not autoGenerated Then
                clearGeneratedAuto()

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
                    For Each row As DataRow In table.Rows
                        Dim name = row("TableName").ToString()
                        Dim type = row("TableType").ToString()
                        Dim item = New ToolStripMenuItem($"{name}", Nothing, AddressOf autoSelect)
                        item.Tag = name
                        If type = "VIEW" Then
                            ViewsToolStripMenuItem.DropDownItems.Add(item)
                        ElseIf type = "TABLE" Then
                            TablesToolStripMenuItem.DropDownItems.Add(item)
                        End If
                    Next row

                    autoGenerated = True
                End Using
            End If
        Catch ex As Exception
            UI.errorBox(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Sub clearGeneratedAuto()
        Try
            If autoGenerated Then
                If SelectToolStripMenuItem1.DropDownItems.Count > 2 Then
                    ViewsToolStripMenuItem.DropDownItems.Clear()
                    TablesToolStripMenuItem.DropDownItems.Clear()
                End If
                autoGenerated = False
            End If
        Catch ex As Exception
            errorBox(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub execute()
        getSelected().execute()
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
        connectionField.Text = generateConnectionString(driverField.Text, connectionGrid)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addTab()
        ToolStripMenuItem3.Checked = My.Settings.FromatExecute
        'SplitContainer2.Panel2Collapsed = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SelectToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TestToolStripMenuItem.PerformClick()
    End Sub

    Private Sub AddProxyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddProxyToolStripMenuItem.Click
        propertyConnectionString("Proxy Port", "8888")
        propertyConnectionString("Proxy Server", "localhost")
        propertyConnectionString("Proxy Auto Detect", "False")
    End Sub

    Private Sub ChangeSplitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeSplitToolStripMenuItem.Click
        getSelected().rotateView()
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        testConnection(driverField.Text, connectionField.Text)
        generateAuto()
    End Sub

    Private Sub SystablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystablesToolStripMenuItem.Click
        getSelected().insertQuery($"Select * From [sys_tables];")
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
            errorBox(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub connectionGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles connectionGrid.CellEndEdit
        connectionField.Text = generateConnectionString(driverField.Text, connectionGrid)
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dim newF1 = New Form1()
        newF1.Show()
    End Sub

    Private Sub NewTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTabToolStripMenuItem.Click
        addTab()
    End Sub

    Private Sub RemoveTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveTabToolStripMenuItem.Click
        removeTab()
    End Sub

    Private Sub ViewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewerToolStripMenuItem.Click
        If Not viewerOpened Then
            Dim page = New TabPage($"Viewer")
            page.Name = page.Text
            page.Controls.Add(New viewerTab With {.Visible = True, .Dock = DockStyle.Fill})
            tabHolder.TabPages.Add(page)
            viewerOpened = True
        End If

        tabHolder.SelectedTab = tabHolder.TabPages($"Viewer")
    End Sub

    Private Sub SystablecolumnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystablecolumnsToolStripMenuItem.Click
        getSelected().insertQuery($"Select * From [sys_tablecolumns];")
    End Sub

    Private Sub CloseViewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseViewerToolStripMenuItem.Click
        If viewerOpened Then
            tabHolder.TabPages.Remove(tabHolder.TabPages($"Viewer"))
            viewerOpened = False
        End If
    End Sub

    Private Sub driverField_DropDown(sender As Object, e As EventArgs) Handles driverField.DropDown
        driverField.Items.Clear()
        ViewsToolStripMenuItem.DropDownItems.Clear()
        TablesToolStripMenuItem.DropDownItems.Clear()
        autoGenerated = False
        Dim driversTable = DbProviderFactories.GetFactoryClasses()
        For Each row In driversTable.Rows
            If row("Name").ToString().Contains("CData") Then
                driverField.Items.Add(row("InvariantName"))
            End If
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Clipboard.SetText(connectionField.Text)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        getSelected().format()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        My.Settings.FromatExecute = ToolStripMenuItem3.Checked
        My.Settings.Save()
    End Sub
End Class
