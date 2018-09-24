<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taRegions.ascx.vb" Inherits="LC_taRegions" %>
<asp:DropDownList 
  ID = "DDLtaRegions"
  DataSourceID = "OdsDdltaRegions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaRegions"
  Runat = "server" 
  ControlToValidate = "DDLtaRegions"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaRegions"
  TypeName = "SIS.TA.taRegions"
  SortParameterName = "OrderBy"
  SelectMethod = "taRegionsSelectList"
  Runat="server" />
