<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogBLTypes.ascx.vb" Inherits="LC_elogBLTypes" %>
<asp:DropDownList 
  ID = "DDLelogBLTypes"
  DataSourceID = "OdsDdlelogBLTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogBLTypes"
  Runat = "server" 
  ControlToValidate = "DDLelogBLTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogBLTypes"
  TypeName = "SIS.ELOG.elogBLTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "elogBLTypesSelectList"
  Runat="server" />
