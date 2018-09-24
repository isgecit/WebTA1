<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakIssueStatus.ascx.vb" Inherits="LC_pakIssueStatus" %>
<asp:DropDownList 
  ID = "DDLpakIssueStatus"
  DataSourceID = "OdsDdlpakIssueStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakIssueStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakIssueStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakIssueStatus"
  TypeName = "SIS.PAK.pakIssueStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakIssueStatusSelectList"
  Runat="server" />
