<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_erpDCRDetail.aspx.vb" Inherits="GF_erpDCRDetail" title="Maintain List: DCR Detail" %>
<asp:Content ID="CPHerpDCRDetail" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpDCRDetail" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelerpDCRDetail" runat="server" Text="&nbsp;List: DCR Detail" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLerpDCRDetail"
      ToolType = "lgNMGrid"
      EditUrl = "~/ERP_Main/App_Edit/EF_erpDCRDetail.aspx"
      AddUrl = "~/ERP_Main/App_Create/AF_erpDCRDetail.aspx"
      AddPostBack = "True"
      ValidationGroup = "erpDCRDetail"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSerpDCRDetail" runat="server" AssociatedUpdatePanelID="UPNLerpDCRDetail" DisplayAfter="100">
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
					<b><asp:Label ID="L_DCRNo" runat="server" Text="DCRNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DCRNo"
						CssClass = "mypktxt"
            Width="70px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_DCRNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DCRNo_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDCRNo"
            BehaviorID="B_ACEDCRNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DCRNoCompletionList"
            TargetControlID="F_DCRNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEDCRNo_Selected"
            OnClientPopulating="ACEDCRNo_Populating"
            OnClientPopulated="ACEDCRNo_Populated"
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
    <asp:GridView ID="GVerpDCRDetail" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSerpDCRDetail" DataKeyNames="DCRNo,DocumentID,RevisionNo">
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
        <asp:TemplateField HeaderText="DCRNo" SortExpression="ERP_DCRHeader1_DCRDescription">
          <ItemTemplate>
             <asp:Label ID="L_DCRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DCRNo") %>' Text='<%# Eval("ERP_DCRHeader1_DCRDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DocumentID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RevisionNo" SortExpression="RevisionNo">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndentNo" SortExpression="IndentNo">
          <ItemTemplate>
            <asp:Label ID="LabelIndentNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndentNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndentLine" SortExpression="IndentLine">
          <ItemTemplate>
            <asp:Label ID="LabelIndentLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndentLine") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="LotItem" SortExpression="LotItem">
          <ItemTemplate>
            <asp:Label ID="LabelLotItem" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LotItem") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ItemDescription" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndenterID" SortExpression="IndenterID">
          <ItemTemplate>
            <asp:Label ID="LabelIndenterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndenterID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerID" SortExpression="BuyerID">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderNo" SortExpression="OrderNo">
          <ItemTemplate>
            <asp:Label ID="LabelOrderNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderLine" SortExpression="OrderLine">
          <ItemTemplate>
            <asp:Label ID="LabelOrderLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderLine") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupplierID" SortExpression="SupplierID">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerIDinPO" SortExpression="BuyerIDinPO">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerIDinPO" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerIDinPO") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndenterName" SortExpression="IndenterName">
          <ItemTemplate>
            <asp:Label ID="LabelIndenterName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndenterName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndenterEMail" SortExpression="IndenterEMail">
          <ItemTemplate>
            <asp:Label ID="LabelIndenterEMail" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndenterEMail") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerName" SortExpression="BuyerName">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerEMail" SortExpression="BuyerEMail">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerEMail" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerEMail") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerIDinPOName" SortExpression="BuyerIDinPOName">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerIDinPOName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerIDinPOName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerIDinPOEMail" SortExpression="BuyerIDinPOEMail">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerIDinPOEMail" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerIDinPOEMail") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupplierName" SortExpression="SupplierName">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DocumentTitle" SortExpression="DocumentTitle">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentTitle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentTitle") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSerpDCRDetail"
      runat = "server"
      DataObjectTypeName = "SIS.ERP.erpDCRDetail"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "erpDCRDetailSelectList"
      TypeName = "SIS.ERP.erpDCRDetail"
      SelectCountMethod = "erpDCRDetailSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DCRNo" PropertyName="Text" Name="DCRNo" Type="String" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVerpDCRDetail" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_DCRNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
