<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakQCListH.ascx.vb" Inherits="LC_pakQCListH" %>
<asp:DropDownList 
  ID = "DDLpakQCListH"
  DataSourceID = "OdsDdlpakQCListH"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakQCListH"
  Runat = "server" 
  ControlToValidate = "DDLpakQCListH"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakQCListH"
  TypeName = "SIS.PAK.pakQCListH"
  SortParameterName = "OrderBy"
  SelectMethod = "pakQCListHSelectList"
  Runat="server" />
