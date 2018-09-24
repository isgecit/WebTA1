<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkPerks.ascx.vb" Inherits="LC_nprkPerks" %>
<asp:DropDownList 
  ID = "DDLnprkPerks"
  DataSourceID = "OdsDdlnprkPerks"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkPerks"
  Runat = "server" 
  ControlToValidate = "DDLnprkPerks"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkPerks"
  TypeName = "SIS.NPRK.nprkPerks"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkPerksSelectList"
  Runat="server" />
