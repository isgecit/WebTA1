<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogStuffingPoints.ascx.vb" Inherits="LC_elogStuffingPoints" %>
<asp:DropDownList 
  ID = "DDLelogStuffingPoints"
  DataSourceID = "OdsDdlelogStuffingPoints"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogStuffingPoints"
  Runat = "server" 
  ControlToValidate = "DDLelogStuffingPoints"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogStuffingPoints"
  TypeName = "SIS.ELOG.elogStuffingPoints"
  SortParameterName = "OrderBy"
  SelectMethod = "elogStuffingPointsSelectList"
  Runat="server" />
