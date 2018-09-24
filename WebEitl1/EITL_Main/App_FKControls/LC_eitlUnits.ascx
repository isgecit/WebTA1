<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlUnits.ascx.vb" Inherits="LC_eitlUnits" %>
<asp:DropDownList 
  ID = "DDLeitlUnits"
  DataSourceID = "OdsDdleitlUnits"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlUnits"
  Runat = "server" 
  ControlToValidate = "DDLeitlUnits"
  Text = "Units is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlUnits"
  runat = "server"
  TargetControlID = "DDLeitlUnits"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlUnits"
  TypeName = "SIS.EITL.eitlUnits"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlUnitsSelectList"
  Runat="server" />
