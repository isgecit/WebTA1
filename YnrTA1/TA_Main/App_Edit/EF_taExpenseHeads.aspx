<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taExpenseHeads.aspx.vb" Inherits="EF_taExpenseHeads" title="Edit: Expense Heads" %>
<asp:Content ID="CPHtaExpenseHeads" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaExpenseHeads" runat="server" Text="&nbsp;Edit: Expense Heads"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaExpenseHeads" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaExpenseHeads"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taExpenseHeads"
    runat = "server" />
<asp:FormView ID="FVtaExpenseHeads"
  runat = "server"
  DataKeyNames = "ExpenseHeadID"
  DataSourceID = "ODStaExpenseHeads"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ExpenseHeadID" runat="server" ForeColor="#CC6633" Text="Expense Head ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ExpenseHeadID"
            Text='<%# Bind("ExpenseHeadID") %>'
            ToolTip="Value of Expense Head ID."
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
            ValidationGroup="taExpenseHeads"
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
            ValidationGroup = "taExpenseHeads"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaExpenseHeads"
  DataObjectTypeName = "SIS.TA.taExpenseHeads"
  SelectMethod = "taExpenseHeadsGetByID"
  UpdateMethod="taExpenseHeadsUpdate"
  DeleteMethod="taExpenseHeadsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taExpenseHeads"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ExpenseHeadID" Name="ExpenseHeadID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
