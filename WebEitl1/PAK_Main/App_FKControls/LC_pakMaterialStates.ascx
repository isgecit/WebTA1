<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakMaterialStates.ascx.vb" Inherits="LC_pakMaterialStates" %>
<asp:DropDownList 
  ID = "DDLpakMaterialStates"
  DataSourceID = "OdsDdlpakMaterialStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakMaterialStates"
  Runat = "server" 
  ControlToValidate = "DDLpakMaterialStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakMaterialStates"
  TypeName = "SIS.PAK.pakMaterialStates"
  SortParameterName = "OrderBy"
  SelectMethod = "pakMaterialStatesSelectList"
  Runat="server" />
