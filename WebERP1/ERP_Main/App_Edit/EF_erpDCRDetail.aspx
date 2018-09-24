<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpDCRDetail.aspx.vb" Inherits="EF_erpDCRDetail" title="Edit: DCR Detail" %>
<asp:Content ID="CPHerpDCRDetail" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpDCRDetail" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpDCRDetail" runat="server" Text="&nbsp;Edit: DCR Detail" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpDCRDetail"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_erpDCRDetail.aspx?pk="
    ValidationGroup = "erpDCRDetail"
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
<asp:FormView ID="FVerpDCRDetail"
	runat = "server"
	DataKeyNames = "DCRNo,DocumentID,RevisionNo"
	DataSourceID = "ODSerpDCRDetail"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRNo" runat="server" ForeColor="#CC6633" Text="DCRNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DCRNo"
            Width="70px"
						Text='<%# Bind("DCRNo") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of DCRNo."
						Runat="Server" />
					<asp:Label
						ID = "F_DCRNo_Display"
						Text='<%# Eval("ERP_DCRHeader1_DCRDescription") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentID" runat="server" ForeColor="#CC6633" Text="DocumentID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentID"
						Text='<%# Bind("DocumentID") %>'
            ToolTip="Value of DocumentID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="210px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RevisionNo" runat="server" ForeColor="#CC6633" Text="RevisionNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RevisionNo"
						Text='<%# Bind("RevisionNo") %>'
            ToolTip="Value of RevisionNo."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="35px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IndentNo" runat="server" Text="IndentNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IndentNo"
						Text='<%# Bind("IndentNo") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndentNo."
						MaxLength="10"
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
            Width="35px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndentLine."
						MaxLength="5"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for LotItem."
						MaxLength="50"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ItemDescription."
						MaxLength="100"
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
            Width="56px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndenterID."
						MaxLength="8"
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
            Width="56px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerID."
						MaxLength="8"
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
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for OrderNo."
						MaxLength="10"
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
            Width="35px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for OrderLine."
						MaxLength="5"
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
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SupplierID."
						MaxLength="10"
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
            Width="56px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerIDinPO."
						MaxLength="8"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndenterName."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndenterEMail."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerName."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerEMail."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerIDinPOName."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BuyerIDinPOEMail."
						MaxLength="50"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SupplierName."
						MaxLength="100"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRDetail"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DocumentTitle."
						MaxLength="100"
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpDCRDetail"
  DataObjectTypeName = "SIS.ERP.erpDCRDetail"
  SelectMethod = "erpDCRDetailGetByID"
  UpdateMethod="erpDCRDetailUpdate"
  DeleteMethod="erpDCRDetailDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpDCRDetail"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DCRNo" Name="DCRNo" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocumentID" Name="DocumentID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RevisionNo" Name="RevisionNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
