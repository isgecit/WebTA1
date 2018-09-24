<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkRECUserClaims.ascx.vb" Inherits="LC_nprkRECUserClaims" %>
<asp:DropDownList 
  ID = "DDLnprkRECUserClaims"
  DataSourceID = "OdsDdlnprkRECUserClaims"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkRECUserClaims"
  Runat = "server" 
  ControlToValidate = "DDLnprkRECUserClaims"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkRECUserClaims"
  TypeName = "SIS.NPRK.nprkRECUserClaims"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkRECUserClaimsSelectList"
  Runat="server" />
