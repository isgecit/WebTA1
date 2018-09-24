<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkClaimStatus.ascx.vb" Inherits="LC_nprkClaimStatus" %>
<asp:DropDownList 
  ID = "DDLnprkClaimStatus"
  DataSourceID = "OdsDdlnprkClaimStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkClaimStatus"
  Runat = "server" 
  ControlToValidate = "DDLnprkClaimStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkClaimStatus"
  TypeName = "SIS.NPRK.nprkClaimStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkClaimStatusSelectList"
  Runat="server" />
