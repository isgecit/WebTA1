<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakIQCListH.ascx.vb" Inherits="LC_pakIQCListH" %>
<asp:DropDownList 
  ID = "DDLpakIQCListH"
  DataSourceID = "OdsDdlpakIQCListH"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakIQCListH"
  Runat = "server" 
  ControlToValidate = "DDLpakIQCListH"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakIQCListH"
  TypeName = "SIS.PAK.pakIQCListH"
  SortParameterName = "OrderBy"
  SelectMethod = "pakIQCListHSelectList"
  Runat="server" />
