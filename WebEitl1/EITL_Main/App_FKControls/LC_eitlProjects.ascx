<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlProjects.ascx.vb" Inherits="LC_eitlProjects" %>
<asp:DropDownList 
  ID = "DDLeitlProjects"
  DataSourceID = "OdsDdleitlProjects"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlProjects"
  Runat = "server" 
  ControlToValidate = "DDLeitlProjects"
  Text = "Projects is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlProjects"
  runat = "server"
  TargetControlID = "DDLeitlProjects"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlProjects"
  TypeName = "SIS.EITL.eitlProjects"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlProjectsSelectList"
  Runat="server" />
