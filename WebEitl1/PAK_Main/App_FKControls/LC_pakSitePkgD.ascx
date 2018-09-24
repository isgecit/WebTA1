<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSitePkgD.ascx.vb" Inherits="LC_pakSitePkgD" %>
<asp:DropDownList 
  ID = "DDLpakSitePkgD"
  DataSourceID = "OdsDdlpakSitePkgD"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSitePkgD"
  Runat = "server" 
  ControlToValidate = "DDLpakSitePkgD"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSitePkgD"
  TypeName = "SIS.PAK.pakSitePkgD"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSitePkgDSelectList"
  Runat="server" />
