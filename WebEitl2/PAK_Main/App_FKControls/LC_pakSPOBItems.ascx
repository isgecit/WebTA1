<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSPOBItems.ascx.vb" Inherits="LC_pakSPOBItems" %>
<asp:DropDownList 
  ID = "DDLpakSPOBItems"
  DataSourceID = "OdsDdlpakSPOBItems"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSPOBItems"
  Runat = "server" 
  ControlToValidate = "DDLpakSPOBItems"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSPOBItems"
  TypeName = "SIS.PAK.pakSPOBItems"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSPOBItemsSelectList"
  Runat="server" />
