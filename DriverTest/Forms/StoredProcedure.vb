Public Class StoredProcedure
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim data As DataRow() = CDataDriver.clone.getProcedure(ComboBox1.Text)
        Dim table As DataTable = New DataTable()
        table.Columns.Add("Parameter").ReadOnly = True
        table.Columns.Add("DataType").ReadOnly = True
        table.Columns.Add("IsRequired").ReadOnly = True
        table.Columns.Add("Description").ReadOnly = True
        table.Columns.Add("Values")
        For Each row In data
            table.Rows.Add(row.ItemArray.Skip(1).ToArray())
        Next
        parameterGrid.DataSource = table
    End Sub

    Private Sub StoredProcedure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data = CDataDriver.clone.getProcedureNames()
        For Each proc In data
            ComboBox1.Items.Add(proc)
        Next
    End Sub

    Private Sub generateBtn_Click(sender As Object, e As EventArgs) Handles generateBtn.Click
        Dim query As String = $"EXEC {ComboBox1.Text} "
        For Each row In parameterGrid.Rows
            If row.Cells(4).Value.ToString().Trim() <> "" Then
                If row.Cells(1).Value.ToString().ToLower() = "varchar" Then
                    query += $"@{row.Cells(0).Value}='{row.Cells(4).Value}', "
                Else
                    query += $"@{row.Cells(0).Value}={row.Cells(4).Value}, "
                End If
            End If
        Next
        query = query.Substring(0, query.Length - 2) & ";"
        Form1.getSelected().insertQuery(query)
    End Sub

End Class