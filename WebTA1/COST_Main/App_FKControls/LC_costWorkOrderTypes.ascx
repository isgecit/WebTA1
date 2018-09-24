<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costWorkOrderTypes.ascx.vb" Inherits="LC_costWorkOrderTypes" %>
<asp:DropDownList 
  ID = "DDLcostWorkOrderTypes"
  DataSourceID = "OdsDdlcostWorkOrderTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostWorkOrderTypes"
  Runat = "server" 
  ControlToValidate = "DDLcostWorkOrderTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostWorkOrderTypes"
  TypeName = "SIS.COST.costWorkOrderTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "costWorkOrderTypesSelectList"
  Runat="server" />
