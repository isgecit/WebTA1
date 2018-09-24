<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_lgEPDCR.aspx.vb" Inherits="EF_lgEPDCR" title="Edit: EPM DCR" %>
<asp:Content ID="CPHlgEPDCR" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgEPDCR" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabellgEPDCR" runat="server" Text="&nbsp;Edit: EPM DCR" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgEPDCR"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    EnableSave="false"
    PrintUrl = "../App_Print/RP_lgEPDCR.aspx?pk="
    ValidationGroup = "lgEPDCR"
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
<asp:FormView ID="FVlgEPDCR"
	runat = "server"
	DataKeyNames = "DocPK,DCRID,DCRLine"
	DataSourceID = "ODSlgEPDCR"
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
						Text='<%# Eval("LG_EPDocument1_DocumentID") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRID" runat="server" ForeColor="#CC6633" Text="DCR ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRID"
						Text='<%# Bind("DCRID") %>'
            ToolTip="Value of DCR ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="224px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRLine" runat="server" ForeColor="#CC6633" Text="DCR Line :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRLine"
						Text='<%# Bind("DCRLine") %>'
            ToolTip="Value of DCR Line."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentID"
						runat = "server"
						ControlToValidate = "F_DocumentID"
						Text = "Document ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
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
						ValidationGroup="lgEPDCR"
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
						ValidationGroup = "lgEPDCR"
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
						ValidationGroup="lgEPDCR"
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
						ValidationGroup = "lgEPDCR"
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
						ValidationGroup="lgEPDCR"
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
						ValidationGroup = "lgEPDCR"
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
						ValidationGroup = "lgEPDCR"
            onblur= "script_lgEPDCR.validate_ProjectID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("LG_Projects2_ProjectDescription") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "Project ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
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
            OnClientItemSelected="script_lgEPDCR.ACEProjectID_Selected"
            OnClientPopulating="script_lgEPDCR.ACEProjectID_Populating"
            OnClientPopulated="script_lgEPDCR.ACEProjectID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRDescription" runat="server" Text="DCR Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRDescription"
						Text='<%# Bind("DCRDescription") %>'
            Width="490px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCR Description."
						MaxLength="70"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRDescription"
						runat = "server"
						ControlToValidate = "F_DCRDescription"
						Text = "DCR Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRCreatedOn" runat="server" Text="DCR Created On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRCreatedOn"
						Text='<%# Bind("DCRCreatedOn") %>'
            Width="100px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
						runat="server" />
					<asp:Image ID="ImageButtonDCRCreatedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDCRCreatedOn"
            TargetControlID="F_DCRCreatedOn"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDCRCreatedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEEDCRCreatedOn"
						runat = "server"
						mask = "99/99/9999 99:99"
						MaskType="DateTime"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_DCRCreatedOn" />
					<AJX:MaskedEditValidator 
						ID = "MEVDCRCreatedOn"
						runat = "server"
						ControlToValidate = "F_DCRCreatedOn"
						ControlExtender = "MEEDCRCreatedOn"
						InvalidValueMessage = "Invalid value for DCR Created On."
						EmptyValueMessage = "DCR Created On is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for DCR Created On."
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRCategory" runat="server" Text="DCR Category :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRCategory"
						Text='<%# Bind("DCRCategory") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCR Category."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRCategory"
						runat = "server"
						ControlToValidate = "F_DCRCategory"
						Text = "DCR Category is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestPriority" runat="server" Text="Request Priority :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestPriority"
						Text='<%# Bind("RequestPriority") %>'
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Request Priority."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRequestPriority"
						runat = "server"
						ControlToValidate = "F_RequestPriority"
						Text = "Request Priority is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApprovalRequiredDate" runat="server" Text="Approval Required Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ApprovalRequiredDate"
						Text='<%# Bind("ApprovalRequiredDate") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
						runat="server" />
					<asp:Image ID="ImageButtonApprovalRequiredDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEApprovalRequiredDate"
            TargetControlID="F_ApprovalRequiredDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonApprovalRequiredDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEApprovalRequiredDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ApprovalRequiredDate" />
					<AJX:MaskedEditValidator 
						ID = "MEVApprovalRequiredDate"
						runat = "server"
						ControlToValidate = "F_ApprovalRequiredDate"
						ControlExtender = "MEEApprovalRequiredDate"
						InvalidValueMessage = "Invalid value for Approval Required Date."
						EmptyValueMessage = "Approval Required Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Approval Required Date."
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRState" runat="server" Text="DCR State :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRState"
						Text='<%# Bind("DCRState") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCR State."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRState"
						runat = "server"
						ControlToValidate = "F_DCRState"
						Text = "DCR State is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
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
  ID = "ODSlgEPDCR"
  DataObjectTypeName = "SIS.LG.lgEPDCR"
  SelectMethod = "lgEPDCRGetByID"
  UpdateMethod="lgEPDCRUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgEPDCR"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocPK" Name="DocPK" Type="Int64" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DCRID" Name="DCRID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DCRLine" Name="DCRLine" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
