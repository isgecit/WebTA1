<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taExpenseHeads.ascx.vb" Inherits="LC_taExpenseHeads" %>
<asp:DropDownList 
  ID = "DDLtaExpenseHeads"
  DataSourceID = "OdsDdltaExpenseHeads"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaExpenseHeads"
  Runat = "server" 
  ControlToValidate = "DDLtaExpenseHeads"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaExpenseHeads"
  TypeName = "SIS.TA.taExpenseHeads"
  SortParameterName = "OrderBy"
  SelectMethod = "taExpenseHeadsSelectList"
  Runat="server" />
