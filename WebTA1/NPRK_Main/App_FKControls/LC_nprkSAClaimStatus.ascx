<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkSAClaimStatus.ascx.vb" Inherits="LC_nprkSAClaimStatus" %>
<asp:DropDownList 
  ID = "DDLnprkSAClaimStatus"
  DataSourceID = "OdsDdlnprkSAClaimStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkSAClaimStatus"
  Runat = "server" 
  ControlToValidate = "DDLnprkSAClaimStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkSAClaimStatus"
  TypeName = "SIS.NPRK.nprkSAClaimStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkSAClaimStatusSelectList"
  Runat="server" />
