<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costGLNatures.ascx.vb" Inherits="LC_costGLNatures" %>
<asp:DropDownList 
  ID = "DDLcostGLNatures"
  DataSourceID = "OdsDdlcostGLNatures"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostGLNatures"
  Runat = "server" 
  ControlToValidate = "DDLcostGLNatures"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostGLNatures"
  TypeName = "SIS.COST.costGLNatures"
  SortParameterName = "OrderBy"
  SelectMethod = "costGLNaturesSelectList"
  Runat="server" />
