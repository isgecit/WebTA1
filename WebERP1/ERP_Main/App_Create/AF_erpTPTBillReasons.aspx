<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpTPTBillReasons.aspx.vb" Inherits="AF_erpTPTBillReasons" title="Add: Reasons" %>
<asp:Content ID="CPHerpTPTBillReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpTPTBillReasons" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpTPTBillReasons" runat="server" Text="&nbsp;Add: Reasons" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpTPTBillReasons"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpTPTBillReasons"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpTPTBillReasons"
	runat = "server"
	DataKeyNames = "ReasonID"
	DataSourceID = "ODSerpTPTBillReasons"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpTPTBillReasons" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReasonID" ForeColor="#CC6633" runat="server" Text="ReasonID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReasonID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="erpTPTBillReasons"
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
						ValidationGroup = "erpTPTBillReasons"
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
  ID = "ODSerpTPTBillReasons"
  DataObjectTypeName = "SIS.ERP.erpTPTBillReasons"
  InsertMethod="erpTPTBillReasonsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpTPTBillReasons"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
