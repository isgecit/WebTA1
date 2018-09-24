<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSiteLocationTypes.ascx.vb" Inherits="LC_pakSiteLocationTypes" %>
<asp:DropDownList 
  ID = "DDLpakSiteLocationTypes"
  DataSourceID = "OdsDdlpakSiteLocationTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSiteLocationTypes"
  Runat = "server" 
  ControlToValidate = "DDLpakSiteLocationTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSiteLocationTypes"
  TypeName = "SIS.PAK.pakSiteLocationTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSiteLocationTypesSelectList"
  Runat="server" />
