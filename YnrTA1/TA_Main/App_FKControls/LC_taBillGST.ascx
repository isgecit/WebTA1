<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taBillGST.ascx.vb" Inherits="LC_taBillGST" %>
<asp:DropDownList 
  ID = "DDLtaBillGST"
  DataSourceID = "OdsDdltaBillGST"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaBillGST"
  Runat = "server" 
  ControlToValidate = "DDLtaBillGST"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaBillGST"
  TypeName = "SIS.TA.taBillGST"
  SortParameterName = "OrderBy"
  SelectMethod = "taBillGSTSelectList"
  Runat="server" />
