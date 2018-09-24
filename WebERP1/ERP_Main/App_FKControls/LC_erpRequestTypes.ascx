<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpRequestTypes.ascx.vb" Inherits="LC_erpRequestTypes" %>
<asp:DropDownList 
  ID = "DDLerpRequestTypes"
  DataSourceID = "OdsDdlerpRequestTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpRequestTypes"
  Runat = "server" 
  ControlToValidate = "DDLerpRequestTypes"
  Text = "Request Types is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpRequestTypes"
  runat = "server"
  TargetControlID = "DDLerpRequestTypes"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpRequestTypes"
  TypeName = "SIS.ERP.erpRequestTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "erpRequestTypesSelectList"
  Runat="server" />
