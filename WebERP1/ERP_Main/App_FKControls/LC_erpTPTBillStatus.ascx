<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpTPTBillStatus.ascx.vb" Inherits="LC_erpTPTBillStatus" %>
<asp:DropDownList 
  ID = "DDLerpTPTBillStatus"
  DataSourceID = "OdsDdlerpTPTBillStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpTPTBillStatus"
  Runat = "server" 
  ControlToValidate = "DDLerpTPTBillStatus"
  Text = "TPT. Bill Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpTPTBillStatus"
  runat = "server"
  TargetControlID = "DDLerpTPTBillStatus"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpTPTBillStatus"
  TypeName = "SIS.ERP.erpTPTBillStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "erpTPTBillStatusSelectList"
  Runat="server" />
