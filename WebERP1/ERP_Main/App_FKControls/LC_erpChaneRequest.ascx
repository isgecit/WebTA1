<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpChaneRequest.ascx.vb" Inherits="LC_erpChaneRequest" %>
<asp:DropDownList 
  ID = "DDLerpChaneRequest"
  DataSourceID = "OdsDdlerpChaneRequest"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpChaneRequest"
  Runat = "server" 
  ControlToValidate = "DDLerpChaneRequest"
  Text = "Change Request is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpChaneRequest"
  runat = "server"
  TargetControlID = "DDLerpChaneRequest"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpChaneRequest"
  TypeName = "SIS.ERP.erpChaneRequest"
  SortParameterName = "OrderBy"
  SelectMethod = "erpChaneRequestSelectList"
  Runat="server" />
