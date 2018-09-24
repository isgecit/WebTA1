<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkUserClaims.aspx.vb" Inherits="GF_nprkUserClaims" title="List of Claims" %>
<asp:Content ID="CPHnprkUserClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkUserClaims" runat="server" Text="&nbsp;List of Claims"></asp:Label>
      <div style="float:right">
        <input type="button" value="Entitlement Sheet" class="myfktxt" style="vertical-align:top;padding-top:0px;" title="Click to view entitlement sheet" onclick="show_entitlement();" />
    </div>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkUserClaims" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkUserClaims"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkUserClaims.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkUserClaims.aspx?skip=1"
      AddPostBack = "True"
      EnableExit="true"
      ValidationGroup = "nprkUserClaims"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkUserClaims" runat="server" AssociatedUpdatePanelID="UPNLnprkUserClaims" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align:top;padding-top:0px;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimStatusID" runat="server" Text="Claim Status :" /></b>
        </td>
        <td>
          <LGM:LC_nprkClaimStatus
            ID="F_ClaimStatusID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="ClaimStatusID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
          <td>
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_', 'App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
      function show_entitlement() {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_nprkUserClaims', 'App_Print/RP_nprkUserEntitlementSheet');
        window.open(url, nam, 'left=20,top=20,width=700,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVnprkUserClaims" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkUserClaims" DataKeyNames="ClaimID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claim Ref.No" SortExpression="ClaimID">
          <ItemTemplate>
            <asp:Label ID="LabelClaimID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ClaimRefNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="TotalAmount">
          <ItemTemplate>
            <asp:Label ID="LabelTotalAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submitted On" SortExpression="SubmittedOn">
          <ItemTemplate>
            <asp:Label ID="LabelSubmittedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SubmittedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Received On" SortExpression="ReceivedOn">
          <ItemTemplate>
            <asp:Label ID="LabelReceivedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReceivedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Returned On" SortExpression="ReturnedOn">
          <ItemTemplate>
            <asp:Label ID="LabelReturnedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReturnedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmount">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claim Status" SortExpression="PRK_ClaimStatus4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ClaimStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ClaimStatusID") %>' Text='<%# Eval("PRK_ClaimStatus4_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fwd.To Accounts">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DEL">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete Returned/Free" SkinID="delete" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Delete Claim ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField >
          <ItemTemplate>
						</td></tr>
						<tr style="background-color:AntiqueWhite; color:DeepPink">
              <td colspan="5"></td>
              <td colspan="6">
                <asp:Label ID="LabelNotification" runat="server" Text='<%# Eval("Notification") %>'></asp:Label>
              </td>
						</tr>
          </ItemTemplate>
          <HeaderStyle Width="10px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkUserClaims"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkUserClaims"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkUserClaimsSelectList"
      TypeName = "SIS.NPRK.nprkUserClaims"
      SelectCountMethod = "nprkUserClaimsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ClaimStatusID" PropertyName="SelectedValue" Name="ClaimStatusID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkUserClaims" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ClaimStatusID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
