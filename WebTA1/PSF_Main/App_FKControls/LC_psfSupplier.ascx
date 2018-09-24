<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_psfSupplier.ascx.vb" Inherits="LC_psfSupplier" %>
<asp:DropDownList 
  ID = "DDLpsfSupplier"
  DataSourceID = "OdsDdlpsfSupplier"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpsfSupplier"
  Runat = "server" 
  ControlToValidate = "DDLpsfSupplier"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpsfSupplier"
  TypeName = "SIS.PSF.psfSupplier"
  SortParameterName = "OrderBy"
  SelectMethod = "psfSupplierSelectList"
  Runat="server" />
