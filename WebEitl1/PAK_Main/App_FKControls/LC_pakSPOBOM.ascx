<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSPOBOM.ascx.vb" Inherits="LC_pakSPOBOM" %>
<asp:DropDownList 
  ID = "DDLpakSPOBOM"
  DataSourceID = "OdsDdlpakSPOBOM"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSPOBOM"
  Runat = "server" 
  ControlToValidate = "DDLpakSPOBOM"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSPOBOM"
  TypeName = "SIS.PAK.pakSPOBOM"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSPOBOMSelectList"
  Runat="server" />
