<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpDCRHeader.ascx.vb" Inherits="LC_erpDCRHeader" %>
<asp:DropDownList 
  ID = "DDLerpDCRHeader"
  DataSourceID = "OdsDdlerpDCRHeader"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpDCRHeader"
  Runat = "server" 
  ControlToValidate = "DDLerpDCRHeader"
  Text = "DCR Header is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpDCRHeader"
  runat = "server"
  TargetControlID = "DDLerpDCRHeader"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpDCRHeader"
  TypeName = "SIS.ERP.erpDCRHeader"
  SortParameterName = "OrderBy"
  SelectMethod = "erpDCRHeaderSelectList"
  Runat="server" />
