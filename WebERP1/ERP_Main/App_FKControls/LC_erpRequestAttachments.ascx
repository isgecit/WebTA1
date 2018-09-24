<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpRequestAttachments.ascx.vb" Inherits="LC_erpRequestAttachments" %>
<asp:DropDownList 
  ID = "DDLerpRequestAttachments"
  DataSourceID = "OdsDdlerpRequestAttachments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpRequestAttachments"
  Runat = "server" 
  ControlToValidate = "DDLerpRequestAttachments"
  Text = "Attachments is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpRequestAttachments"
  runat = "server"
  TargetControlID = "DDLerpRequestAttachments"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpRequestAttachments"
  TypeName = "SIS.ERP.erpRequestAttachments"
  SortParameterName = "OrderBy"
  SelectMethod = "erpRequestAttachmentsSelectList"
  Runat="server" />
