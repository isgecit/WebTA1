<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPOStatus.ascx.vb" Inherits="LC_pakPOStatus" %>
<asp:DropDownList 
  ID = "DDLpakPOStatus"
  DataSourceID = "OdsDdlpakPOStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPOStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakPOStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPOStatus"
  TypeName = "SIS.PAK.pakPOStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPOStatusSelectList"
  Runat="server" />
