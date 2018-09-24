<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakTCPOL.ascx.vb" Inherits="LC_pakTCPOL" %>
<asp:DropDownList 
  ID = "DDLpakTCPOL"
  DataSourceID = "OdsDdlpakTCPOL"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakTCPOL"
  Runat = "server" 
  ControlToValidate = "DDLpakTCPOL"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakTCPOL"
  TypeName = "SIS.PAK.pakTCPOL"
  SortParameterName = "OrderBy"
  SelectMethod = "pakTCPOLSelectList"
  Runat="server" />
