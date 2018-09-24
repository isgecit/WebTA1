<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_lgProjects.ascx.vb" Inherits="LC_lgProjects" %>
<asp:DropDownList 
  ID = "DDLlgProjects"
  DataSourceID = "OdsDdllgProjects"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorlgProjects"
  Runat = "server" 
  ControlToValidate = "DDLlgProjects"
  Text = "Projects is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSElgProjects"
  runat = "server"
  TargetControlID = "DDLlgProjects"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdllgProjects"
  TypeName = "SIS.LG.lgProjects"
  SortParameterName = "OrderBy"
  SelectMethod = "lgProjectsSelectList"
  Runat="server" />
