<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.connectionField = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.driverField = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.queryStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.connectionStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.QuickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddProxyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystablecolumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GETANDREFRESHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REFRESHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeSplitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.connectionGrid = New System.Windows.Forms.DataGridView()
        Me.CProperty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tabHolder = New System.Windows.Forms.TabControl()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.connectionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Execute"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.connectionField)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.driverField)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(926, 67)
        Me.Panel1.TabIndex = 2
        '
        'connectionField
        '
        Me.connectionField.Location = New System.Drawing.Point(334, 5)
        Me.connectionField.Multiline = True
        Me.connectionField.Name = "connectionField"
        Me.connectionField.Size = New System.Drawing.Size(464, 58)
        Me.connectionField.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(140, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Test Connection"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'driverField
        '
        Me.driverField.FormattingEnabled = True
        Me.driverField.Location = New System.Drawing.Point(56, 8)
        Me.driverField.Name = "driverField"
        Me.driverField.Size = New System.Drawing.Size(211, 21)
        Me.driverField.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(273, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Connection " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "String"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Driver:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.queryStatus, Me.connectionStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(926, 24)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'queryStatus
        '
        Me.queryStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.queryStatus.Name = "queryStatus"
        Me.queryStatus.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.queryStatus.Size = New System.Drawing.Size(118, 19)
        Me.queryStatus.Text = "Query Status: None"
        '
        'connectionStatus
        '
        Me.connectionStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.connectionStatus.Name = "connectionStatus"
        Me.connectionStatus.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.connectionStatus.Size = New System.Drawing.Size(148, 19)
        Me.connectionStatus.Text = "Connection Status: None"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuickToolStripMenuItem, Me.QueryToolStripMenuItem1, Me.ConnectionToolStripMenuItem1, Me.ViewToolStripMenuItem, Me.WindowToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(926, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'QuickToolStripMenuItem
        '
        Me.QuickToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddProxyToolStripMenuItem})
        Me.QuickToolStripMenuItem.Name = "QuickToolStripMenuItem"
        Me.QuickToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.QuickToolStripMenuItem.Text = "Quick"
        '
        'AddProxyToolStripMenuItem
        '
        Me.AddProxyToolStripMenuItem.Name = "AddProxyToolStripMenuItem"
        Me.AddProxyToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.AddProxyToolStripMenuItem.Text = "Add Proxy"
        '
        'QueryToolStripMenuItem1
        '
        Me.QueryToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.SelectToolStripMenuItem1})
        Me.QueryToolStripMenuItem1.Name = "QueryToolStripMenuItem1"
        Me.QueryToolStripMenuItem1.Size = New System.Drawing.Size(51, 20)
        Me.QueryToolStripMenuItem1.Text = "Query"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(115, 22)
        Me.ToolStripMenuItem1.Text = "Execute"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(112, 6)
        '
        'SelectToolStripMenuItem1
        '
        Me.SelectToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystablesToolStripMenuItem, Me.SystablecolumnsToolStripMenuItem, Me.TablesToolStripMenuItem, Me.ViewsToolStripMenuItem})
        Me.SelectToolStripMenuItem1.Name = "SelectToolStripMenuItem1"
        Me.SelectToolStripMenuItem1.Size = New System.Drawing.Size(115, 22)
        Me.SelectToolStripMenuItem1.Text = "Select"
        '
        'SystablesToolStripMenuItem
        '
        Me.SystablesToolStripMenuItem.Name = "SystablesToolStripMenuItem"
        Me.SystablesToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SystablesToolStripMenuItem.Text = "sys_tables"
        '
        'SystablecolumnsToolStripMenuItem
        '
        Me.SystablecolumnsToolStripMenuItem.Name = "SystablecolumnsToolStripMenuItem"
        Me.SystablecolumnsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SystablecolumnsToolStripMenuItem.Text = "sys_tablecolumns"
        '
        'TablesToolStripMenuItem
        '
        Me.TablesToolStripMenuItem.Name = "TablesToolStripMenuItem"
        Me.TablesToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.TablesToolStripMenuItem.Text = "Tables"
        '
        'ViewsToolStripMenuItem
        '
        Me.ViewsToolStripMenuItem.Name = "ViewsToolStripMenuItem"
        Me.ViewsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ViewsToolStripMenuItem.Text = "Views"
        '
        'ConnectionToolStripMenuItem1
        '
        Me.ConnectionToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestToolStripMenuItem, Me.ToolStripSeparator2, Me.InsertToolStripMenuItem})
        Me.ConnectionToolStripMenuItem1.Name = "ConnectionToolStripMenuItem1"
        Me.ConnectionToolStripMenuItem1.Size = New System.Drawing.Size(81, 20)
        Me.ConnectionToolStripMenuItem1.Text = "Connection"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(133, 6)
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GETANDREFRESHToolStripMenuItem, Me.REFRESHToolStripMenuItem})
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.InsertToolStripMenuItem.Text = "InitiateAuth"
        '
        'GETANDREFRESHToolStripMenuItem
        '
        Me.GETANDREFRESHToolStripMenuItem.Name = "GETANDREFRESHToolStripMenuItem"
        Me.GETANDREFRESHToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.GETANDREFRESHToolStripMenuItem.Text = "GetAndRefresh"
        '
        'REFRESHToolStripMenuItem
        '
        Me.REFRESHToolStripMenuItem.Name = "REFRESHToolStripMenuItem"
        Me.REFRESHToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.REFRESHToolStripMenuItem.Text = "Refresh"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeSplitToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ChangeSplitToolStripMenuItem
        '
        Me.ChangeSplitToolStripMenuItem.Name = "ChangeSplitToolStripMenuItem"
        Me.ChangeSplitToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ChangeSplitToolStripMenuItem.Text = "Change Split"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWindowToolStripMenuItem, Me.ToolStripSeparator3, Me.NewTabToolStripMenuItem, Me.RemoveTabToolStripMenuItem, Me.ToolStripSeparator4, Me.ViewerToolStripMenuItem, Me.CloseViewerToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.NewWindowToolStripMenuItem.Text = "New Window"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(142, 6)
        '
        'NewTabToolStripMenuItem
        '
        Me.NewTabToolStripMenuItem.Name = "NewTabToolStripMenuItem"
        Me.NewTabToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.NewTabToolStripMenuItem.Text = "New Tab"
        '
        'RemoveTabToolStripMenuItem
        '
        Me.RemoveTabToolStripMenuItem.Name = "RemoveTabToolStripMenuItem"
        Me.RemoveTabToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.RemoveTabToolStripMenuItem.Text = "Remove Tab"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(142, 6)
        '
        'ViewerToolStripMenuItem
        '
        Me.ViewerToolStripMenuItem.Name = "ViewerToolStripMenuItem"
        Me.ViewerToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.ViewerToolStripMenuItem.Text = "Open Viewer"
        '
        'CloseViewerToolStripMenuItem
        '
        Me.CloseViewerToolStripMenuItem.Name = "CloseViewerToolStripMenuItem"
        Me.CloseViewerToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.CloseViewerToolStripMenuItem.Text = "Close Viewer"
        '
        'connectionGrid
        '
        Me.connectionGrid.AllowUserToAddRows = False
        Me.connectionGrid.AllowUserToDeleteRows = False
        Me.connectionGrid.AllowUserToResizeRows = False
        Me.connectionGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.connectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.connectionGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CProperty, Me.Value})
        Me.connectionGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.connectionGrid.Location = New System.Drawing.Point(0, 0)
        Me.connectionGrid.MultiSelect = False
        Me.connectionGrid.Name = "connectionGrid"
        Me.connectionGrid.RowHeadersVisible = False
        Me.connectionGrid.RowHeadersWidth = 51
        Me.connectionGrid.Size = New System.Drawing.Size(221, 369)
        Me.connectionGrid.TabIndex = 9
        '
        'CProperty
        '
        Me.CProperty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CProperty.FillWeight = 50.0!
        Me.CProperty.HeaderText = "Property"
        Me.CProperty.MinimumWidth = 6
        Me.CProperty.Name = "CProperty"
        Me.CProperty.ReadOnly = True
        Me.CProperty.Width = 71
        '
        'Value
        '
        Me.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Value.FillWeight = 50.0!
        Me.Value.HeaderText = "Value"
        Me.Value.MinimumWidth = 6
        Me.Value.Name = "Value"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 91)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tabHolder)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.connectionGrid)
        Me.SplitContainer2.Size = New System.Drawing.Size(926, 371)
        Me.SplitContainer2.SplitterDistance = 699
        Me.SplitContainer2.TabIndex = 10
        '
        'tabHolder
        '
        Me.tabHolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabHolder.Location = New System.Drawing.Point(0, 0)
        Me.tabHolder.Name = "tabHolder"
        Me.tabHolder.SelectedIndex = 0
        Me.tabHolder.Size = New System.Drawing.Size(697, 369)
        Me.tabHolder.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(273, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Copy"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 486)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Form1"
        Me.Text = "Driver Test"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.connectionGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents driverField As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents connectionField As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents QuickToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddProxyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeSplitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents queryStatus As ToolStripStatusLabel
    Friend WithEvents ConnectionToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueryToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SystablesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents InsertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GETANDREFRESHToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REFRESHToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents connectionStatus As ToolStripStatusLabel
    Friend WithEvents connectionGrid As DataGridView
    Friend WithEvents CProperty As DataGridViewTextBoxColumn
    Friend WithEvents Value As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tabHolder As TabControl
    Friend WithEvents WindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewTabToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveTabToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SystablecolumnsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TablesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents CloseViewerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button3 As Button
End Class
