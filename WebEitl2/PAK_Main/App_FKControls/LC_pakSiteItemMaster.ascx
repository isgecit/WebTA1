<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_pakSiteItemMaster.ascx.vb" Inherits="LC_pakSiteItemMaster" %>
<asp:DropDownList 
  ID = "DDLpakSiteItemMaster"
  DataSourceID = "OdsDdlpakSiteItemMaster"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpakSiteItemMaster"
  Runat = "server" 
  ControlToValidate = "DDLpakSiteItemMaster"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpakSiteItemMaster"
  TypeName = "SIS.PAK.pakSiteItemMaster"
  SortParameterName = "OrderBy"
  SelectMethod = "pakSiteItemMasterSelectList"
  Runat="server" />
