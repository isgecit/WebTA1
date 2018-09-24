<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakTCPOLRStatus.ascx.vb" Inherits="LC_pakTCPOLRStatus" %>
<asp:DropDownList 
  ID = "DDLpakTCPOLRStatus"
  DataSourceID = "OdsDdlpakTCPOLRStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakTCPOLRStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakTCPOLRStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakTCPOLRStatus"
  TypeName = "SIS.PAK.pakTCPOLRStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakTCPOLRStatusSelectList"
  Runat="server" />
