<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costProjects.ascx.vb" Inherits="LC_costProjects" %>
<asp:DropDownList 
  ID = "DDLcostProjects"
  DataSourceID = "OdsDdlcostProjects"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostProjects"
  Runat = "server" 
  ControlToValidate = "DDLcostProjects"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostProjects"
  TypeName = "SIS.COST.costProjects"
  SortParameterName = "OrderBy"
  SelectMethod = "costProjectsSelectList"
  Runat="server" />
