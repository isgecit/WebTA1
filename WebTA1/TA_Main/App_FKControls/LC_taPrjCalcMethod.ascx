<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taPrjCalcMethod.ascx.vb" Inherits="LC_taPrjCalcMethod" %>
<asp:DropDownList 
  ID = "DDLtaPrjCalcMethod"
  DataSourceID = "OdsDdltaPrjCalcMethod"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaPrjCalcMethod"
  Runat = "server" 
  ControlToValidate = "DDLtaPrjCalcMethod"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaPrjCalcMethod"
  TypeName = "SIS.TA.taPrjCalcMethod"
  SortParameterName = "OrderBy"
  SelectMethod = "taPrjCalcMethodSelectList"
  Runat="server" />
