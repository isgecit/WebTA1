<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_lgWTDocument.aspx.vb" Inherits="EF_lgWTDocument" title="Edit: WT Documents" %>
<asp:Content ID="CPHlgWTDocument" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgWTDocument" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabellgWTDocument" runat="server" Text="&nbsp;Edit: WT Documents" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgWTDocument"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    EnableSave="false"
    PrintUrl = "../App_Print/RP_lgWTDocument.aspx?pk="
    ValidationGroup = "lgWTDocument"
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
<asp:FormView ID="FVlgWTDocument"
	runat = "server"
	DataKeyNames = "DocPK"
	DataSourceID = "ODSlgWTDocument"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocPK" runat="server" ForeColor="#CC6633" Text="DocPK :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocPK"
						Text='<%# Bind("DocPK") %>'
            ToolTip="Value of DocPK."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="133px"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentID"
						Text='<%# Bind("DocumentID") %>'
            Width="224px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
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
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Iteration" runat="server" Text="Iteration :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Iteration"
						Text='<%# Bind("Iteration") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
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
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedOn"
						Text='<%# Bind("CreatedOn") %>'
            Width="100px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
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
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Title" runat="server" Text="Title :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Title"
						Text='<%# Bind("Title") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTDocument"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Doc Type."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocType"
						runat = "server"
						ControlToValidate = "F_DocType"
						Text = "Doc Type is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgWTDocument"
						SetFocusOnError="true" />
				</td>
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
						ValidationGroup = "lgWTDocument"
            onblur= "script_lgWTDocument.validate_ProjectID(this);"
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
						ValidationGroup = "lgWTDocument"
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
            OnClientItemSelected="script_lgWTDocument.ACEProjectID_Selected"
            OnClientPopulating="script_lgWTDocument.ACEProjectID_Populating"
            OnClientPopulated="script_lgWTDocument.ACEProjectID_Populated"
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
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectDescription" runat="server" Text="Project Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectDescription"
						Text='<%# Bind("ProjectDescription") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
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
						ValidationGroup="lgWTDocument"
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
						ValidationGroup = "lgWTDocument"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
