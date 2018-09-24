<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlPOItemList.aspx.vb" Inherits="AF_eitlPOItemList" title="Add: PO Item" %>
<asp:Content ID="CPHeitlPOItemList" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPOItemList" runat="server" Text="&nbsp;Add: PO Item"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPOItemList" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPOItemList"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "eitlPOItemList"
    runat = "server" />
<asp:FormView ID="FVeitlPOItemList"
	runat = "server"
	DataKeyNames = "SerialNo,ItemLineNo"
	DataSourceID = "ODSeitlPOItemList"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgeitlPOItemList" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
						ValidationGroup = "eitlPOItemList"
            onblur= "script_eitlPOItemList.validate_SerialNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text='<%# Eval("EITL_POList5_PONumber") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSerialNo"
						runat = "server"
						ControlToValidate = "F_SerialNo"
						Text = "Serial No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOItemList"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_eitlPOItemList.ACESerialNo_Selected"
            OnClientPopulating="script_eitlPOItemList.ACESerialNo_Populating"
            OnClientPopulated="script_eitlPOItemList.ACESerialNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ItemLineNo" ForeColor="#CC6633" runat="server" Text="Item Line No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ItemLineNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ItemCode"
						Text='<%# Bind("ItemCode") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPOItemList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Code."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVItemCode"
						runat = "server"
						ControlToValidate = "F_ItemCode"
						Text = "Item Code is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOItemList"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPOItemList"
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
						ValidationGroup = "eitlPOItemList"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UOM" runat="server" Text="UOM :" /></b>
				</td>
        <td>
          <LGM:LC_eitlUnits
            ID="F_UOM"
            SelectedValue='<%# Bind("UOM") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "eitlPOItemList"
            RequiredFieldErrorMessage = "UOM is required."
            onblur= "script_eitlPOItemList.validate_UOM(this);"
            Runat="Server" />
          </td>
				<td class="alignright">
					<b><asp:Label ID="L_Quantity" runat="server" Text="Quantity :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Quantity"
						Text='<%# Bind("Quantity") %>'
            Width="70px"
						style="text-align: right"
						CssClass = "mytxt"
						ValidationGroup="eitlPOItemList"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEQuantity"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_Quantity" />
					<AJX:MaskedEditValidator 
						ID = "MEVQuantity"
						runat = "server"
						ControlToValidate = "F_Quantity"
						ControlExtender = "MEEQuantity"
						InvalidValueMessage = "Invalid value for Quantity."
						EmptyValueMessage = "Quantity is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Quantity."
						EnableClientScript = "true"
						ValidationGroup = "eitlPOItemList"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Quantity should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_WeightInKG" runat="server" Text="Weight In KG :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_WeightInKG"
						Text='<%# Bind("WeightInKG") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="eitlPOItemList"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEWeightInKG"
						runat = "server"
						mask = "9999999999999999.9999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_WeightInKG" />
					<AJX:MaskedEditValidator 
						ID = "MEVWeightInKG"
						runat = "server"
						ControlToValidate = "F_WeightInKG"
						ControlExtender = "MEEWeightInKG"
						InvalidValueMessage = "Invalid value for Weight In KG."
						EmptyValueMessage = "Weight In KG is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Weight In KG."
						EnableClientScript = "true"
						ValidationGroup = "eitlPOItemList"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Weight In KG should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentLineNo" runat="server" Text="Document Line No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocumentLineNo"
						CssClass = "myfktxt"
            Width="70px"
						Text='<%# Bind("DocumentLineNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Document Line No."
						ValidationGroup = "eitlPOItemList"
            onblur= "script_eitlPOItemList.validate_DocumentLineNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DocumentLineNo_Display"
						Text='<%# Eval("EITL_PODocumentList3_DocumentID") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentLineNo"
						runat = "server"
						ControlToValidate = "F_DocumentLineNo"
						Text = "Document Line No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOItemList"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEDocumentLineNo"
            BehaviorID="B_ACEDocumentLineNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DocumentLineNoCompletionList"
            TargetControlID="F_DocumentLineNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_eitlPOItemList.ACEDocumentLineNo_Selected"
            OnClientPopulating="script_eitlPOItemList.ACEDocumentLineNo_Populating"
            OnClientPopulated="script_eitlPOItemList.ACEDocumentLineNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
           runat="server" />
				</td>
			<td></td></tr>
		</table>
		</div>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlPOItemList"
  DataObjectTypeName = "SIS.EITL.eitlPOItemList"
  InsertMethod="eitlPOItemListInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPOItemList"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
