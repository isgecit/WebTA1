Partial Class AF_elogDetentionBill
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogDetentionBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogDetentionBill.Init
    DataClassName = "AelogDetentionBill"
    SetFormView = FVelogDetentionBill
  End Sub
  Protected Sub TBLelogDetentionBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogDetentionBill.Init
    SetToolBar = TBLelogDetentionBill
  End Sub
  Protected Sub FVelogDetentionBill_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogDetentionBill.DataBound
    SIS.ELOG.elogDetentionBill.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogDetentionBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogDetentionBill.PreRender
    Dim oF_SupplierID_Display As Label  = FVelogDetentionBill.FindControl("F_SupplierID_Display")
    oF_SupplierID_Display.Text = String.Empty
    If Not Session("F_SupplierID_Display") Is Nothing Then
      If Session("F_SupplierID_Display") <> String.Empty Then
        oF_SupplierID_Display.Text = Session("F_SupplierID_Display")
      End If
    End If
    Dim oF_SupplierID As TextBox  = FVelogDetentionBill.FindControl("F_SupplierID")
    oF_SupplierID.Enabled = True
    oF_SupplierID.Text = String.Empty
    If Not Session("F_SupplierID") Is Nothing Then
      If Session("F_SupplierID") <> String.Empty Then
        oF_SupplierID.Text = Session("F_SupplierID")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVelogDetentionBill.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVelogDetentionBill.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogDetentionBill.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogDetentionBill") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogDetentionBill", mStr)
    End If
    If Request.QueryString("IRNo") IsNot Nothing Then
      CType(FVelogDetentionBill.FindControl("F_IRNo"), TextBox).Text = Request.QueryString("IRNo")
      CType(FVelogDetentionBill.FindControl("F_IRNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_elogDetentionBill(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim IRNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.ELOG.elogDetentionBill = SIS.ELOG.elogDetentionBill.elogDetentionBillGetByID(IRNo)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ELOG_DetentionBill_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ELOG_DetentionBill_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validatePK_vrTransporterBill(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim IRNo As Int32 = CType(aVal(1).Replace("_", ""), Int32)
    Dim oVar As List(Of SIS.ELOG.GRDetails) = SIS.ELOG.GRDetails.GetIRFromBaaN(IRNo)
    If oVar.Count <= 0 Then
      mRet = "1|" & aVal(0) & "|IR allready exists."
    Else
      mRet = mRet & "|"
      mRet = mRet & "<table>"
      For Each var As SIS.ELOG.GRDetails In oVar
        mRet = mRet & "<tr>"
        mRet = mRet & "<td>" & var.t_irno & "</td>"
        mRet = mRet & "<td>" & var.t_nama & "</td>"
        mRet = mRet & "</tr>"
      Next
      mRet = mRet & "</table>"
    End If
    Return mRet
  End Function

End Class
