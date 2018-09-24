Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkLinkedSAClaims
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case FK_PRK_SiteAllowanceClaims_AdviceNo.StatusID
        Case saAdviceStates.Free, saAdviceStates.ClaimsLinked, saAdviceStates.ReceivedInAccounts
          mRet = True
      End Select
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Select Case FK_PRK_SiteAllowanceClaims_AdviceNo.StatusID
        Case saAdviceStates.Free, saAdviceStates.ClaimsLinked, saAdviceStates.ReceivedInAccounts
          mRet = True
      End Select
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
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case FK_PRK_SiteAllowanceClaims_AdviceNo.StatusID
            Case saAdviceStates.ClaimsLinked, saAdviceStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function RejectWF(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String, ByVal PrimaryKey As String) As SIS.NPRK.nprkLinkedSAClaims
      Dim Results As SIS.NPRK.nprkLinkedSAClaims = nprkLinkedSAClaimsGetByID(FinYear, Quarter, EmployeeID)
      With Results
        .AdviceNo = ""
        .StatusID = saClaimStates.SubmittedToHO
        .Linked = False
      End With
      Results = SIS.NPRK.nprkLinkedSAClaims.UpdateData(Results)
      SIS.NPRK.nprkSiteAllowanceAdvice.Validate(PrimaryKey)
      Return Results
    End Function
    Public Shared Function UZ_nprkLinkedSAClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal AdviceNo As Int32) As List(Of SIS.NPRK.nprkLinkedSAClaims)
      Dim Results As List(Of SIS.NPRK.nprkLinkedSAClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_LinkedSAClaimsSelectListSearch"
            Cmd.CommandText = "spnprkLinkedSAClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_LinkedSAClaimsSelectListFilteres"
            Cmd.CommandText = "spnprkLinkedSAClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_AdviceNo",SqlDbType.Int,10, IIf(AdviceNo = Nothing, 0,AdviceNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLinkedSAClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLinkedSAClaims(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkLinkedSAClaimsUpdate(ByVal Record As SIS.NPRK.nprkLinkedSAClaims) As SIS.NPRK.nprkLinkedSAClaims
      Dim _Result As SIS.NPRK.nprkLinkedSAClaims = nprkLinkedSAClaimsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkLinkedSAClaimsInsert(ByVal Record As SIS.NPRK.nprkLinkedSAClaims) As SIS.NPRK.nprkLinkedSAClaims
      Dim _Result As SIS.NPRK.nprkLinkedSAClaims = nprkLinkedSAClaimsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkLinkedSAClaimsDelete(ByVal Record As SIS.NPRK.nprkLinkedSAClaims) As Int32
      Record = SIS.NPRK.nprkLinkedSAClaims.nprkLinkedSAClaimsGetByID(Record.FinYear, Record.Quarter, Record.EmployeeID)
      Dim _Result As Integer = UZ_nprkSiteAllowanceClaimsDelete(Record)
      SIS.NPRK.nprkSiteAllowanceAdvice.Validate(Record.FK_PRK_SiteAllowanceClaims_AdviceNo.PrimaryKey)
      Return _Result
    End Function
  End Class
End Namespace
