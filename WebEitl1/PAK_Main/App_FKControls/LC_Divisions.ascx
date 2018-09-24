<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_Divisions.ascx.vb" Inherits="LC_Divisions" %>
<asp:DropDownList 
  ID = "DDLDivisions"
  DataSourceID = "OdsDdlDivisions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorDivisions"
  Runat = "server" 
  ControlToValidate = "DDLDivisions"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlDivisions"
  TypeName = "SIS.PAK.Divisions"
  SortParameterName = "OrderBy"
  SelectMethod = "DivisionsSelectList"
  Runat="server" />
