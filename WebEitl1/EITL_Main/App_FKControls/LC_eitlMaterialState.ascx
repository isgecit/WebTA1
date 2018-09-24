<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlMaterialState.ascx.vb" Inherits="LC_eitlMaterialState" %>
<asp:DropDownList 
  ID = "DDLeitlMaterialState"
  DataSourceID = "OdsDdleitlMaterialState"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlMaterialState"
  Runat = "server" 
  ControlToValidate = "DDLeitlMaterialState"
  Text = "Material State is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlMaterialState"
  runat = "server"
  TargetControlID = "DDLeitlMaterialState"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlMaterialState"
  TypeName = "SIS.EITL.eitlMaterialState"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlMaterialStateSelectList"
  Runat="server" />
