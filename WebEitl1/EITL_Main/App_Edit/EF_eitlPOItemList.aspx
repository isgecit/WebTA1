<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlPOItemList.aspx.vb" Inherits="EF_eitlPOItemList" title="Edit: PO Item" %>
<asp:Content ID="CPHeitlPOItemList" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPOItemList" runat="server" Text="&nbsp;Edit: PO Item"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPOItemList" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPOItemList"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_eitlPOItemList.aspx?pk="
    ValidationGroup = "eitlPOItemList"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVeitlPOItemList"
	runat = "server"
	DataKeyNames = "SerialNo,ItemLineNo"
	DataSourceID = "ODSeitlPOItemList"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Serial No."
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
						CssClass = "mypktxt"
            Width="70px"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPOItemList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Code."
						MaxLength="50"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPOItemList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="200"
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
            CssClass="myfktxt"
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
						style="text-align: right"
            Width="70px"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
						Text='<%# Bind("DocumentLineNo") %>'
						AutoCompleteType = "None"
            Width="70px"
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
  ID = "ODSeitlPOItemList"
  DataObjectTypeName = "SIS.EITL.eitlPOItemList"
  SelectMethod = "eitlPOItemListGetByID"
  UpdateMethod="eitlPOItemListUpdate"
  DeleteMethod="eitlPOItemListDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPOItemList"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemLineNo" Name="ItemLineNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
