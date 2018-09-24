<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taApprovalWFTypes.ascx.vb" Inherits="LC_taApprovalWFTypes" %>
<asp:DropDownList 
  ID = "DDLtaApprovalWFTypes"
  DataSourceID = "OdsDdltaApprovalWFTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaApprovalWFTypes"
  Runat = "server" 
  ControlToValidate = "DDLtaApprovalWFTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaApprovalWFTypes"
  TypeName = "SIS.TA.taApprovalWFTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "taApprovalWFTypesSelectList"
  Runat="server" />
