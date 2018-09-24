<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakDivisions.ascx.vb" Inherits="LC_pakDivisions" %>
<asp:DropDownList 
  ID = "DDLpakDivisions"
  DataSourceID = "OdsDdlpakDivisions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakDivisions"
  Runat = "server" 
  ControlToValidate = "DDLpakDivisions"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakDivisions"
  TypeName = "SIS.PAK.pakDivisions"
  SortParameterName = "OrderBy"
  SelectMethod = "pakDivisionsSelectList"
  Runat="server" />
