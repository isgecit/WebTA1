<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_lgEPDocument.ascx.vb" Inherits="LC_lgEPDocument" %>
<asp:DropDownList 
  ID = "DDLlgEPDocument"
  DataSourceID = "OdsDdllgEPDocument"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorlgEPDocument"
  Runat = "server" 
  ControlToValidate = "DDLlgEPDocument"
  Text = "Document is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSElgEPDocument"
  runat = "server"
  TargetControlID = "DDLlgEPDocument"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdllgEPDocument"
  TypeName = "SIS.LG.lgEPDocument"
  SortParameterName = "OrderBy"
  SelectMethod = "lgEPDocumentSelectList"
  Runat="server" />
