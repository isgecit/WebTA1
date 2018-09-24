<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_erpDCRHeader.aspx.vb" Inherits="AF_erpDCRHeader" title="Add: DCR Header" %>
<asp:Content ID="CPHerpDCRHeader" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpDCRHeader" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelerpDCRHeader" runat="server" Text="&nbsp;Add: DCR Header" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpDCRHeader"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "erpDCRHeader"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpDCRHeader"
	runat = "server"
	DataKeyNames = "DCRNo"
	DataSourceID = "ODSerpDCRHeader"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgerpDCRHeader" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRNo" ForeColor="#CC6633" runat="server" Text="DCRNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRNo"
						Text='<%# Bind("DCRNo") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRNo."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRNo"
						runat = "server"
						ControlToValidate = "F_DCRNo"
						Text = "DCRNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRDate" runat="server" Text="DCRDate :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRDate"
						Text='<%# Bind("DCRDate") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRDate."
						MaxLength="20"
            Width="140px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRDate"
						runat = "server"
						ControlToValidate = "F_DCRDate"
						Text = "DCRDate is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRDescription" runat="server" Text="DCRDescription :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRDescription"
						Text='<%# Bind("DCRDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRDescription."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRDescription"
						runat = "server"
						ControlToValidate = "F_DCRDescription"
						Text = "DCRDescription is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedBy" runat="server" Text="CreatedBy :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedBy"
						Text='<%# Bind("CreatedBy") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CreatedBy."
						MaxLength="8"
            Width="56px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCreatedBy"
						runat = "server"
						ControlToValidate = "F_CreatedBy"
						Text = "CreatedBy is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedName" runat="server" Text="CreatedName :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedName"
						Text='<%# Bind("CreatedName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CreatedName."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCreatedName"
						runat = "server"
						ControlToValidate = "F_CreatedName"
						Text = "CreatedName is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedEMail" runat="server" Text="CreatedEMail :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedEMail"
						Text='<%# Bind("CreatedEMail") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CreatedEMail."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCreatedEMail"
						runat = "server"
						ControlToValidate = "F_CreatedEMail"
						Text = "CreatedEMail is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="ProjectID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectID"
						Text='<%# Bind("ProjectID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ProjectID."
						MaxLength="6"
            Width="42px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "ProjectID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectDescription" runat="server" Text="ProjectDescription :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectDescription"
						Text='<%# Bind("ProjectDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ProjectDescription."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectDescription"
						runat = "server"
						ControlToValidate = "F_ProjectDescription"
						Text = "ProjectDescription is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
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
  ID = "ODSerpDCRHeader"
  DataObjectTypeName = "SIS.ERP.erpDCRHeader"
  InsertMethod="erpDCRHeaderInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpDCRHeader"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
