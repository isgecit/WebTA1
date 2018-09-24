<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_taCurrencies.ascx.vb" Inherits="LC_taCurrencies" %>
<script type="text/javascript">
  function change_cf(o) {
    var all = document.getElementsByTagName('input');
    for (var i = 0, max = all.length; i < max; i++) {
      if (all[i].id.toLowerCase().indexOf('conversionfactor') !== -1) {
        if (o.value == 'INR') {
          all[i].className = 'dmytxt';
          all[i].value = '1.000000';
          all[i].disabled = true;
        } else {
          all[i].className = 'mytxt';
          all[i].value = '0.000000';
          all[i].disabled = false;
        }
      }
    }
  }
</script>
<asp:DropDownList 
  ID = "DDLtaCurrencies"
  DataSourceID = "OdsDdltaCurrencies"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  onchange="change_cf(this);"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortaCurrencies"
  Runat = "server" 
  ControlToValidate = "DDLtaCurrencies"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltaCurrencies"
  TypeName = "SIS.TA.taCurrencies"
  SortParameterName = "OrderBy"
  SelectMethod = "taCurrenciesSelectList"
  Runat="server" />
