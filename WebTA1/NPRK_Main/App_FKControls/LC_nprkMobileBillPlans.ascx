<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_nprkMobileBillPlans.ascx.vb" Inherits="LC_nprkMobileBillPlans" %>
<asp:DropDownList 
  ID = "DDLnprkMobileBillPlans"
  DataSourceID = "OdsDdlnprkMobileBillPlans"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatornprkMobileBillPlans"
  Runat = "server" 
  ControlToValidate = "DDLnprkMobileBillPlans"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlnprkMobileBillPlans"
  TypeName = "SIS.NPRK.nprkMobileBillPlans"
  SortParameterName = "OrderBy"
  SelectMethod = "nprkMobileBillPlansSelectList"
  Runat="server" />
