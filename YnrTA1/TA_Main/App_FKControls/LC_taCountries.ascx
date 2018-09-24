<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taCountries.ascx.vb" Inherits="LC_taCountries" %>
<asp:DropDownList 
  ID = "DDLtaCountries"
  DataSourceID = "OdsDdltaCountries"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaCountries"
  Runat = "server" 
  ControlToValidate = "DDLtaCountries"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaCountries"
  TypeName = "SIS.TA.taCountries"
  SortParameterName = "OrderBy"
  SelectMethod = "taCountriesSelectList"
  Runat="server" />
