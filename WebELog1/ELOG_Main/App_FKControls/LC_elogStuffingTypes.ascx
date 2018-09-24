<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogStuffingTypes.ascx.vb" Inherits="LC_elogStuffingTypes" %>
<asp:DropDownList 
  ID = "DDLelogStuffingTypes"
  DataSourceID = "OdsDdlelogStuffingTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogStuffingTypes"
  Runat = "server" 
  ControlToValidate = "DDLelogStuffingTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogStuffingTypes"
  TypeName = "SIS.ELOG.elogStuffingTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "elogStuffingTypesSelectList"
  Runat="server" />
