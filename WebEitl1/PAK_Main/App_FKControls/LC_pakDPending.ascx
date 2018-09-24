<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakDPending.ascx.vb" Inherits="LC_pakDPending" %>
<asp:DropDownList 
  ID = "DDLpakDPending"
  DataSourceID = "OdsDdlpakDPending"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakDPending"
  Runat = "server" 
  ControlToValidate = "DDLpakDPending"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakDPending"
  TypeName = "SIS.PAK.pakDPending"
  SortParameterName = "OrderBy"
  SelectMethod = "pakDPendingSelectList"
  Runat="server" />
