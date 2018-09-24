<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakPOBOMStatus.ascx.vb" Inherits="LC_pakPOBOMStatus" %>
<asp:DropDownList 
  ID = "DDLpakPOBOMStatus"
  DataSourceID = "OdsDdlpakPOBOMStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakPOBOMStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakPOBOMStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakPOBOMStatus"
  TypeName = "SIS.PAK.pakPOBOMStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakPOBOMStatusSelectList"
  Runat="server" />
