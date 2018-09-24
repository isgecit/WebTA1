<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_erpUserRoles.aspx.vb" Inherits="GF_erpUserRoles" title="Maintain List: User Roles" %>
<asp:Content ID="CPHerpUserRoles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpUserRoles" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelerpUserRoles" runat="server" Text="&nbsp;List: User Roles" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLerpUserRoles"
      ToolType = "lgNMGrid"
      EditUrl = "~/ERP_Main/App_Edit/EF_erpUserRoles.aspx"
      AddUrl = "~/ERP_Main/App_Create/AF_erpUserRoles.aspx"
      ValidationGroup = "erpUserRoles"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSerpUserRoles" runat="server" AssociatedUpdatePanelID="UPNLerpUserRoles" DisplayAfter="100">
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
					<b><asp:Label ID="L_RequesterID" runat="server" Text="User  :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequesterID"
						CssClass = "myfktxt"
            Width="56px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_RequesterID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_RequesterID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERequesterID"
            BehaviorID="B_ACERequesterID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequesterIDCompletionList"
            TargetControlID="F_RequesterID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACERequesterID_Selected"
            OnClientPopulating="ACERequesterID_Populating"
            OnClientPopulated="ACERequesterID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApproverID" runat="server" Text="Approver (If user is Requester) :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ApproverID"
						CssClass = "myfktxt"
            Width="56px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_ApproverID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ApproverID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEApproverID"
            BehaviorID="B_ACEApproverID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApproverIDCompletionList"
            TargetControlID="F_ApproverID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEApproverID_Selected"
            OnClientPopulating="ACEApproverID_Populating"
            OnClientPopulated="ACEApproverID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RoleID" runat="server" Text="User Role :" /></b>
				</td>
        <td>
          <LGM:LC_erpRoles
            ID="F_RoleID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="RoleID"
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
    <br />
    <asp:GridView ID="GVerpUserRoles" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSerpUserRoles" DataKeyNames="SerialNo">
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
        <asp:TemplateField HeaderText="User " SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_RequesterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequesterID") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approver (If user is Requester)" SortExpression="aspnet_Users2_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ApproverID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ApproverID") %>' Text='<%# Eval("aspnet_Users2_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User Role" SortExpression="ERP_Roles3_Description">
          <ItemTemplate>
             <asp:Label ID="L_RoleID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RoleID") %>' Text='<%# Eval("ERP_Roles3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSerpUserRoles"
      runat = "server"
      DataObjectTypeName = "SIS.ERP.erpUserRoles"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "erpUserRolesSelectList"
      TypeName = "SIS.ERP.erpUserRoles"
      SelectCountMethod = "erpUserRolesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_RequesterID" PropertyName="Text" Name="RequesterID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_ApproverID" PropertyName="Text" Name="ApproverID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_RoleID" PropertyName="SelectedValue" Name="RoleID" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVerpUserRoles" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_RequesterID" />
    <asp:AsyncPostBackTrigger ControlID="F_ApproverID" />
    <asp:AsyncPostBackTrigger ControlID="F_RoleID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
