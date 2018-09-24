<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkRECUserClaims.aspx.vb" Inherits="EF_nprkRECUserClaims" title="Edit: Receive / Return User Claims" %>
<asp:Content ID="CPHnprkRECUserClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkRECUserClaims" runat="server" Text="&nbsp;Edit: Receive / Return User Claims"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkRECUserClaims" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkRECUserClaims"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_nprkRECUserClaims.aspx?pk="
    ValidationGroup = "nprkRECUserClaims"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVnprkRECUserClaims"
  runat = "server"
  DataKeyNames = "ClaimID"
  DataSourceID = "ODSnprkRECUserClaims"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" runat="server" ForeColor="#CC6633" Text="Claim ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ClaimID"
            Text='<%# Bind("ClaimID") %>'
            ToolTip="Value of Claim ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CardNo" runat="server" Text="Card No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CardNo"
            Width="72px"
            Text='<%# Bind("CardNo") %>'
            Enabled = "False"
            ToolTip="Value of Card No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="nprkRECUserClaims_0"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Accounts Details</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            ToolTip="Value of Description."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalAmount" runat="server" Text="Claimed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalAmount"
            Text='<%# Bind("TotalAmount") %>'
            ToolTip="Value of Claimed Amount."
            Enabled = "False"
            Width="120px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ClaimStatusID" runat="server" Text="Claim Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ClaimStatusID"
            Width="88px"
            Text='<%# Bind("ClaimStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Claim Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ClaimStatusID_Display"
            Text='<%# Eval("PRK_ClaimStatus4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DeclarationAccepted" runat="server" Text="Declaration Accepted :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DeclarationAccepted"
            Checked='<%# Bind("DeclarationAccepted") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SubmittedOn" runat="server" Text="Submitted On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SubmittedOn"
            Text='<%# Bind("SubmittedOn") %>'
            ToolTip="Value of Submitted On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PassedAmount" runat="server" Text="Passed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmount"
            Text='<%# Bind("PassedAmount") %>'
            ToolTip="Value of Passed Amount."
            Enabled = "False"
            Width="120px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CompletedOn" runat="server" Text="Completed On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CompletedOn"
            Text='<%# Bind("CompletedOn") %>'
            ToolTip="Value of Completed On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReceivedOn" runat="server" Text="Received On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReceivedOn"
            Text='<%# Bind("ReceivedOn") %>'
            ToolTip="Value of Received On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ReceivedBy" runat="server" Text="Received By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceivedBy"
            Width="72px"
            Text='<%# Bind("ReceivedBy") %>'
            Enabled = "False"
            ToolTip="Value of Received By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ReceivedBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReturnedOn" runat="server" Text="Returned On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReturnedOn"
            Text='<%# Bind("ReturnedOn") %>'
            ToolTip="Value of Returned On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ReturnedBy" runat="server" Text="Returned By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReturnedBy"
            Width="72px"
            Text='<%# Bind("ReturnedBy") %>'
            Enabled = "False"
            ToolTip="Value of Returned By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ReturnedBy_Display"
            Text='<%# Eval("aspnet_users3_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AccountsRemarks" runat="server" Text="Accounts Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AccountsRemarks"
            Text='<%# Bind("AccountsRemarks") %>'
            ToolTip="Value of Accounts Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
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
  ID = "ODSnprkRECUserClaims"
  DataObjectTypeName = "SIS.NPRK.nprkRECUserClaims"
  SelectMethod = "nprkRECUserClaimsGetByID"
  UpdateMethod="UZ_nprkRECUserClaimsUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkRECUserClaims"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ClaimID" Name="ClaimID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
