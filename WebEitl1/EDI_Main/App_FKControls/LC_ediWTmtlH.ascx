<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_ediWTmtlH.ascx.vb" Inherits="LC_ediWTmtlH" %>
<asp:DropDownList 
  ID = "DDLediWTmtlH"
  DataSourceID = "OdsDdlediWTmtlH"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorediWTmtlH"
  Runat = "server" 
  ControlToValidate = "DDLediWTmtlH"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlediWTmtlH"
  TypeName = "SIS.EDI.ediWTmtlH"
  SortParameterName = "OrderBy"
  SelectMethod = "ediWTmtlHSelectList"
  Runat="server" />
