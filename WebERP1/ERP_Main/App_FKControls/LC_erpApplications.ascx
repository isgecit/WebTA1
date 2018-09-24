<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpApplications.ascx.vb" Inherits="LC_erpApplications" %>
<asp:DropDownList 
  ID = "DDLerpApplications"
  DataSourceID = "OdsDdlerpApplications"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpApplications"
  Runat = "server" 
  ControlToValidate = "DDLerpApplications"
  Text = "Applications is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpApplications"
  runat = "server"
  TargetControlID = "DDLerpApplications"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpApplications"
  TypeName = "SIS.ERP.erpApplications"
  SortParameterName = "OrderBy"
  SelectMethod = "erpApplicationsSelectList"
  Runat="server" />
