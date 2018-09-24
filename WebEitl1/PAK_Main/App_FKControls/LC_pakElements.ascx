<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakElements.ascx.vb" Inherits="LC_pakElements" %>
<asp:DropDownList 
  ID = "DDLpakElements"
  DataSourceID = "OdsDdlpakElements"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakElements"
  Runat = "server" 
  ControlToValidate = "DDLpakElements"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakElements"
  TypeName = "SIS.PAK.pakElements"
  SortParameterName = "OrderBy"
  SelectMethod = "pakElementsSelectList"
  Runat="server" />
