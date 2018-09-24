<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpRoles.ascx.vb" Inherits="LC_erpRoles" %>
<asp:DropDownList 
  ID = "DDLerpRoles"
  DataSourceID = "OdsDdlerpRoles"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpRoles"
  Runat = "server" 
  ControlToValidate = "DDLerpRoles"
  Text = "Roles is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpRoles"
  runat = "server"
  TargetControlID = "DDLerpRoles"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpRoles"
  TypeName = "SIS.ERP.erpRoles"
  SortParameterName = "OrderBy"
  SelectMethod = "erpRolesSelectList"
  Runat="server" />
