<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taCurrencies.aspx.vb" Inherits="EF_taCurrencies" title="Edit: Currencies" %>
<asp:Content ID="CPHtaCurrencies" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCurrencies" runat="server" Text="&nbsp;Edit: Currencies"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCurrencies" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCurrencies"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taCurrencies"
    runat = "server" />
<asp:FormView ID="FVtaCurrencies"
  runat = "server"
  DataKeyNames = "CurrencyID"
  DataSourceID = "ODStaCurrencies"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CurrencyID" runat="server" ForeColor="#CC6633" Text="Currency ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CurrencyID"
            Text='<%# Bind("CurrencyID") %>'
            ToolTip="Value of Currency ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="42px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyName" runat="server" Text="Currency Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CurrencyName"
            Text='<%# Bind("CurrencyName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCurrencies"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Currency Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCurrencyName"
            runat = "server"
            ControlToValidate = "F_CurrencyName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCurrencies"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCurrencies"
  DataObjectTypeName = "SIS.TA.taCurrencies"
  SelectMethod = "taCurrenciesGetByID"
  UpdateMethod="taCurrenciesUpdate"
  DeleteMethod="taCurrenciesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCurrencies"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CurrencyID" Name="CurrencyID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
