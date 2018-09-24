<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taWebUsers.ascx.vb" Inherits="LC_taWebUsers" %>
<asp:DropDownList 
  ID = "DDLtaWebUsers"
  DataSourceID = "OdsDdltaWebUsers"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaWebUsers"
  Runat = "server" 
  ControlToValidate = "DDLtaWebUsers"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaWebUsers"
  TypeName = "SIS.TA.taWebUsers"
  SortParameterName = "OrderBy"
  SelectMethod = "taWebUsersSelectList"
  Runat="server" />
