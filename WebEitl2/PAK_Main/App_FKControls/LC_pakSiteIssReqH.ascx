<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSiteIssReqH.ascx.vb" Inherits="LC_pakSiteIssReqH" %>
<asp:DropDownList 
  ID = "DDLpakSiteIssReqH"
  DataSourceID = "OdsDdlpakSiteIssReqH"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSiteIssReqH"
  Runat = "server" 
  ControlToValidate = "DDLpakSiteIssReqH"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSiteIssReqH"
  TypeName = "SIS.PAK.pakSiteIssReqH"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSiteIssReqHSelectList"
  Runat="server" />
