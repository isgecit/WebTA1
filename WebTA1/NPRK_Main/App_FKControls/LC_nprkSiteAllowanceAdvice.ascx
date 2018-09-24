<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkSiteAllowanceAdvice.ascx.vb" Inherits="LC_nprkSiteAllowanceAdvice" %>
<asp:DropDownList 
  ID = "DDLnprkSiteAllowanceAdvice"
  DataSourceID = "OdsDdlnprkSiteAllowanceAdvice"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkSiteAllowanceAdvice"
  Runat = "server" 
  ControlToValidate = "DDLnprkSiteAllowanceAdvice"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkSiteAllowanceAdvice"
  TypeName = "SIS.NPRK.nprkSiteAllowanceAdvice"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkSiteAllowanceAdviceSelectList"
  Runat="server" />
