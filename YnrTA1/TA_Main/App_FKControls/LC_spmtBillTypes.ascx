<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_spmtBillTypes.ascx.vb" Inherits="LC_spmtBillTypes" %>
<asp:DropDownList 
  ID = "DDLspmtBillTypes"
  DataSourceID = "OdsDdlspmtBillTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorspmtBillTypes"
  Runat = "server" 
  ControlToValidate = "DDLspmtBillTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlspmtBillTypes"
  TypeName = "SIS.SPMT.spmtBillTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "spmtBillTypesSelectList"
  Runat="server" />
