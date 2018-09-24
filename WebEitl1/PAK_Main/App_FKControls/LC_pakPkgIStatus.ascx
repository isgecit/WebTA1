<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPkgIStatus.ascx.vb" Inherits="LC_pakPkgIStatus" %>
<asp:DropDownList 
  ID = "DDLpakPkgIStatus"
  DataSourceID = "OdsDdlpakPkgIStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPkgIStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakPkgIStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPkgIStatus"
  TypeName = "SIS.PAK.pakPkgIStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPkgIStatusSelectList"
  Runat="server" />
