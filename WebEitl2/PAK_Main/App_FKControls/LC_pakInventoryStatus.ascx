<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakInventoryStatus.ascx.vb" Inherits="LC_pakInventoryStatus" %>
<asp:DropDownList 
  ID = "DDLpakInventoryStatus"
  DataSourceID = "OdsDdlpakInventoryStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakInventoryStatus"
  Runat = "server" 
  ControlToValidate = "DDLpakInventoryStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakInventoryStatus"
  TypeName = "SIS.PAK.pakInventoryStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "pakInventoryStatusSelectList"
  Runat="server" />
