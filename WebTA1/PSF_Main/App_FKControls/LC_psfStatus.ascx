<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_psfStatus.ascx.vb" Inherits="LC_psfStatus" %>
<asp:DropDownList 
  ID = "DDLpsfStatus"
  DataSourceID = "OdsDdlpsfStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpsfStatus"
  Runat = "server" 
  ControlToValidate = "DDLpsfStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpsfStatus"
  TypeName = "SIS.PSF.psfStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "psfStatusSelectList"
  Runat="server" />
