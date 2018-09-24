Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkLedger
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_nprkLedgerSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_LedgerSelectListSearch"
            Cmd.CommandText = "spnprkLedgerSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_LedgerSelectListFilteres"
            Cmd.CommandText = "spnprkLedgerSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkLedgerInsert(ByVal Record As SIS.NPRK.nprkLedger) As SIS.NPRK.nprkLedger
      Dim _Result As SIS.NPRK.nprkLedger = nprkLedgerInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkLedgerUpdate(ByVal Record As SIS.NPRK.nprkLedger) As SIS.NPRK.nprkLedger
      Dim _Result As SIS.NPRK.nprkLedger = nprkLedgerUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkLedgerDelete(ByVal Record As SIS.NPRK.nprkLedger) As Integer
      Dim _Result as Integer = nprkLedgerDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_DocumentID"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeID"), TextBox).Text = 0
        CType(.FindControl("F_PerkID"), TextBox).Text = 0
        CType(.FindControl("F_TranType"), TextBox).Text = ""
        CType(.FindControl("F_TranDate"), TextBox).Text = ""
        CType(.FindControl("F_FinYear"), TextBox).Text = 0
        CType(.FindControl("F_Value"), TextBox).Text = 0
        CType(.FindControl("F_UOM"), TextBox).Text = ""
        CType(.FindControl("F_Amount"), TextBox).Text = 0
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_CreatedBy"), TextBox).Text = 0
        CType(.FindControl("F_ParentDocumentID"), TextBox).Text = 0
        CType(.FindControl("F_ApplicationID"), TextBox).Text = 0
        CType(.FindControl("F_PostedInBaaN"), CheckBox).Checked = False
        CType(.FindControl("F_PostedOn"), TextBox).Text = ""
        CType(.FindControl("F_PostedBy"), TextBox).Text = 0
        CType(.FindControl("F_BatchNo"), TextBox).Text = ""
        CType(.FindControl("F_VoucherNo"), TextBox).Text = ""
        CType(.FindControl("F_VoucherLineNo"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Private Shared _totAmt As Double = 0
    Private _InterperkTransfer As Boolean
    Private _TargetPerkID As Int32
    Public ProcessID As String
    Public Property TargetPerkID() As Int32
      Get
        Return _TargetPerkID
      End Get
      Set(ByVal value As Int32)
        _TargetPerkID = value
      End Set
    End Property
    Public Property InterperkTransfer() As Boolean
      Get
        Return _InterperkTransfer
      End Get
      Set(ByVal value As Boolean)
        _InterperkTransfer = value
      End Set
    End Property
    Public Shared Property TotalAmount() As Double
      Get
        Return _totAmt
      End Get
      Set(ByVal value As Double)
        _totAmt = _totAmt + value
      End Set
    End Property
    Public Shared Function GetByApplicationID(ByVal ApplicationID As Int32) As SIS.NPRK.nprkLedger
      Dim Results As SIS.NPRK.nprkLedger = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_LedgerSelectByApplicationID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, ApplicationID.ToString.Length, ApplicationID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkLedger(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetByEmployeeIDPerkIDSep(ByVal EmployeeID As Int32, ByVal PerkID As Int32, ByVal TranDate As DateTime) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_LedgerSelectByEmployeeIDPerkIDSep"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, TranDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function GetByEmployeeIDPerkID(ByVal EmployeeID As Int32, ByVal PerkID As Int32) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_LedgerSelectByEmployeeIDPerkID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetDisplayLedgerToBePosted(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal TranDate As DateTime) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_GetPayments"
          If orderBy = String.Empty Then orderBy = "TRANTYPE"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType", SqlDbType.NVarChar, 4, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, TranDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.Int, 10, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID", SqlDbType.Int, 10, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN", SqlDbType.Int, 10, -1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetLedgerToBePosted(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal TranDate As DateTime) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_GetPayments"
          If orderBy = String.Empty Then orderBy = "TRANTYPE"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType", SqlDbType.NVarChar, 4, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, TranDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.Int, 10, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID", SqlDbType.Int, 10, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN", SqlDbType.Int, 10, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetChequePayments(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal TranDate As DateTime, ByVal EmployeeID As Int32, ByVal PerkID As Int32) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_GetPayments"
          If orderBy = String.Empty Then orderBy = "TRANDATE DESC"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType", SqlDbType.NVarChar, 4, "JVR")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, TranDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID", SqlDbType.Int, PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN", SqlDbType.Int, 10, -1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetCashPayments(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal TranDate As DateTime, ByVal EmployeeID As Int32, ByVal PerkID As Int32, ByVal TranType As String) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_GetPayments"
          If orderBy = String.Empty Then orderBy = "TRANDATE DESC"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType", SqlDbType.NVarChar, 4, TranType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, TranDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID", SqlDbType.Int, PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN", SqlDbType.Int, 10, -1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectCount(ByVal TranDate As DateTime) As Integer
      Return _RecordCount
    End Function
    Public Shared Function SelectCount(ByVal TranDate As DateTime, ByVal EmployeeID As Int32, ByVal PerkID As Int32) As Integer
      Return _RecordCount
    End Function
    Public Shared Function SelectCount(ByVal TranDate As DateTime, ByVal EmployeeID As Int32, ByVal PerkID As Int32, ByVal TranType As String) As Integer
      Return _RecordCount
    End Function
    Public Shared Function UpdateBaaNPosting(ByVal Record As SIS.NPRK.nprkLedger) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_LedgerUpdateBaaNPosting"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentID", SqlDbType.Int, 11, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN", SqlDbType.Bit, 3, Record.PostedInBaaN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn", SqlDbType.DateTime, 21, IIf(Record.PostedOn = "", Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy", SqlDbType.Int, 11, IIf(Record.PostedBy = "", Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BatchNo", SqlDbType.NVarChar, 7, Record.BatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherNo", SqlDbType.NVarChar, 9, Record.VoucherNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherLineNo", SqlDbType.NVarChar, 11, Record.VoucherLineNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function

    Public Shared Function UZ_Insert(ByVal Record As SIS.NPRK.nprkLedger) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_LedgerInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType", SqlDbType.NVarChar, 4, Record.TranType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, Global.System.Web.HttpContext.Current.Session("Today"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Value", SqlDbType.Decimal, 13, Record.Value)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM", SqlDbType.NVarChar, 6, Record.UOM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount", SqlDbType.Decimal, 13, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, Record.Remarks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.Int, 11, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 11, IIf(Record.ApplicationID = "", Convert.DBNull, Record.ApplicationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentDocumentID", SqlDbType.Int, 11, 0)
          Cmd.Parameters.Add("@DocumentID", SqlDbType.Int)
          Cmd.Parameters("@DocumentID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@DocumentID").Value
        End Using
        'If Interperk Transfer Entry is to be done
        If Record.InterperkTransfer Then
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "spPrk_LG_LedgerInsert"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 11, Record.EmployeeID)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, Record.TargetPerkID)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType", SqlDbType.NVarChar, 4, Record.TranType)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate", SqlDbType.DateTime, 21, Global.System.Web.HttpContext.Current.Session("Today"))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Value", SqlDbType.Decimal, 13, (Record.Value * -1))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM", SqlDbType.NVarChar, 6, Record.UOM)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount", SqlDbType.Decimal, 13, (Record.Amount * -1))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, Record.Remarks)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.Int, 11, Global.System.Web.HttpContext.Current.Session("LoginID"))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, Global.System.Web.HttpContext.Current.Session("FinYear"))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 11, IIf(Record.ApplicationID = "", Convert.DBNull, Record.ApplicationID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentDocumentID", SqlDbType.Int, 11, _Result)
            Cmd.Parameters.Add("@DocumentID", SqlDbType.Int)
            Cmd.Parameters("@DocumentID").Direction = ParameterDirection.Output
            Cmd.ExecuteNonQuery()
            _Result = Cmd.Parameters("@DocumentID").Value
          End Using
        End If
      End Using
      Return _Result
    End Function
    Public Shared Function GetNetValue(ByVal EmployeeID As Integer, ByVal PerkID As Integer, ByVal FinYear As Integer) As Decimal
      Dim Results As Decimal = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_NetLedgerValue"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 11, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, FinYear)
          Cmd.Parameters.Add("@NetValue", SqlDbType.Decimal)
          Cmd.Parameters("@NetValue").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Results = Cmd.Parameters("@NetValue").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetOPBLedger(ByVal EmployeeID As Integer, ByVal PerkID As Integer, ByVal FinYear As Integer) As SIS.NPRK.nprkLedger
      Dim Results As SIS.NPRK.nprkLedger = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_OPBLedger"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 11, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, FinYear)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkLedger(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetClosingLedger(ByVal EmployeeID As Integer, ByVal PerkID As Integer, ByVal FinYear As Integer) As SIS.NPRK.nprkLedger
      Dim Results As SIS.NPRK.nprkLedger = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spPrk_LG_ClosingLedger"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 11, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, FinYear)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkLedger(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetLedgerByEmployeeID(ByVal EmployeeID As Integer) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnPrk_LG_LedgersSelectByEmployeeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, -1, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetPaidMedBenfitWithADJinBalMed(ByVal EmployeeID As Integer) As Decimal
      Dim Results As Decimal = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnPrk_LG_PaidMedBenfitWithADJinBalMed"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 11, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@NetValue", SqlDbType.Decimal)
          Cmd.Parameters("@NetValue").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Results = Cmd.Parameters("@NetValue").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
