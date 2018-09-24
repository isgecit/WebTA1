<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taCities.ascx.vb" Inherits="LC_taCities" %>
<asp:DropDownList 
  ID = "DDLtaCities"
  DataSourceID = "OdsDdltaCities"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaCities"
  Runat = "server" 
  ControlToValidate = "DDLtaCities"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaCities"
  TypeName = "SIS.TA.taCities"
  SortParameterName = "OrderBy"
  SelectMethod = "taCitiesSelectList"
  Runat="server" />
