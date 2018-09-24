<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_lgDMisg.aspx.vb" Inherits="GF_lgDMisg" title="Maintain List: BaaN Document" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgDMisg" runat="server" Text="&nbsp;List: BaaN Document" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLlgDMisg"
      ToolType = "lgNMGrid"
      EditUrl = "~/LG_Main/App_Edit/EF_lgDMisg.aspx"
      EnableAdd = "False"
      ValidationGroup = "lgDMisg"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSlgDMisg" runat="server" AssociatedUpdatePanelID="UPNLlgDMisg" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <br />
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
					<b><asp:Label ID="L_t_cprj" runat="server" Text="Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_t_cprj"
						CssClass = "myfktxt"
            Width="140px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_t_cprj(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_t_cprj_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEt_cprj"
            BehaviorID="B_ACEt_cprj"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="t_cprjCompletionList"
            TargetControlID="F_t_cprj"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEt_cprj_Selected"
            OnClientPopulating="ACEt_cprj_Populating"
            OnClientPopulated="ACEt_cprj_Populated"
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
    <br />
    <asp:GridView ID="GVlgDMisg" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSlgDMisg" DataKeyNames="t_docn,t_revn">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document Number" SortExpression="t_docn">
          <ItemTemplate>
            <asp:Label ID="Labelt_docn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_docn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revision" SortExpression="t_revn">
          <ItemTemplate>
            <asp:Label ID="Labelt_revn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_revn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="t_dttl">
          <ItemTemplate>
            <asp:Label ID="Labelt_dttl" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_dttl") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element" SortExpression="t_cspa">
          <ItemTemplate>
            <asp:Label ID="Labelt_cspa" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_cspa") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="t_stat">
          <ItemTemplate>
            <asp:Label ID="Labelt_stat" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# Eval("t_stat") %>' Text='<%# Eval("stat") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WFStatus" SortExpression="t_wfst">
          <ItemTemplate>
            <asp:Label ID="Labelt_wfst" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# Eval("t_wfst") %>' Text='<%# Eval("wfstat") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_dsca" SortExpression="t_dsca">
          <ItemTemplate>
            <asp:Label ID="Labelt_dsca" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_dsca") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_sorc" SortExpression="t_sorc">
          <ItemTemplate>
            <asp:Label ID="Labelt_sorc" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_sorc") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSlgDMisg"
      runat = "server"
      DataObjectTypeName = "SIS.LG.lgDMisg"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "lgDMisgSelectList"
      TypeName = "SIS.LG.lgDMisg"
      SelectCountMethod = "lgDMisgSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_t_cprj" PropertyName="Text" Name="t_cprj" Type="String" Size="20" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVlgDMisg" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_t_cprj" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
