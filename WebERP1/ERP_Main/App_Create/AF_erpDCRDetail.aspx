<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpDCRDetail.aspx.vb" Inherits="AF_erpDCRDetail" title="Add: DCR Detail" %>
<asp:Content ID="CPHerpDCRDetail" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpDCRDetail" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpDCRDetail" runat="server" Text="&nbsp;Add: DCR Detail" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpDCRDetail"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpDCRDetail"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpDCRDetail"
	runat = "server"
	DataKeyNames = "DCRNo,DocumentID,RevisionNo"
	DataSourceID = "ODSerpDCRDetail"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpDCRDetail" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRNo" ForeColor="#CC6633" runat="server" Text="DCRNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DCRNo"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("DCRNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for DCRNo."
						ValidationGroup = "erpDCRDetail"
            onblur= "script_erpDCRDetail.validate_DCRNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DCRNo_Display"
						Text='<%# Eval("ERP_DCRHeader1_DCRDescription") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRNo"
						runat = "server"
						ControlToValidate = "F_DCRNo"
						Text = "DCRNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEDCRNo"
            BehaviorID="B_ACEDCRNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DCRNoCompletionList"
            TargetControlID="F_DCRNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpDCRDetail.ACEDCRNo_Selected"
            OnClientPopulating="script_erpDCRDetail.ACEDCRNo_Populating"
            OnClientPopulated="script_erpDCRDetail.ACEDCRNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentID" ForeColor="#CC6633" runat="server" Text="DocumentID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentID"
						Text='<%# Bind("DocumentID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DocumentID."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentID"
						runat = "server"
						ControlToValidate = "F_DocumentID"
						Text = "DocumentID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RevisionNo" ForeColor="#CC6633" runat="server" Text="RevisionNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RevisionNo"
						Text='<%# Bind("RevisionNo") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for RevisionNo."
						MaxLength="5"
            Width="35px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRevisionNo"
						runat = "server"
						ControlToValidate = "F_RevisionNo"
						Text = "RevisionNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IndentNo" runat="server" Text="IndentNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IndentNo"
						Text='<%# Bind("IndentNo") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndentNo."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVIndentNo"
						runat = "server"
						ControlToValidate = "F_IndentNo"
						Text = "IndentNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IndentLine" runat="server" Text="IndentLine :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IndentLine"
						Text='<%# Bind("IndentLine") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndentLine."
						MaxLength="5"
            Width="35px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVIndentLine"
						runat = "server"
						ControlToValidate = "F_IndentLine"
						Text = "IndentLine is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LotItem" runat="server" Text="LotItem :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LotItem"
						Text='<%# Bind("LotItem") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for LotItem."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVLotItem"
						runat = "server"
						ControlToValidate = "F_LotItem"
						Text = "LotItem is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ItemDescription" runat="server" Text="ItemDescription :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ItemDescription"
						Text='<%# Bind("ItemDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ItemDescription."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVItemDescription"
						runat = "server"
						ControlToValidate = "F_ItemDescription"
						Text = "ItemDescription is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IndenterID" runat="server" Text="IndenterID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IndenterID"
						Text='<%# Bind("IndenterID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndenterID."
						MaxLength="8"
            Width="56px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVIndenterID"
						runat = "server"
						ControlToValidate = "F_IndenterID"
						Text = "IndenterID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BuyerID" runat="server" Text="BuyerID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BuyerID"
						Text='<%# Bind("BuyerID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerID."
						MaxLength="8"
            Width="56px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVBuyerID"
						runat = "server"
						ControlToValidate = "F_BuyerID"
						Text = "BuyerID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_OrderNo" runat="server" Text="OrderNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_OrderNo"
						Text='<%# Bind("OrderNo") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for OrderNo."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVOrderNo"
						runat = "server"
						ControlToValidate = "F_OrderNo"
						Text = "OrderNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_OrderLine" runat="server" Text="OrderLine :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_OrderLine"
						Text='<%# Bind("OrderLine") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for OrderLine."
						MaxLength="5"
            Width="35px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVOrderLine"
						runat = "server"
						ControlToValidate = "F_OrderLine"
						Text = "OrderLine is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierID" runat="server" Text="SupplierID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SupplierID"
						Text='<%# Bind("SupplierID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SupplierID."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSupplierID"
						runat = "server"
						ControlToValidate = "F_SupplierID"
						Text = "SupplierID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BuyerIDinPO" runat="server" Text="BuyerIDinPO :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BuyerIDinPO"
						Text='<%# Bind("BuyerIDinPO") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerIDinPO."
						MaxLength="8"
            Width="56px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVBuyerIDinPO"
						runat = "server"
						ControlToValidate = "F_BuyerIDinPO"
						Text = "BuyerIDinPO is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IndenterName" runat="server" Text="IndenterName :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IndenterName"
						Text='<%# Bind("IndenterName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndenterName."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVIndenterName"
						runat = "server"
						ControlToValidate = "F_IndenterName"
						Text = "IndenterName is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IndenterEMail" runat="server" Text="IndenterEMail :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IndenterEMail"
						Text='<%# Bind("IndenterEMail") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndenterEMail."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVIndenterEMail"
						runat = "server"
						ControlToValidate = "F_IndenterEMail"
						Text = "IndenterEMail is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BuyerName" runat="server" Text="BuyerName :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BuyerName"
						Text='<%# Bind("BuyerName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerName."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVBuyerName"
						runat = "server"
						ControlToValidate = "F_BuyerName"
						Text = "BuyerName is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BuyerEMail" runat="server" Text="BuyerEMail :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BuyerEMail"
						Text='<%# Bind("BuyerEMail") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerEMail."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVBuyerEMail"
						runat = "server"
						ControlToValidate = "F_BuyerEMail"
						Text = "BuyerEMail is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BuyerIDinPOName" runat="server" Text="BuyerIDinPOName :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BuyerIDinPOName"
						Text='<%# Bind("BuyerIDinPOName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerIDinPOName."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVBuyerIDinPOName"
						runat = "server"
						ControlToValidate = "F_BuyerIDinPOName"
						Text = "BuyerIDinPOName is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BuyerIDinPOEMail" runat="server" Text="BuyerIDinPOEMail :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BuyerIDinPOEMail"
						Text='<%# Bind("BuyerIDinPOEMail") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerIDinPOEMail."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVBuyerIDinPOEMail"
						runat = "server"
						ControlToValidate = "F_BuyerIDinPOEMail"
						Text = "BuyerIDinPOEMail is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierName" runat="server" Text="SupplierName :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SupplierName"
						Text='<%# Bind("SupplierName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SupplierName."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSupplierName"
						runat = "server"
						ControlToValidate = "F_SupplierName"
						Text = "SupplierName is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentTitle" runat="server" Text="DocumentTitle :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentTitle"
						Text='<%# Bind("DocumentTitle") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DocumentTitle."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentTitle"
						runat = "server"
						ControlToValidate = "F_DocumentTitle"
						Text = "DocumentTitle is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRDetail"
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
  ID = "ODSerpDCRDetail"
  DataObjectTypeName = "SIS.ERP.erpDCRDetail"
  InsertMethod="erpDCRDetailInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpDCRDetail"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
