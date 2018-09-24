<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpRequestTypes.aspx.vb" Inherits="AF_erpRequestTypes" title="Add: Request Types" %>
<asp:Content ID="CPHerpRequestTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRequestTypes" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpRequestTypes" runat="server" Text="&nbsp;Add: Request Types" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRequestTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpRequestTypes"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRequestTypes"
	runat = "server"
	DataKeyNames = "RequestTypeID"
	DataSourceID = "ODSerpRequestTypes"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpRequestTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestTypeID" ForeColor="#CC6633" runat="server" Text="Request Type :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestTypeID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="erpRequestTypes"
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
						ValidationGroup = "erpRequestTypes"
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
  ID = "ODSerpRequestTypes"
  DataObjectTypeName = "SIS.ERP.erpRequestTypes"
  InsertMethod="erpRequestTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRequestTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
