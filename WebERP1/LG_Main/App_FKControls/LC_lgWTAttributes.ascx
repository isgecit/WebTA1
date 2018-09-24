<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_lgWTAttributes.ascx.vb" Inherits="LC_lgWTAttributes" %>
<asp:DropDownList 
  ID = "DDLlgWTAttributes"
  DataSourceID = "OdsDdllgWTAttributes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorlgWTAttributes"
  Runat = "server" 
  ControlToValidate = "DDLlgWTAttributes"
  Text = "WT Attributes is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSElgWTAttributes"
  runat = "server"
  TargetControlID = "DDLlgWTAttributes"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdllgWTAttributes"
  TypeName = "SIS.LG.lgWTAttributes"
  SortParameterName = "OrderBy"
  SelectMethod = "lgWTAttributesSelectList"
  Runat="server" />
