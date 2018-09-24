<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costDivisions.ascx.vb" Inherits="LC_costDivisions" %>
<asp:DropDownList 
  ID = "DDLcostDivisions"
  DataSourceID = "OdsDdlcostDivisions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostDivisions"
  Runat = "server" 
  ControlToValidate = "DDLcostDivisions"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostDivisions"
  TypeName = "SIS.COST.costDivisions"
  SortParameterName = "OrderBy"
  SelectMethod = "costDivisionsSelectList"
  Runat="server" />
