Public Class TableComponent

    Public Sub New(ByVal name As String)
        Me.TopLevel = False
        InitializeComponent()
        Me.Text = name
    End Sub

    Public Sub addColumns(columns As Dictionary(Of String, CDataColumn))
        For Each col As KeyValuePair(Of String, CDataColumn) In columns
            DataGridView1.Rows.Add(New String() {col.Value.name(), col.Value.dataType()})
        Next
    End Sub

    Private Sub TableComponent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class