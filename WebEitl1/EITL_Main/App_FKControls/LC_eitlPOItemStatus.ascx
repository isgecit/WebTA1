<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlPOItemStatus.ascx.vb" Inherits="LC_eitlPOItemStatus" %>
<asp:DropDownList 
  ID = "DDLeitlPOItemStatus"
  DataSourceID = "OdsDdleitlPOItemStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlPOItemStatus"
  Runat = "server" 
  ControlToValidate = "DDLeitlPOItemStatus"
  Text = "PO Item Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlPOItemStatus"
  runat = "server"
  TargetControlID = "DDLeitlPOItemStatus"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlPOItemStatus"
  TypeName = "SIS.EITL.eitlPOItemStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlPOItemStatusSelectList"
  Runat="server" />
