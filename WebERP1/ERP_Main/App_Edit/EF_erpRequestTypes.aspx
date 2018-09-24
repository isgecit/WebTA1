<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpRequestTypes.aspx.vb" Inherits="EF_erpRequestTypes" title="Edit: Request Types" %>
<asp:Content ID="CPHerpRequestTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRequestTypes" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpRequestTypes" runat="server" Text="&nbsp;Edit: Request Types" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRequestTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "erpRequestTypes"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRequestTypes"
	runat = "server"
	DataKeyNames = "RequestTypeID"
	DataSourceID = "ODSerpRequestTypes"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestTypeID" runat="server" ForeColor="#CC6633" Text="Request Type :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestTypeID"
						Text='<%# Bind("RequestTypeID") %>'
            ToolTip="Value of Request Type."
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
						ValidationGroup="erpRequestTypes"
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
						ValidationGroup = "erpRequestTypes"
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
  ID = "ODSerpRequestTypes"
  DataObjectTypeName = "SIS.ERP.erpRequestTypes"
  SelectMethod = "erpRequestTypesGetByID"
  UpdateMethod="erpRequestTypesUpdate"
  DeleteMethod="erpRequestTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRequestTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestTypeID" Name="RequestTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
