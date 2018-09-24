<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costProjectTypes.ascx.vb" Inherits="LC_costProjectTypes" %>
<asp:DropDownList 
  ID = "DDLcostProjectTypes"
  DataSourceID = "OdsDdlcostProjectTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostProjectTypes"
  Runat = "server" 
  ControlToValidate = "DDLcostProjectTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostProjectTypes"
  TypeName = "SIS.COST.costProjectTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "costProjectTypesSelectList"
  Runat="server" />
