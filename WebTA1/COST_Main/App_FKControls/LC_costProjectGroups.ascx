<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costProjectGroups.ascx.vb" Inherits="LC_costProjectGroups" %>
<asp:DropDownList 
  ID = "DDLcostProjectGroups"
  DataSourceID = "OdsDdlcostProjectGroups"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostProjectGroups"
  Runat = "server" 
  ControlToValidate = "DDLcostProjectGroups"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostProjectGroups"
  TypeName = "SIS.COST.costProjectGroups"
  SortParameterName = "OrderBy"
  SelectMethod = "costProjectGroupsSelectList"
  Runat="server" />
