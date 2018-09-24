<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakResponsibleAgencies.ascx.vb" Inherits="LC_pakResponsibleAgencies" %>
<asp:DropDownList 
  ID = "DDLpakResponsibleAgencies"
  DataSourceID = "OdsDdlpakResponsibleAgencies"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakResponsibleAgencies"
  Runat = "server" 
  ControlToValidate = "DDLpakResponsibleAgencies"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakResponsibleAgencies"
  TypeName = "SIS.PAK.pakResponsibleAgencies"
  SortParameterName = "OrderBy"
  SelectMethod = "pakResponsibleAgenciesSelectList"
  Runat="server" />
