<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costvGLGroups.ascx.vb" Inherits="LC_costvGLGroups" %>
<asp:DropDownList 
  ID = "DDLcostvGLGroups"
  DataSourceID = "OdsDdlcostvGLGroups"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostvGLGroups"
  Runat = "server" 
  ControlToValidate = "DDLcostvGLGroups"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostvGLGroups"
  TypeName = "SIS.COST.costvGLGroups"
  SortParameterName = "OrderBy"
  SelectMethod = "costvGLGroupsSelectList"
  Runat="server" />
