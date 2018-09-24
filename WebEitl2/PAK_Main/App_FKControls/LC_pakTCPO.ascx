<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakTCPO.ascx.vb" Inherits="LC_pakTCPO" %>
<asp:DropDownList 
  ID = "DDLpakTCPO"
  DataSourceID = "OdsDdlpakTCPO"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakTCPO"
  Runat = "server" 
  ControlToValidate = "DDLpakTCPO"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakTCPO"
  TypeName = "SIS.PAK.pakTCPO"
  SortParameterName = "OrderBy"
  SelectMethod = "pakTCPOSelectList"
  Runat="server" />
