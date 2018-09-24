Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK

#Region " ERP Components Classes "
  Public Class erpData
    Public Class erpPO
      'Main Function PO Import
      Public Shared Function ImportFromERP(Optional ByVal ProjectID As String = "", Optional ByVal PONumber As String = "", Optional ByVal ForTC As Boolean = False, Optional ByVal AsIsgecEngineered As Boolean = False, Optional ByVal AsBoughtOut As Boolean = False) As List(Of SIS.PAK.pakPO)

        Dim oePOs As List(Of SIS.PAK.pakPO) = SIS.PAK.erpData.erpPO.GetFromERP(ProjectID, PONumber)
        Dim mRet As New List(Of SIS.PAK.pakPO)
        For Each oePO As SIS.PAK.pakPO In oePOs
          '1. Check Supplier
          Dim oSup As SIS.PAK.pakBusinessPartner = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(oePO.SupplierID)
          If oSup Is Nothing Then
            'Create Supplier
            oSup = SIS.PAK.erpData.erpSupplier.GetFromERP(oePO.SupplierID)
            SIS.PAK.pakBusinessPartner.InsertData(oSup)
          End If
          '2. Check Project
          Dim oPrj As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(oePO.ProjectID)
          If oPrj Is Nothing Then
            'Create Project
            oPrj = SIS.PAK.erpData.erpProject.GetFromERP(oePO.ProjectID)
            '2.1 Check Project Customer
            Dim oCus As SIS.PAK.pakBusinessPartner = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(oPrj.BusinessPartnerID)
            If oCus Is Nothing Then
              'Create Customer
              oCus = SIS.PAK.erpData.erpSupplier.GetFromERP(oPrj.BusinessPartnerID)
              SIS.PAK.pakBusinessPartner.InsertData(oCus)
            End If
            'After Customer Create Project
            SIS.QCM.qcmProjects.InsertData(oPrj)
          End If
          '3. Check Buyer
          'Correct BuyerID
          If oePO.BuyerID.Length < 4 Then
            oePO.BuyerID = oePO.BuyerID.PadLeft(4, "0")
          End If
          Dim oUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(oePO.BuyerID)
          If oUsr Is Nothing Then
            'Create Buyer as Web User
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
              oUsr.PW = SIS.QCM.qcmUsers.CreateWebUser(oUsr)
              SIS.QCM.qcmUsers.UpdateData(oUsr)
            End If
            'send error for Buyer Login Not Created
            'FK checking removed in data base
          End If
          '4. Check PO List for PO Number to update latest rev. no.
          If ForTC Then
            oePO.POFOR = "TC"
          Else
            oePO.POFOR = "PK"
          End If
          Dim oPO As SIS.PAK.pakPO = SIS.PAK.erpData.erpPO.pakPOGetByPONumber(oePO.PONumber, ForTC)
          If oPO IsNot Nothing Then
            'Update Revision
            oPO.PORevision = oePO.PORevision
            'If oePO.erpPOStatus = "30" Then
            '  oPO.POStatusID = 5
            'End If
            oePO = SIS.PAK.pakPO.UpdateData(oPO)
            mRet.Add(oePO)
          Else
            If AsIsgecEngineered Then
              oePO.POTypeID = pakErpPOTypes.ISGECEngineered
              oePO.POStatusID = pakPOStates.ImportedFromERP
            ElseIf AsBoughtOut Then
              oePO.POTypeID = pakErpPOTypes.Boughtout
              oePO.POStatusID = pakPOStates.ImportedFromERP
            Else
              oePO.POTypeID = pakErpPOTypes.Package
              oePO.POStatusID = pakPOStates.Free
            End If
            If Not Convert.ToBoolean(ConfigurationManager.AppSettings("PortRequired")) Then
              oePO.PortRequired = False
            End If
            oePO = SIS.PAK.pakPO.InsertData(oePO)
            mRet.Add(oePO)
          End If
          Select Case oePO.POTypeID
            Case pakErpPOTypes.ISGECEngineered, pakErpPOTypes.Boughtout
              Dim xPOLines As List(Of SIS.PAK.pakERPPOLine) = SIS.PAK.erpData.erpPO.GetPOLine(oePO)
              For Each POL As SIS.PAK.pakERPPOLine In xPOLines
                '1. Check Element
                'New with Pack Elements, For Tree Using Elements
                Dim oEle As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetByID(POL.t_cspa)
                If oEle Is Nothing Then
                  oEle = SIS.PAK.erpData.erpPAKElement.GetFromERP(POL.t_cspa)
                  oEle.ElementLevel = 1
                  oEle.ResponsibleAgencyID = 1
                  oEle = SIS.PAK.pakElements.InsertData(oEle)
                End If
                '2. Check POLine exists in POBOM
                Dim tmpPOBOM As SIS.PAK.pakPOBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByERPPOLine(oePO.SerialNo, POL.t_pono)
                Dim Found As Boolean = True
                Dim BomNo As Integer = 0
                If tmpPOBOM Is Nothing Then
                  Found = False
                Else
                  BomNo = tmpPOBOM.BOMNo
                End If
                tmpPOBOM = SIS.PAK.pakERPPOLine.GetPOBOM(POL, oePO)
                tmpPOBOM.BOMNo = BomNo
                If Found Then
                  tmpPOBOM = SIS.PAK.pakPOBOM.UpdateData(tmpPOBOM)
                Else
                  tmpPOBOM = SIS.PAK.pakPOBOM.InsertData(tmpPOBOM)
                End If
                '3. Insert POBOM in BItem
                Dim tmpPOBItem As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBOM.GetPOBItem(tmpPOBOM)
                If Found Then
                  tmpPOBItem = SIS.PAK.pakPOBItems.UpdateData(tmpPOBItem)
                Else
                  tmpPOBItem = SIS.PAK.pakPOBItems.InsertData(tmpPOBItem)
                End If
                '4. Child Items of POBOM
                Dim xPOLChild As List(Of SIS.PAK.pakERPPOLChild) = SIS.PAK.erpData.erpPO.GetPOLChild(oePO, tmpPOBOM)
                For Each POLC As SIS.PAK.pakERPPOLChild In xPOLChild
                  tmpPOBItem = SIS.PAK.pakERPPOLChild.GetPOBItems(POLC, oePO, tmpPOBOM)
                  Found = True
                  Dim xPOBItem As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByItemCode(tmpPOBItem.SerialNo, tmpPOBItem.BOMNo, tmpPOBItem.ItemCode)
                  If xPOBItem Is Nothing Then
                    xPOBItem = New SIS.PAK.pakPOBItems
                    Found = False
                  End If
                  If Found Then
                    With xPOBItem
                      Try
                        System.Diagnostics.Debug.WriteLine("PO Item: " & POL.t_item & " Child : " & POLC.t_item)
                        .ItemDescription = POLC.t_desc
                        If POLC.t_quom <> "" Then
                          .UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByDescription(POLC.t_quom).UnitID
                        End If
                        If POLC.t_qnty >= 0.0001 Then
                          .Quantity = POLC.t_qnty
                        Else
                          .Quantity = 0
                        End If
                        .UOMWeight = SIS.PAK.pakUnits.pakUnitsGetByDescription("kg").UnitID
                        If POLC.t_wght >= 0.0001 AndAlso POLC.t_qnty >= 0.0001 Then
                          .WeightPerUnit = POLC.t_wght / POLC.t_qnty
                        Else
                          .WeightPerUnit = 0
                        End If
                      Catch ex As Exception
                        Throw New Exception("Err Assign Child Item: " & ex.Message)
                      End Try
                      'Create or Get DocumentNO
                      System.Diagnostics.Debug.WriteLine("ERROR IS SOME WHERE ELSE")

                      Dim tmpDoc As List(Of SIS.PAK.pakDocuments) = SIS.PAK.pakDocuments.pakDocumentsSelectByDocID(POLC.t_docn)
                      If tmpDoc.Count <= 0 Then
                        Dim tmpD = New SIS.PAK.pakDocuments
                        With tmpD
                          .DocumentID = POLC.t_docn
                          .DocumentRevision = POLC.t_revi
                          .Description = POLC.DocumentDescription
                          .ExternalDocument = False
                          .DisskFile = ""
                          .Filename = ""
                        End With
                        tmpD = SIS.PAK.pakDocuments.InsertData(tmpD)
                        .DocumentNo = tmpD.DocumentNo
                      Else
                        For Each tmpD As SIS.PAK.pakDocuments In tmpDoc
                          With tmpD
                            .DocumentID = POLC.t_docn
                            .DocumentRevision = POLC.t_revi
                            .Description = POLC.DocumentDescription
                            .ExternalDocument = False
                            .DisskFile = ""
                            .Filename = ""
                          End With
                          tmpD = SIS.PAK.pakDocuments.UpdateData(tmpD)
                        Next
                      End If
                    End With
                    System.Diagnostics.Debug.WriteLine("Updating Bom Item")
                    xPOBItem = SIS.PAK.pakPOBItems.UpdateData(xPOBItem)
                    System.Diagnostics.Debug.WriteLine("Bom Item Updated")
                    'If POLC.t_item.Trim = "CSB136-50060200-042-0394" Then
                    '  Dim xx As String = ""
                    'End If
                  Else
                    System.Diagnostics.Debug.WriteLine("Inserting Bom Item")
                    'Find Next AVBL ItemNo
                    Dim mNextItemNo As Integer = GetNextItemNo(tmpPOBItem.SerialNo, tmpPOBItem.BOMNo)
                    tmpPOBItem.ItemNo = mNextItemNo
                    tmpPOBItem = SIS.PAK.pakPOBItems.InsertData(tmpPOBItem)
                    System.Diagnostics.Debug.WriteLine("Inserted Bom Item")
                  End If
                Next
                '5. Reverse check to delete, Items Deleted in ERP
                'But there may despatches against them
                'If NO Despatch found delete child Item
                ' TO WRITE
              Next
          End Select
        Next
        Return mRet
      End Function
      Public Shared Function ImportPOLineFromERP(ByVal po As SIS.PAK.pakPO) As List(Of SIS.PAK.pakERPPOLine)
        Dim xPOLines As List(Of SIS.PAK.pakERPPOLine) = SIS.PAK.erpData.erpPO.GetPOLine(po)
        For Each POL As SIS.PAK.pakERPPOLine In xPOLines
          '1. Check Element
          Dim oEle As SIS.PAK.pakWBS = SIS.PAK.pakWBS.pakWBSGetByID(POL.t_cspa)
          If oEle Is Nothing Then
            oEle = SIS.PAK.erpData.erpElement.GetFromERP(POL.t_cspa)
            oEle.WBSLevel = 1
            oEle.ResponsibleAgencyID = 1
            SIS.PAK.pakWBS.InsertData(oEle)
          End If
          Dim xPOL As SIS.PAK.pakTCPOL = SIS.PAK.pakERPPOLine.GetTCPOL(POL)
          With xPOL
            .SerialNo = po.SerialNo
            .ItemStatusID = 1
          End With
          SIS.PAK.pakTCPOL.InsertData(xPOL)
        Next
        Return xPOLines
      End Function
      Private Shared Function GetNextItemNo(ByVal SerialNo As Integer, ByVal BomNo As Integer) As Integer
        Dim tmp As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT MAX(ISNULL(ItemNo,0)) FROM [PAK_POBitems] WHERE SerialNo = " & SerialNo & " and BOMNo=" & BomNo
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            Try
              tmp = Cmd.ExecuteScalar()
              tmp += 1
            Catch ex As Exception
              tmp = 1
            End Try
          End Using
        End Using
        Return tmp
      End Function
      Public Shared Function pakPOGetByPONumber(ByVal PONumber As String, ByVal forTC As Boolean) As SIS.PAK.pakPO
        Dim Results As SIS.PAK.pakPO = Nothing
        Dim TC As String = IIf(forTC, "TC", "PK")
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "sppak_LG_POSelectByPONumber"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@forTC", SqlDbType.NVarChar, 2, TC)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber", SqlDbType.NVarChar, PONumber.Length, PONumber)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If Reader.Read() Then
              Results = New SIS.PAK.pakPO(Reader)
            End If
            Reader.Close()
          End Using
        End Using
        Return Results
      End Function
      Public Shared Function GetPOLine(ByVal po As SIS.PAK.pakPO) As List(Of SIS.PAK.pakERPPOLine)
        Dim Results As New List(Of SIS.PAK.pakERPPOLine)
        Dim Sql As String = ""
        Sql &= "select "
        Sql &= "  [po].*,"
        Sql &= "  tc.t_dsca as ItemDescription "
        Sql &= "  from ttdpur401200 as po "
        Sql &= "  inner join ttcibd001200 as tc on po.t_item = tc.t_item "
        Sql &= "  where po.t_orno =  '" & po.PONumber & "'"
        Sql &= "  and po.t_oltp in (2,4) "     '2=>Detail, 4=>Order Line
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Results = New List(Of SIS.PAK.pakERPPOLine)
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Results.Add(New SIS.PAK.pakERPPOLine(Reader))
            End While
            Reader.Close()
          End Using
        End Using
        Return Results
      End Function
      Public Shared Function GetPOLChild(ByVal po As SIS.PAK.pakPO, ByVal poBom As SIS.PAK.pakPOBOM) As List(Of SIS.PAK.pakERPPOLChild)
        Dim Results As New List(Of SIS.PAK.pakERPPOLChild)
        Dim Sql As String = ""
        Sql &= "select isnull(cDoc.t_iref,'') as t_iref, isnull(dItm.t_sitm,'') as t_sitm, isnull(iRef.t_sub2,'') as t_sub2, isnull(iRef.t_sub3,'') as t_sub3, isnull(iRef.t_sub4,'') as t_sub4, cItm.* "
        Sql &= "from ttdisg002200 as cItm "
        Sql &= "left outer join tdmisg140200 as cDoc "
        Sql &= "        on cItm.t_docn = cDoc.t_docn "
        Sql &= "left outer join tdmisg002200 as dItm "
        Sql &= "        on dItm.t_docn = cItm.t_docn "
        Sql &= "       and dItm.t_revn = cItm.t_revi "
        Sql &= "	   and dItm.t_item = cItm.t_item "
        Sql &= "left outer join ttpisg243200 as iRef "
        Sql &= "        on cDoc.t_pcod = iRef.t_cprd "
        Sql &= "	   and cDoc.t_iref = iRef.t_iref "
        Sql &= "	   and '' = isnull(iRef.t_sitm,'') "
        Sql &= "where cItm.t_orno='" & po.PONumber & "'"
        Sql &= "  and cItm.t_pono= " & poBom.ItemNo
        Sql &= "union all "
        Sql &= "select isnull(cDoc.t_iref,'') as t_iref, isnull(dItm.t_sitm,'') as t_sitm, isnull(iRef.t_sub2,'') as t_sub2, isnull(iRef.t_sub3,'') as t_sub3, isnull(iRef.t_sub4,'') as t_sub4, cItm.* "
        Sql &= "from ttdisg002200 as cItm "
        Sql &= "left outer join tdmisg140200 as cDoc "
        Sql &= "        on cItm.t_docn = cDoc.t_docn "
        Sql &= "left outer join tdmisg002200 as dItm "
        Sql &= "        on dItm.t_docn = cItm.t_docn "
        Sql &= "       and dItm.t_revn = cItm.t_revi "
        Sql &= "	   and dItm.t_item = cItm.t_item "
        Sql &= "inner join ttpisg243200 as iRef "
        Sql &= "        on cDoc.t_pcod = iRef.t_cprd "
        Sql &= "	   and cDoc.t_iref = iRef.t_iref "
        Sql &= "	   and isnull(dItm.t_sitm,'') = isnull(iRef.t_sitm,'') "
        Sql &= "where cItm.t_orno='" & po.PONumber & "'"
        Sql &= "  and cItm.t_pono= " & poBom.ItemNo
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Results = New List(Of SIS.PAK.pakERPPOLChild)
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Results.Add(New SIS.PAK.pakERPPOLChild(Reader))
            End While
            Reader.Close()
          End Using
        End Using
        Return Results
      End Function
      Public Shared Function GetFromERP(Optional ByVal ProjectID As String = "", Optional ByVal PONumber As String = "") As List(Of SIS.PAK.pakPO)
        Dim POSinceDays As Integer = ConfigurationManager.AppSettings("POSinceDays")
        Dim PODivision As String = HttpContext.Current.Session("DivisionID")
        Dim Sql As String = ""
        '--t_work = 3 =>Completed
        '--t_hdst 10 =>Approved
        '--       30 =>Cancelled
        '--cdf_catg=1 Boughtout,2 Fabrication, 3 General
        Sql &= "select TOP 10 "
        Sql &= "  apo.t_orno as PONumber,"
        Sql &= "  apo.t_vrsn as PORevision,"
        Sql &= "  apo.t_apdt as PODate,"
        Sql &= "  lpo.t_cprj as ProjectID,"
        Sql &= "  hpo.t_otbp as SupplierID,"
        Sql &= "  hpo.t_otad as BuyFromAddressID,"
        Sql &= "  hpo.t_ccon as BuyerID,"
        Sql &= "  (select top 1 (case when xx.t_bptc='IN' then 0 else 1 end) as tmp from ttppdm740200 as xx where xx.t_cprj = lpo.t_cprj ) As PortRequired,"
        Sql &= "  substring(apo.t_orno+'ZZ',2,1) as DivisionID,"
        Sql &= "  hpo.t_hdst as erpPOStatus, "
        Sql &= "  (select sum(case when t_wght=0 then t_qnty else t_wght end) from ttdisg002200 where t_orno='" & PONumber & "') As POWeight "
        Sql &= "  from ttdmsl400200 apo "
        Sql &= "  cross apply (select top 1 tmp.t_cprj from ttdpur401200 tmp where tmp.t_orno=apo.t_orno   "
        Sql &= "              ) lpo "
        Sql &= "  inner join ttdpur400200 as hpo on apo.t_orno = hpo.t_orno "
        Sql &= "  where apo.t_work = 3 "
        Sql &= "  and apo.t_vrsn = (select max(tmp.t_vrsn) from ttdmsl400200 tmp where tmp.t_orno=apo.t_orno) "
        If PODivision <> "0" Then
          Sql &= "  and substring(apo.t_orno+'ZZ',2,1) = '" & PODivision & "'"
        End If
        If ProjectID <> String.Empty Then
          Sql &= "  and lpo.t_cprj = '" & ProjectID & "'"
        End If
        If PONumber <> String.Empty Then
          Sql &= "  and apo.t_orno='" & PONumber & "'"
        End If
        Dim Results As List(Of SIS.PAK.pakPO) = Nothing
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Results = New List(Of SIS.PAK.pakPO)
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Results.Add(New SIS.PAK.pakPO(Reader))
            End While
            Reader.Close()
          End Using
        End Using
        Return Results
      End Function
      Sub New()
        'dummy
      End Sub
    End Class
    Public Class erpProject
      Inherits SIS.QCM.qcmProjects
      Public Shared Function GetFromERP(ByVal ProjectID As String) As SIS.PAK.erpData.erpProject
        Dim Ret As SIS.PAK.erpData.erpProject = Nothing
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
              Ret = New SIS.PAK.erpData.erpProject(Reader)
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
      Public Shared Function GetFromERP(ByVal SupplierID As String) As SIS.PAK.pakBusinessPartner
        Dim Ret As SIS.PAK.pakBusinessPartner = Nothing
        Dim Sql As String = ""
        Sql &= "select                                                           "
        Sql &= "  suh.t_bpid as BPID,                                      "
        Sql &= "  suh.t_nama as BPName,                                    "
        Sql &= "  adh.t_ln01 as Address1Line,                                        "
        Sql &= "  adh.t_ln02 as Address2Line,                                        "
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
              Ret = New SIS.PAK.pakBusinessPartner(Reader)
            End If
            Reader.Close()
          End Using
        End Using
        Return Ret
      End Function
    End Class
    Public Class erpElement
      Inherits SIS.PAK.pakWBS
      Public Shared Function GetFromERP(ByVal ElementID As String) As SIS.PAK.pakWBS
        Dim Ret As SIS.PAK.pakWBS = Nothing
        Dim Sql As String = ""
        Sql &= "select top 1  "
        Sql &= "  t_cspa as WBSID,  "
        Sql &= "  t_desc as Description "
        Sql &= "  from ttppdm090200  "
        Sql &= "  where t_cspa ='" & ElementID & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              Ret = New SIS.PAK.pakWBS(Reader)
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
    Public Class erpPAKElement
      Inherits SIS.PAK.pakElements
      Public Shared Function GetFromERP(ByVal ElementID As String) As SIS.PAK.pakElements
        Dim Ret As SIS.PAK.pakElements = Nothing
        Dim Sql As String = ""
        Sql &= "select top 1  "
        Sql &= "  t_cspa as ElementID,  "
        Sql &= "  t_desc as Description "
        Sql &= "  from ttppdm090200  "
        Sql &= "  where t_cspa ='" & ElementID & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              Ret = New SIS.PAK.pakElements(Reader)
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


    Public Class erpEnggGroup
      Public Property EngGroup As String = ""
      Public Property EmpID As String = ""
      Public Property EmpName As String = ""
      Public Property EMailID As String = ""
      Public Property ProjectID As String = ""
      Public Shared Function GetFromERP(ByVal eUnit As String, ByVal ProjectID As String) As List(Of erpEnggGroup)
        Dim Ret As New List(Of erpEnggGroup)
        Dim Sql As String = ""
        Sql &= "  Select distinct en.t_engi as EngGroup,en.t_logn as EmpID,em.t_nama As EmpName,bp.t_mail As EMailID, en.t_cprj as ProjectID from tdmisg133200 As en "
        Sql &= "  inner Join ttccom001200 As em On en.t_logn = em.t_loco "
        Sql &= "  Left outer join tbpmdm001200 as bp on em.t_emno=bp.t_emno "
        Sql &= "  where en.t_eunt ='" & eUnit & "'"
        Sql &= "  and en.t_cprj ='" & ProjectID & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Ret.Add(New erpEnggGroup(Reader))
            End While
            Reader.Close()
          End Using
        End Using
        Return Ret
      End Function
      Sub New(ByVal rd As SqlDataReader)
        EngGroup = rd("EngGroup")
        EmpID = rd("EmpID")
        EmpName = rd("EmpName")
        EMailID = IIf(Convert.IsDBNull(rd("EMailID")), "", rd("EMailID"))
        ProjectID = IIf(Convert.IsDBNull(rd("ProjectID")), "", rd("ProjectID"))
      End Sub
      Sub New()
        MyBase.New()
      End Sub
    End Class

  End Class

#End Region
End Namespace
