<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taDivisions.ascx.vb" Inherits="LC_taDivisions" %>
<asp:DropDownList 
  ID = "DDLtaDivisions"
  DataSourceID = "OdsDdltaDivisions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaDivisions"
  Runat = "server" 
  ControlToValidate = "DDLtaDivisions"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaDivisions"
  TypeName = "SIS.TA.taDivisions"
  SortParameterName = "OrderBy"
  SelectMethod = "taDivisionsSelectList"
  Runat="server" />
