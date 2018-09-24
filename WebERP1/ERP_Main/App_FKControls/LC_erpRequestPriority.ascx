<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpRequestPriority.ascx.vb" Inherits="LC_erpRequestPriority" %>
<asp:DropDownList 
  ID = "DDLerpRequestPriority"
  DataSourceID = "OdsDdlerpRequestPriority"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpRequestPriority"
  Runat = "server" 
  ControlToValidate = "DDLerpRequestPriority"
  Text = "Request Priority is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpRequestPriority"
  runat = "server"
  TargetControlID = "DDLerpRequestPriority"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpRequestPriority"
  TypeName = "SIS.ERP.erpRequestPriority"
  SortParameterName = "OrderBy"
  SelectMethod = "erpRequestPrioritySelectList"
  Runat="server" />
