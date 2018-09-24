<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costProjectsInput.ascx.vb" Inherits="LC_costProjectsInput" %>
<asp:DropDownList 
  ID = "DDLcostProjectsInput"
  DataSourceID = "OdsDdlcostProjectsInput"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostProjectsInput"
  Runat = "server" 
  ControlToValidate = "DDLcostProjectsInput"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostProjectsInput"
  TypeName = "SIS.COST.costProjectsInput"
  SortParameterName = "OrderBy"
  SelectMethod = "costProjectsInputSelectList"
  Runat="server" />
