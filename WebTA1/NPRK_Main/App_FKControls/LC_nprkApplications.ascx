<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkApplications.ascx.vb" Inherits="LC_nprkApplications" %>
<asp:DropDownList 
  ID = "DDLnprkApplications"
  DataSourceID = "OdsDdlnprkApplications"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkApplications"
  Runat = "server" 
  ControlToValidate = "DDLnprkApplications"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkApplications"
  TypeName = "SIS.NPRK.nprkApplications"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkApplicationsSelectList"
  Runat="server" />
