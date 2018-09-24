<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSPO.ascx.vb" Inherits="LC_pakSPO" %>
<asp:DropDownList 
  ID = "DDLpakSPO"
  DataSourceID = "OdsDdlpakSPO"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSPO"
  Runat = "server" 
  ControlToValidate = "DDLpakSPO"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSPO"
  TypeName = "SIS.PAK.pakSPO"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSPOSelectList"
  Runat="server" />
