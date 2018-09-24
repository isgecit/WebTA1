<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlIssuedPOItem.aspx.vb" Inherits="EF_eitlIssuedPOItem" title="Edit: Issued PO Items" %>
<asp:Content ID="CPHeitlIssuedPOItem" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlIssuedPOItem" runat="server" Text="&nbsp;Edit: Issued PO Items"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlIssuedPOItem" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlIssuedPOItem"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnableSave = "false"
    ValidationGroup = "eitlIssuedPOItem"
    runat = "server" />
<asp:FormView ID="FVeitlIssuedPOItem"
	runat = "server"
	DataKeyNames = "SerialNo,ItemLineNo"
	DataSourceID = "ODSeitlIssuedPOItem"
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
						Text='<%# Eval("EITL_POList5_PONumber") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ItemLineNo" runat="server" ForeColor="#CC6633" Text="Item Line No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ItemLineNo"
						Text='<%# Bind("ItemLineNo") %>'
            ToolTip="Value of Item Line No."
            Enabled = "False"
            Width="70px"
						CssClass = "dmypktxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ItemCode"
						Text='<%# Bind("ItemCode") %>'
            ToolTip="Value of Item Code."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
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
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UOM" runat="server" Text="UOM :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_UOM"
            Width="21px"
						Text='<%# Bind("UOM") %>'
            Enabled = "False"
            ToolTip="Value of UOM."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_UOM_Display"
						Text='<%# Eval("EITL_Units6_Description") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_Quantity" runat="server" Text="Quantity :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Quantity"
						Text='<%# Bind("Quantity") %>'
            ToolTip="Value of Quantity."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_WeightInKG" runat="server" Text="Weight In KG :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_WeightInKG"
						Text='<%# Bind("WeightInKG") %>'
            ToolTip="Value of Weight In KG."
            Enabled = "False"
            Width="126px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentLineNo" runat="server" Text="Document  :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocumentLineNo"
            Width="70px"
						Text='<%# Bind("DocumentLineNo") %>'
            Enabled = "False"
            ToolTip="Value of Document ."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_DocumentLineNo_Display"
						Text='<%# Eval("EITL_PODocumentList3_DocumentID") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReadyToDespatch" runat="server" Text="Ready To Despatch :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_ReadyToDespatch"
					  Checked='<%# Bind("ReadyToDespatch") %>'
            Enabled = "False"
            runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Despatched" runat="server" Text="Despatched :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_Despatched"
					  Checked='<%# Bind("Despatched") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VR_ExecutionNo" runat="server" Text="VR Execution No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_VR_ExecutionNo"
						Text='<%# Bind("VR_ExecutionNo") %>'
            ToolTip="Value of VR Execution No."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DespatchDate" runat="server" Text="Despatch Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DespatchDate"
						Text='<%# Bind("DespatchDate") %>'
            ToolTip="Value of Despatch Date."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_QuantityReceipt" runat="server" Text="Quantity Receipt :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_QuantityReceipt"
						Text='<%# Bind("QuantityReceipt") %>'
            ToolTip="Value of Quantity Receipt."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_WeightInKGReceipt" runat="server" Text="Weight In KG Receipt :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_WeightInKGReceipt"
						Text='<%# Bind("WeightInKGReceipt") %>'
            ToolTip="Value of Weight In KG Receipt."
            Enabled = "False"
            Width="126px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaterialStateID" runat="server" Text="Material State :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_MaterialStateID"
            Width="70px"
						Text='<%# Bind("MaterialStateID") %>'
            Enabled = "False"
            ToolTip="Value of Material State."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_MaterialStateID_Display"
						Text='<%# Eval("EITL_MaterialState2_Description") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ReceivedBy" runat="server" Text="Received By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ReceivedBy"
            Width="56px"
						Text='<%# Bind("ReceivedBy") %>'
            Enabled = "False"
            ToolTip="Value of Received By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ReceivedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReceivedOn" runat="server" Text="Received On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReceivedOn"
						Text='<%# Bind("ReceivedOn") %>'
            ToolTip="Value of Received On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ItemStatusID" runat="server" Text="Item Status :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ItemStatusID"
            Width="70px"
						Text='<%# Bind("ItemStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Item Status."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ItemStatusID_Display"
						Text='<%# Eval("EITL_POItemStatus4_Description") %>'
						Runat="Server" />
        </td>
			</tr>
		</table>
	</div>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlIssuedPOItem"
  DataObjectTypeName = "SIS.EITL.eitlIssuedPOItem"
  SelectMethod = "eitlIssuedPOItemGetByID"
  UpdateMethod="eitlIssuedPOItemUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlIssuedPOItem"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemLineNo" Name="ItemLineNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
