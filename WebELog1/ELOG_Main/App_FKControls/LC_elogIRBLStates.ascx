<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogIRBLStates.ascx.vb" Inherits="LC_elogIRBLStates" %>
<asp:DropDownList 
  ID = "DDLelogIRBLStates"
  DataSourceID = "OdsDdlelogIRBLStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogIRBLStates"
  Runat = "server" 
  ControlToValidate = "DDLelogIRBLStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogIRBLStates"
  TypeName = "SIS.ELOG.elogIRBLStates"
  SortParameterName = "OrderBy"
  SelectMethod = "elogIRBLStatesSelectList"
  Runat="server" />
