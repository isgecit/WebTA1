<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpRoles.aspx.vb" Inherits="AF_erpRoles" title="Add: Roles" %>
<asp:Content ID="CPHerpRoles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRoles" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpRoles" runat="server" Text="&nbsp;Add: Roles" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRoles"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpRoles"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRoles"
	runat = "server"
	DataKeyNames = "RoleID"
	DataSourceID = "ODSerpRoles"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpRoles" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RoleID" ForeColor="#CC6633" runat="server" Text="Role :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RoleID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpRoles"
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
						ValidationGroup = "erpRoles"
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
  ID = "ODSerpRoles"
  DataObjectTypeName = "SIS.ERP.erpRoles"
  InsertMethod="erpRolesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRoles"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
