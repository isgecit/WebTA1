<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPkgListH.ascx.vb" Inherits="LC_pakPkgListH" %>
<asp:DropDownList 
  ID = "DDLpakPkgListH"
  DataSourceID = "OdsDdlpakPkgListH"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPkgListH"
  Runat = "server" 
  ControlToValidate = "DDLpakPkgListH"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPkgListH"
  TypeName = "SIS.PAK.pakPkgListH"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPkgListHSelectList"
  Runat="server" />
