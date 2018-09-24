<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpUserRoles.aspx.vb" Inherits="EF_erpUserRoles" title="Edit: User Roles" %>
<asp:Content ID="CPHerpUserRoles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpUserRoles" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpUserRoles" runat="server" Text="&nbsp;Edit: User Roles" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpUserRoles"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "erpUserRoles"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpUserRoles"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSerpUserRoles"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequesterID" runat="server" Text="User  :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequesterID"
						CssClass = "myfktxt"
						Text='<%# Bind("RequesterID") %>'
						AutoCompleteType = "None"
            Width="56px"
						onfocus = "return this.select();"
            ToolTip="Enter value for User ."
						ValidationGroup = "erpUserRoles"
            onblur= "script_erpUserRoles.validate_RequesterID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_RequesterID_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRequesterID"
						runat = "server"
						ControlToValidate = "F_RequesterID"
						Text = "User  is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpUserRoles"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACERequesterID"
            BehaviorID="B_ACERequesterID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequesterIDCompletionList"
            TargetControlID="F_RequesterID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpUserRoles.ACERequesterID_Selected"
            OnClientPopulating="script_erpUserRoles.ACERequesterID_Populating"
            OnClientPopulated="script_erpUserRoles.ACERequesterID_Populated"
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
						Text='<%# Bind("ApproverID") %>'
						AutoCompleteType = "None"
            Width="56px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Approver (If user is Requester)."
            onblur= "script_erpUserRoles.validate_ApproverID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ApproverID_Display"
						Text='<%# Eval("aspnet_Users2_UserFullName") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEApproverID"
            BehaviorID="B_ACEApproverID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApproverIDCompletionList"
            TargetControlID="F_ApproverID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpUserRoles.ACEApproverID_Selected"
            OnClientPopulating="script_erpUserRoles.ACEApproverID_Populating"
            OnClientPopulated="script_erpUserRoles.ACEApproverID_Populated"
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
            SelectedValue='<%# Bind("RoleID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myfktxt"
						ValidationGroup = "erpUserRoles"
            RequiredFieldErrorMessage = "User Role is required."
            onblur= "script_erpUserRoles.validate_RoleID(this);"
            Runat="Server" />
          </td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpUserRoles"
  DataObjectTypeName = "SIS.ERP.erpUserRoles"
  SelectMethod = "erpUserRolesGetByID"
  UpdateMethod="erpUserRolesUpdate"
  DeleteMethod="erpUserRolesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpUserRoles"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
