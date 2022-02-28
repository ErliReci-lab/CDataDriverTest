Public Class StoredProcedure
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim data As DataRow() = Form1.chache.getData(Form1.CacheKeys.StoredProcedures, Function()
                                                                                           Return Core.getStoreProcedures(Form1.driverField.Text, Form1.connectionField.Text)
                                                                                       End Function).Select().Where(Function(x) x("ProcedureName") = ComboBox1.Text).ToArray()
        Dim table As DataTable = New DataTable()
        table.Columns.Add("Parameter").ReadOnly = True
        table.Columns.Add("DataType").ReadOnly = True
        table.Columns.Add("IsRequired").ReadOnly = True
        table.Columns.Add("Description").ReadOnly = True
        table.Columns.Add("DefaultValue").ReadOnly = True
        table.Columns.Add("Values")
        For Each row In data
            Dim temp = row.ItemArray.Skip(1).ToArray()
            table.Rows.Add(temp)
        Next
        parameterGrid.DataSource = table
    End Sub

    Private Sub StoredProcedure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data = Form1.chache.getData(Form1.CacheKeys.StoredProcedures, Function()
                                                                              Return Core.getStoreProcedures(Form1.driverField.Text, Form1.connectionField.Text)
                                                                          End Function).Select().GroupBy(Function(x) x("ProcedureName")).ToArray()
        For Each procRow In data
            ComboBox1.Items.Add(procRow(0)("ProcedureName"))
        Next
    End Sub

    Private Sub generateBtn_Click(sender As Object, e As EventArgs) Handles generateBtn.Click
        Dim query As String = $"EXEC {ComboBox1.Text} "
        For Each row In parameterGrid.Rows
            If row.Cells(5).Value.ToString().Trim() <> "" Then
                Dim tempVal = row.Cells(5).Value
                If row.Cells(4).Value.ToString() = "True" Then
                    tempVal = tempVal.ToString().Split(",")(0)
                End If
                If row.Cells(1).Value.ToString().ToLower() = "varchar" Then
                    query += $"@{row.Cells(0).Value}='{tempVal}', "
                Else
                    query += $"@{row.Cells(0).Value}={tempVal}, "
                End If
            End If
        Next
        query = query.Substring(0, query.Length - 2) & ";"
        Form1.getSelected().insertQuery(query)
    End Sub

End Class