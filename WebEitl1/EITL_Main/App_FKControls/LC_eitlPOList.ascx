<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_eitlPOList.ascx.vb" Inherits="LC_eitlPOList" %>
<asp:DropDownList 
  ID = "DDLeitlPOList"
  DataSourceID = "OdsDdleitlPOList"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoreitlPOList"
  Runat = "server" 
  ControlToValidate = "DDLeitlPOList"
  Text = "PO List is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEeitlPOList"
  runat = "server"
  TargetControlID = "DDLeitlPOList"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdleitlPOList"
  TypeName = "SIS.EITL.eitlPOList"
  SortParameterName = "OrderBy"
  SelectMethod = "eitlPOListSelectList"
  Runat="server" />
