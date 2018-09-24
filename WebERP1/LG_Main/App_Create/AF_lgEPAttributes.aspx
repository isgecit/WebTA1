<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_lgEPAttributes.aspx.vb" Inherits="AF_lgEPAttributes" title="Add: EPM Attributes" %>
<asp:Content ID="CPHlgEPAttributes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgEPAttributes" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabellgEPAttributes" runat="server" Text="&nbsp;Add: EPM Attributes" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgEPAttributes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "lgEPAttributes"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVlgEPAttributes"
	runat = "server"
	DataKeyNames = "DocPK,displayName"
	DataSourceID = "ODSlgEPAttributes"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsglgEPAttributes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
						ValidationGroup = "lgEPAttributes"
            onblur= "script_lgEPAttributes.validate_DocPK(this);"
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
						ValidationGroup = "lgEPAttributes"
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
            OnClientItemSelected="script_lgEPAttributes.ACEDocPK_Selected"
            OnClientPopulating="script_lgEPAttributes.ACEDocPK_Populating"
            OnClientPopulated="script_lgEPAttributes.ACEDocPK_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
						ValidationGroup="lgEPAttributes"
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
						ValidationGroup = "lgEPAttributes"
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
						ValidationGroup="lgEPAttributes"
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
						ValidationGroup = "lgEPAttributes"
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
						ValidationGroup="lgEPAttributes"
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
						ValidationGroup = "lgEPAttributes"
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
						ValidationGroup="lgEPAttributes"
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
						ValidationGroup = "lgEPAttributes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_displayName" ForeColor="#CC6633" runat="server" Text="Attribute Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_displayName"
						Text='<%# Bind("displayName") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPAttributes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Attribute Name."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVdisplayName"
						runat = "server"
						ControlToValidate = "F_displayName"
						Text = "Attribute Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPAttributes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_value" runat="server" Text="Value :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_value"
						Text='<%# Bind("value") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPAttributes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Value."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVvalue"
						runat = "server"
						ControlToValidate = "F_value"
						Text = "Value is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPAttributes"
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
  ID = "ODSlgEPAttributes"
  DataObjectTypeName = "SIS.LG.lgEPAttributes"
  InsertMethod="lgEPAttributesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgEPAttributes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
