<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakTCPOLStatus.ascx.vb" Inherits="LC_pakTCPOLStatus" %>
<asp:DropDownList 
  ID = "DDLpakTCPOLStatus"
  DataSourceID = "OdsDdlpakTCPOLStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakTCPOLStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakTCPOLStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakTCPOLStatus"
  TypeName = "SIS.PAK.pakTCPOLStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakTCPOLStatusSelectList"
  Runat="server" />
