<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakTCPOLRCate.ascx.vb" Inherits="LC_pakTCPOLRCate" %>
<asp:DropDownList 
  ID = "DDLpakTCPOLRCate"
  DataSourceID = "OdsDdlpakTCPOLRCate"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakTCPOLRCate"
  Runat = "server" 
  ControlToValidate = "DDLpakTCPOLRCate"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakTCPOLRCate"
  TypeName = "SIS.PAK.pakTCPOLRCate"
  SortParameterName = "OrderBy"
  SelectMethod = "pakTCPOLRCateSelectList"
  Runat="server" />
