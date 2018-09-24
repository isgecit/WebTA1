<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakUnits.ascx.vb" Inherits="LC_pakUnits" %>
<asp:DropDownList 
  ID = "DDLpakUnits"
  DataSourceID = "OdsDdlpakUnits"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakUnits"
  Runat = "server" 
  ControlToValidate = "DDLpakUnits"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakUnits"
  TypeName = "SIS.PAK.pakUnits"
  SortParameterName = "OrderBy"
  SelectMethod = "pakUnitsSelectList"
  Runat="server" />
