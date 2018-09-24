<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpRequestPriority.aspx.vb" Inherits="AF_erpRequestPriority" title="Add: Request Priority" %>
<asp:Content ID="CPHerpRequestPriority" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRequestPriority" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpRequestPriority" runat="server" Text="&nbsp;Add: Request Priority" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRequestPriority"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpRequestPriority"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRequestPriority"
	runat = "server"
	DataKeyNames = "PriorityID"
	DataSourceID = "ODSerpRequestPriority"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpRequestPriority" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PriorityID" ForeColor="#CC6633" runat="server" Text="Priority :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PriorityID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="erpRequestPriority"
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
						ValidationGroup = "erpRequestPriority"
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
  ID = "ODSerpRequestPriority"
  DataObjectTypeName = "SIS.ERP.erpRequestPriority"
  InsertMethod="erpRequestPriorityInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRequestPriority"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
