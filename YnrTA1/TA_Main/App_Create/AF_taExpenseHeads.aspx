<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taExpenseHeads.aspx.vb" Inherits="AF_taExpenseHeads" title="Add: Expense Heads" %>
<asp:Content ID="CPHtaExpenseHeads" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaExpenseHeads" runat="server" Text="&nbsp;Add: Expense Heads"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaExpenseHeads" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaExpenseHeads"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taExpenseHeads"
    runat = "server" />
<asp:FormView ID="FVtaExpenseHeads"
  runat = "server"
  DataKeyNames = "ExpenseHeadID"
  DataSourceID = "ODStaExpenseHeads"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaExpenseHeads" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ExpenseHeadID" ForeColor="#CC6633" runat="server" Text="Expense Head ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ExpenseHeadID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
            ValidationGroup="taExpenseHeads"
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
            ValidationGroup = "taExpenseHeads"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OneTimeInTour" runat="server" Text="One Time In Tour :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_OneTimeInTour"
           Checked='<%# Bind("OneTimeInTour") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequiresMDApproval" runat="server" Text="Requires MD Approval :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_RequiresMDApproval"
           Checked='<%# Bind("RequiresMDApproval") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaExpenseHeads"
  DataObjectTypeName = "SIS.TA.taExpenseHeads"
  InsertMethod="taExpenseHeadsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taExpenseHeads"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
