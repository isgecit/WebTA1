<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpTPTBillReasons.ascx.vb" Inherits="LC_erpTPTBillReasons" %>
<asp:DropDownList 
  ID = "DDLerpTPTBillReasons"
  DataSourceID = "OdsDdlerpTPTBillReasons"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpTPTBillReasons"
  Runat = "server" 
  ControlToValidate = "DDLerpTPTBillReasons"
  Text = ""
  ErrorMessage = ""
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlerpTPTBillReasons"
  TypeName = "SIS.ERP.erpTPTBillReasons"
  SortParameterName = "OrderBy"
  SelectMethod = "erpTPTBillReasonsSelectList"
  Runat="server" />
