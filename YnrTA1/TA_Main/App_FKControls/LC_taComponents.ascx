<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taComponents.ascx.vb" Inherits="LC_taComponents" %>
<asp:DropDownList 
  ID = "DDLtaComponents"
  DataSourceID = "OdsDdltaComponents"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaComponents"
  Runat = "server" 
  ControlToValidate = "DDLtaComponents"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaComponents"
  TypeName = "SIS.TA.taComponents"
  SortParameterName = "OrderBy"
  SelectMethod = "taComponentsSelectList"
  Runat="server" />
