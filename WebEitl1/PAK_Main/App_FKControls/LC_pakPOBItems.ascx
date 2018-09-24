<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPOBItems.ascx.vb" Inherits="LC_pakPOBItems" %>
<asp:DropDownList 
  ID = "DDLpakPOBItems"
  DataSourceID = "OdsDdlpakPOBItems"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPOBItems"
  Runat = "server" 
  ControlToValidate = "DDLpakPOBItems"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPOBItems"
  TypeName = "SIS.PAK.pakPOBItems"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPOBItemsSelectList"
  Runat="server" />
