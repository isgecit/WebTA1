<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taFinanceHeads.aspx.vb" Inherits="EF_taFinanceHeads" title="Edit: Finance Heads" %>
<asp:Content ID="CPHtaFinanceHeads" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaFinanceHeads" runat="server" Text="&nbsp;Edit: Finance Heads"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaFinanceHeads" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaFinanceHeads"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taFinanceHeads"
    runat = "server" />
<asp:FormView ID="FVtaFinanceHeads"
  runat = "server"
  DataKeyNames = "FinanceHeadID"
  DataSourceID = "ODStaFinanceHeads"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinanceHeadID" runat="server" ForeColor="#CC6633" Text="Finance Head :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FinanceHeadID"
            Text='<%# Bind("FinanceHeadID") %>'
            ToolTip="Value of Finance Head."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taFinanceHeads"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taFinanceHeads"
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
  ID = "ODStaFinanceHeads"
  DataObjectTypeName = "SIS.TA.taFinanceHeads"
  SelectMethod = "taFinanceHeadsGetByID"
  UpdateMethod="taFinanceHeadsUpdate"
  DeleteMethod="taFinanceHeadsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taFinanceHeads"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinanceHeadID" Name="FinanceHeadID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
