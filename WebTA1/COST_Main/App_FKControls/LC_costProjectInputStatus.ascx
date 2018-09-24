<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costProjectInputStatus.ascx.vb" Inherits="LC_costProjectInputStatus" %>
<asp:DropDownList 
  ID = "DDLcostProjectInputStatus"
  DataSourceID = "OdsDdlcostProjectInputStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostProjectInputStatus"
  Runat = "server" 
  ControlToValidate = "DDLcostProjectInputStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostProjectInputStatus"
  TypeName = "SIS.COST.costProjectInputStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "costProjectInputStatusSelectList"
  Runat="server" />
