<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSTCPOL.ascx.vb" Inherits="LC_pakSTCPOL" %>
<asp:DropDownList 
  ID = "DDLpakSTCPOL"
  DataSourceID = "OdsDdlpakSTCPOL"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSTCPOL"
  Runat = "server" 
  ControlToValidate = "DDLpakSTCPOL"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSTCPOL"
  TypeName = "SIS.PAK.pakSTCPOL"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSTCPOLSelectList"
  Runat="server" />
