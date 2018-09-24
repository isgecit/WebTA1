<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taCalcMethod.ascx.vb" Inherits="LC_taCalcMethod" %>
<asp:DropDownList 
  ID = "DDLtaCalcMethod"
  DataSourceID = "OdsDdltaCalcMethod"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaCalcMethod"
  Runat = "server" 
  ControlToValidate = "DDLtaCalcMethod"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaCalcMethod"
  TypeName = "SIS.TA.taCalcMethod"
  SortParameterName = "OrderBy"
  SelectMethod = "taCalcMethodSelectList"
  Runat="server" />
