<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlPOStatus.aspx.vb" Inherits="AF_eitlPOStatus" title="Add: PO Status" %>
<asp:Content ID="CPHeitlPOStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPOStatus" runat="server" Text="&nbsp;Add: PO Status"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPOStatus" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPOStatus"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "eitlPOStatus"
    runat = "server" />
<asp:FormView ID="FVeitlPOStatus"
	runat = "server"
	DataKeyNames = "StatusID"
	DataSourceID = "ODSeitlPOStatus"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <br />
    <asp:Label ID="L_ErrMsgeitlPOStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_StatusID" ForeColor="#CC6633" runat="server" Text="Status ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_StatusID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPOStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOStatus"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
		<br />
		</div>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlPOStatus"
  DataObjectTypeName = "SIS.EITL.eitlPOStatus"
  InsertMethod="eitlPOStatusInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPOStatus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
