<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_qcmSRequests.ascx.vb" Inherits="LC_qcmSRequests" %>
<asp:DropDownList 
  ID = "DDLqcmRequests"
  DataSourceID = "OdsDdlqcmRequests"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorqcmRequests"
  Runat = "server" 
  ControlToValidate = "DDLqcmRequests"
  Text = "<div class='errorLG'>Required!</div>"
  ErrorMessage = "*"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlqcmRequests"
  TypeName = "SIS.QCM.qcmRequests"
  SortParameterName = "SupplierID"
  SelectMethod = "qcmSRequestsToBeAttended"
  Runat="server" />
