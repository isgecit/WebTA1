<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costGLGroups.ascx.vb" Inherits="LC_costGLGroups" %>
<asp:DropDownList 
  ID = "DDLcostGLGroups"
  DataSourceID = "OdsDdlcostGLGroups"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostGLGroups"
  Runat = "server" 
  ControlToValidate = "DDLcostGLGroups"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostGLGroups"
  TypeName = "SIS.COST.costGLGroups"
  SortParameterName = "OrderBy"
  SelectMethod = "costGLGroupsSelectList"
  Runat="server" />
