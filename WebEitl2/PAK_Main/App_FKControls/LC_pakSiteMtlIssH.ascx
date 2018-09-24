<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSiteMtlIssH.ascx.vb" Inherits="LC_pakSiteMtlIssH" %>
<asp:DropDownList 
  ID = "DDLpakSiteMtlIssH"
  DataSourceID = "OdsDdlpakSiteMtlIssH"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSiteMtlIssH"
  Runat = "server" 
  ControlToValidate = "DDLpakSiteMtlIssH"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSiteMtlIssH"
  TypeName = "SIS.PAK.pakSiteMtlIssH"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSiteMtlIssHSelectList"
  Runat="server" />
