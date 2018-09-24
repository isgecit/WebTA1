<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakReceiveStatus.ascx.vb" Inherits="LC_pakReceiveStatus" %>
<asp:DropDownList 
  ID = "DDLpakReceiveStatus"
  DataSourceID = "OdsDdlpakReceiveStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakReceiveStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakReceiveStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakReceiveStatus"
  TypeName = "SIS.PAK.pakReceiveStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakReceiveStatusSelectList"
  Runat="server" />
