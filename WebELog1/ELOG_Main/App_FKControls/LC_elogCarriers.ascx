<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogCarriers.ascx.vb" Inherits="LC_elogCarriers" %>
<asp:DropDownList 
  ID = "DDLelogCarriers"
  DataSourceID = "OdsDdlelogCarriers"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogCarriers"
  Runat = "server" 
  ControlToValidate = "DDLelogCarriers"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogCarriers"
  TypeName = "SIS.ELOG.elogCarriers"
  SortParameterName = "OrderBy"
  SelectMethod = "LG_elogCarriersSelectList"
  Runat="server" />
