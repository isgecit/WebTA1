<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakQCListStatus.ascx.vb" Inherits="LC_pakQCListStatus" %>
<asp:DropDownList 
  ID = "DDLpakQCListStatus"
  DataSourceID = "OdsDdlpakQCListStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakQCListStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakQCListStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakQCListStatus"
  TypeName = "SIS.PAK.pakQCListStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakQCListStatusSelectList"
  Runat="server" />
