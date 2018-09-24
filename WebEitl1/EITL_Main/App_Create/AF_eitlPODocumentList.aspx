<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlPODocumentList.aspx.vb" Inherits="AF_eitlPODocumentList" title="Add: PO Document" %>
<asp:Content ID="CPHeitlPODocumentList" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPODocumentList" runat="server" Text="&nbsp;Add: PO Document"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPODocumentList" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPODocumentList"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/EITL_Main/App_Edit/EF_eitlPODocumentList.aspx"
    ValidationGroup = "eitlPODocumentList"
    runat = "server" />
<asp:FormView ID="FVeitlPODocumentList"
	runat = "server"
	DataKeyNames = "SerialNo,DocumentLineNo"
	DataSourceID = "ODSeitlPODocumentList"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgeitlPODocumentList" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
            Width="70px"
						style="text-align: right"
						CssClass = "mypktxt"
						ValidationGroup="eitlPODocumentList"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEESerialNo"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_SerialNo" />
					<AJX:MaskedEditValidator 
						ID = "MEVSerialNo"
						runat = "server"
						ControlToValidate = "F_SerialNo"
						ControlExtender = "MEESerialNo"
						InvalidValueMessage = "Invalid value for Serial No."
						EmptyValueMessage = "Serial No is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Serial No."
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentList"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Serial No should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentLineNo" ForeColor="#CC6633" runat="server" Text="Document Line No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentLineNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentID"
						Text='<%# Bind("DocumentID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentID"
						runat = "server"
						ControlToValidate = "F_DocumentID"
						Text = "Document ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentList"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_RevisionNo" runat="server" Text="Revision No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RevisionNo"
						Text='<%# Bind("RevisionNo") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Revision No."
						MaxLength="3"
            Width="21px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRevisionNo"
						runat = "server"
						ControlToValidate = "F_RevisionNo"
						Text = "Revision No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentList"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentList"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ReadyToDespatch" runat="server" Text="Ready To Despatch :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_ReadyToDespatch"
					 Checked='<%# Bind("ReadyToDespatch") %>'
           runat="server" />
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
  ID = "ODSeitlPODocumentList"
  DataObjectTypeName = "SIS.EITL.eitlPODocumentList"
  InsertMethod="eitlPODocumentListInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPODocumentList"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
