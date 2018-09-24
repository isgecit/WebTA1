<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taDepartments.ascx.vb" Inherits="LC_taDepartments" %>
<asp:DropDownList 
  ID = "DDLtaDepartments"
  DataSourceID = "OdsDdltaDepartments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaDepartments"
  Runat = "server" 
  ControlToValidate = "DDLtaDepartments"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaDepartments"
  TypeName = "SIS.TA.taDepartments"
  SortParameterName = "OrderBy"
  SelectMethod = "taDepartmentsSelectList"
  Runat="server" />
