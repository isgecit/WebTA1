<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taTravelTypes.ascx.vb" Inherits="LC_taTravelTypes" %>
<script type="text/javascript">
  function tt_changed(o) {
    try {
    if (o.value == '1') {
      opt1.style.display = '';
      opt2.style.display = '';
      opt3.style.display = 'none';
      opt4.style.display = '';
    } else {
      opt1.style.display = 'none';
      opt2.style.display = 'none';
      opt3.style.display = '';
      opt4.style.display = 'none';
    }
    } catch (e) { }
    return false;
  }
</script>
<asp:DropDownList 
  ID = "DDLtaTravelTypes"
  DataSourceID = "OdsDdltaTravelTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  onchange="tt_changed(this);"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaTravelTypes"
  Runat = "server" 
  ControlToValidate = "DDLtaTravelTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaTravelTypes"
  TypeName = "SIS.TA.taTravelTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "taTravelTypesSelectList"
  Runat="server" />
