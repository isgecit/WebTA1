<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_lgWTFile.ascx.vb" Inherits="LC_lgWTFile" %>
<asp:DropDownList 
  ID = "DDLlgWTFile"
  DataSourceID = "OdsDdllgWTFile"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorlgWTFile"
  Runat = "server" 
  ControlToValidate = "DDLlgWTFile"
  Text = "WT File Details is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSElgWTFile"
  runat = "server"
  TargetControlID = "DDLlgWTFile"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdllgWTFile"
  TypeName = "SIS.LG.lgWTFile"
  SortParameterName = "OrderBy"
  SelectMethod = "lgWTFileSelectList"
  Runat="server" />
