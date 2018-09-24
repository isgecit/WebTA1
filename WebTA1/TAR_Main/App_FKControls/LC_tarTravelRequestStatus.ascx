<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tarTravelRequestStatus.ascx.vb" Inherits="LC_tarTravelRequestStatus" %>
<asp:DropDownList 
  ID = "DDLtarTravelRequestStatus"
  DataSourceID = "OdsDdltarTravelRequestStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortarTravelRequestStatus"
  Runat = "server" 
  ControlToValidate = "DDLtarTravelRequestStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltarTravelRequestStatus"
  TypeName = "SIS.TAR.tarTravelRequestStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "tarTravelRequestStatusSelectList"
  Runat="server" />
