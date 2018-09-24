<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taCityTypes.ascx.vb" Inherits="LC_taCityTypes" %>
<asp:DropDownList 
  ID = "DDLtaCityTypes"
  DataSourceID = "OdsDdltaCityTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaCityTypes"
  Runat = "server" 
  ControlToValidate = "DDLtaCityTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaCityTypes"
  TypeName = "SIS.TA.taCityTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "taCityTypesSelectList"
  Runat="server" />
