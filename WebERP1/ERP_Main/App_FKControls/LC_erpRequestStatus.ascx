<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_erpRequestStatus.ascx.vb" Inherits="LC_erpRequestStatus" %>
<asp:DropDownList 
  ID = "DDLerpRequestStatus"
  DataSourceID = "OdsDdlerpRequestStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorerpRequestStatus"
  Runat = "server" 
  ControlToValidate = "DDLerpRequestStatus"
  Text = "Request Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEerpRequestStatus"
  runat = "server"
  TargetControlID = "DDLerpRequestStatus"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlerpRequestStatus"
  TypeName = "SIS.ERP.erpRequestStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "erpRequestStatusSelectList"
  Runat="server" />
