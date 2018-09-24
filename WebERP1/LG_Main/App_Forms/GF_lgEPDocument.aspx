<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_lgEPDocument.aspx.vb" Inherits="GF_lgEPDocument" title="Maintain List: Document" %>
<asp:Content ID="CPHlgEPDocument" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgEPDocument" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgEPDocument" runat="server" Text="&nbsp;List: Document" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLlgEPDocument"
      ToolType = "lgNMGrid"
      EditUrl = "~/LG_Main/App_Edit/EF_lgEPDocument.aspx"
      EnableAdd = "False"
      ValidationGroup = "lgEPDocument"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSlgEPDocument" runat="server" AssociatedUpdatePanelID="UPNLlgEPDocument" DisplayAfter="100">
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
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
            Width="140px"
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
       function script_download(id, typ, id1) {
       	pcnt = pcnt + 1;
       	var nam = 'wdwd' + pcnt;
       	var url = self.location.href.replace('App_Forms/GF_lgEPDocument.aspx', 'App_Download/filedownload.aspx');
       	url = url + '?id=' + id + '&typ=' + typ + '&id1=' + id1;
       	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
       	return false;
       }
    </script>
    <asp:GridView ID="GVlgEPDocument" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSlgEPDocument" DataKeyNames="DocPK">
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
        <asp:TemplateField HeaderText="Doc PK" SortExpression="DocPK">
          <ItemTemplate>
            <asp:Label ID="LabelDocPK" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocPK") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document Number" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:LinkButton ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("DocumentID") %>' OnClientClick='<%# Eval("GetLink") %>' CommandName="DownloadFile" CommandArgument='<%# Container.DataItemIndex %>'  ></asp:LinkButton>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revision" SortExpression="Revision">
          <ItemTemplate>
            <asp:Label ID="LabelRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Revision") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Iteration" SortExpression="Iteration">
          <ItemTemplate>
            <asp:Label ID="LabelIteration" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Iteration") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="Status">
          <ItemTemplate>
            <asp:Label ID="LabelStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Status") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="Title">
          <ItemTemplate>
            <asp:Label ID="LabelTitle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Title") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Updated On" SortExpression="UpdatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelUpdatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UpdatedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="LG_Projects1_ProjectDescription">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("LG_Projects1_ProjectDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element ID" SortExpression="ElementID">
          <ItemTemplate>
            <asp:Label ID="LabelElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ElementID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSlgEPDocument"
      runat = "server"
      DataObjectTypeName = "SIS.LG.lgEPDocument"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_lgEPDocumentSelectList"
      TypeName = "SIS.LG.lgEPDocument"
      SelectCountMethod = "lgEPDocumentSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="20" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVlgEPDocument" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
 
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
