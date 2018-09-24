<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_lgProjects.aspx.vb" Inherits="AF_lgProjects" title="Add: Projects" %>
<asp:Content ID="CPHlgProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgProjects" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabellgProjects" runat="server" Text="&nbsp;Add: Projects" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgProjects"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "lgProjects"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVlgProjects"
	runat = "server"
	DataKeyNames = "ProjectID"
	DataSourceID = "ODSlgProjects"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsglgProjects" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="ProjectID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectID"
						Text='<%# Bind("ProjectID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="lgProjects"
            onblur= "script_lgProjects.validate_ProjectID(this);"
            ToolTip="Enter value for ProjectID."
						MaxLength="20"
            Width="140px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "ProjectID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgProjects"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectDescription" runat="server" Text="Project Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectDescription"
						Text='<%# Bind("ProjectDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Description."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectDescription"
						runat = "server"
						ControlToValidate = "F_ProjectDescription"
						Text = "Project Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgProjects"
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
  ID = "ODSlgProjects"
  DataObjectTypeName = "SIS.LG.lgProjects"
  InsertMethod="lgProjectsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgProjects"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
