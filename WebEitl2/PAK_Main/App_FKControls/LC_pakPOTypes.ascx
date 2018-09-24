<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPOTypes.ascx.vb" Inherits="LC_pakPOTypes" %>
<asp:DropDownList 
  ID = "DDLpakPOTypes"
  DataSourceID = "OdsDdlpakPOTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPOTypes"
  Runat = "server" 
  ControlToValidate = "DDLpakPOTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPOTypes"
  TypeName = "SIS.PAK.pakPOTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPOTypesSelectList"
  Runat="server" />
