<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSiteLocations.ascx.vb" Inherits="LC_pakSiteLocations" %>
<asp:DropDownList 
  ID = "DDLpakSiteLocations"
  DataSourceID = "OdsDdlpakSiteLocations"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSiteLocations"
  Runat = "server" 
  ControlToValidate = "DDLpakSiteLocations"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSiteLocations"
  TypeName = "SIS.PAK.pakSiteLocations"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSiteLocationsSelectList"
  Runat="server" />
