<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakTCPOLRD.ascx.vb" Inherits="LC_pakTCPOLRD" %>
<asp:DropDownList 
  ID = "DDLpakTCPOLRD"
  DataSourceID = "OdsDdlpakTCPOLRD"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakTCPOLRD"
  Runat = "server" 
  ControlToValidate = "DDLpakTCPOLRD"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakTCPOLRD"
  TypeName = "SIS.PAK.pakTCPOLRD"
  SortParameterName = "OrderBy"
  SelectMethod = "pakTCPOLRDSelectList"
  Runat="server" />
