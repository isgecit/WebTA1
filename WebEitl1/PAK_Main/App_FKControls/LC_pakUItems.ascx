<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakUItems.ascx.vb" Inherits="LC_pakUItems" %>
<asp:DropDownList 
  ID = "DDLpakUItems"
  DataSourceID = "OdsDdlpakUItems"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakUItems"
  Runat = "server" 
  ControlToValidate = "DDLpakUItems"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakUItems"
  TypeName = "SIS.PAK.pakUItems"
  SortParameterName = "OrderBy"
  SelectMethod = "pakUItemsSelectList"
  Runat="server" />
