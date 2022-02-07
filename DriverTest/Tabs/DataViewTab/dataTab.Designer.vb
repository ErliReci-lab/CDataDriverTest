<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dataTab
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tableList = New System.Windows.Forms.ComboBox()
        Me.resultView = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.resultView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tableList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel1.Size = New System.Drawing.Size(867, 53)
        Me.Panel1.TabIndex = 0
        '
        'tableList
        '
        Me.tableList.FormattingEnabled = True
        Me.tableList.Location = New System.Drawing.Point(15, 15)
        Me.tableList.Margin = New System.Windows.Forms.Padding(15)
        Me.tableList.Name = "tableList"
        Me.tableList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tableList.Size = New System.Drawing.Size(827, 24)
        Me.tableList.Sorted = True
        Me.tableList.TabIndex = 0
        '
        'resultView
        '
        Me.resultView.AllowUserToAddRows = False
        Me.resultView.AllowUserToDeleteRows = False
        Me.resultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.resultView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.resultView.Location = New System.Drawing.Point(0, 53)
        Me.resultView.Name = "resultView"
        Me.resultView.ReadOnly = True
        Me.resultView.RowHeadersWidth = 51
        Me.resultView.RowTemplate.Height = 24
        Me.resultView.Size = New System.Drawing.Size(867, 496)
        Me.resultView.TabIndex = 1
        '
        'dataTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.resultView)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "dataTab"
        Me.Size = New System.Drawing.Size(867, 549)
        Me.Panel1.ResumeLayout(False)
        CType(Me.resultView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents resultView As DataGridView
    Friend WithEvents tableList As ComboBox
End Class
