<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPO.ascx.vb" Inherits="LC_pakPO" %>
<asp:DropDownList 
  ID = "DDLpakPO"
  DataSourceID = "OdsDdlpakPO"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPO"
  Runat = "server" 
  ControlToValidate = "DDLpakPO"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPO"
  TypeName = "SIS.PAK.pakPO"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPOSelectList"
  Runat="server" />
