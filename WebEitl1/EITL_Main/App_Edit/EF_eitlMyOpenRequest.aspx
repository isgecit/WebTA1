<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlMyOpenRequest.aspx.vb" Inherits="EF_eitlMyOpenRequest" title="Edit: My Re-Open Request" %>
<asp:Content ID="CPHeitlMyOpenRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlMyOpenRequest" runat="server" Text="&nbsp;Edit: My Re-Open Request"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlMyOpenRequest" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlMyOpenRequest"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "eitlMyOpenRequest"
    runat = "server" />
<asp:FormView ID="FVeitlMyOpenRequest"
	runat = "server"
	DataKeyNames = "RequestNo"
	DataSourceID = "ODSeitlMyOpenRequest"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestNo" runat="server" ForeColor="#CC6633" Text="Request No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestNo"
						Text='<%# Bind("RequestNo") %>'
            ToolTip="Value of Request No."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" Text="PO No. :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
            Enabled = "False"
            ToolTip="Value of PO No.."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text='<%# Eval("EITL_POList2_PONumber") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PORevision" runat="server" Text="PO REV. :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PORevision"
						Text='<%# Bind("PORevision") %>'
            ToolTip="Value of PO REV.."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SupplierID"
            Width="63px"
						Text='<%# Bind("SupplierID") %>'
            Enabled = "False"
            ToolTip="Value of Supplier."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SupplierID_Display"
						Text='<%# Eval("EITL_Suppliers3_SupplierName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Reason :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
            ToolTip="Value of Reason."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_RequestedOn" runat="server" Text="Requested On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestedOn"
						Text='<%# Bind("RequestedOn") %>'
            ToolTip="Value of Requested On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ExecutedBy" runat="server" Text="Executed By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ExecutedBy"
            Width="56px"
						Text='<%# Bind("ExecutedBy") %>'
            Enabled = "False"
            ToolTip="Value of Executed By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ExecutedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ExecutedOn" runat="server" Text="Executed On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ExecutedOn"
						Text='<%# Bind("ExecutedOn") %>'
            ToolTip="Value of Executed On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ExecuterRemarks" runat="server" Text="Executer Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ExecuterRemarks"
						Text='<%# Bind("ExecuterRemarks") %>'
            ToolTip="Value of Executer Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ExecutedToOpen" runat="server" Text="Re-Opened :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_ExecutedToOpen"
					  Checked='<%# Bind("ExecutedToOpen") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
		</table>
	</div>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlMyOpenRequest"
  DataObjectTypeName = "SIS.EITL.eitlMyOpenRequest"
  SelectMethod = "eitlMyOpenRequestGetByID"
  UpdateMethod="eitlMyOpenRequestUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlMyOpenRequest"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestNo" Name="RequestNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
