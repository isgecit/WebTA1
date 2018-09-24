<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkMonths.ascx.vb" Inherits="LC_nprkMonths" %>
<asp:DropDownList 
  ID = "DDLnprkMonths"
  DataSourceID = "OdsDdlnprkMonths"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkMonths"
  Runat = "server" 
  ControlToValidate = "DDLnprkMonths"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkMonths"
  TypeName = "SIS.NPRK.nprkMonths"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkMonthsSelectList"
  Runat="server" />
