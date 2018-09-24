<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakTCPOLR.ascx.vb" Inherits="LC_pakTCPOLR" %>
<asp:DropDownList 
  ID = "DDLpakTCPOLR"
  DataSourceID = "OdsDdlpakTCPOLR"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakTCPOLR"
  Runat = "server" 
  ControlToValidate = "DDLpakTCPOLR"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakTCPOLR"
  TypeName = "SIS.PAK.pakTCPOLR"
  SortParameterName = "OrderBy"
  SelectMethod = "pakTCPOLRSelectList"
  Runat="server" />
