<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogChargeCategories.ascx.vb" Inherits="LC_elogChargeCategories" %>
<asp:DropDownList 
  ID = "DDLelogChargeCategories"
  DataSourceID = "OdsDdlelogChargeCategories"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogChargeCategories"
  Runat = "server" 
  ControlToValidate = "DDLelogChargeCategories"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogChargeCategories"
  TypeName = "SIS.ELOG.elogChargeCategories"
  SortParameterName = "OrderBy"
  SelectMethod = "elogChargeCategoriesSelectList"
  Runat="server" />
