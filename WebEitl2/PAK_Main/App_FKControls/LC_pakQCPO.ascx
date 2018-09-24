<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakQCPO.ascx.vb" Inherits="LC_pakQCPO" %>
<asp:DropDownList 
  ID = "DDLpakQCPO"
  DataSourceID = "OdsDdlpakQCPO"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakQCPO"
  Runat = "server" 
  ControlToValidate = "DDLpakQCPO"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakQCPO"
  TypeName = "SIS.PAK.pakQCPO"
  SortParameterName = "OrderBy"
  SelectMethod = "pakQCPOSelectList"
  Runat="server" />
