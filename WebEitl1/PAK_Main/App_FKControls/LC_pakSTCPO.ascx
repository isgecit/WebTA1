<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSTCPO.ascx.vb" Inherits="LC_pakSTCPO" %>
<asp:DropDownList 
  ID = "DDLpakSTCPO"
  DataSourceID = "OdsDdlpakSTCPO"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSTCPO"
  Runat = "server" 
  ControlToValidate = "DDLpakSTCPO"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSTCPO"
  TypeName = "SIS.PAK.pakSTCPO"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSTCPOSelectList"
  Runat="server" />
