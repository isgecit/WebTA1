Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  Partial Public Class eitlImportPOList
		Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal SerialNo As Int32) As SIS.EITL.eitlImportPOList
      'Issue To Supplier
      Dim Results As SIS.EITL.eitlImportPOList = eitlImportPOListGetByID(SerialNo)
      With Results
        .POStatusID = 2
        .IssuedBy = HttpContext.Current.Session("LoginID")
        .IssuedOn = Now
      End With
      Results = SIS.EITL.eitlImportPOList.UpdateData(Results)
      'Send E-Mail
      SIS.EITL.Alerts.Alert(SerialNo, AlertEvents.POIssued)
      Return Results
    End Function
    Public Shared Function UZ_eitlImportPOListSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.EITL.eitlImportPOList)
      Dim Results As List(Of SIS.EITL.eitlImportPOList) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "speitlImportPOListSelectListSearch"
            Cmd.CommandText = "speitl_LG_ImportPOListSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "speitlImportPOListSelectListFilteres"
            Cmd.CommandText = "speitl_LG_ImportPOListSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlImportPOList)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlImportPOList(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_eitlImportPOListInsert(ByVal Record As SIS.EITL.eitlImportPOList) As SIS.EITL.eitlImportPOList
      Dim _Result As SIS.EITL.eitlImportPOList = eitlImportPOListInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_eitlImportPOListUpdate(ByVal Record As SIS.EITL.eitlImportPOList) As SIS.EITL.eitlImportPOList
      Dim _Result As SIS.EITL.eitlImportPOList = eitlImportPOListUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_eitlImportPOListDelete(ByVal Record As SIS.EITL.eitlImportPOList) As Integer
      Dim _Result as Integer = eitlImportPOListDelete(Record)
      Return _Result
    End Function
    'Public Shared Function ImportFromERP1(Optional ByVal ProjectID As String = "", Optional ByVal PONumber As String = "") As List(Of SIS.EITL.eitlPOList)
    '  Dim POSinceDays As Integer = ConfigurationManager.AppSettings("POSinceDays")
    '  Dim Sql As String = ""

    '  Dim Results As List(Of SIS.EITL.eitlPOList) = Nothing
    '  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
    '    Using Cmd As SqlCommand = Con.CreateCommand()
    '      Cmd.CommandType = CommandType.Text
    '      Cmd.CommandText = Sql
    '      Results = New List(Of SIS.EITL.eitlPOList)()
    '      Con.Open()
    '      Dim Reader As SqlDataReader = Cmd.ExecuteReader()
    '      While (Reader.Read())
    '        Results.Add(New SIS.EITL.eitlPOList(Reader))
    '      End While
    '      Reader.Close()
    '    End Using
    '  End Using
    '  Return Results
    'End Function
    Public Shared Function GetByPONumber(ByVal PONumber As String) As SIS.EITL.eitlImportPOList
      Dim Results As SIS.EITL.eitlImportPOList = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitl_LG_POListGetByPONumber"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber", SqlDbType.NVarChar, 10, PONumber)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.EITL.eitlImportPOList(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ImportFrom_ERP(Optional ByVal ProjectID As String = "", Optional ByVal PONumber As String = "") As List(Of SIS.EITL.erpComponents.erpPO)
      'Dim ts As IO.StreamWriter = New IO.StreamWriter(HttpContext.Current.Server.MapPath("~/../App_Temp") & "/" & "")

      Dim oePOs As List(Of SIS.EITL.erpComponents.erpPO) = SIS.EITL.erpComponents.erpPO.GetFromERP(ProjectID, PONumber)
      For Each oePO As SIS.EITL.erpComponents.erpPO In oePOs
        '1. Check Supplier
        Dim oSup As SIS.EITL.eitlSuppliers = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(oePO.SupplierID)
        If oSup Is Nothing Then
          'Create Supplier First
          oSup = SIS.EITL.erpComponents.erpSupplier.GetFromERP(oePO.SupplierID)
          SIS.EITL.eitlSuppliers.InsertData(oSup)
          'Create WebUser for supplier
          'WebLoginID
          Dim LoginID As String = oePO.SupplierID.Substring(1)
          Dim owUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(LoginID)
          If owUsr Is Nothing Then
            owUsr = New SIS.QCM.qcmUsers
            With owUsr
              .UserName = LoginID
              .UserFullName = oSup.SupplierName
              .ActiveState = 1
              .EMailID = oSup.EMailID
            End With
            owUsr.MobileNo = SIS.QCM.qcmUsers.CreateWebUser(owUsr)
            SIS.QCM.qcmUsers.UpdateData(owUsr)
          End If
        End If
        '2. Check Project
        Dim oPrj As SIS.EITL.eitlProjects = SIS.EITL.eitlProjects.eitlProjectsGetByID(oePO.ProjectID)
        If oPrj Is Nothing Then
          'Create Project First
          oPrj = SIS.EITL.erpComponents.erpProject.GetFromERP(oePO.ProjectID)
          '2.1 Check Project Customer
          Dim oCus As SIS.EITL.eitlSuppliers = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(oPrj.BusinessPartnerID)
          If oCus Is Nothing Then
            'Create Customer First
            oCus = SIS.EITL.erpComponents.erpSupplier.GetFromERP(oPrj.BusinessPartnerID)
            SIS.EITL.eitlSuppliers.InsertData(oCus)
          End If
          'After Customer Create Project
          SIS.EITL.eitlProjects.InsertData(oPrj)
        End If
        '3. Check Buyer
        Dim oUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(oePO.BuyerID)
        If oUsr Is Nothing Then
          'Create Web User First
          Dim oEmp As SIS.QCM.qcmEmployees = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(oePO.BuyerID)
          If oEmp IsNot Nothing Then
            oUsr = New SIS.QCM.qcmUsers
            With oUsr
              .UserName = oePO.BuyerID
              .UserFullName = oEmp.EmployeeName
              .ActiveState = oEmp.ActiveState
              .C_CompanyID = oEmp.C_CompanyID
              .C_DepartmentID = oEmp.C_DepartmentID
              .C_DesignationID = oEmp.C_DesignationID
              .C_DivisionID = oEmp.C_DivisionID
              .C_OfficeID = oEmp.C_OfficeID
              .Contractual = oEmp.Contractual
              .EMailID = oEmp.EMailID
            End With
            oUsr.MobileNo = SIS.QCM.qcmUsers.CreateWebUser(oUsr)
            SIS.QCM.qcmUsers.UpdateData(oUsr)
          End If
          'send error for Buyer Login Not Created
          'FK checking removed in data base
        End If
        '4. Check PO List for PO Number to update latest rev. no.
        Dim oPO As SIS.EITL.eitlImportPOList = SIS.EITL.eitlImportPOList.GetByPONumber(oePO.PONumber)
        If oPO IsNot Nothing Then
          'Update Revision
          oPO.PORevision = oePO.PORevision
          If oePO.erpPOStatus = "30" Then
            oPO.POStatusID = 5
          End If
          SIS.EITL.eitlImportPOList.UpdateData(oPO)
        Else
          oePO.POStatusID = 1
          SIS.EITL.eitlImportPOList.InsertData(oePO)
        End If
      Next
      Return oePOs
    End Function
  End Class
#Region " ERP Components Classes "
  Public Class erpComponents
    Public Class erpProject
      Inherits SIS.EITL.eitlProjects
      Public Shared Function GetFromERP(ByVal ProjectID As String) As SIS.EITL.erpComponents.erpProject
        Dim Ret As SIS.EITL.erpComponents.erpProject = Nothing
        Dim Sql As String = ""
        Sql &= "select top 1  "
        Sql &= "  prh.t_cprj as ProjectID,  "
        Sql &= "  prd.t_dsca as Description, "
        Sql &= "  prb.t_ofbp as BusinessPartnerID "
        Sql &= "  from ttppdm600200 as prh  "
        Sql &= "  right outer join ttcmcs052200 as prd on prd.t_cprj=prh.t_cprj"
        Sql &= "  right outer join ttppdm740200 as prb on prb.t_cprj=prh.t_cprj"
        Sql &= "  where prh.t_cprj ='" & ProjectID & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              Ret = New SIS.EITL.erpComponents.erpProject(Reader)
            End If
            Reader.Close()
          End Using
        End Using
        Return Ret
      End Function
      Sub New(ByVal rd As SqlDataReader)
        MyBase.New(rd)
      End Sub
      Sub New()
        MyBase.New()
      End Sub
    End Class
    Public Class erpSupplier
      Inherits SIS.EITL.eitlSuppliers
      Public Shared Function GetFromERP(ByVal SupplierID As String) As SIS.EITL.erpComponents.erpSupplier
        Dim Ret As SIS.EITL.erpComponents.erpSupplier = Nothing
        Dim Sql As String = ""
        Sql &= "select                                                           "
        Sql &= "  suh.t_bpid as SupplierID,                                      "
        Sql &= "  suh.t_nama as SupplierName,                                    "
        Sql &= "  adh.t_ln01 as Address1,                                        "
        Sql &= "  adh.t_ln02 as Address2,                                        "
        Sql &= "  adh.t_ln03 as Address3,                                        "
        Sql &= "  adh.t_ln04 as Address4,                                        "
        Sql &= "  adh.t_ln05 as City,                                            "
        Sql &= "  adh.t_ln06 as State,                                           "
        Sql &= "  adh.t_pstc as Zip,                                             "
        Sql &= "  adh.t_ccty as Country,                                         "
        Sql &= "  cnh.t_fuln as ContactPerson,                                   "
        Sql &= "  cnh.t_telp as ContactNo,                                       "
        Sql &= "  cnh.t_info as EMailID                                          "
        Sql &= "  from ttccom100200 as suh                                       "
        Sql &= "  left outer join ttccom130200 as adh on suh.t_cadr = adh.t_cadr "
        Sql &= "  left outer join ttccom140200 as cnh on suh.t_ccnt = cnh.t_ccnt "
        Sql &= "  where suh.t_bpid ='" & SupplierID & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              Ret = New SIS.EITL.erpComponents.erpSupplier(Reader)
            End If
            Reader.Close()
          End Using
        End Using
        Return Ret
      End Function
      Sub New(ByVal rd As SqlDataReader)
        MyBase.New(rd)
      End Sub
    End Class
    Public Class erpPO
      Inherits SIS.EITL.eitlImportPOList
      Public Property BuyFromAddress As String = ""
      Public Property erpPOStatus As String = ""
      Public Shared Function GetFromERP(Optional ByVal ProjectID As String = "", Optional ByVal PONumber As String = "") As List(Of SIS.EITL.erpComponents.erpPO)
        Dim POSinceDays As Integer = ConfigurationManager.AppSettings("POSinceDays")
        Dim Sql As String = ""
        '--t_work = 3 =>Completed
        '--t_hdst 10 =>Approved
        '--       30 =>Cancelled
        '--cdf_catg=1 Boughtout,2 Fabrication, 3 General
        Sql &= "select "
        Sql &= "  apo.t_orno as PONumber,"
        Sql &= "  apo.t_vrsn as PORevision,"
        Sql &= "  apo.t_apdt as PODate,"
        Sql &= "  lpo.t_cprj as ProjectID,"
        Sql &= "  hpo.t_otbp as SupplierID,"
        Sql &= "  hpo.t_otad as BuyFromAddressID,"
        Sql &= "  hpo.t_ccon as BuyerID,"
        Sql &= "  hpo.t_cofc as DivisionID,"
        Sql &= "  hpo.t_hdst as erpPOStatus "
        Sql &= "  from ttdmsl400200 apo "
        Sql &= "  cross apply (select top 1 tmp.t_cprj from ttdpur401200 tmp where tmp.t_orno=apo.t_orno   "
        Sql &= "               and tmp.t_cspa in (select t_cspa from ttppdm090200 where t_cdf_catg=1)"
        Sql &= "              ) lpo "
        Sql &= "  inner join ttdpur400200 as hpo on apo.t_orno = hpo.t_orno "
        Sql &= "  where apo.t_work = 3 "
        Sql &= "  and apo.t_vrsn = (select max(tmp.t_vrsn) from ttdmsl400200 tmp where tmp.t_orno=apo.t_orno) "
        Sql &= "  and datediff(d,apo.t_apdt,getdate())<= " & POSinceDays
        If ProjectID <> String.Empty Then
          Sql &= "  and lpo.t_cprj = '" & ProjectID & "'"
        End If
        If PONumber <> String.Empty Then
          Sql &= "  and apo.t_orno='" & PONumber & "'"
        End If
        Dim Results As List(Of SIS.EITL.erpComponents.erpPO) = Nothing
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Results = New List(Of SIS.EITL.erpComponents.erpPO)
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Results.Add(New SIS.EITL.erpComponents.erpPO(Reader))
            End While
            Reader.Close()
          End Using
        End Using
        Return Results
      End Function

      Sub New(ByVal rd As SqlDataReader)
        MyBase.New(rd)
        If Not IsDBNull(rd("BuyFromAddressID")) Then BuyFromAddress = rd("BuyFromAddressID") Else BuyFromAddress = ""
        If Not IsDBNull(rd("erpPOStatus")) Then erpPOStatus = rd("erpPOStatus")
      End Sub
      Sub New()
        MyBase.New()
      End Sub
    End Class
  End Class

#End Region
End Namespace
