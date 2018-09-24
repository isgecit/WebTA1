<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taBillStates.ascx.vb" Inherits="LC_taBillStates" %>
<asp:DropDownList 
  ID = "DDLtaBillStates"
  DataSourceID = "OdsDdltaBillStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaBillStates"
  Runat = "server" 
  ControlToValidate = "DDLtaBillStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaBillStates"
  TypeName = "SIS.TA.taBillStates"
  SortParameterName = "OrderBy"
  SelectMethod = "taBillStatesSelectList"
  Runat="server" />
