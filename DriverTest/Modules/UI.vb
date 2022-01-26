Module UI
    Public Sub errorBox(message As String, details As String)
        Dim dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg"
        Dim dialogType = GetType(Form).Assembly.[GetType](dialogTypeName)
        Dim dialog = CType(Activator.CreateInstance(dialogType, New PropertyGrid()), Form)
        dialog.Text = "Error"
        dialogType.GetProperty("Details").SetValue(dialog, details, Nothing)
        dialogType.GetProperty("Message").SetValue(dialog, message, Nothing)
        dialog.ShowDialog()
    End Sub
End Module
