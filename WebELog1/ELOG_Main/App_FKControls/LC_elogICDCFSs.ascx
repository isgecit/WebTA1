<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogICDCFSs.ascx.vb" Inherits="LC_elogICDCFSs" %>
<asp:DropDownList 
  ID = "DDLelogICDCFSs"
  DataSourceID = "OdsDdlelogICDCFSs"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogICDCFSs"
  Runat = "server" 
  ControlToValidate = "DDLelogICDCFSs"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogICDCFSs"
  TypeName = "SIS.ELOG.elogICDCFSs"
  SortParameterName = "OrderBy"
  SelectMethod = "LG_elogICDCFSsSelectList"
  Runat="server" />
