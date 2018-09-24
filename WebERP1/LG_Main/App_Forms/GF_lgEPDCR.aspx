<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_lgEPDCR.aspx.vb" Inherits="GF_lgEPDCR" title="Maintain List: EPM DCR" %>
<asp:Content ID="CPHlgEPDCR" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgEPDCR" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgEPDCR" runat="server" Text="&nbsp;List: EPM DCR" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLlgEPDCR"
      ToolType = "lgNMGrid"
      EditUrl = "~/LG_Main/App_Edit/EF_lgEPDCR.aspx"
      EnableAdd = "False"
      ValidationGroup = "lgEPDCR"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSlgEPDCR" runat="server" AssociatedUpdatePanelID="UPNLlgEPDCR" DisplayAfter="100">
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
					<b><asp:Label ID="L_DocPK" runat="server" Text="DocPK :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocPK"
						CssClass = "mypktxt"
            Width="133px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_DocPK(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DocPK_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDocPK"
            BehaviorID="B_ACEDocPK"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DocPKCompletionList"
            TargetControlID="F_DocPK"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEDocPK_Selected"
            OnClientPopulating="ACEDocPK_Populating"
            OnClientPopulated="ACEDocPK_Populated"
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
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVlgEPDCR" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSlgEPDCR" DataKeyNames="DocPK,DCRID,DCRLine">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR ID" SortExpression="DCRID">
          <ItemTemplate>
            <asp:Label ID="LabelDCRID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR Line" SortExpression="DCRLine">
          <ItemTemplate>
            <asp:Label ID="LabelDCRLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRLine") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR Description" SortExpression="DCRDescription">
          <ItemTemplate>
            <asp:Label ID="LabelDCRDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR Created On" SortExpression="DCRCreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelDCRCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRCreatedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR Category" SortExpression="DCRCategory">
          <ItemTemplate>
            <asp:Label ID="LabelDCRCategory" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRCategory") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Priority" SortExpression="RequestPriority">
          <ItemTemplate>
            <asp:Label ID="LabelRequestPriority" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestPriority") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approval Required Date" SortExpression="ApprovalRequiredDate">
          <ItemTemplate>
            <asp:Label ID="LabelApprovalRequiredDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovalRequiredDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR State" SortExpression="DCRState">
          <ItemTemplate>
            <asp:Label ID="LabelDCRState" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRState") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSlgEPDCR"
      runat = "server"
      DataObjectTypeName = "SIS.LG.lgEPDCR"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_lgEPDCRSelectList"
      TypeName = "SIS.LG.lgEPDCR"
      SelectCountMethod = "lgEPDCRSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DocPK" PropertyName="Text" Name="DocPK" Type="Int64" Size="19" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVlgEPDCR" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_DocPK" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
