<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlPODocumentFile.aspx.vb" Inherits="AF_eitlPODocumentFile" title="Add: PO Document File" %>
<asp:Content ID="CPHeitlPODocumentFile" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPODocumentFile" runat="server" Text="&nbsp;Add: PO Document File"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPODocumentFile" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPODocumentFile"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "eitlPODocumentFile"
    runat = "server" />
<asp:FormView ID="FVeitlPODocumentFile"
	runat = "server"
	DataKeyNames = "SerialNo,DocumentLineNo,FileNo"
	DataSourceID = "ODSeitlPODocumentFile"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgeitlPODocumentFile" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="SerialNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for SerialNo."
						ValidationGroup = "eitlPODocumentFile"
            onblur= "script_eitlPODocumentFile.validate_SerialNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text='<%# Eval("EITL_POList2_PONumber") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSerialNo"
						runat = "server"
						ControlToValidate = "F_SerialNo"
						Text = "SerialNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentFile"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_eitlPODocumentFile.ACESerialNo_Selected"
            OnClientPopulating="script_eitlPODocumentFile.ACESerialNo_Populating"
            OnClientPopulated="script_eitlPODocumentFile.ACESerialNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentLineNo" ForeColor="#CC6633" runat="server" Text="DocumentLineNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocumentLineNo"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("DocumentLineNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for DocumentLineNo."
						ValidationGroup = "eitlPODocumentFile"
            onblur= "script_eitlPODocumentFile.validate_DocumentLineNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DocumentLineNo_Display"
						Text='<%# Eval("EITL_PODocumentList1_DocumentID") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentLineNo"
						runat = "server"
						ControlToValidate = "F_DocumentLineNo"
						Text = "DocumentLineNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentFile"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEDocumentLineNo"
            BehaviorID="B_ACEDocumentLineNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DocumentLineNoCompletionList"
            TargetControlID="F_DocumentLineNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_eitlPODocumentFile.ACEDocumentLineNo_Selected"
            OnClientPopulating="script_eitlPODocumentFile.ACEDocumentLineNo_Populating"
            OnClientPopulated="script_eitlPODocumentFile.ACEDocumentLineNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FileNo" ForeColor="#CC6633" runat="server" Text="FileNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FileNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentFile"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FileName" runat="server" Text="FileName :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FileName"
						Text='<%# Bind("FileName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for FileName."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVFileName"
						runat = "server"
						ControlToValidate = "F_FileName"
						Text = "FileName is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentFile"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DiskFile" runat="server" Text="DiskFile :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DiskFile"
						Text='<%# Bind("DiskFile") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentFile"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DiskFile."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDiskFile"
						runat = "server"
						ControlToValidate = "F_DiskFile"
						Text = "DiskFile is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentFile"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
		<br />
		</div>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlPODocumentFile"
  DataObjectTypeName = "SIS.EITL.eitlPODocumentFile"
  InsertMethod="eitlPODocumentFileInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPODocumentFile"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
