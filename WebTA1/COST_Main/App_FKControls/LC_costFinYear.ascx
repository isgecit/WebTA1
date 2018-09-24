<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costFinYear.ascx.vb" Inherits="LC_costFinYear" %>
<asp:DropDownList 
  ID = "DDLcostFinYear"
  DataSourceID = "OdsDdlcostFinYear"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostFinYear"
  Runat = "server" 
  ControlToValidate = "DDLcostFinYear"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostFinYear"
  TypeName = "SIS.COST.costFinYear"
  SortParameterName = "OrderBy"
  SelectMethod = "costFinYearSelectList"
  Runat="server" />
