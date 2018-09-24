<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakItems.ascx.vb" Inherits="LC_pakItems" %>
<asp:DropDownList 
  ID = "DDLpakItems"
  DataSourceID = "OdsDdlpakItems"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakItems"
  Runat = "server" 
  ControlToValidate = "DDLpakItems"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakItems"
  TypeName = "SIS.PAK.pakItems"
  SortParameterName = "OrderBy"
  SelectMethod = "pakItemsSelectList"
  Runat="server" />
