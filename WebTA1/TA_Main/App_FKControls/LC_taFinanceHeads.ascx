<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taFinanceHeads.ascx.vb" Inherits="LC_taFinanceHeads" %>
<asp:DropDownList 
  ID = "DDLtaFinanceHeads"
  DataSourceID = "OdsDdltaFinanceHeads"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaFinanceHeads"
  Runat = "server" 
  ControlToValidate = "DDLtaFinanceHeads"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaFinanceHeads"
  TypeName = "SIS.TA.taFinanceHeads"
  SortParameterName = "OrderBy"
  SelectMethod = "taFinanceHeadsSelectList"
  Runat="server" />
