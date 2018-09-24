<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakResponsibleAgency.ascx.vb" Inherits="LC_pakResponsibleAgency" %>
<asp:DropDownList 
  ID = "DDLpakResponsibleAgency"
  DataSourceID = "OdsDdlpakResponsibleAgency"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakResponsibleAgency"
  Runat = "server" 
  ControlToValidate = "DDLpakResponsibleAgency"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakResponsibleAgency"
  TypeName = "SIS.PAK.pakResponsibleAgency"
  SortParameterName = "OrderBy"
  SelectMethod = "pakResponsibleAgencySelectList"
  Runat="server" />
