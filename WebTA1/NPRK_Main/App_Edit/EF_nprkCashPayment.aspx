<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkCashPayment.aspx.vb" Inherits="EF_nprkCashPayment" title="Edit: Cash Payment" %>
<asp:Content ID="CPHnprkCashPayment" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkCashPayment" runat="server" Text="&nbsp;Edit: Cash Payment"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkCashPayment" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkCashPayment"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "nprkCashPayment"
    runat = "server" />
<asp:FormView ID="FVnprkCashPayment"
  runat = "server"
  DataKeyNames = "ClaimID,ApplicationID"
  DataSourceID = "ODSnprkCashPayment"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" runat="server" ForeColor="#CC6633" Text="Claim Number :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ClaimID"
            Width="88px"
            Text='<%# Bind("ClaimID") %>'
            Enabled = "False"
            ToolTip="Value of Claim Number."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ClaimID_Display"
            Text='<%# Eval("PRK_UserClaims9_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ApplicationID" runat="server" ForeColor="#CC6633" Text="Application ID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApplicationID"
            Text='<%# Bind("ApplicationID") %>'
            ToolTip="Value of Application ID."
            Enabled = "False"
            Width="88px"
            CssClass = "dmypktxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_EmployeeID"
            Width="88px"
            Text='<%# Bind("EmployeeID") %>'
            Enabled = "False"
            ToolTip="Value of Employee."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("PRK_Employees1_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PerkID" runat="server" Text="Perk :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_PerkID"
            Width="88px"
            Text='<%# Bind("PerkID") %>'
            Enabled = "False"
            ToolTip="Value of Perk."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PerkID_Display"
            Text='<%# Eval("PRK_Perks7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AppliedOn" runat="server" Text="Applied On :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AppliedOn"
            Text='<%# Bind("AppliedOn") %>'
            ToolTip="Value of Applied On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Value" runat="server" Text="Claimed Amount :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Value"
            Text='<%# Bind("Value") %>'
            ToolTip="Value of Claimed Amount."
            Enabled = "False"
            Width="104px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserRemark" runat="server" Text="User Remark :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UserRemark"
            Text='<%# Bind("UserRemark") %>'
            ToolTip="Value of User Remark."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Documents" runat="server" Text="Doc.OK :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_Documents"
            SelectedValue='<%# Bind("Documents") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Verified" runat="server" Text="Verified :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_Verified"
            SelectedValue='<%# Bind("Verified") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Approved" runat="server" Text="Approved :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_Approved"
            SelectedValue='<%# Bind("Approved") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedAmt" runat="server" Text="Approved Amt :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApprovedAmt"
            Text='<%# Bind("ApprovedAmt") %>'
            ToolTip="Value of Approved Amt."
            Enabled = "False"
            Width="104px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PaymentMethod" runat="server" Text="Payment Method :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_PaymentMethod"
            SelectedValue='<%# Bind("PaymentMethod") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="Cash">Cash</asp:ListItem>
            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
            <asp:ListItem Value="Imprest">Imprest</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverRemark" runat="server" Text="Approver Remark :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemark"
            Text='<%# Bind("ApproverRemark") %>'
            ToolTip="Value of Approver Remark."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="Label1" runat="server" Text="Paid At :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_PaidAt"
            SelectedValue='<%# Bind("PaidAt") %>'
            Width="200px"
            CssClass = "myddl"
            ValidationGroup = "nprkCashPayment"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="CSH">Sector-24</asp:ListItem>
            <asp:ListItem Value="CS1">Sector-63</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVPaidAt"
            runat = "server"
            ControlToValidate = "F_PaidAt"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkCashPayment"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UpdatedInLedger" runat="server" Text="Paid :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_UpdatedInLedger"
            SelectedValue='<%# Bind("UpdatedInLedger") %>'
            CssClass = "myddl"
            Width="200px"
            ValidationGroup = "nprkCashPayment"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVUpdatedInLedger"
            runat = "server"
            ControlToValidate = "F_UpdatedInLedger"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkCashPayment"
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
  ID = "ODSnprkCashPayment"
  DataObjectTypeName = "SIS.NPRK.nprkCashPayment"
  SelectMethod = "nprkCashPaymentGetByID"
  UpdateMethod="UZ_nprkCashPaymentUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkCashPayment"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ClaimID" Name="ClaimID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplicationID" Name="ApplicationID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
