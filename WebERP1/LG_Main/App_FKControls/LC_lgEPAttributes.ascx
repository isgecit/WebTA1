<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_lgEPAttributes.ascx.vb" Inherits="LC_lgEPAttributes" %>
<asp:DropDownList 
  ID = "DDLlgEPAttributes"
  DataSourceID = "OdsDdllgEPAttributes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorlgEPAttributes"
  Runat = "server" 
  ControlToValidate = "DDLlgEPAttributes"
  Text = "EPM Attributes is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSElgEPAttributes"
  runat = "server"
  TargetControlID = "DDLlgEPAttributes"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdllgEPAttributes"
  TypeName = "SIS.LG.lgEPAttributes"
  SortParameterName = "OrderBy"
  SelectMethod = "lgEPAttributesSelectList"
  Runat="server" />
