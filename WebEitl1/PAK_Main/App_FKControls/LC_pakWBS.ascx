<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakWBS.ascx.vb" Inherits="LC_pakWBS" %>
<asp:DropDownList 
  ID = "DDLpakWBS"
  DataSourceID = "OdsDdlpakWBS"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakWBS"
  Runat = "server" 
  ControlToValidate = "DDLpakWBS"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakWBS"
  TypeName = "SIS.PAK.pakWBS"
  SortParameterName = "OrderBy"
  SelectMethod = "pakWBSSelectList"
  Runat="server" />
