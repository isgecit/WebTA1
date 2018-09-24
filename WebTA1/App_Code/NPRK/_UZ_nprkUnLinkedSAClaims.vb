Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkUnLinkedSAClaims
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String, ByVal PrimaryKey As String) As SIS.NPRK.nprkUnLinkedSAClaims
      Dim Results As SIS.NPRK.nprkUnLinkedSAClaims = nprkUnLinkedSAClaimsGetByID(FinYear, Quarter, EmployeeID)
      With Results
        .AdviceNo = PrimaryKey.Split("|".ToCharArray)(2)
        .StatusID = saClaimStates.LinkedInAdvice
        .Linked = True
      End With
      Results = SIS.NPRK.nprkLinkedSAClaims.UpdateData(Results)
      SIS.NPRK.nprkSiteAllowanceAdvice.Validate(PrimaryKey)
      Return Results
    End Function
    Public Shared Function UZ_nprkUnLinkedSAClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.NPRK.nprkUnLinkedSAClaims)
      Dim Results As List(Of SIS.NPRK.nprkUnLinkedSAClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_UnLinkedSAClaimsSelectListSearch"
            Cmd.CommandText = "spnprkUnLinkedSAClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_UnLinkedSAClaimsSelectListFilteres"
            Cmd.CommandText = "spnprkUnLinkedSAClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Linked",SqlDbType.Bit,2, False)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,10, saClaimStates.SubmittedToHO)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkUnLinkedSAClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkUnLinkedSAClaims(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkUnLinkedSAClaimsUpdate(ByVal Record As SIS.NPRK.nprkUnLinkedSAClaims) As SIS.NPRK.nprkUnLinkedSAClaims
      Dim _Result As SIS.NPRK.nprkUnLinkedSAClaims = nprkUnLinkedSAClaimsUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
