<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_lgEPDCR.aspx.vb" Inherits="AF_lgEPDCR" title="Add: EPM DCR" %>
<asp:Content ID="CPHlgEPDCR" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgEPDCR" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabellgEPDCR" runat="server" Text="&nbsp;Add: EPM DCR" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgEPDCR"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "lgEPDCR"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVlgEPDCR"
	runat = "server"
	DataKeyNames = "DocPK,DCRID,DCRLine"
	DataSourceID = "ODSlgEPDCR"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsglgEPDCR" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
						ValidationGroup = "lgEPDCR"
            onblur= "script_lgEPDCR.validate_DocPK(this);"
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
						ValidationGroup = "lgEPDCR"
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
            OnClientItemSelected="script_lgEPDCR.ACEDocPK_Selected"
            OnClientPopulating="script_lgEPDCR.ACEDocPK_Populating"
            OnClientPopulated="script_lgEPDCR.ACEDocPK_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRID" ForeColor="#CC6633" runat="server" Text="DCRID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRID"
						Text='<%# Bind("DCRID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRID."
						MaxLength="32"
            Width="224px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRID"
						runat = "server"
						ControlToValidate = "F_DCRID"
						Text = "DCRID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRLine" ForeColor="#CC6633" runat="server" Text="DCRLine :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRLine" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="lgEPDCR"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
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
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="ProjectID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectID"
						Text='<%# Bind("ProjectID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ProjectID."
						MaxLength="20"
            Width="140px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "ProjectID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRDescription" runat="server" Text="DCRDescription :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRDescription"
						Text='<%# Bind("DCRDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRDescription."
						MaxLength="70"
            Width="490px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRDescription"
						runat = "server"
						ControlToValidate = "F_DCRDescription"
						Text = "DCRDescription is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRCreatedOn" runat="server" Text="DCRCreatedOn :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRCreatedOn"
						Text='<%# Bind("DCRCreatedOn") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="lgEPDCR"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonDCRCreatedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDCRCreatedOn"
            TargetControlID="F_DCRCreatedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDCRCreatedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEEDCRCreatedOn"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
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
						InvalidValueMessage = "Invalid value for DCRCreatedOn."
						EmptyValueMessage = "DCRCreatedOn is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for DCRCreatedOn."
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRCategory" runat="server" Text="DCRCategory :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRCategory"
						Text='<%# Bind("DCRCategory") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRCategory."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRCategory"
						runat = "server"
						ControlToValidate = "F_DCRCategory"
						Text = "DCRCategory is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestPriority" runat="server" Text="RequestPriority :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestPriority"
						Text='<%# Bind("RequestPriority") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for RequestPriority."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRequestPriority"
						runat = "server"
						ControlToValidate = "F_RequestPriority"
						Text = "RequestPriority is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApprovalRequiredDate" runat="server" Text="ApprovalRequiredDate :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ApprovalRequiredDate"
						Text='<%# Bind("ApprovalRequiredDate") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="lgEPDCR"
						onfocus = "return this.select();"
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
						InvalidValueMessage = "Invalid value for ApprovalRequiredDate."
						EmptyValueMessage = "ApprovalRequiredDate is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for ApprovalRequiredDate."
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRState" runat="server" Text="DCRState :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRState"
						Text='<%# Bind("DCRState") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPDCR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRState."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRState"
						runat = "server"
						ControlToValidate = "F_DCRState"
						Text = "DCRState is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPDCR"
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
  ID = "ODSlgEPDCR"
  DataObjectTypeName = "SIS.LG.lgEPDCR"
  InsertMethod="lgEPDCRInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgEPDCR"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
