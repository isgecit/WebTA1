<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakUnitSets.ascx.vb" Inherits="LC_pakUnitSets" %>
<asp:DropDownList 
  ID = "DDLpakUnitSets"
  DataSourceID = "OdsDdlpakUnitSets"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakUnitSets"
  Runat = "server" 
  ControlToValidate = "DDLpakUnitSets"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakUnitSets"
  TypeName = "SIS.PAK.pakUnitSets"
  SortParameterName = "OrderBy"
  SelectMethod = "pakUnitSetsSelectList"
  Runat="server" />
