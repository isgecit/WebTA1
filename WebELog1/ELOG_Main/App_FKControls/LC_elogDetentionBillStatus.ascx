<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogDetentionBillStatus.ascx.vb" Inherits="LC_elogDetentionBillStatus" %>
<asp:DropDownList 
  ID = "DDLelogDetentionBillStatus"
  DataSourceID = "OdsDdlelogDetentionBillStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogDetentionBillStatus"
  Runat = "server" 
  ControlToValidate = "DDLelogDetentionBillStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogDetentionBillStatus"
  TypeName = "SIS.ELOG.elogDetentionBillStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "elogDetentionBillStatusSelectList"
  Runat="server" />
