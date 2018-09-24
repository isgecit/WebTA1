<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpTPTBillReasons.aspx.vb" Inherits="EF_erpTPTBillReasons" title="Edit: Reasons" %>
<asp:Content ID="CPHerpTPTBillReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpTPTBillReasons" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpTPTBillReasons" runat="server" Text="&nbsp;Edit: Reasons" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpTPTBillReasons"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "erpTPTBillReasons"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpTPTBillReasons"
	runat = "server"
	DataKeyNames = "ReasonID"
	DataSourceID = "ODSerpTPTBillReasons"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReasonID" runat="server" ForeColor="#CC6633" Text="ReasonID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReasonID"
						Text='<%# Bind("ReasonID") %>'
            ToolTip="Value of ReasonID."
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
						ValidationGroup="erpTPTBillReasons"
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
						ValidationGroup = "erpTPTBillReasons"
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
  ID = "ODSerpTPTBillReasons"
  DataObjectTypeName = "SIS.ERP.erpTPTBillReasons"
  SelectMethod = "erpTPTBillReasonsGetByID"
  UpdateMethod="erpTPTBillReasonsUpdate"
  DeleteMethod="erpTPTBillReasonsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpTPTBillReasons"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ReasonID" Name="ReasonID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
