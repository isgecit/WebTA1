<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpTPTBillStatus.aspx.vb" Inherits="AF_erpTPTBillStatus" title="Add: TPT. Bill Status" %>
<asp:Content ID="CPHerpTPTBillStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpTPTBillStatus" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpTPTBillStatus" runat="server" Text="&nbsp;Add: TPT. Bill Status" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpTPTBillStatus"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpTPTBillStatus"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpTPTBillStatus"
	runat = "server"
	DataKeyNames = "BillStatusID"
	DataSourceID = "ODSerpTPTBillStatus"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpTPTBillStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillStatusID" ForeColor="#CC6633" runat="server" Text="Bill Status ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BillStatusID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="erpTPTBillStatus"
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
						ValidationGroup = "erpTPTBillStatus"
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
  ID = "ODSerpTPTBillStatus"
  DataObjectTypeName = "SIS.ERP.erpTPTBillStatus"
  InsertMethod="erpTPTBillStatusInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpTPTBillStatus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
