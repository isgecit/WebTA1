<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkBillDetails.aspx.vb" Inherits="GF_nprkBillDetails" title="Maintain List: Bill Details" %>
<asp:Content ID="CPHnprkBillDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkBillDetails" runat="server" Text="&nbsp;List: Bill Details"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkBillDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkBillDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkBillDetails.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkBillDetails.aspx"
      AddPostBack = "True"
      ValidationGroup = "nprkBillDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkBillDetails" runat="server" AssociatedUpdatePanelID="UPNLnprkBillDetails" DisplayAfter="100">
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
          <b><asp:Label ID="L_ClaimID" runat="server" Text="Claim ID :" /></b>
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
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ApplicationID" runat="server" Text="Application ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApplicationID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ApplicationID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ApplicationID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEApplicationID"
            BehaviorID="B_ACEApplicationID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApplicationIDCompletionList"
            TargetControlID="F_ApplicationID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEApplicationID_Selected"
            OnClientPopulating="ACEApplicationID_Populating"
            OnClientPopulated="ACEApplicationID_Populated"
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
    <asp:GridView ID="GVnprkBillDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkBillDetails" DataKeyNames="ClaimID,ApplicationID,AttachmentID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL NO" SortExpression="BillNo">
          <ItemTemplate>
            <asp:Label ID="LabelBillNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL DATE" SortExpression="BillDate">
          <ItemTemplate>
            <asp:Label ID="LabelBillDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PARTICULARS" SortExpression="Particulars">
          <ItemTemplate>
            <asp:Label ID="LabelParticulars" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Particulars") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL AMT." SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CLAIMED AMT." SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkBillDetails"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkBillDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkBillDetailsSelectList"
      TypeName = "SIS.NPRK.nprkBillDetails"
      SelectCountMethod = "nprkBillDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ApplicationID" PropertyName="Text" Name="ApplicationID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ClaimID" PropertyName="Text" Name="ClaimID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkBillDetails" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ApplicationID" />
    <asp:AsyncPostBackTrigger ControlID="F_ClaimID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
