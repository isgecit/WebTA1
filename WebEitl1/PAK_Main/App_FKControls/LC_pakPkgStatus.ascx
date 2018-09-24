<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPkgStatus.ascx.vb" Inherits="LC_pakPkgStatus" %>
<asp:DropDownList 
  ID = "DDLpakPkgStatus"
  DataSourceID = "OdsDdlpakPkgStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPkgStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakPkgStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPkgStatus"
  TypeName = "SIS.PAK.pakPkgStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPkgStatusSelectList"
  Runat="server" />
