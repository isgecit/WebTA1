<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlPODocumentList.ascx.vb" Inherits="LC_eitlPODocumentList" %>
<asp:DropDownList 
  ID = "DDLeitlPODocumentList"
  DataSourceID = "OdsDdleitlPODocumentList"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlPODocumentList"
  Runat = "server" 
  ControlToValidate = "DDLeitlPODocumentList"
  Text = "PO Document is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlPODocumentList"
  runat = "server"
  TargetControlID = "DDLeitlPODocumentList"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlPODocumentList"
  TypeName = "SIS.EITL.eitlPODocumentList"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlPODocumentListSelectList"
  Runat="server" />
