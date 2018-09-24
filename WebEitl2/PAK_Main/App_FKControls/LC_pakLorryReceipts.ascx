<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakLorryReceipts.ascx.vb" Inherits="LC_pakLorryReceipts" %>
<asp:DropDownList 
  ID = "DDLpakLorryReceipts"
  DataSourceID = "OdsDdlpakLorryReceipts"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakLorryReceipts"
  Runat = "server" 
  ControlToValidate = "DDLpakLorryReceipts"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakLorryReceipts"
  TypeName = "SIS.PAK.pakLorryReceipts"
  SortParameterName = "OrderBy"
  SelectMethod = "pakLorryReceiptsSelectList"
  Runat="server" />
