<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogShipmentModes.ascx.vb" Inherits="LC_elogShipmentModes" %>
<asp:DropDownList 
  ID = "DDLelogShipmentModes"
  DataSourceID = "OdsDdlelogShipmentModes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogShipmentModes"
  Runat = "server" 
  ControlToValidate = "DDLelogShipmentModes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogShipmentModes"
  TypeName = "SIS.ELOG.elogShipmentModes"
  SortParameterName = "OrderBy"
  SelectMethod = "elogShipmentModesSelectList"
  Runat="server" />
