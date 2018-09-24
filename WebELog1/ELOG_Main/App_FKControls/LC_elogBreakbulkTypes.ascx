<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_elogBreakbulkTypes.ascx.vb" Inherits="LC_elogBreakbulkTypes" %>
<asp:DropDownList 
  ID = "DDLelogBreakbulkTypes"
  DataSourceID = "OdsDdlelogBreakbulkTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorelogBreakbulkTypes"
  Runat = "server" 
  ControlToValidate = "DDLelogBreakbulkTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlelogBreakbulkTypes"
  TypeName = "SIS.ELOG.elogBreakbulkTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "elogBreakbulkTypesSelectList"
  Runat="server" />
