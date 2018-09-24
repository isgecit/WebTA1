Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class EF_pakSPO
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSpakSPO_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSPO.Selected
    Dim tmp As SIS.PAK.pakSPO = CType(e.ReturnValue, SIS.PAK.pakSPO)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSPO.Init
    DataClassName = "EpakSPO"
    SetFormView = FVpakSPO
  End Sub
  Protected Sub TBLpakSPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSPO.Init
    SetToolBar = TBLpakSPO
  End Sub
  Protected Sub FVpakSPO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSPO.PreRender
    TBLpakSPO.EnableSave = Editable
    TBLpakSPO.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSPO.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSPO") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSPO", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSPOBOMCC As New gvBase
  Protected Sub GVpakSPOBOM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSPOBOM.Init
    gvpakSPOBOMCC.DataClassName = "GpakSPOBOM"
    gvpakSPOBOMCC.SetGridView = GVpakSPOBOM
  End Sub
  Protected Sub TBLpakSPOBOM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSPOBOM.Init
    gvpakSPOBOMCC.SetToolBar = TBLpakSPOBOM
  End Sub
  Protected Sub GVpakSPOBOM_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSPOBOM.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim RedirectUrl As String = TBLpakSPOBOM.EditUrl & "?SerialNo=" & SerialNo & "&BOMNo=" & BOMNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("BOMNo")
        SIS.PAK.pakSPOBOM.InitiateWF(SerialNo, BOMNo)
        GVpakSPOBOM.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("BOMNo")
        SIS.PAK.pakSPOBOM.ApproveWF(SerialNo, BOMNo)
        GVpakSPOBOM.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("BOMNo")
        SIS.PAK.pakSPOBOM.RejectWF(SerialNo, BOMNo)
        GVpakSPOBOM.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBOM.DataKeys(e.CommandArgument).Values("BOMNo")
        SIS.PAK.pakSPOBOM.CompleteWF(SerialNo, BOMNo)
        GVpakSPOBOM.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Try
      With F_FileUpload
        If .HasFile Then
          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          .SaveAs(tmpFile)
          Dim fi As FileInfo = New FileInfo(tmpFile)
          Using xlP As ExcelPackage = New ExcelPackage(fi)
            Dim wsD As ExcelWorksheet = Nothing
            Try
              Try
                wsD = xlP.Workbook.Worksheets("Data")
              Catch ex As Exception
                wsD = Nothing
              End Try
              If wsD Is Nothing Then
                errMsg.Text = "XL File does not have DATA sheet, Invalid MS-EXCEL file."
                xlP.Dispose()
                Exit Sub
              End If
              Dim SerialNo As Integer = wsD.Cells(3, 2).Text
              Dim BOMNo As Integer = wsD.Cells(4, 2).Text
              Dim PItemNo As Integer = wsD.Cells(5, 2).Text
              Dim POStatusID As String = wsD.Cells(5, 6).Text.Split("-".ToCharArray)(0)

              Dim tmpPO As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
              If POStatusID <> tmpPO.POStatusID Then
                errMsg.Text = "PO Status does not match with uploaded file."
                xlP.Dispose()
                Exit Sub
              End If
              Dim tmpBOM As SIS.PAK.pakPOBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByID(SerialNo, BOMNo)
              Dim tmpBItem As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(SerialNo, BOMNo, PItemNo)

              Dim ItemNo As String = ""
              Dim ItemDesc As String = ""
              For I As Integer = 9 To 99000
                ItemNo = wsD.Cells(I, 1).Text
                If ItemNo = String.Empty Then Exit For
                Dim tmp As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
                If tmp Is Nothing Then Continue For
                If tmp.StatusID = pakItemStates.FreezedbyISGEC Then Continue For
                With tmp
                  Dim sUnit As String = wsD.Cells(I, 5).Text
                  Dim vUnit As String = ""
                  If sUnit <> "" Then
                    Dim tmpUnit As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByDescription(sUnit)
                    If tmpUnit IsNot Nothing Then
                      vUnit = tmpUnit.UnitID
                    End If
                  End If
                  .UOMQuantity = vUnit
                  .Quantity = IIf(wsD.Cells(I, 6).Text = "", 0, wsD.Cells(I, 6).Text)
                  sUnit = wsD.Cells(I, 7).Text
                  vUnit = ""
                  If sUnit <> "" Then
                    Dim tmpUnit As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByDescription(sUnit)
                    If tmpUnit IsNot Nothing Then
                      vUnit = tmpUnit.UnitID
                    End If
                  End If
                  .UOMWeight = vUnit
                  .WeightPerUnit = IIf(wsD.Cells(I, 8).Text = "", 0, wsD.Cells(I, 8).Text)
                  .SupplierRemarks = wsD.Cells(I, 10).Text
                  Dim tmpVer As Boolean = IIf(wsD.Cells(I, 9).Text = "Y", True, False)
                  If tmpVer Then
                    .StatusID = pakItemStates.VerifiedbySupplier
                    .AcceptedBy = HttpContext.Current.Session("LoginID")
                    .AcceptedOn = Now
                    .Accepted = True
                    .Changed = False
                  Else
                    'Do not update change required from Excel as discussed
                    'It will be done latter as per practic
                    '.StatusID = pakItemStates.ChangeRequiredBySupplier
                    '.AcceptedBy = HttpContext.Current.Session("LoginID")
                    '.AcceptedOn = Now
                    '.Accepted = False
                    '.Changed = True
                  End If
                End With
                Try
                  tmp = SIS.PAK.pakPOBItems.UpdateData(tmp)
                Catch ex As Exception
                  wsD.Cells(I, 3).AddComment(ex.Message, "Error")
                End Try
              Next
            Catch ex As Exception
              Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
              Dim script As String = String.Format("alert({0});", message)
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
            End Try
            xlP.Save()
            wsD.Dispose()
            xlP.Dispose()
          End Using
          Dim FileNameForUser As String = F_FileUpload.FileName
          '======================
          Response.Clear()
          Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
          Response.WriteFile(tmpFile)
          HttpContext.Current.Server.ScriptTimeout = st
          Response.End()
        End If
      End With
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
over:
  End Sub

End Class
