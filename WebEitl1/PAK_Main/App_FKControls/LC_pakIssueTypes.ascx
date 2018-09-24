<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakIssueTypes.ascx.vb" Inherits="LC_pakIssueTypes" %>
<asp:DropDownList 
  ID = "DDLpakIssueTypes"
  DataSourceID = "OdsDdlpakIssueTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakIssueTypes"
  Runat = "server" 
  ControlToValidate = "DDLpakIssueTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakIssueTypes"
  TypeName = "SIS.PAK.pakIssueTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "pakIssueTypesSelectList"
  Runat="server" />
