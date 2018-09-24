<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_erpProcessTPTBill.aspx.vb" Inherits="GF_erpProcessTPTBill" title="Maintain List: Process Transporter Bill" %>
<asp:Content ID="CPHerpProcessTPTBill" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpProcessTPTBill" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelerpProcessTPTBill" runat="server" Text="&nbsp;List: Process Transporter Bill" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLerpProcessTPTBill"
      ToolType = "lgNMGrid"
      EditUrl = "~/ERP_Main/App_Edit/EF_erpProcessTPTBill.aspx"
      EnableAdd = "False"
      ValidationGroup = "erpProcessTPTBill"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSerpProcessTPTBill" runat="server" AssociatedUpdatePanelID="UPNLerpProcessTPTBill" DisplayAfter="100">
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
					<b><asp:Label ID="L_TPTCode" runat="server" Text="Transporter Code :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_TPTCode"
						CssClass = "myfktxt"
            Width="63px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_TPTCode(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_TPTCode_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETPTCode"
            BehaviorID="B_ACETPTCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TPTCodeCompletionList"
            TargetControlID="F_TPTCode"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACETPTCode_Selected"
            OnClientPopulating="ACETPTCode_Populating"
            OnClientPopulated="ACETPTCode_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
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
					<b><asp:Label ID="L_BillStatus" runat="server" Text="Bill Status :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_BillStatus"
						CssClass = "myfktxt"
            Width="70px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_BillStatus(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_BillStatus_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBillStatus"
            BehaviorID="B_ACEBillStatus"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BillStatusCompletionList"
            TargetControlID="F_BillStatus"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEBillStatus_Selected"
            OnClientPopulating="ACEBillStatus_Populating"
            OnClientPopulated="ACEBillStatus_Populated"
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
		<asp:Label ID="ErrorMsg" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="14px" Visible="false" Text="" />
    <br />
    <asp:GridView ID="GVerpProcessTPTBill" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSerpProcessTPTBill" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter Bill No." SortExpression="TPTBillNo">
          <ItemTemplate>
            <asp:Label ID="LabelTPTBillNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TPTBillNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter Bill Date" SortExpression="TPTBillDate">
          <ItemTemplate>
            <asp:Label ID="LabelTPTBillDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TPTBillDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter Code" SortExpression="VR_Transporters10_TransporterName">
          <ItemTemplate>
             <asp:Label ID="L_TPTCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TPTCode") %>' Text='<%# Eval("VR_Transporters10_TransporterName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects9_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects9_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forwarded To Accounts On" SortExpression="FWDToAccountsOn">
          <ItemTemplate>
            <asp:Label ID="LabelFWDToAccountsOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FWDToAccountsOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forwarded To Accounts By" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_FWDToAccountsBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FWDToAccountsBy") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PTR No" SortExpression="PTRNo">
          <ItemTemplate>
            <asp:Label ID="LabelPTRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PTRNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PTR Amount" SortExpression="PTRAmount">
          <ItemTemplate>
            <asp:Label ID="LabelPTRAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PTRAmount") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank Voucher No" SortExpression="BankVCHNo">
          <ItemTemplate>
            <asp:Label ID="LabelBankVCHNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BankVCHNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank Voucher Amount" SortExpression="BankVCHAmount">
          <ItemTemplate>
            <asp:Label ID="LabelBankVCHAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BankVCHAmount") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Status" SortExpression="ERP_TPTBillStatus8_Description">
          <ItemTemplate>
             <asp:Label ID="L_BillStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BillStatus") %>' Text='<%# Eval("ERP_TPTBillStatus8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receive">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Receive" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Receive record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Return">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Processed">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Processed" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Processed record ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
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
      ID = "ODSerpProcessTPTBill"
      runat = "server"
      DataObjectTypeName = "SIS.ERP.erpProcessTPTBill"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_erpProcessTPTBillSelectList"
      TypeName = "SIS.ERP.erpProcessTPTBill"
      SelectCountMethod = "erpProcessTPTBillSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TPTCode" PropertyName="Text" Name="TPTCode" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_BillStatus" PropertyName="Text" Name="BillStatus" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVerpProcessTPTBill" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_TPTCode" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_BillStatus" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
