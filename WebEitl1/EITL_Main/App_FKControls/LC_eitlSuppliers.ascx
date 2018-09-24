<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlSuppliers.ascx.vb" Inherits="LC_eitlSuppliers" %>
<asp:DropDownList 
  ID = "DDLeitlSuppliers"
  DataSourceID = "OdsDdleitlSuppliers"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlSuppliers"
  Runat = "server" 
  ControlToValidate = "DDLeitlSuppliers"
  Text = "Suppliers is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlSuppliers"
  runat = "server"
  TargetControlID = "DDLeitlSuppliers"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlSuppliers"
  TypeName = "SIS.EITL.eitlSuppliers"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlSuppliersSelectList"
  Runat="server" />
