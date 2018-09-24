<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_costProjectInputFiles.ascx.vb" Inherits="LC_costProjectInputFiles" %>
<asp:DropDownList 
  ID = "DDLcostProjectInputFiles"
  DataSourceID = "OdsDdlcostProjectInputFiles"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorcostProjectInputFiles"
  Runat = "server" 
  ControlToValidate = "DDLcostProjectInputFiles"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlcostProjectInputFiles"
  TypeName = "SIS.COST.costProjectInputFiles"
  SortParameterName = "OrderBy"
  SelectMethod = "costProjectInputFilesSelectList"
  Runat="server" />
