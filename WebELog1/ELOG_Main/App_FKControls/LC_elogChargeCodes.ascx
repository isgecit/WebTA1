<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogChargeCodes.ascx.vb" Inherits="LC_elogChargeCodes" %>
<asp:DropDownList 
  ID = "DDLelogChargeCodes"
  DataSourceID = "OdsDdlelogChargeCodes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogChargeCodes"
  Runat = "server" 
  ControlToValidate = "DDLelogChargeCodes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogChargeCodes"
  TypeName = "SIS.ELOG.elogChargeCodes"
  SortParameterName = "OrderBy"
  SelectMethod = "LG_elogChargeCodesSelectList"
  Runat="server" />
