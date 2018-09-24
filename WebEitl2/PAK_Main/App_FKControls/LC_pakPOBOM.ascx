<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPOBOM.ascx.vb" Inherits="LC_pakPOBOM" %>
<asp:DropDownList 
  ID = "DDLpakPOBOM"
  DataSourceID = "OdsDdlpakPOBOM"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPOBOM"
  Runat = "server" 
  ControlToValidate = "DDLpakPOBOM"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPOBOM"
  TypeName = "SIS.PAK.pakPOBOM"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPOBOMSelectList"
  Runat="server" />
