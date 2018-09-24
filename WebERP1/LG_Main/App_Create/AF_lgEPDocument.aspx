<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_lgEPDocument.aspx.vb" Inherits="AF_lgEPDocument" title="Add: Document" %>
<asp:Content ID="CPHlgEPDocument" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgEPDocument" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabellgEPDocument" runat="server" Text="&nbsp;Add: Document" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgEPDocument"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/LG_Main/App_Edit/EF_lgEPDocument.aspx"
    ValidationGroup = "lgEPDocument"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVlgEPDocument"
	runat = "server"
	DataKeyNames = "DocPK"
	DataSourceID = "ODSlgEPDocument"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsglgEPDocument" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocPK" ForeColor="#CC6633" runat="server" Text="Doc PK :" /></b>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentID" runat="server" Text="Document Number :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentID"
						Text='<%# Bind("DocumentID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document Number."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentID"
						runat = "server"
						ControlToValidate = "F_DocumentID"
						Text = "Document Number is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Revision" runat="server" Text="Revision :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Revision"
						Text='<%# Bind("Revision") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Revision."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRevision"
						runat = "server"
						ControlToValidate = "F_Revision"
						Text = "Revision is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Iteration" runat="server" Text="Iteration :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Iteration"
						Text='<%# Bind("Iteration") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Iteration."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVIteration"
						runat = "server"
						ControlToValidate = "F_Iteration"
						Text = "Iteration is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Status" runat="server" Text="Status :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Status"
						Text='<%# Bind("Status") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Status."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVStatus"
						runat = "server"
						ControlToValidate = "F_Status"
						Text = "Status is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Title" runat="server" Text="Title :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Title"
						Text='<%# Bind("Title") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Title."
						MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTitle"
						runat = "server"
						ControlToValidate = "F_Title"
						Text = "Title is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedOn"
						Text='<%# Bind("CreatedOn") %>'
            Width="100px"
						CssClass = "mytxt"
						ValidationGroup="lgEPDocument"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonCreatedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CECreatedOn"
            TargetControlID="F_CreatedOn"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonCreatedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEECreatedOn"
						runat = "server"
						mask = "99/99/9999 99:99"
						MaskType="DateTime"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_CreatedOn" />
					<AJX:MaskedEditValidator 
						ID = "MEVCreatedOn"
						runat = "server"
						ControlToValidate = "F_CreatedOn"
						ControlExtender = "MEECreatedOn"
						InvalidValueMessage = "Invalid value for Created On."
						EmptyValueMessage = "Created On is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Created On."
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UpdatedOn" runat="server" Text="Updated On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_UpdatedOn"
						Text='<%# Bind("UpdatedOn") %>'
            Width="100px"
						CssClass = "mytxt"
						ValidationGroup="lgEPDocument"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonUpdatedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEUpdatedOn"
            TargetControlID="F_UpdatedOn"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonUpdatedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEEUpdatedOn"
						runat = "server"
						mask = "99/99/9999 99:99"
						MaskType="DateTime"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_UpdatedOn" />
					<AJX:MaskedEditValidator 
						ID = "MEVUpdatedOn"
						runat = "server"
						ControlToValidate = "F_UpdatedOn"
						ControlExtender = "MEEUpdatedOn"
						InvalidValueMessage = "Invalid value for Updated On."
						EmptyValueMessage = "Updated On is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Updated On."
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocType" runat="server" Text="Doc Type :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocType"
						Text='<%# Bind("DocType") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Doc Type."
						MaxLength="12"
            Width="84px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocType"
						runat = "server"
						ControlToValidate = "F_DocType"
						Text = "Doc Type is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
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
            Width="140px"
						Text='<%# Bind("ProjectID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
						ValidationGroup = "lgEPDocument"
            onblur= "script_lgEPDocument.validate_ProjectID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("LG_Projects1_ProjectDescription") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "Project ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_lgEPDocument.ACEProjectID_Selected"
            OnClientPopulating="script_lgEPDocument.ACEProjectID_Populating"
            OnClientPopulated="script_lgEPDocument.ACEProjectID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ElementID" runat="server" Text="Element ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ElementID"
						Text='<%# Bind("ElementID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Element ID."
						MaxLength="8"
            Width="56px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVElementID"
						runat = "server"
						ControlToValidate = "F_ElementID"
						Text = "Element ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectDescription" runat="server" Text="Project Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectDescription"
						Text='<%# Bind("ProjectDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Description."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectDescription"
						runat = "server"
						ControlToValidate = "F_ProjectDescription"
						Text = "Project Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ElementDescription" runat="server" Text="Element Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ElementDescription"
						Text='<%# Bind("ElementDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Element Description."
						MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVElementDescription"
						runat = "server"
						ControlToValidate = "F_ElementDescription"
						Text = "Element Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiskFileName" runat="server" Text="Disk File Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DiskFileName"
						Text='<%# Bind("DiskFileName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Disk File Name."
						MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDiskFileName"
						runat = "server"
						ControlToValidate = "F_DiskFileName"
						Text = "Disk File Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDocument"
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
  ID = "ODSlgEPDocument"
  DataObjectTypeName = "SIS.LG.lgEPDocument"
  InsertMethod="lgEPDocumentInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgEPDocument"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
