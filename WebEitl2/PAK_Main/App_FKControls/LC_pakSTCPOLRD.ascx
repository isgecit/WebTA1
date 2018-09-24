<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSTCPOLRD.ascx.vb" Inherits="LC_pakSTCPOLRD" %>
<asp:DropDownList 
  ID = "DDLpakSTCPOLRD"
  DataSourceID = "OdsDdlpakSTCPOLRD"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSTCPOLRD"
  Runat = "server" 
  ControlToValidate = "DDLpakSTCPOLRD"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSTCPOLRD"
  TypeName = "SIS.PAK.pakSTCPOLRD"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSTCPOLRDSelectList"
  Runat="server" />
