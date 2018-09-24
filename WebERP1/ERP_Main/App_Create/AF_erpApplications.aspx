<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpApplications.aspx.vb" Inherits="AF_erpApplications" title="Add: Applications" %>
<asp:Content ID="CPHerpApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpApplications" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpApplications" runat="server" Text="&nbsp;Add: Applications" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpApplications"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpApplications"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpApplications"
	runat = "server"
	DataKeyNames = "ApplID"
	DataSourceID = "ODSerpApplications"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpApplications" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApplID" ForeColor="#CC6633" runat="server" Text="Appl ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ApplID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApplName" runat="server" Text="Application Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ApplName"
						Text='<%# Bind("ApplName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Application Name."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVApplName"
						runat = "server"
						ControlToValidate = "F_ApplName"
						Text = "Application Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpApplications"
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
  ID = "ODSerpApplications"
  DataObjectTypeName = "SIS.ERP.erpApplications"
  InsertMethod="erpApplicationsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpApplications"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
