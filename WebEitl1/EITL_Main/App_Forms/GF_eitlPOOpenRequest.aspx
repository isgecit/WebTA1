<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_eitlPOOpenRequest.aspx.vb" Inherits="GF_eitlPOOpenRequest" title="Maintain List: PO Re-Open Request" %>
<asp:Content ID="CPHeitlPOOpenRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeleitlPOOpenRequest" runat="server" Text="&nbsp;List: PO Re-Open Request"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPOOpenRequest" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlPOOpenRequest"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlPOOpenRequest.aspx"
      EnableAdd = "False"
      ValidationGroup = "eitlPOOpenRequest"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlPOOpenRequest" runat="server" AssociatedUpdatePanelID="UPNLeitlPOOpenRequest" DisplayAfter="100">
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
					<b><asp:Label ID="L_SerialNo" runat="server" Text="S.No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
						CssClass = "myfktxt"
            Width="70px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_SerialNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESerialNo_Selected"
            OnClientPopulating="ACESerialNo_Populating"
            OnClientPopulated="ACESerialNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
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
    </table>
		</asp:Panel>
		<AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVeitlPOOpenRequest" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlPOOpenRequest" DataKeyNames="RequestNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Req.No" SortExpression="RequestNo">
          <ItemTemplate>
            <asp:Label ID="LabelRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO No" SortExpression="EITL_POList2_PONumber">
          <ItemTemplate>
             <asp:Label ID="L_SerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SerialNo") %>' Text='<%# Eval("EITL_POList2_PONumber") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO REV." SortExpression="PORevision">
          <ItemTemplate>
            <asp:Label ID="LabelPORevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PORevision") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier" SortExpression="EITL_Suppliers3_SupplierName">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("EITL_Suppliers3_SupplierName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested On" SortExpression="RequestedOn">
          <ItemTemplate>
            <asp:Label ID="LabelRequestedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Executed By" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ExecutedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ExecutedBy") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Executed On" SortExpression="ExecutedOn">
          <ItemTemplate>
            <asp:Label ID="LabelExecutedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExecutedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Re-Opened" SortExpression="ExecutedToOpen">
          <ItemTemplate>
            <asp:Label ID="LabelExecutedToOpen" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExecutedToOpen") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Executer Remarks" SortExpression="ExecuterRemarks">
          <ItemTemplate>
					<asp:TextBox ID="F_ExecuterRemarks"
						Text='<%# Bind("ExecuterRemarks") %>'
            Width="150px" Height="20px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter Executer Remarks."
						MaxLength="500"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVExecuterRemarks"
						runat = "server"
						ControlToValidate = "F_ExecuterRemarks"
						Text = "*"
						ErrorMessage = "*"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = '<%# "Reject" & Container.DataItemIndex %>'
						SetFocusOnError="true" />
          </ItemTemplate>
        <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reject">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reject" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Reject record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSeitlPOOpenRequest"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlPOOpenRequest"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "eitlPOOpenRequestSelectList"
      TypeName = "SIS.EITL.eitlPOOpenRequest"
      SelectCountMethod = "eitlPOOpenRequestSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="9" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVeitlPOOpenRequest" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
    <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
