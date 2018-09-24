<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSTCPOLR.ascx.vb" Inherits="LC_pakSTCPOLR" %>
<asp:DropDownList 
  ID = "DDLpakSTCPOLR"
  DataSourceID = "OdsDdlpakSTCPOLR"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSTCPOLR"
  Runat = "server" 
  ControlToValidate = "DDLpakSTCPOLR"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSTCPOLR"
  TypeName = "SIS.PAK.pakSTCPOLR"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSTCPOLRSelectList"
  Runat="server" />
