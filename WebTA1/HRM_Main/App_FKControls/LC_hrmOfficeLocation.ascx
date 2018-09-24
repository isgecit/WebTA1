<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_hrmOfficeLocation.ascx.vb" Inherits="LC_hrmOfficeLocation" %>
<asp:DropDownList 
  ID = "DDLhrmOfficeLocation"
  DataSourceID = "OdsDdlhrmOfficeLocation"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorhrmOfficeLocation"
  Runat = "server" 
  ControlToValidate = "DDLhrmOfficeLocation"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlhrmOfficeLocation"
  TypeName = "SIS.HRM.hrmOfficeLocation"
  SortParameterName = "OrderBy"
  SelectMethod = "hrmOfficeLocationSelectList"
  Runat="server" />
