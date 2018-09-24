<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taTravelModes.ascx.vb" Inherits="LC_taTravelModes" %>
<asp:DropDownList 
  ID = "DDLtaTravelModes"
  DataSourceID = "OdsDdltaTravelModes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaTravelModes"
  Runat = "server" 
  ControlToValidate = "DDLtaTravelModes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaTravelModes"
  TypeName = "SIS.TA.taTravelModes"
  SortParameterName = "OrderBy"
  SelectMethod = "taTravelModesSelectList"
  Runat="server" />
