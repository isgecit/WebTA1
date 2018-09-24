<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taEmployees.ascx.vb" Inherits="LC_taEmployees" %>
<asp:DropDownList 
  ID = "DDLtaEmployees"
  DataSourceID = "OdsDdltaEmployees"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaEmployees"
  Runat = "server" 
  ControlToValidate = "DDLtaEmployees"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaEmployees"
  TypeName = "SIS.TA.taEmployees"
  SortParameterName = "OrderBy"
  SelectMethod = "taEmployeesSelectList"
  Runat="server" />
