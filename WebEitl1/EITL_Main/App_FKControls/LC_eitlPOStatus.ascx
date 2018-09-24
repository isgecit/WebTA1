<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlPOStatus.ascx.vb" Inherits="LC_eitlPOStatus" %>
<asp:DropDownList 
  ID = "DDLeitlPOStatus"
  DataSourceID = "OdsDdleitlPOStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlPOStatus"
  Runat = "server" 
  ControlToValidate = "DDLeitlPOStatus"
  Text = "PO Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlPOStatus"
  runat = "server"
  TargetControlID = "DDLeitlPOStatus"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlPOStatus"
  TypeName = "SIS.EITL.eitlPOStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlPOStatusSelectList"
  Runat="server" />
