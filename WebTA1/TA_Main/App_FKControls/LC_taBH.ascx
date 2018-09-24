<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taBH.ascx.vb" Inherits="LC_taBH" %>
<asp:DropDownList 
  ID = "DDLtaBH"
  DataSourceID = "OdsDdltaBH"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaBH"
  Runat = "server" 
  ControlToValidate = "DDLtaBH"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaBH"
  TypeName = "SIS.TA.taBH"
  SortParameterName = "OrderBy"
  SelectMethod = "taBHSelectList"
  Runat="server" />
