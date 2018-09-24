<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSitePkgH.ascx.vb" Inherits="LC_pakSitePkgH" %>
<asp:DropDownList 
  ID = "DDLpakSitePkgH"
  DataSourceID = "OdsDdlpakSitePkgH"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSitePkgH"
  Runat = "server" 
  ControlToValidate = "DDLpakSitePkgH"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSitePkgH"
  TypeName = "SIS.PAK.pakSitePkgH"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSitePkgHSelectList"
  Runat="server" />
