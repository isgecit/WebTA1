<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taLCModes.ascx.vb" Inherits="LC_taLCModes" %>
<asp:DropDownList 
  ID = "DDLtaLCModes"
  DataSourceID = "OdsDdltaLCModes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaLCModes"
  Runat = "server" 
  ControlToValidate = "DDLtaLCModes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaLCModes"
  TypeName = "SIS.TA.taLCModes"
  SortParameterName = "OrderBy"
  SelectMethod = "taLCModesSelectList"
  Runat="server" />
