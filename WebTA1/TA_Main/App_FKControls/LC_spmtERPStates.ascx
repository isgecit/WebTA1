<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_spmtERPStates.ascx.vb" Inherits="LC_spmtERPStates" %>
<asp:DropDownList 
  ID = "DDLspmtERPStates"
  DataSourceID = "OdsDdlspmtERPStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorspmtERPStates"
  Runat = "server" 
  ControlToValidate = "DDLspmtERPStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlspmtERPStates"
  TypeName = "SIS.SPMT.spmtERPStates"
  SortParameterName = "OrderBy"
  SelectMethod = "spmtERPStatesSelectList"
  Runat="server" />
