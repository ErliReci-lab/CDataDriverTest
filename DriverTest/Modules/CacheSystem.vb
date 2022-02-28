Public Class CacheSystem
    Private _chachedData As New Dictionary(Of String, DataTable)

    Public Sub chache(key As String, data As DataTable)
        _chachedData.Add(key, data)
    End Sub

    Public Function getData(key As String) As DataTable
        Return _chachedData(key)
    End Function

    Public Function getData(key As String, fallBack As Func(Of DataTable)) As DataTable
        If Not _chachedData.ContainsKey(key) Then
            chache(key, fallBack())
        End If
        Return getData(key)
    End Function

    Public Sub purgeAll()
        _chachedData.Clear()
    End Sub
End Class
