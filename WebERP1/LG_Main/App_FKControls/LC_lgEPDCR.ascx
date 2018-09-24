<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_lgEPDCR.ascx.vb" Inherits="LC_lgEPDCR" %>
<asp:DropDownList 
  ID = "DDLlgEPDCR"
  DataSourceID = "OdsDdllgEPDCR"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorlgEPDCR"
  Runat = "server" 
  ControlToValidate = "DDLlgEPDCR"
  Text = "EPM DCR is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSElgEPDCR"
  runat = "server"
  TargetControlID = "DDLlgEPDCR"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdllgEPDCR"
  TypeName = "SIS.LG.lgEPDCR"
  SortParameterName = "OrderBy"
  SelectMethod = "lgEPDCRSelectList"
  Runat="server" />
