Public Module CurrentUserSession
    Public FullName As String = ""
    Public Role As String = ""

    ' Helper function to get a clean role name from the VerifiedID
    Public Function GetRoleFromID(verifiedID As String) As String
        If String.IsNullOrWhiteSpace(verifiedID) OrElse Not verifiedID.Contains("-") Then
            Return "Unknown"
        End If

        Dim roleCode As String = verifiedID.Split("-"c)(1).ToUpper
        Select Case roleCode
            Case "AD"
                Return "Admin"
            Case "DR"
                Return "Doctor"
            Case "ST"
                Return "Staff"
            Case Else
                Return "Staff" ' Default
        End Select
    End Function
End Module