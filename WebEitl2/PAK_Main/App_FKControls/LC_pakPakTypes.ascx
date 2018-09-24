<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPakTypes.ascx.vb" Inherits="LC_pakPakTypes" %>
<asp:DropDownList 
  ID = "DDLpakPakTypes"
  DataSourceID = "OdsDdlpakPakTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPakTypes"
  Runat = "server" 
  ControlToValidate = "DDLpakPakTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPakTypes"
  TypeName = "SIS.PAK.pakPakTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPakTypesSelectList"
  Runat="server" />
