<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSiteIssRecD.ascx.vb" Inherits="LC_pakSiteIssRecD" %>
<asp:DropDownList 
  ID = "DDLpakSiteIssRecD"
  DataSourceID = "OdsDdlpakSiteIssRecD"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSiteIssRecD"
  Runat = "server" 
  ControlToValidate = "DDLpakSiteIssRecD"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSiteIssRecD"
  TypeName = "SIS.PAK.pakSiteIssRecD"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSiteIssRecDSelectList"
  Runat="server" />
