<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_hrmLocations.ascx.vb" Inherits="LC_hrmLocations" %>
<asp:DropDownList 
  ID = "DDLhrmLocations"
  DataSourceID = "OdsDdlhrmLocations"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorhrmLocations"
  Runat = "server" 
  ControlToValidate = "DDLhrmLocations"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlhrmLocations"
  TypeName = "SIS.HRM.hrmLocations"
  SortParameterName = "OrderBy"
  SelectMethod = "hrmLocationsSelectList"
  Runat="server" />
