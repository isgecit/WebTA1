<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpRequestAttachments.aspx.vb" Inherits="AF_erpRequestAttachments" title="Add: Attachments" %>
<asp:Content ID="CPHerpRequestAttachments" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRequestAttachments" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpRequestAttachments" runat="server" Text="&nbsp;Add: Attachments" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRequestAttachments"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpRequestAttachments"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRequestAttachments"
	runat = "server"
	DataKeyNames = "ApplID,RequestID,SerialNo"
	DataSourceID = "ODSerpRequestAttachments"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpRequestAttachments" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
						ValidationGroup = "erpRequestAttachments"
            onblur= "script_erpRequestAttachments.validate_ApplID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ApplID_Display"
						Text='<%# Eval("ERP_Applications1_ApplName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVApplID"
						runat = "server"
						ControlToValidate = "F_ApplID"
						Text = "Appl ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpRequestAttachments"
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
            OnClientItemSelected="script_erpRequestAttachments.ACEApplID_Selected"
            OnClientPopulating="script_erpRequestAttachments.ACEApplID_Populating"
            OnClientPopulated="script_erpRequestAttachments.ACEApplID_Populated"
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
					<asp:TextBox
						ID = "F_RequestID"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("RequestID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Request ID."
						ValidationGroup = "erpRequestAttachments"
            onblur= "script_erpRequestAttachments.validate_RequestID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestID_Display"
						Text='<%# Eval("ERP_ChaneRequest2_ChangeSubject") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRequestID"
						runat = "server"
						ControlToValidate = "F_RequestID"
						Text = "Request ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpRequestAttachments"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACERequestID"
            BehaviorID="B_ACERequestID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequestIDCompletionList"
            TargetControlID="F_RequestID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpRequestAttachments.ACERequestID_Selected"
            OnClientPopulating="script_erpRequestAttachments.ACERequestID_Populating"
            OnClientPopulated="script_erpRequestAttachments.ACERequestID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpRequestAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpRequestAttachments"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FileName" runat="server" Text="File Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FileName"
						Text='<%# Bind("FileName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpRequestAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File Name."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVFileName"
						runat = "server"
						ControlToValidate = "F_FileName"
						Text = "File Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpRequestAttachments"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiskFile" runat="server" Text="Disk File :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DiskFile"
						Text='<%# Bind("DiskFile") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpRequestAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Disk File."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDiskFile"
						runat = "server"
						ControlToValidate = "F_DiskFile"
						Text = "Disk File is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpRequestAttachments"
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
  ID = "ODSerpRequestAttachments"
  DataObjectTypeName = "SIS.ERP.erpRequestAttachments"
  InsertMethod="erpRequestAttachmentsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRequestAttachments"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
