<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkFinYears.ascx.vb" Inherits="LC_nprkFinYears" %>
<asp:DropDownList 
  ID = "DDLnprkFinYears"
  DataSourceID = "OdsDdlnprkFinYears"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkFinYears"
  Runat = "server" 
  ControlToValidate = "DDLnprkFinYears"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkFinYears"
  TypeName = "SIS.NPRK.nprkFinYears"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkFinYearsSelectList"
  Runat="server" />
