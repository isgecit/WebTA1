<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakSiteMtlIssDL.aspx.vb" Inherits="GF_pakSiteMtlIssDL" title="Maintain List: Site Material Issue Item Location" %>
<asp:Content ID="CPHpakSiteMtlIssDL" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakSiteMtlIssDL" runat="server" Text="&nbsp;List: Site Material Issue Item Location"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteMtlIssDL" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSiteMtlIssDL"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSiteMtlIssDL.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakSiteMtlIssDL.aspx"
      AddPostBack = "True"
      ValidationGroup = "pakSiteMtlIssDL"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSiteMtlIssDL" runat="server" AssociatedUpdatePanelID="UPNLpakSiteMtlIssDL" DisplayAfter="100">
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
          <b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectID_Selected"
            OnClientPopulating="ACEProjectID_Populating"
            OnClientPopulated="ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueNo" runat="server" Text="Issue No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_IssueNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IssueNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIssueNo"
            BehaviorID="B_ACEIssueNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IssueNoCompletionList"
            TargetControlID="F_IssueNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEIssueNo_Selected"
            OnClientPopulating="ACEIssueNo_Populating"
            OnClientPopulated="ACEIssueNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueSrNo" runat="server" Text="Issue Sr No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueSrNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_IssueSrNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IssueSrNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIssueSrNo"
            BehaviorID="B_ACEIssueSrNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IssueSrNoCompletionList"
            TargetControlID="F_IssueSrNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEIssueSrNo_Selected"
            OnClientPopulating="ACEIssueSrNo_Populating"
            OnClientPopulated="ACEIssueSrNo_Populated"
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
    <asp:GridView ID="GVpakSiteMtlIssDL" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSiteMtlIssDL" DataKeyNames="ProjectID,IssueNo,IssueSrNo,IssueSrLNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Issue Sr L No" SortExpression="IssueSrLNo">
          <ItemTemplate>
            <asp:Label ID="LabelIssueSrLNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IssueSrLNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Site Mark No" SortExpression="PAK_SiteItemMaster4_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_SiteMarkNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SiteMarkNo") %>' Text='<%# Eval("PAK_SiteItemMaster4_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location" SortExpression="PAK_SiteLocations5_Description">
          <ItemTemplate>
             <asp:Label ID="L_LocationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("LocationID") %>' Text='<%# Eval("PAK_SiteLocations5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Quantity" SortExpression="PAK_Units6_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMQuantity") %>' Text='<%# Eval("PAK_Units6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity Available" SortExpression="QuantityAvailable">
          <ItemTemplate>
            <asp:Label ID="LabelQuantityAvailable" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QuantityAvailable") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity Issued" SortExpression="QuantityIssued">
          <ItemTemplate>
            <asp:Label ID="LabelQuantityIssued" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QuantityIssued") %>'></asp:Label>
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
      ID = "ODSpakSiteMtlIssDL"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSiteMtlIssDL"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakSiteMtlIssDLSelectList"
      TypeName = "SIS.PAK.pakSiteMtlIssDL"
      SelectCountMethod = "pakSiteMtlIssDLSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IssueNo" PropertyName="Text" Name="IssueNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_IssueSrNo" PropertyName="Text" Name="IssueSrNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSiteMtlIssDL" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_IssueNo" />
    <asp:AsyncPostBackTrigger ControlID="F_IssueSrNo" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
