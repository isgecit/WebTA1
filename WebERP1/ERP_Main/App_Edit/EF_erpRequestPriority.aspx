<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpRequestPriority.aspx.vb" Inherits="EF_erpRequestPriority" title="Edit: Request Priority" %>
<asp:Content ID="CPHerpRequestPriority" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRequestPriority" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpRequestPriority" runat="server" Text="&nbsp;Edit: Request Priority" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRequestPriority"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "erpRequestPriority"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRequestPriority"
	runat = "server"
	DataKeyNames = "PriorityID"
	DataSourceID = "ODSerpRequestPriority"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PriorityID" runat="server" ForeColor="#CC6633" Text="Priority :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PriorityID"
						Text='<%# Bind("PriorityID") %>'
            ToolTip="Value of Priority."
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
						ValidationGroup="erpRequestPriority"
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
						ValidationGroup = "erpRequestPriority"
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
  ID = "ODSerpRequestPriority"
  DataObjectTypeName = "SIS.ERP.erpRequestPriority"
  SelectMethod = "erpRequestPriorityGetByID"
  UpdateMethod="erpRequestPriorityUpdate"
  DeleteMethod="erpRequestPriorityDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRequestPriority"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PriorityID" Name="PriorityID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
