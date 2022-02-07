<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class conHistoryTab
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.historyGrid = New System.Windows.Forms.DataGridView()
        Me.Driver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConnectionString = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.historyGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'historyGrid
        '
        Me.historyGrid.AllowUserToAddRows = False
        Me.historyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.historyGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Driver, Me.ConnectionString})
        Me.historyGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.historyGrid.Location = New System.Drawing.Point(0, 28)
        Me.historyGrid.MultiSelect = False
        Me.historyGrid.Name = "historyGrid"
        Me.historyGrid.RowHeadersWidth = 51
        Me.historyGrid.RowTemplate.Height = 24
        Me.historyGrid.Size = New System.Drawing.Size(714, 475)
        Me.historyGrid.TabIndex = 0
        '
        'Driver
        '
        Me.Driver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Driver.FillWeight = 32.08557!
        Me.Driver.HeaderText = "Driver"
        Me.Driver.MinimumWidth = 30
        Me.Driver.Name = "Driver"
        Me.Driver.ReadOnly = True
        '
        'ConnectionString
        '
        Me.ConnectionString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ConnectionString.FillWeight = 167.9145!
        Me.ConnectionString.HeaderText = "Connection String"
        Me.ConnectionString.MinimumWidth = 70
        Me.ConnectionString.Name = "ConnectionString"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(714, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(68, 24)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(66, 24)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'conHistoryTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.historyGrid)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "conHistoryTab"
        Me.Size = New System.Drawing.Size(714, 503)
        CType(Me.historyGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents historyGrid As DataGridView
    Friend WithEvents Driver As DataGridViewTextBoxColumn
    Friend WithEvents ConnectionString As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
