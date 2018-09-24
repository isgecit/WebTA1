<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakDocuments.ascx.vb" Inherits="LC_pakDocuments" %>
<asp:DropDownList 
  ID = "DDLpakDocuments"
  DataSourceID = "OdsDdlpakDocuments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakDocuments"
  Runat = "server" 
  ControlToValidate = "DDLpakDocuments"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakDocuments"
  TypeName = "SIS.PAK.pakDocuments"
  SortParameterName = "OrderBy"
  SelectMethod = "pakDocumentsSelectList"
  Runat="server" />
