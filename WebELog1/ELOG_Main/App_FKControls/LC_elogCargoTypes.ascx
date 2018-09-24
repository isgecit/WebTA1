<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogCargoTypes.ascx.vb" Inherits="LC_elogCargoTypes" %>
<asp:DropDownList 
  ID = "DDLelogCargoTypes"
  DataSourceID = "OdsDdlelogCargoTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogCargoTypes"
  Runat = "server" 
  ControlToValidate = "DDLelogCargoTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogCargoTypes"
  TypeName = "SIS.ELOG.elogCargoTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "elogCargoTypesSelectList"
  Runat="server" />
