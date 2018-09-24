<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlIssuedPODocument.ascx.vb" Inherits="LC_eitlIssuedPODocument" %>
<asp:DropDownList 
  ID = "DDLeitlIssuedPODocument"
  DataSourceID = "OdsDdleitlIssuedPODocument"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlIssuedPODocument"
  Runat = "server" 
  ControlToValidate = "DDLeitlIssuedPODocument"
  Text = "Issued PO Document is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlIssuedPODocument"
  runat = "server"
  TargetControlID = "DDLeitlIssuedPODocument"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlIssuedPODocument"
  TypeName = "SIS.EITL.eitlIssuedPODocument"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlIssuedPODocumentSelectList"
  Runat="server" />