<asp:UpdatePanel ID="UPNLlgWTFile" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgWTFile" runat="server" Text="&nbsp;List: WT File Details" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLlgWTFile"
      ToolType = "lgNMGrid"
      EditUrl = "~/LG_Main/App_Edit/EF_lgWTFile.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "lgWTFile"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSlgWTFile" runat="server" AssociatedUpdatePanelID="UPNLlgWTFile" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
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
      function script_download(id, typ, id1) {
      	pcnt = pcnt + 1;
      	var nam = 'wdwd' + pcnt;
      	var url = self.location.href.replace('App_Edit/EF_lgWTDocument.aspx', 'App_Download/filedownload.aspx');
      	url = url + '&id=' + id + '&typ=' + typ + '&id1=' + id1;
      	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
      	return false;
      }
    </script>
    <asp:GridView ID="GVlgWTFile" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSlgWTFile" DataKeyNames="DocPK,FilePK">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FilePK" SortExpression="FilePK">
          <ItemTemplate>
            <asp:Label ID="LabelFilePK" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FilePK") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revision" SortExpression="Revision">
          <ItemTemplate>
            <asp:Label ID="LabelRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Revision") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Iteration" SortExpression="Iteration">
          <ItemTemplate>
            <asp:Label ID="LabelIteration" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Iteration") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="Status">
          <ItemTemplate>
            <asp:Label ID="LabelStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Status") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Updated On" SortExpression="UpdatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelUpdatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UpdatedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="Title">
          <ItemTemplate>
            <asp:Label ID="LabelTitle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Title") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Doc Type" SortExpression="DocType">
          <ItemTemplate>
            <asp:Label ID="LabelDocType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocType") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="LG_Projects1_ProjectDescription">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("LG_Projects1_ProjectDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element ID" SortExpression="ElementID">
          <ItemTemplate>
            <asp:Label ID="LabelElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ElementID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Disk File Name" SortExpression="DiskFileName">
          <ItemTemplate>
            <asp:Label ID="LabelDiskFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DiskFileName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSlgWTFile"
      runat = "server"
      DataObjectTypeName = "SIS.LG.lgWTFile"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_lgWTFileSelectList"
      TypeName = "SIS.LG.lgWTFile"
      SelectCountMethod = "lgWTFileSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DocPK" PropertyName="Text" Name="DocPK" Type="Int64" Size="19" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVlgWTFile" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UPNLlgWTAttachment" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgWTAttachment" runat="server" Text="&nbsp;List: WT Attachments" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLlgWTAttachment"
      ToolType = "lgNMGrid"
      EditUrl = "~/LG_Main/App_Edit/EF_lgWTAttachment.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "lgWTAttachment"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSlgWTAttachment" runat="server" AssociatedUpdatePanelID="UPNLlgWTAttachment" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
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
    <asp:GridView ID="GVlgWTAttachment" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSlgWTAttachment" DataKeyNames="DocPK,FilePK">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FilePK" SortExpression="FilePK">
          <ItemTemplate>
            <asp:Label ID="LabelFilePK" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FilePK") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:LinkButton ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("DocumentID") %>' OnClientClick='<%# Eval("GetLink") %>' CommandName="DownloadFile" CommandArgument='<%# Container.DataItemIndex %>'  ></asp:LinkButton>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revision" SortExpression="Revision">
          <ItemTemplate>
            <asp:Label ID="LabelRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Revision") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Iteration" SortExpression="Iteration">
          <ItemTemplate>
            <asp:Label ID="LabelIteration" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Iteration") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="Status">
          <ItemTemplate>
            <asp:Label ID="LabelStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Status") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Updated On" SortExpression="UpdatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelUpdatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UpdatedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="Title">
          <ItemTemplate>
            <asp:Label ID="LabelTitle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Title") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Doc Type" SortExpression="DocType">
          <ItemTemplate>
            <asp:Label ID="LabelDocType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocType") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="LG_Projects1_ProjectDescription">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("LG_Projects1_ProjectDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element ID" SortExpression="ElementID">
          <ItemTemplate>
            <asp:Label ID="LabelElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ElementID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Disk File Name" SortExpression="DiskFileName">
          <ItemTemplate>
            <asp:Label ID="LabelDiskFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DiskFileName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSlgWTAttachment"
      runat = "server"
      DataObjectTypeName = "SIS.LG.lgWTAttachment"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_lgWTAttachmentSelectList"
      TypeName = "SIS.LG.lgWTAttachment"
      SelectCountMethod = "lgWTAttachmentSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DocPK" PropertyName="Text" Name="DocPK" Type="Int64" Size="19" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVlgWTAttachment" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UPNLlgWTAttributes" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgWTAttributes" runat="server" Text="&nbsp;List: WT Attributes" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLlgWTAttributes"
      ToolType = "lgNMGrid"
      EditUrl = "~/LG_Main/App_Edit/EF_lgWTAttributes.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "lgWTAttributes"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSlgWTAttributes" runat="server" AssociatedUpdatePanelID="UPNLlgWTAttributes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
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
    <asp:GridView ID="GVlgWTAttributes" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSlgWTAttributes" DataKeyNames="DocPK,displayName">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Attribute Name" SortExpression="displayName">
          <ItemTemplate>
            <asp:Label ID="LabeldisplayName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("displayName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value" SortExpression="value">
          <ItemTemplate>
            <asp:Label ID="Labelvalue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("value") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSlgWTAttributes"
      runat = "server"
      DataObjectTypeName = "SIS.LG.lgWTAttributes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_lgWTAttributesSelectList"
      TypeName = "SIS.LG.lgWTAttributes"
      SelectCountMethod = "lgWTAttributesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DocPK" PropertyName="Text" Name="DocPK" Type="Int64" Size="19" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVlgWTAttributes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UPNLlgWTDCR" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgWTDCR" runat="server" Text="&nbsp;List: WT DCR" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLlgWTDCR"
      ToolType = "lgNMGrid"
      EditUrl = "~/LG_Main/App_Edit/EF_lgWTDCR.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "lgWTDCR"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSlgWTDCR" runat="server" AssociatedUpdatePanelID="UPNLlgWTDCR" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
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
    <asp:GridView ID="GVlgWTDCR" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSlgWTDCR" DataKeyNames="DocPK,DCRID,DCRLine">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR ID" SortExpression="DCRID">
          <ItemTemplate>
            <asp:Label ID="LabelDCRID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR Line" SortExpression="DCRLine">
          <ItemTemplate>
            <asp:Label ID="LabelDCRLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRLine") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR Description" SortExpression="DCRDescription">
          <ItemTemplate>
            <asp:Label ID="LabelDCRDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR Created On" SortExpression="DCRCreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelDCRCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRCreatedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR Category" SortExpression="DCRCategory">
          <ItemTemplate>
            <asp:Label ID="LabelDCRCategory" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRCategory") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Priority" SortExpression="RequestPriority">
          <ItemTemplate>
            <asp:Label ID="LabelRequestPriority" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestPriority") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approval Required Date" SortExpression="ApprovalRequiredDate">
          <ItemTemplate>
            <asp:Label ID="LabelApprovalRequiredDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovalRequiredDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCR State" SortExpression="DCRState">
          <ItemTemplate>
            <asp:Label ID="LabelDCRState" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRState") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSlgWTDCR"
      runat = "server"
      DataObjectTypeName = "SIS.LG.lgWTDCR"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_lgWTDCRSelectList"
      TypeName = "SIS.LG.lgWTDCR"
      SelectCountMethod = "lgWTDCRSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DocPK" PropertyName="Text" Name="DocPK" Type="Int64" Size="19" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVlgWTDCR" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSlgWTDocument"
  DataObjectTypeName = "SIS.LG.lgWTDocument"
  SelectMethod = "lgWTDocumentGetByID"
  UpdateMethod="lgWTDocumentUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgWTDocument"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocPK" Name="DocPK" Type="Int64" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
