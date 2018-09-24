<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakCItems.ascx.vb" Inherits="LC_pakCItems" %>
<asp:DropDownList 
  ID = "DDLpakCItems"
  DataSourceID = "OdsDdlpakCItems"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakCItems"
  Runat = "server" 
  ControlToValidate = "DDLpakCItems"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakCItems"
  TypeName = "SIS.PAK.pakCItems"
  SortParameterName = "OrderBy"
  SelectMethod = "pakCItemsSelectList"
  Runat="server" />
