<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPkgPO.ascx.vb" Inherits="LC_pakPkgPO" %>
<asp:DropDownList 
  ID = "DDLpakPkgPO"
  DataSourceID = "OdsDdlpakPkgPO"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPkgPO"
  Runat = "server" 
  ControlToValidate = "DDLpakPkgPO"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPkgPO"
  TypeName = "SIS.PAK.pakPkgPO"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPkgPOSelectList"
  Runat="server" />
