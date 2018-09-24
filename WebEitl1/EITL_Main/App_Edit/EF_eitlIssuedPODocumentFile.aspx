<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlIssuedPODocumentFile.aspx.vb" Inherits="EF_eitlIssuedPODocumentFile" title="View: Issued PO Document File" %>
<asp:Content ID="CPHeitlIssuedPODocumentFile" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlIssuedPODocumentFile" runat="server" Text="&nbsp;View: Issued PO Document File"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlIssuedPODocumentFile" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlIssuedPODocumentFile"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnableSave = "false"
    ValidationGroup = "eitlIssuedPODocumentFile"
    runat = "server" />
<asp:FormView ID="FVeitlIssuedPODocumentFile"
	runat = "server"
	DataKeyNames = "SerialNo,DocumentLineNo,FileNo"
	DataSourceID = "ODSeitlIssuedPODocumentFile"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="PO No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of PO No."
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text='<%# Eval("EITL_POList2_PONumber") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentLineNo" runat="server" ForeColor="#CC6633" Text="Document Line No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocumentLineNo"
            Width="70px"
						Text='<%# Bind("DocumentLineNo") %>'
            Enabled = "False"
            ToolTip="Value of Document Line No."
						CssClass = "dmypktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_DocumentLineNo_Display"
						Text='<%# Eval("EITL_PODocumentList1_DocumentID") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FileNo" runat="server" ForeColor="#CC6633" Text="FileNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FileNo"
						Text='<%# Bind("FileNo") %>'
            ToolTip="Value of FileNo."
            Enabled = "False"
            Width="70px"
						CssClass = "dmypktxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            ToolTip="Value of Description."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
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
        <td class="alignright">
          <b><asp:Label ID="L_DiskFile" runat="server" Text="Physical File ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_DiskFile"
            Text='<%# Bind("DiskFile") %>'
            ToolTip="Value of Physical File ID."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
		</table>
	</div>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlIssuedPODocumentFile"
  DataObjectTypeName = "SIS.EITL.eitlIssuedPODocumentFile"
  SelectMethod = "eitlIssuedPODocumentFileGetByID"
  UpdateMethod="eitlIssuedPODocumentFileUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlIssuedPODocumentFile"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocumentLineNo" Name="DocumentLineNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FileNo" Name="FileNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
