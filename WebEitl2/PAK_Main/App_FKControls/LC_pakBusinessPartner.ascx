<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakBusinessPartner.ascx.vb" Inherits="LC_pakBusinessPartner" %>
<asp:DropDownList 
  ID = "DDLpakBusinessPartner"
  DataSourceID = "OdsDdlpakBusinessPartner"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakBusinessPartner"
  Runat = "server" 
  ControlToValidate = "DDLpakBusinessPartner"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakBusinessPartner"
  TypeName = "SIS.PAK.pakBusinessPartner"
  SortParameterName = "OrderBy"
  SelectMethod = "pakBusinessPartnerSelectList"
  Runat="server" />
