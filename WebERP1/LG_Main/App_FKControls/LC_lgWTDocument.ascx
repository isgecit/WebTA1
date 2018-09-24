<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_lgWTDocument.ascx.vb" Inherits="LC_lgWTDocument" %>
<asp:DropDownList 
  ID = "DDLlgWTDocument"
  DataSourceID = "OdsDdllgWTDocument"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorlgWTDocument"
  Runat = "server" 
  ControlToValidate = "DDLlgWTDocument"
  Text = "WT Documents is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSElgWTDocument"
  runat = "server"
  TargetControlID = "DDLlgWTDocument"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdllgWTDocument"
  TypeName = "SIS.LG.lgWTDocument"
  SortParameterName = "OrderBy"
  SelectMethod = "lgWTDocumentSelectList"
  Runat="server" />
