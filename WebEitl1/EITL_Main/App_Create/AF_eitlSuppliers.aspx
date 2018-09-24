<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlSuppliers.aspx.vb" Inherits="AF_eitlSuppliers" title="Add: Suppliers" %>
<asp:Content ID="CPHeitlSuppliers" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlSuppliers" runat="server" Text="&nbsp;Add: Suppliers"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlSuppliers" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlSuppliers"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "eitlSuppliers"
    runat = "server" />
<asp:FormView ID="FVeitlSuppliers"
	runat = "server"
	DataKeyNames = "SupplierID"
	DataSourceID = "ODSeitlSuppliers"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <br />
    <asp:Label ID="L_ErrMsgeitlSuppliers" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierID" ForeColor="#CC6633" runat="server" Text="Supplier ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SupplierID"
						Text='<%# Bind("SupplierID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlSuppliers"
            onblur= "script_eitlSuppliers.validate_SupplierID(this);"
            ToolTip="Enter value for Supplier ID."
						MaxLength="9"
            Width="63px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSupplierID"
						runat = "server"
						ControlToValidate = "F_SupplierID"
						Text = "Supplier ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlSuppliers"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SupplierName"
						Text='<%# Bind("SupplierName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlSuppliers"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Name."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSupplierName"
						runat = "server"
						ControlToValidate = "F_SupplierName"
						Text = "Supplier Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlSuppliers"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Address1" runat="server" Text="Address [1] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address1"
						Text='<%# Bind("Address1") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlSuppliers"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [1]."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVAddress1"
						runat = "server"
						ControlToValidate = "F_Address1"
						Text = "Address [1] is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlSuppliers"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Address2" runat="server" Text="Address [2] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address2"
						Text='<%# Bind("Address2") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [2]."
						MaxLength="50"
            Width="350px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Address3" runat="server" Text="Address [3] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address3"
						Text='<%# Bind("Address3") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [3]."
						MaxLength="50"
            Width="350px"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Address4" runat="server" Text="Address [4] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address4"
						Text='<%# Bind("Address4") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [4]."
						MaxLength="50"
            Width="350px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_City" runat="server" Text="City :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_City"
						Text='<%# Bind("City") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City."
						MaxLength="50"
            Width="350px"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_State" runat="server" Text="State :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_State"
						Text='<%# Bind("State") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for State."
						MaxLength="50"
            Width="350px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Country" runat="server" Text="Country :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Country"
						Text='<%# Bind("Country") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Country."
						MaxLength="50"
            Width="350px"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Zip" runat="server" Text="Zip :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Zip"
						Text='<%# Bind("Zip") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Zip."
						MaxLength="10"
            Width="70px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ContactPerson" runat="server" Text="Contact Person :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ContactPerson"
						Text='<%# Bind("ContactPerson") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact Person."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_EMailID" runat="server" Text="E-Mail ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EMailID"
						Text='<%# Bind("EMailID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for E-Mail ID."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ContactNo" runat="server" Text="Contact Nos :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ContactNo"
						Text='<%# Bind("ContactNo") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact Nos."
						MaxLength="50"
            Width="350px"
						runat="server" />
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
  ID = "ODSeitlSuppliers"
  DataObjectTypeName = "SIS.EITL.eitlSuppliers"
  InsertMethod="UZ_eitlSuppliersInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlSuppliers"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
