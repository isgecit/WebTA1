<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkStatus.ascx.vb" Inherits="LC_nprkStatus" %>
<asp:DropDownList 
  ID = "DDLnprkStatus"
  DataSourceID = "OdsDdlnprkStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkStatus"
  Runat = "server" 
  ControlToValidate = "DDLnprkStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkStatus"
  TypeName = "SIS.NPRK.nprkStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkStatusSelectList"
  Runat="server" />
