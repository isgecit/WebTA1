<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogBLHeader.ascx.vb" Inherits="LC_elogBLHeader" %>
<asp:DropDownList 
  ID = "DDLelogBLHeader"
  DataSourceID = "OdsDdlelogBLHeader"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogBLHeader"
  Runat = "server" 
  ControlToValidate = "DDLelogBLHeader"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogBLHeader"
  TypeName = "SIS.ELOG.elogBLHeader"
  SortParameterName = "OrderBy"
  SelectMethod = "elogBLHeaderSelectList"
  Runat="server" />
