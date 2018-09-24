<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPkgListD.ascx.vb" Inherits="LC_pakPkgListD" %>
<asp:DropDownList 
  ID = "DDLpakPkgListD"
  DataSourceID = "OdsDdlpakPkgListD"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPkgListD"
  Runat = "server" 
  ControlToValidate = "DDLpakPkgListD"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPkgListD"
  TypeName = "SIS.PAK.pakPkgListD"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPkgListDSelectList"
  Runat="server" />
