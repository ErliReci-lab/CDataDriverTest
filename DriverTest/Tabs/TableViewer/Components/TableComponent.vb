Public Class TableComponent

    Public Sub New(ByVal name As String)
        Me.TopLevel = False
        InitializeComponent()
        Me.Text = name
    End Sub

    Public Sub addColumns(columns As DataRow())
        For Each col In columns
            DataGridView1.Rows.Add(New String() {col("ColumnName"), col("DataTypeName")})
        Next
    End Sub

    Private Sub TableComponent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class