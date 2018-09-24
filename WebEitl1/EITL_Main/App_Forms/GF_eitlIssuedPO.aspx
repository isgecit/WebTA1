<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_eitlIssuedPO.aspx.vb" Inherits="GF_eitlIssuedPO" title="Maintain List: Issued Purchase Orders" %>
<asp:Content ID="CPHeitlIssuedPO" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeleitlIssuedPO" runat="server" Text="&nbsp;List: Issued Purchase Orders"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlIssuedPO" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlIssuedPO"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlIssuedPO.aspx"
      EnableAdd = "False"
      ValidationGroup = "eitlIssuedPO"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlIssuedPO" runat="server" AssociatedUpdatePanelID="UPNLeitlIssuedPO" DisplayAfter="100">
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
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SupplierID"
						CssClass = "myfktxt"
            Width="63px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_SupplierID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SupplierID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierID"
            BehaviorID="B_ACESupplierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierIDCompletionList"
            TargetControlID="F_SupplierID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESupplierID_Selected"
            OnClientPopulating="ACESupplierID_Populating"
            OnClientPopulated="ACESupplierID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
            Width="42px"
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
					<b><asp:Label ID="L_BuyerID" runat="server" Text="Buyer :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_BuyerID"
						CssClass = "myfktxt"
            Width="56px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_BuyerID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_BuyerID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBuyerID"
            BehaviorID="B_ACEBuyerID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BuyerIDCompletionList"
            TargetControlID="F_BuyerID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEBuyerID_Selected"
            OnClientPopulating="ACEBuyerID_Populating"
            OnClientPopulated="ACEBuyerID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_POStatusID" runat="server" Text="PO Status :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_POStatusID"
						CssClass = "myfktxt"
            Width="70px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_POStatusID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_POStatusID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEPOStatusID"
            BehaviorID="B_ACEPOStatusID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="POStatusIDCompletionList"
            TargetControlID="F_POStatusID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEPOStatusID_Selected"
            OnClientPopulating="ACEPOStatusID_Populating"
            OnClientPopulated="ACEPOStatusID_Populated"
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
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_eitlIssuedPO.aspx', 'App_Print/RP_eitlPOList.aspx');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVeitlIssuedPO" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlIssuedPO" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="View">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Print">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Number" SortExpression="PONumber">
          <ItemTemplate>
            <asp:Label ID="LabelPONumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PONumber") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REV." SortExpression="PORevision">
          <ItemTemplate>
            <asp:Label ID="LabelPORevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PORevision") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Date" SortExpression="PODate">
          <ItemTemplate>
            <asp:Label ID="LabelPODate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PODate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier" SortExpression="EITL_Suppliers5_SupplierName">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("EITL_Suppliers5_SupplierName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects6_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Buyer" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_BuyerID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BuyerID") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Status" SortExpression="EITL_POStatus4_Description">
          <ItemTemplate>
             <asp:Label ID="L_POStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("POStatusID") %>' Text='<%# Eval("EITL_POStatus4_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Issued By" SortExpression="aspnet_Users3_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_IssuedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("IssuedBy") %>' Text='<%# Eval("aspnet_Users3_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Issued On" SortExpression="IssuedOn">
          <ItemTemplate>
            <asp:Label ID="LabelIssuedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IssuedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSeitlIssuedPO"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlIssuedPO"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_eitlIssuedPOSelectList"
      TypeName = "SIS.EITL.eitlIssuedPO"
      SelectCountMethod = "eitlIssuedPOSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_BuyerID" PropertyName="Text" Name="BuyerID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_POStatusID" PropertyName="Text" Name="POStatusID" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVeitlIssuedPO" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_BuyerID" />
    <asp:AsyncPostBackTrigger ControlID="F_POStatusID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
