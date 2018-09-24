<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpRequestStatus.aspx.vb" Inherits="AF_erpRequestStatus" title="Add: Request Status" %>
<asp:Content ID="CPHerpRequestStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRequestStatus" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpRequestStatus" runat="server" Text="&nbsp;Add: Request Status" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRequestStatus"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpRequestStatus"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRequestStatus"
	runat = "server"
	DataKeyNames = "StatusID"
	DataSourceID = "ODSerpRequestStatus"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpRequestStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_StatusID" ForeColor="#CC6633" runat="server" Text="Status :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_StatusID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="erpRequestStatus"
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
						ValidationGroup = "erpRequestStatus"
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
  ID = "ODSerpRequestStatus"
  DataObjectTypeName = "SIS.ERP.erpRequestStatus"
  InsertMethod="erpRequestStatusInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRequestStatus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
