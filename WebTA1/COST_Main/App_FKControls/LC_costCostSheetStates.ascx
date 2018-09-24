<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costCostSheetStates.ascx.vb" Inherits="LC_costCostSheetStates" %>
<asp:DropDownList 
  ID = "DDLcostCostSheetStates"
  DataSourceID = "OdsDdlcostCostSheetStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostCostSheetStates"
  Runat = "server" 
  ControlToValidate = "DDLcostCostSheetStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostCostSheetStates"
  TypeName = "SIS.COST.costCostSheetStates"
  SortParameterName = "OrderBy"
  SelectMethod = "costCostSheetStatesSelectList"
  Runat="server" />
