<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taOOEReasons.ascx.vb" Inherits="LC_taOOEReasons" %>
<asp:DropDownList 
  ID = "DDLtaOOEReasons"
  DataSourceID = "OdsDdltaOOEReasons"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaOOEReasons"
  Runat = "server" 
  ControlToValidate = "DDLtaOOEReasons"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaOOEReasons"
  TypeName = "SIS.TA.taOOEReasons"
  SortParameterName = "OrderBy"
  SelectMethod = "taOOEReasonsSelectList"
  Runat="server" />
