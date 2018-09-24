<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costQuarters.ascx.vb" Inherits="LC_costQuarters" %>
<asp:DropDownList 
  ID = "DDLcostQuarters"
  DataSourceID = "OdsDdlcostQuarters"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostQuarters"
  Runat = "server" 
  ControlToValidate = "DDLcostQuarters"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostQuarters"
  TypeName = "SIS.COST.costQuarters"
  SortParameterName = "OrderBy"
  SelectMethod = "costQuartersSelectList"
  Runat="server" />
