<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkUserClaims.aspx.vb" Inherits="EF_nprkUserClaims" title="Perk Claim Form" %>
<asp:Content ID="CPHnprkUserClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkUserClaims" runat="server" Text="&nbsp;Perk Claim Form"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkUserClaims" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkUserClaims"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_nprkUserClaims.aspx?pk="
    ValidationGroup = "nprkUserClaims"
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
<asp:FormView ID="FVnprkUserClaims"
  runat = "server"
  DataKeyNames = "ClaimID"
  DataSourceID = "ODSnprkUserClaims"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" runat="server" ForeColor="#CC6633" Text="Claim Ref. No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="TextBox1"
            Text='<%# Bind("ClaimRefNo") %>'
            ToolTip="Value of Claim ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />

          <asp:TextBox ID="F_ClaimID"
            Text='<%# Bind("ClaimID") %>'
            ToolTip="Value of Claim ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right; display:none;"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="nprkUserClaims_0"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Click here for Claim's Summary & Status</td></tr>
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CardNo" runat="server" Text="Card No :" />&nbsp;
        </td>
        <td colspan="3">
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
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelnprkApplications" runat="server" Text="&nbsp;Add Perk Detail"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkApplications" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkApplications"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkApplications.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkApplications.aspx?skip=1"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "nprkApplications"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkApplications" runat="server" AssociatedUpdatePanelID="UPNLnprkApplications" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVnprkApplications" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkApplications" DataKeyNames="ClaimID,ApplicationID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Perk Type" SortExpression="PRK_Perks7_Description">
          <ItemTemplate>
             <asp:Label ID="L_PerkID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("PerkID") %>' Text='<%# Eval("PRK_Perks7_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Applied On" SortExpression="AppliedOn">
          <ItemTemplate>
            <asp:Label ID="LabelAppliedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AppliedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="Value">
          <ItemTemplate>
            <asp:Label ID="LabelValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verified On" SortExpression="VerifiedOn">
          <ItemTemplate>
            <asp:Label ID="LabelVerifiedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VerifiedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approved On" SortExpression="ApprovedOn">
          <ItemTemplate>
            <asp:Label ID="LabelApprovedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Posted On" SortExpression="PostedOn">
          <ItemTemplate>
            <asp:Label ID="LabelPostedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PostedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approved Amt" SortExpression="ApprovedAmt">
          <ItemTemplate>
            <asp:Label ID="LabelApprovedAmt" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovedAmt") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Accounts Status" SortExpression="PRK_Status8_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("PRK_Status8_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkApplications"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkApplications"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkApplicationsSelectList"
      TypeName = "SIS.NPRK.nprkApplications"
      SelectCountMethod = "nprkApplicationsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ClaimID" PropertyName="Text" Name="ClaimID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkApplications" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkUserClaims"
  DataObjectTypeName = "SIS.NPRK.nprkUserClaims"
  SelectMethod = "nprkUserClaimsGetByID"
  UpdateMethod="UZ_nprkUserClaimsUpdate"
  DeleteMethod="UZ_nprkUserClaimsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkUserClaims"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ClaimID" Name="ClaimID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
