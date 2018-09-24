<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkEmployees.ascx.vb" Inherits="LC_nprkEmployees" %>
<asp:DropDownList 
  ID = "DDLnprkEmployees"
  DataSourceID = "OdsDdlnprkEmployees"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkEmployees"
  Runat = "server" 
  ControlToValidate = "DDLnprkEmployees"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkEmployees"
  TypeName = "SIS.NPRK.nprkEmployees"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkEmployeesSelectList"
  Runat="server" />
