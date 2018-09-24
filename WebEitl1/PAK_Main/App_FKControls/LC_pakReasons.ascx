<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakReasons.ascx.vb" Inherits="LC_pakReasons" %>
<asp:DropDownList 
  ID = "DDLpakReasons"
  DataSourceID = "OdsDdlpakReasons"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakReasons"
  Runat = "server" 
  ControlToValidate = "DDLpakReasons"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakReasons"
  TypeName = "SIS.PAK.pakReasons"
  SortParameterName = "OrderBy"
  SelectMethod = "pakReasonsSelectList"
  Runat="server" />
