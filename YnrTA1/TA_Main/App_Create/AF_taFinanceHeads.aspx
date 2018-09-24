<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taFinanceHeads.aspx.vb" Inherits="AF_taFinanceHeads" title="Add: Finance Heads" %>
<asp:Content ID="CPHtaFinanceHeads" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaFinanceHeads" runat="server" Text="&nbsp;Add: Finance Heads"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaFinanceHeads" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaFinanceHeads"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taFinanceHeads"
    runat = "server" />
<asp:FormView ID="FVtaFinanceHeads"
  runat = "server"
  DataKeyNames = "FinanceHeadID"
  DataSourceID = "ODStaFinanceHeads"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaFinanceHeads" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinanceHeadID" ForeColor="#CC6633" runat="server" Text="Finance Head :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FinanceHeadID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taFinanceHeads"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaFinanceHeads"
  DataObjectTypeName = "SIS.TA.taFinanceHeads"
  InsertMethod="taFinanceHeadsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taFinanceHeads"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
