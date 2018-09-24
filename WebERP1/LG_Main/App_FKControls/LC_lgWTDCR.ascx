<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_lgWTDCR.ascx.vb" Inherits="LC_lgWTDCR" %>
<asp:DropDownList 
  ID = "DDLlgWTDCR"
  DataSourceID = "OdsDdllgWTDCR"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorlgWTDCR"
  Runat = "server" 
  ControlToValidate = "DDLlgWTDCR"
  Text = "WT DCR is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSElgWTDCR"
  runat = "server"
  TargetControlID = "DDLlgWTDCR"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdllgWTDCR"
  TypeName = "SIS.LG.lgWTDCR"
  SortParameterName = "OrderBy"
  SelectMethod = "lgWTDCRSelectList"
  Runat="server" />
