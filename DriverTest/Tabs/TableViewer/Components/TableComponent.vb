Public Class TableComponent

    Public Sub New(ByVal name As String)
        Me.Visible = True
        Me.TopLevel = False
        InitializeComponent()
        Me.Text = name
    End Sub

    Public Sub addColumns(cols As List(Of Tuple(Of String, String)))
        For Each col In cols
            DataGridView1.Rows.Add(New String() {col.Item1, col.Item2})
        Next
    End Sub
End Class