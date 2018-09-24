Public Module ModMain
  Public Enum PhotoSize
    Small = 1
    Medium = 2
    Large = 3
    Original = 4
  End Enum
  Public Enum PhotoTypes
    Blog = 1
    User = 2
    Comment = 3
  End Enum
  Public Structure MyValues
    Dim pageNo_UserForm As Integer
    Dim LoggedIn As Boolean
    Dim UserID As Guid
    Dim UserName As String
    Dim StartTime As DateTime
    Dim LastLogin As DateTime
    Dim CreatedOn As DateTime
    Public Sub New(ByVal pageNo As Integer)
      pageNo_UserForm = -1
    End Sub
  End Structure
  Public Function GetSes(ByVal obj As Object) As MyValues
    Return CType(obj, MyValues)
  End Function
End Module
