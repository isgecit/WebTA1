<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpApplications.aspx.vb" Inherits="EF_erpApplications" title="Edit: Applications" %>
<asp:Content ID="CPHerpApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpApplications" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpApplications" runat="server" Text="&nbsp;Edit: Applications" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpApplications"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "erpApplications"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpApplications"
	runat = "server"
	DataKeyNames = "ApplID"
	DataSourceID = "ODSerpApplications"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApplID" runat="server" ForeColor="#CC6633" Text="Appl ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ApplID"
						Text='<%# Bind("ApplID") %>'
            ToolTip="Value of Appl ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApplName" runat="server" Text="Application Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ApplName"
						Text='<%# Bind("ApplName") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Application Name."
						MaxLength="50"
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpApplications"
  DataObjectTypeName = "SIS.ERP.erpApplications"
  SelectMethod = "erpApplicationsGetByID"
  UpdateMethod="erpApplicationsUpdate"
  DeleteMethod="erpApplicationsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpApplications"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplID" Name="ApplID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
