<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_lgWTFile.aspx.vb" Inherits="EF_lgWTFile" title="Edit: WT File Details" %>
<asp:Content ID="CPHlgWTFile" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgWTFile" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabellgWTFile" runat="server" Text="&nbsp;Edit: WT File Details" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgWTFile"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    EnableSave="false"
    PrintUrl = "../App_Print/RP_lgWTFile.aspx?pk="
    ValidationGroup = "lgWTFile"
    Skin = "tbl_blue"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVlgWTFile"
	runat = "server"
	DataKeyNames = "DocPK,FilePK"
	DataSourceID = "ODSlgWTFile"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocPK" runat="server" ForeColor="#CC6633" Text="DocPK :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocPK"
            Width="133px"
						Text='<%# Bind("DocPK") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of DocPK."
						Runat="Server" />
					<asp:Label
						ID = "F_DocPK_Display"
						Text='<%# Eval("LG_WTDocument2_DocumentID") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FilePK" runat="server" ForeColor="#CC6633" Text="FilePK :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FilePK"
						Text='<%# Bind("FilePK") %>'
            ToolTip="Value of FilePK."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="133px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentID"
						Text='<%# Bind("DocumentID") %>'
            Width="224px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
						MaxLength="32"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentID"
						runat = "server"
						ControlToValidate = "F_DocumentID"
						Text = "Document ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Revision."
						MaxLength="10"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRevision"
						runat = "server"
						ControlToValidate = "F_Revision"
						Text = "Revision is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Iteration."
						MaxLength="10"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVIteration"
						runat = "server"
						ControlToValidate = "F_Iteration"
						Text = "Iteration is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Status."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVStatus"
						runat = "server"
						ControlToValidate = "F_Status"
						Text = "Status is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
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
						ValidationGroup = "lgWTFile"
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
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
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
						ValidationGroup = "lgWTFile"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Title."
						MaxLength="160"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTitle"
						runat = "server"
						ControlToValidate = "F_Title"
						Text = "Title is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Doc Type."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocType"
						runat = "server"
						ControlToValidate = "F_DocType"
						Text = "Doc Type is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
            Width="140px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Attachment."
						MaxLength="20"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVAttachment"
						runat = "server"
						ControlToValidate = "F_Attachment"
						Text = "Attachment is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
						Text='<%# Bind("ProjectID") %>'
						AutoCompleteType = "None"
            Width="140px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
						ValidationGroup = "lgWTFile"
            onblur= "script_lgWTFile.validate_ProjectID(this);"
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
						ValidationGroup = "lgWTFile"
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
            OnClientItemSelected="script_lgWTFile.ACEProjectID_Selected"
            OnClientPopulating="script_lgWTFile.ACEProjectID_Populating"
            OnClientPopulated="script_lgWTFile.ACEProjectID_Populated"
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
            Width="56px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Element ID."
						MaxLength="8"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVElementID"
						runat = "server"
						ControlToValidate = "F_ElementID"
						Text = "Element ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Description."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectDescription"
						runat = "server"
						ControlToValidate = "F_ProjectDescription"
						Text = "Project Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Element Description."
						MaxLength="200"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVElementDescription"
						runat = "server"
						ControlToValidate = "F_ElementDescription"
						Text = "Element Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Disk File Name."
						MaxLength="256"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDiskFileName"
						runat = "server"
						ControlToValidate = "F_DiskFileName"
						Text = "Disk File Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_category" runat="server" Text="Category :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_category"
						Text='<%# Bind("category") %>'
            Width="140px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category."
						MaxLength="20"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVcategory"
						runat = "server"
						ControlToValidate = "F_category"
						Text = "Category is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_fileSize" runat="server" Text="File Size :" /></b>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FileNumber" runat="server" Text="File Number :" /></b>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_path" runat="server" Text="Path :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_path"
						Text='<%# Bind("path") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Path."
						MaxLength="200"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVpath"
						runat = "server"
						ControlToValidate = "F_path"
						Text = "Path is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DownloadedFileLocation" runat="server" Text="Downloaded File Location :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DownloadedFileLocation"
						Text='<%# Bind("DownloadedFileLocation") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Downloaded File Location."
						MaxLength="1000"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDownloadedFileLocation"
						runat = "server"
						ControlToValidate = "F_DownloadedFileLocation"
						Text = "Downloaded File Location is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DownloadedFileName" runat="server" Text="Downloaded File Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DownloadedFileName"
						Text='<%# Bind("DownloadedFileName") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Downloaded File Name."
						MaxLength="200"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDownloadedFileName"
						runat = "server"
						ControlToValidate = "F_DownloadedFileName"
						Text = "Downloaded File Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTFile"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSlgWTFile"
  DataObjectTypeName = "SIS.LG.lgWTFile"
  SelectMethod = "lgWTFileGetByID"
  UpdateMethod="lgWTFileUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgWTFile"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocPK" Name="DocPK" Type="Int64" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FilePK" Name="FilePK" Type="Int64" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
