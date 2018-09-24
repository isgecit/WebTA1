<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogDetentionBillTypes.ascx.vb" Inherits="LC_elogDetentionBillTypes" %>
<asp:DropDownList 
  ID = "DDLelogDetentionBillTypes"
  DataSourceID = "OdsDdlelogDetentionBillTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogDetentionBillTypes"
  Runat = "server" 
  ControlToValidate = "DDLelogDetentionBillTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogDetentionBillTypes"
  TypeName = "SIS.ELOG.elogDetentionBillTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "elogDetentionBillTypesSelectList"
  Runat="server" />
