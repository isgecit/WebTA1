<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkUserClaims.ascx.vb" Inherits="LC_nprkUserClaims" %>
<asp:DropDownList 
  ID = "DDLnprkUserClaims"
  DataSourceID = "OdsDdlnprkUserClaims"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkUserClaims"
  Runat = "server" 
  ControlToValidate = "DDLnprkUserClaims"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkUserClaims"
  TypeName = "SIS.NPRK.nprkUserClaims"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkUserClaimsSelectList"
  Runat="server" />
