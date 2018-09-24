<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costERPGLCodes.ascx.vb" Inherits="LC_costERPGLCodes" %>
<asp:DropDownList 
  ID = "DDLcostERPGLCodes"
  DataSourceID = "OdsDdlcostERPGLCodes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostERPGLCodes"
  Runat = "server" 
  ControlToValidate = "DDLcostERPGLCodes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostERPGLCodes"
  TypeName = "SIS.COST.costERPGLCodes"
  SortParameterName = "OrderBy"
  SelectMethod = "costERPGLCodesSelectList"
  Runat="server" />
