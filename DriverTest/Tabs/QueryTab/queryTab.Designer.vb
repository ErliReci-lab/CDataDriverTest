<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class queryTab
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.queryHolder = New System.Windows.Forms.Panel()
        Me.resultViewHolder = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.queryHolder)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Controls.Add(Me.resultViewHolder)
        Me.SplitContainer1.Size = New System.Drawing.Size(1030, 553)
        Me.SplitContainer1.SplitterDistance = 341
        Me.SplitContainer1.TabIndex = 8
        '
        'queryHolder
        '
        Me.queryHolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.queryHolder.Location = New System.Drawing.Point(0, 0)
        Me.queryHolder.Name = "queryHolder"
        Me.queryHolder.Size = New System.Drawing.Size(339, 551)
        Me.queryHolder.TabIndex = 0
        '
        'resultViewHolder
        '
        Me.resultViewHolder.ColumnCount = 1
        Me.resultViewHolder.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.resultViewHolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.resultViewHolder.Location = New System.Drawing.Point(0, 0)
        Me.resultViewHolder.Name = "resultViewHolder"
        Me.resultViewHolder.RowCount = 1
        Me.resultViewHolder.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.resultViewHolder.Size = New System.Drawing.Size(683, 551)
        Me.resultViewHolder.TabIndex = 0
        '
        'queryTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "queryTab"
        Me.Size = New System.Drawing.Size(1030, 553)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents queryHolder As Panel
    Friend WithEvents resultViewHolder As TableLayoutPanel
End Class
