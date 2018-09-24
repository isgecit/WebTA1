<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_erpEvaluateByIT.aspx.vb" Inherits="GF_erpEvaluateByIT" title="Maintain List: Evaluation By IT" %>
<asp:Content ID="CPHerpEvaluateByIT" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaBH" runat="server" Text="&nbsp;List: Evaluation By IT"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLerpEvaluateByIT" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLerpEvaluateByIT"
      ToolType = "lgNMGrid"
      EditUrl = "~/ERP_Main/App_Edit/EF_erpEvaluateByIT.aspx"
      EnableAdd = "False"
      ValidationGroup = "erpEvaluateByIT"
      SkinID = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSerpEvaluateByIT" runat="server" AssociatedUpdatePanelID="UPNLerpEvaluateByIT" DisplayAfter="100">
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
					<b><asp:Label ID="L_ApplID" runat="server" Text="Appl ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ApplID"
						CssClass = "mypktxt"
            Width="70px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_ApplID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ApplID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEApplID"
            BehaviorID="B_ACEApplID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApplIDCompletionList"
            TargetControlID="F_ApplID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEApplID_Selected"
            OnClientPopulating="ACEApplID_Populating"
            OnClientPopulated="ACEApplID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequestedBy"
						CssClass = "myfktxt"
            Width="56px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_RequestedBy(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestedBy_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERequestedBy"
            BehaviorID="B_ACERequestedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequestedByCompletionList"
            TargetControlID="F_RequestedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACERequestedBy_Selected"
            OnClientPopulating="ACERequestedBy_Populating"
            OnClientPopulated="ACERequestedBy_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestTypeID" runat="server" Text="Request Type :" /></b>
				</td>
        <td>
          <LGM:LC_erpRequestTypes
            ID="F_RequestTypeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="RequestTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_StatusID" runat="server" Text="STATUS :" /></b>
				</td>
        <td>
          <LGM:LC_erpRequestStatus
            ID="F_StatusID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="StatusID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PriorityID" runat="server" Text="PRIORITY :" /></b>
				</td>
        <td>
          <LGM:LC_erpRequestPriority
            ID="F_PriorityID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="PriorityID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
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
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
		<script type="text/javascript"> 
   var script_EvaluationByIT = {
		temp: function() {
		}
		}
		</script>
    <script type="text/javascript">
      var pcnt = 0;
      function show_notes(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = o.getAttribute('CommandValue');
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVerpEvaluateByIT" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSerpEvaluateByIT" DataKeyNames="ApplID,RequestID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="30px" CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="30px" CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NOTE">
          <ItemTemplate>
            <asp:ImageButton ID="cmdNotes" runat="server" AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="View/reply Notes in TA Bill" SkinID="notes" CommandValue='<%# Eval("GetNotesLink") %>' OnClientClick="return show_notes(this);" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request ID" SortExpression="RequestID">
          <ItemTemplate>
            <asp:Label ID="LabelRequestID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested By" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_RequestedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestedBy") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Type" SortExpression="ERP_RequestTypes6_Description">
          <ItemTemplate>
             <asp:Label ID="L_RequestTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestTypeID") %>' Text='<%# Eval("ERP_RequestTypes6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Brief Problem (Improvement) Statement" SortExpression="ChangeSubject">
          <ItemTemplate>
            <div class="page" style="height:40px;width:400px;margin:0px;">
            <asp:Label ID="LabelChangeSubject" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ChangeSubject") %>'></asp:Label>
            </div>
          </ItemTemplate>
          <HeaderStyle Width="300px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approved On" SortExpression="ApprovedOn">
          <ItemTemplate>
            <asp:Label ID="LabelApprovedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Evaluated By IT On" SortExpression="EvaluationByITOn">
          <ItemTemplate>
            <asp:Label ID="LabelEvaluationByITOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EvaluationByITOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STATUS" SortExpression="ERP_RequestStatus5_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("ERP_RequestStatus5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Evaluation By IT" SortExpression="EvaluationByIT">
          <ItemTemplate>
					<asp:TextBox ID="F_EvaluationByIT"
						Text='<%# Bind("EvaluationByIT") %>'
            Width="150px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Evaluation By IT."
						MaxLength="2000"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEvaluationByIT"
						runat = "server"
						ControlToValidate = "F_EvaluationByIT"
						Text = "Evaluation By IT is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = '<%# "Reject" & Container.DataItemIndex %>'
						SetFocusOnError="true" />

          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reject">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reject" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Reject record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
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
      ID = "ODSerpEvaluateByIT"
      runat = "server"
      DataObjectTypeName = "SIS.ERP.erpEvaluateByIT"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_erpEvaluateByITSelectList"
      TypeName = "SIS.ERP.erpEvaluateByIT"
      SelectCountMethod = "erpEvaluateByITSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ApplID" PropertyName="Text" Name="ApplID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RequestedBy" PropertyName="Text" Name="RequestedBy" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_RequestTypeID" PropertyName="SelectedValue" Name="RequestTypeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="SelectedValue" Name="StatusID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_PriorityID" PropertyName="SelectedValue" Name="PriorityID" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVerpEvaluateByIT" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ApplID" />
    <asp:AsyncPostBackTrigger ControlID="F_RequestedBy" />
    <asp:AsyncPostBackTrigger ControlID="F_RequestTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
    <asp:AsyncPostBackTrigger ControlID="F_PriorityID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
