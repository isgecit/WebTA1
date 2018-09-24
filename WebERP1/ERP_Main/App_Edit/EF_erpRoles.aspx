<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpRoles.aspx.vb" Inherits="EF_erpRoles" title="Edit: Roles" %>
<asp:Content ID="CPHerpRoles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRoles" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpRoles" runat="server" Text="&nbsp;Edit: Roles" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRoles"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "erpRoles"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRoles"
	runat = "server"
	DataKeyNames = "RoleID"
	DataSourceID = "ODSerpRoles"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RoleID" runat="server" ForeColor="#CC6633" Text="Role :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RoleID"
						Text='<%# Bind("RoleID") %>'
            ToolTip="Value of Role."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpRoles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpRoles"
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
  ID = "ODSerpRoles"
  DataObjectTypeName = "SIS.ERP.erpRoles"
  SelectMethod = "erpRolesGetByID"
  UpdateMethod="erpRolesUpdate"
  DeleteMethod="erpRolesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRoles"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RoleID" Name="RoleID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
