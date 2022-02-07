<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoredProcedure
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.generateBtn = New System.Windows.Forms.Button()
        Me.parameterGrid = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.parameterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(373, 24)
        Me.ComboBox1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.generateBtn)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(509, 49)
        Me.Panel1.TabIndex = 1
        '
        'generateBtn
        '
        Me.generateBtn.Location = New System.Drawing.Point(403, 12)
        Me.generateBtn.Name = "generateBtn"
        Me.generateBtn.Size = New System.Drawing.Size(94, 24)
        Me.generateBtn.TabIndex = 1
        Me.generateBtn.Text = "Generate"
        Me.generateBtn.UseVisualStyleBackColor = True
        '
        'parameterGrid
        '
        Me.parameterGrid.AllowUserToAddRows = False
        Me.parameterGrid.AllowUserToDeleteRows = False
        Me.parameterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.parameterGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.parameterGrid.Location = New System.Drawing.Point(0, 49)
        Me.parameterGrid.Name = "parameterGrid"
        Me.parameterGrid.RowHeadersWidth = 51
        Me.parameterGrid.RowTemplate.Height = 24
        Me.parameterGrid.Size = New System.Drawing.Size(509, 320)
        Me.parameterGrid.TabIndex = 2
        '
        'StoredProcedure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 369)
        Me.Controls.Add(Me.parameterGrid)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "StoredProcedure"
        Me.Text = "StoredProcedure"
        Me.Panel1.ResumeLayout(False)
        CType(Me.parameterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents generateBtn As Button
    Friend WithEvents parameterGrid As DataGridView
End Class
