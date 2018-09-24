<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPOBIDocuments.ascx.vb" Inherits="LC_pakPOBIDocuments" %>
<asp:DropDownList 
  ID = "DDLpakPOBIDocuments"
  DataSourceID = "OdsDdlpakPOBIDocuments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPOBIDocuments"
  Runat = "server" 
  ControlToValidate = "DDLpakPOBIDocuments"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPOBIDocuments"
  TypeName = "SIS.PAK.pakPOBIDocuments"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPOBIDocumentsSelectList"
  Runat="server" />
