<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costCostSheet.ascx.vb" Inherits="LC_costCostSheet" %>
<asp:DropDownList 
  ID = "DDLcostCostSheet"
  DataSourceID = "OdsDdlcostCostSheet"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostCostSheet"
  Runat = "server" 
  ControlToValidate = "DDLcostCostSheet"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostCostSheet"
  TypeName = "SIS.COST.costCostSheet"
  SortParameterName = "OrderBy"
  SelectMethod = "costCostSheetSelectList"
  Runat="server" />
