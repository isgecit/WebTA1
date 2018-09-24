<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogIRBL.ascx.vb" Inherits="LC_elogIRBL" %>
<asp:DropDownList 
  ID = "DDLelogIRBL"
  DataSourceID = "OdsDdlelogIRBL"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogIRBL"
  Runat = "server" 
  ControlToValidate = "DDLelogIRBL"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogIRBL"
  TypeName = "SIS.ELOG.elogIRBL"
  SortParameterName = "OrderBy"
  SelectMethod = "elogIRBLSelectList"
  Runat="server" />
