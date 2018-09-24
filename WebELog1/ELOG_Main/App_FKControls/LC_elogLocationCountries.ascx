<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogLocationCountries.ascx.vb" Inherits="LC_elogLocationCountries" %>
<asp:DropDownList 
  ID = "DDLelogLocationCountries"
  DataSourceID = "OdsDdlelogLocationCountries"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogLocationCountries"
  Runat = "server" 
  ControlToValidate = "DDLelogLocationCountries"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogLocationCountries"
  TypeName = "SIS.ELOG.elogLocationCountries"
  SortParameterName = "OrderBy"
  SelectMethod = "elogLocationCountriesSelectList"
  Runat="server" />
