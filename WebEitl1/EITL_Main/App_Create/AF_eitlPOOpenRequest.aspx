<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlPOOpenRequest.aspx.vb" Inherits="AF_eitlPOOpenRequest" title="Add: PO Re-Open Request" %>
<asp:Content ID="CPHeitlPOOpenRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPOOpenRequest" runat="server" Text="&nbsp;Add: PO Re-Open Request"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPOOpenRequest" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPOOpenRequest"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "eitlPOOpenRequest"
    runat = "server" />
<asp:FormView ID="FVeitlPOOpenRequest"
	runat = "server"
	DataKeyNames = "RequestNo"
	DataSourceID = "ODSeitlPOOpenRequest"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgeitlPOOpenRequest" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestNo" ForeColor="#CC6633" runat="server" Text="Request No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" Text="S.No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
						CssClass = "myfktxt"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for S.No."
						ValidationGroup = "eitlPOOpenRequest"
            onblur= "script_eitlPOOpenRequest.validate_SerialNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text='<%# Eval("EITL_POList2_PONumber") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSerialNo"
						runat = "server"
						ControlToValidate = "F_SerialNo"
						Text = "S.No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOOpenRequest"
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
            OnClientItemSelected="script_eitlPOOpenRequest.ACESerialNo_Selected"
            OnClientPopulating="script_eitlPOOpenRequest.ACESerialNo_Populating"
            OnClientPopulated="script_eitlPOOpenRequest.ACESerialNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PORevision" runat="server" Text="PO REV. :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PORevision"
						Text='<%# Bind("PORevision") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPOOpenRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PO REV.."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVPORevision"
						runat = "server"
						ControlToValidate = "F_PORevision"
						Text = "PO REV. is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOOpenRequest"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SupplierID"
						CssClass = "myfktxt"
            Width="63px"
						Text='<%# Bind("SupplierID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Supplier."
						ValidationGroup = "eitlPOOpenRequest"
            onblur= "script_eitlPOOpenRequest.validate_SupplierID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SupplierID_Display"
						Text='<%# Eval("EITL_Suppliers3_SupplierName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSupplierID"
						runat = "server"
						ControlToValidate = "F_SupplierID"
						Text = "Supplier is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOOpenRequest"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierID"
            BehaviorID="B_ACESupplierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierIDCompletionList"
            TargetControlID="F_SupplierID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_eitlPOOpenRequest.ACESupplierID_Selected"
            OnClientPopulating="script_eitlPOOpenRequest.ACESupplierID_Populating"
            OnClientPopulated="script_eitlPOOpenRequest.ACESupplierID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Reason :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPOOpenRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Reason."
						MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRemarks"
						runat = "server"
						ControlToValidate = "F_Remarks"
						Text = "Reason is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOOpenRequest"
						SetFocusOnError="true" />
				</td>
			<td></td></tr>
		</table>
		<br />
		</div>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlPOOpenRequest"
  DataObjectTypeName = "SIS.EITL.eitlPOOpenRequest"
  InsertMethod="eitlPOOpenRequestInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPOOpenRequest"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
