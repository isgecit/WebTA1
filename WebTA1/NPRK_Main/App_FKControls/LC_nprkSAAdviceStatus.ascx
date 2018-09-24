<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkSAAdviceStatus.ascx.vb" Inherits="LC_nprkSAAdviceStatus" %>
<asp:DropDownList 
  ID = "DDLnprkSAAdviceStatus"
  DataSourceID = "OdsDdlnprkSAAdviceStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkSAAdviceStatus"
  Runat = "server" 
  ControlToValidate = "DDLnprkSAAdviceStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkSAAdviceStatus"
  TypeName = "SIS.NPRK.nprkSAAdviceStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkSAAdviceStatusSelectList"
  Runat="server" />
