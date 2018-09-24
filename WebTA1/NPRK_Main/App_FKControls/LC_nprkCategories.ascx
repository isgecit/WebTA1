<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkCategories.ascx.vb" Inherits="LC_nprkCategories" %>
<asp:DropDownList 
  ID = "DDLnprkCategories"
  DataSourceID = "OdsDdlnprkCategories"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkCategories"
  Runat = "server" 
  ControlToValidate = "DDLnprkCategories"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkCategories"
  TypeName = "SIS.NPRK.nprkCategories"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkCategoriesSelectList"
  Runat="server" />
