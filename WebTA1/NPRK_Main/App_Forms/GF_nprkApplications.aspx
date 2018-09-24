<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkApplications.aspx.vb" Inherits="GF_nprkApplications" title="Maintain List: Claim Perks" %>
<asp:Content ID="CPHnprkApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkApplications" runat="server" Text="&nbsp;List: Claim Perks"></asp:Label>
</div>
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
      ValidationGroup = "nprkApplications"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkApplications" runat="server" AssociatedUpdatePanelID="UPNLnprkApplications" DisplayAfter="100">
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
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" runat="server" Text="Claim Number :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ClaimID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ClaimID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ClaimID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEClaimID"
            BehaviorID="B_ACEClaimID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ClaimIDCompletionList"
            TargetControlID="F_ClaimID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEClaimID_Selected"
            OnClientPopulating="ACEClaimID_Populating"
            OnClientPopulated="ACEClaimID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVnprkApplications" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkApplications" DataKeyNames="ApplicationID,ClaimID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Perk ID" SortExpression="PRK_Perks7_Description">
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
        <asp:TemplateField HeaderText="Status ID" SortExpression="PRK_Status8_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("PRK_Status8_Description") %>'></asp:Label>
          </ItemTemplate>
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
    <asp:AsyncPostBackTrigger ControlID="F_ClaimID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
