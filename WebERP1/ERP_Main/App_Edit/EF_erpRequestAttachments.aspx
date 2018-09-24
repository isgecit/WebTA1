<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpRequestAttachments.aspx.vb" Inherits="EF_erpRequestAttachments" title="Edit: Attachments" %>
<asp:Content ID="CPHerpRequestAttachments" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpRequestAttachments" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpRequestAttachments" runat="server" Text="&nbsp;Edit: Attachments" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpRequestAttachments"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "erpRequestAttachments"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVerpRequestAttachments"
	runat = "server"
	DataKeyNames = "ApplID,RequestID,SerialNo"
	DataSourceID = "ODSerpRequestAttachments"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApplID" runat="server" ForeColor="#CC6633" Text="Appl ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ApplID"
            Width="70px"
						Text='<%# Bind("ApplID") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Appl ID."
						Runat="Server" />
					<asp:Label
						ID = "F_ApplID_Display"
						Text='<%# Eval("ERP_Applications1_ApplName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestID" runat="server" ForeColor="#CC6633" Text="Request ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequestID"
            Width="70px"
						Text='<%# Bind("RequestID") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Request ID."
						Runat="Server" />
					<asp:Label
						ID = "F_RequestID_Display"
						Text='<%# Eval("ERP_ChaneRequest2_ChangeSubject") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpRequestAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpRequestAttachments"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FileName" runat="server" Text="File Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FileName"
						Text='<%# Bind("FileName") %>'
            ToolTip="Value of File Name."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiskFile" runat="server" Text="Disk File :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DiskFile"
						Text='<%# Bind("DiskFile") %>'
            ToolTip="Value of Disk File."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpRequestAttachments"
  DataObjectTypeName = "SIS.ERP.erpRequestAttachments"
  SelectMethod = "erpRequestAttachmentsGetByID"
  UpdateMethod="erpRequestAttachmentsUpdate"
  DeleteMethod="erpRequestAttachmentsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpRequestAttachments"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplID" Name="ApplID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestID" Name="RequestID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
