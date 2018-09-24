<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_lgEPFile.aspx.vb" Inherits="AF_lgEPFile" title="Add: EPM File Details" %>
<asp:Content ID="CPHlgEPFile" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgEPFile" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabellgEPFile" runat="server" Text="&nbsp;Add: EPM File Details" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgEPFile"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "lgEPFile"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVlgEPFile"
	runat = "server"
	DataKeyNames = "DocPK,FilePK"
	DataSourceID = "ODSlgEPFile"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsglgEPFile" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocPK" ForeColor="#CC6633" runat="server" Text="DocPK :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocPK"
						CssClass = "mypktxt"
            Width="133px"
						Text='<%# Bind("DocPK") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for DocPK."
						ValidationGroup = "lgEPFile"
            onblur= "script_lgEPFile.validate_DocPK(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DocPK_Display"
						Text='<%# Eval("LG_EPDocument1_DocumentID") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocPK"
						runat = "server"
						ControlToValidate = "F_DocPK"
						Text = "DocPK is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEDocPK"
            BehaviorID="B_ACEDocPK"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DocPKCompletionList"
            TargetControlID="F_DocPK"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_lgEPFile.ACEDocPK_Selected"
            OnClientPopulating="script_lgEPFile.ACEDocPK_Populating"
            OnClientPopulated="script_lgEPFile.ACEDocPK_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FilePK" ForeColor="#CC6633" runat="server" Text="FilePK :" /></b>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentID" runat="server" Text="DocumentID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentID"
						Text='<%# Bind("DocumentID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DocumentID."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentID"
						runat = "server"
						ControlToValidate = "F_DocumentID"
						Text = "DocumentID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
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
						ValidationGroup="lgEPFile"
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
						ValidationGroup = "lgEPFile"
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
						ValidationGroup="lgEPFile"
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
						ValidationGroup = "lgEPFile"
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
						ValidationGroup="lgEPFile"
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
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedOn" runat="server" Text="CreatedOn :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedOn"
						Text='<%# Bind("CreatedOn") %>'
            Width="100px"
						CssClass = "mytxt"
						ValidationGroup="lgEPFile"
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
						InvalidValueMessage = "Invalid value for CreatedOn."
						EmptyValueMessage = "CreatedOn is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for CreatedOn."
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UpdatedOn" runat="server" Text="UpdatedOn :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_UpdatedOn"
						Text='<%# Bind("UpdatedOn") %>'
            Width="100px"
						CssClass = "mytxt"
						ValidationGroup="lgEPFile"
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
						InvalidValueMessage = "Invalid value for UpdatedOn."
						EmptyValueMessage = "UpdatedOn is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for UpdatedOn."
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						IsValidEmpty = "false"
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
						ValidationGroup="lgEPFile"
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
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocType" runat="server" Text="DocType :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocType"
						Text='<%# Bind("DocType") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DocType."
						MaxLength="12"
            Width="84px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocType"
						runat = "server"
						ControlToValidate = "F_DocType"
						Text = "DocType is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Attachment" runat="server" Text="Attachment :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Attachment"
						Text='<%# Bind("Attachment") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Attachment."
						MaxLength="20"
            Width="140px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVAttachment"
						runat = "server"
						ControlToValidate = "F_Attachment"
						Text = "Attachment is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="ProjectID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
            Width="140px"
						Text='<%# Bind("ProjectID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for ProjectID."
						ValidationGroup = "lgEPFile"
            onblur= "script_lgEPFile.validate_ProjectID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("LG_Projects2_ProjectDescription") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "ProjectID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
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
            OnClientItemSelected="script_lgEPFile.ACEProjectID_Selected"
            OnClientPopulating="script_lgEPFile.ACEProjectID_Populating"
            OnClientPopulated="script_lgEPFile.ACEProjectID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ElementID" runat="server" Text="ElementID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ElementID"
						Text='<%# Bind("ElementID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ElementID."
						MaxLength="8"
            Width="56px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVElementID"
						runat = "server"
						ControlToValidate = "F_ElementID"
						Text = "ElementID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectDescription" runat="server" Text="ProjectDescription :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectDescription"
						Text='<%# Bind("ProjectDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ProjectDescription."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectDescription"
						runat = "server"
						ControlToValidate = "F_ProjectDescription"
						Text = "ProjectDescription is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ElementDescription" runat="server" Text="ElementDescription :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ElementDescription"
						Text='<%# Bind("ElementDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ElementDescription."
						MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVElementDescription"
						runat = "server"
						ControlToValidate = "F_ElementDescription"
						Text = "ElementDescription is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiskFileName" runat="server" Text="DiskFileName :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DiskFileName"
						Text='<%# Bind("DiskFileName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DiskFileName."
						MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDiskFileName"
						runat = "server"
						ControlToValidate = "F_DiskFileName"
						Text = "DiskFileName is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_category" runat="server" Text="category :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_category"
						Text='<%# Bind("category") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for category."
						MaxLength="20"
            Width="140px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVcategory"
						runat = "server"
						ControlToValidate = "F_category"
						Text = "category is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_fileSize" runat="server" Text="fileSize :" /></b>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FileNumber" runat="server" Text="FileNumber :" /></b>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_path" runat="server" Text="path :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_path"
						Text='<%# Bind("path") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for path."
						MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVpath"
						runat = "server"
						ControlToValidate = "F_path"
						Text = "path is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPFile"
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
  ID = "ODSlgEPFile"
  DataObjectTypeName = "SIS.LG.lgEPFile"
  InsertMethod="lgEPFileInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgEPFile"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
