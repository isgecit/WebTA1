<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_spmtIsgecGSTIN.ascx.vb" Inherits="LC_spmtIsgecGSTIN" %>
<asp:DropDownList 
  ID = "DDLspmtIsgecGSTIN"
  DataSourceID = "OdsDdlspmtIsgecGSTIN"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorspmtIsgecGSTIN"
  Runat = "server" 
  ControlToValidate = "DDLspmtIsgecGSTIN"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlspmtIsgecGSTIN"
  TypeName = "SIS.SPMT.spmtIsgecGSTIN"
  SortParameterName = "OrderBy"
  SelectMethod = "spmtIsgecGSTINSelectList"
  Runat="server" />
