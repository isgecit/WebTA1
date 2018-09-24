<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogPorts.ascx.vb" Inherits="LC_elogPorts" %>
<asp:DropDownList 
  ID = "DDLelogPorts"
  DataSourceID = "OdsDdlelogPorts"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogPorts"
  Runat = "server" 
  ControlToValidate = "DDLelogPorts"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogPorts"
  TypeName = "SIS.ELOG.elogPorts"
  SortParameterName = "OrderBy"
  SelectMethod = "elogPortsSelectList"
  Runat="server" />
