<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpChaneRequest.aspx.vb" Inherits="AF_erpChaneRequest" title="Add: Change Request" %>
<asp:Content ID="CPHerpChaneRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpChaneRequest" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpChaneRequest" runat="server" Text="&nbsp;Add: Change Request" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpChaneRequest"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/ERP_Main/App_Edit/EF_erpChaneRequest.aspx"
    ValidationGroup = "erpChaneRequest"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpChaneRequest"
	runat = "server"
	DataKeyNames = "ApplID,RequestID"
	DataSourceID = "ODSerpChaneRequest"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpChaneRequest" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApplID" ForeColor="#CC6633" runat="server" Text="Appl ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ApplID"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("ApplID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Appl ID."
						ValidationGroup = "erpChaneRequest"
            onblur= "script_erpChaneRequest.validate_ApplID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ApplID_Display"
						Text='<%# Eval("ERP_Applications3_ApplName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVApplID"
						runat = "server"
						ControlToValidate = "F_ApplID"
						Text = "Appl ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpChaneRequest"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEApplID"
            BehaviorID="B_ACEApplID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApplIDCompletionList"
            TargetControlID="F_ApplID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpChaneRequest.ACEApplID_Selected"
            OnClientPopulating="script_erpChaneRequest.ACEApplID_Populating"
            OnClientPopulated="script_erpChaneRequest.ACEApplID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestID" ForeColor="#CC6633" runat="server" Text="Request ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestTypeID" runat="server" Text="Request Type :" /></b>
				</td>
        <td>
          <LGM:LC_erpRequestTypes
            ID="F_RequestTypeID"
            SelectedValue='<%# Bind("RequestTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "erpChaneRequest"
            RequiredFieldErrorMessage = "Request Type is required."
            onblur= "script_erpChaneRequest.validate_RequestTypeID(this);"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChangeSubject" runat="server" Text="Brief Problem (Improvement) Statement :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChangeSubject"
						Text='<%# Bind("ChangeSubject") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpChaneRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Brief Problem (Improvement) Statement."
						MaxLength="1000"
            Width="700px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVChangeSubject"
						runat = "server"
						ControlToValidate = "F_ChangeSubject"
						Text = "Brief Problem (Improvement) Statement is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpChaneRequest"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChangeDetails" runat="server" Text="Change Requested (In Detail) :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChangeDetails"
						Text='<%# Bind("ChangeDetails") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpChaneRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Change Requested (In Detail)."
						MaxLength="2000"
            Width="700px" Height="80px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVChangeDetails"
						runat = "server"
						ControlToValidate = "F_ChangeDetails"
						Text = "Change Requested (In Detail) is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpChaneRequest"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
		<br />
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpChaneRequest"
  DataObjectTypeName = "SIS.ERP.erpChaneRequest"
  InsertMethod="UZ_erpChaneRequestInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpChaneRequest"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
