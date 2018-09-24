<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taRegionTypes.ascx.vb" Inherits="LC_taRegionTypes" %>
<asp:DropDownList 
  ID = "DDLtaRegionTypes"
  DataSourceID = "OdsDdltaRegionTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaRegionTypes"
  Runat = "server" 
  ControlToValidate = "DDLtaRegionTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaRegionTypes"
  TypeName = "SIS.TA.taRegionTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "taRegionTypesSelectList"
  Runat="server" />
