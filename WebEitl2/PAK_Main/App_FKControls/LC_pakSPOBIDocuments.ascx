<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSPOBIDocuments.ascx.vb" Inherits="LC_pakSPOBIDocuments" %>
<asp:DropDownList 
  ID = "DDLpakSPOBIDocuments"
  DataSourceID = "OdsDdlpakSPOBIDocuments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSPOBIDocuments"
  Runat = "server" 
  ControlToValidate = "DDLpakSPOBIDocuments"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSPOBIDocuments"
  TypeName = "SIS.PAK.pakSPOBIDocuments"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSPOBIDocumentsSelectList"
  Runat="server" />
