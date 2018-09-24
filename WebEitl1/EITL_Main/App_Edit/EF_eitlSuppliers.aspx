<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlSuppliers.aspx.vb" Inherits="EF_eitlSuppliers" title="Edit: Suppliers" %>
<asp:Content ID="CPHeitlSuppliers" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlSuppliers" runat="server" Text="&nbsp;Edit: Suppliers"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlSuppliers" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlSuppliers"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "eitlSuppliers"
    runat = "server" />
<asp:FormView ID="FVeitlSuppliers"
	runat = "server"
	DataKeyNames = "SupplierID"
	DataSourceID = "ODSeitlSuppliers"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierID" runat="server" ForeColor="#CC6633" Text="Supplier ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SupplierID"
						Text='<%# Bind("SupplierID") %>'
            ToolTip="Value of Supplier ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="63px"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SupplierName"
						Text='<%# Bind("SupplierName") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlSuppliers"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Name."
						MaxLength="100"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlSuppliers"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [1]."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [2]."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [3]."
						MaxLength="50"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Address4" runat="server" Text="Address [4] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address4"
						Text='<%# Bind("Address4") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [4]."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City."
						MaxLength="50"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_State" runat="server" Text="State :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_State"
						Text='<%# Bind("State") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for State."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Country."
						MaxLength="50"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Zip" runat="server" Text="Zip :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Zip"
						Text='<%# Bind("Zip") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Zip."
						MaxLength="10"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact Person."
						MaxLength="100"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_EMailID" runat="server" Text="E-Mail ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EMailID"
						Text='<%# Bind("EMailID") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for E-Mail ID."
						MaxLength="100"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact Nos."
						MaxLength="50"
						runat="server" />
				</td>
			<td></td><td></td></tr>
		</table>
	</div>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlSuppliers"
  DataObjectTypeName = "SIS.EITL.eitlSuppliers"
  SelectMethod = "eitlSuppliersGetByID"
  UpdateMethod="UZ_eitlSuppliersUpdate"
  DeleteMethod="UZ_eitlSuppliersDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlSuppliers"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SupplierID" Name="SupplierID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
