<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpTPTBillStatus.aspx.vb" Inherits="EF_erpTPTBillStatus" title="Edit: TPT. Bill Status" %>
<asp:Content ID="CPHerpTPTBillStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpTPTBillStatus" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpTPTBillStatus" runat="server" Text="&nbsp;Edit: TPT. Bill Status" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpTPTBillStatus"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "erpTPTBillStatus"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpTPTBillStatus"
	runat = "server"
	DataKeyNames = "BillStatusID"
	DataSourceID = "ODSerpTPTBillStatus"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillStatusID" runat="server" ForeColor="#CC6633" Text="Bill Status ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BillStatusID"
						Text='<%# Bind("BillStatusID") %>'
            ToolTip="Value of Bill Status ID."
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
						ValidationGroup="erpTPTBillStatus"
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
						ValidationGroup = "erpTPTBillStatus"
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
  ID = "ODSerpTPTBillStatus"
  DataObjectTypeName = "SIS.ERP.erpTPTBillStatus"
  SelectMethod = "erpTPTBillStatusGetByID"
  UpdateMethod="erpTPTBillStatusUpdate"
  DeleteMethod="erpTPTBillStatusDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpTPTBillStatus"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BillStatusID" Name="BillStatusID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
