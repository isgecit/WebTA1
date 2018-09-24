<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogChargeTypes.ascx.vb" Inherits="LC_elogChargeTypes" %>
<asp:DropDownList 
  ID = "DDLelogChargeTypes"
  DataSourceID = "OdsDdlelogChargeTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogChargeTypes"
  Runat = "server" 
  ControlToValidate = "DDLelogChargeTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogChargeTypes"
  TypeName = "SIS.ELOG.elogChargeTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "elogChargeTypesSelectList"
  Runat="server" />
