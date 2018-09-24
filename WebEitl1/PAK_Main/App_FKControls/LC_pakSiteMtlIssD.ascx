<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSiteMtlIssD.ascx.vb" Inherits="LC_pakSiteMtlIssD" %>
<asp:DropDownList 
  ID = "DDLpakSiteMtlIssD"
  DataSourceID = "OdsDdlpakSiteMtlIssD"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSiteMtlIssD"
  Runat = "server" 
  ControlToValidate = "DDLpakSiteMtlIssD"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSiteMtlIssD"
  TypeName = "SIS.PAK.pakSiteMtlIssD"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSiteMtlIssDSelectList"
  Runat="server" />
