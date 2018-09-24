<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpCreateTPTBill.aspx.vb" Inherits="EF_erpCreateTPTBill" title="Edit: Create Transporter Bill" %>
<asp:Content ID="CPHerpCreateTPTBill" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpCreateTPTBill" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpCreateTPTBill" runat="server" Text="&nbsp;Edit: Create Transporter Bill" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpCreateTPTBill"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_erpCreateTPTBill.aspx?pk="
    ValidationGroup = "erpCreateTPTBill"
    Skin = "tbl_blue"
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
<asp:FormView ID="FVerpCreateTPTBill"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSerpCreateTPTBill"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
    <table width="98%">
			<tr>
				<td > 
				<table>
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
					<b><asp:Label ID="Label2" runat="server" ForeColor="#CC6633" Text="IR Number :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IRNumber" 
					  runat="server" 
					  CssClass="mytxt" 
					  MaxLength="10" 
					  Width="80px"
					  ValidationGroup = "erpCreateTPTBill"
					  Text='<%# Bind("IRNumber") %>' />
					<input type="button" id="getIRData" value="Get IR Details from ERP" onclick="script_erpCreateTPTBill.getIRData('ctl00_cph1_FVerpCreateTPTBill_F_IRNumber');" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TPTBillNo" runat="server" Text="Transporter Bill No. :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TPTBillNo"
						Text='<%# Bind("TPTBillNo") %>'
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpCreateTPTBill"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Transporter Bill No.."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTPTBillNo"
						runat = "server"
						ControlToValidate = "F_TPTBillNo"
						Text = "Transporter Bill No. is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TPTBillDate" runat="server" Text="Transporter Bill Date :" /></b>
				</td>
				<td style="vertical-align:bottom">
					<asp:TextBox ID="F_TPTBillDate"
						Text='<%# Bind("TPTBillDate") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpCreateTPTBill"
						runat="server" />
					<asp:Image ID="ImageButtonTPTBillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETPTBillDate"
            TargetControlID="F_TPTBillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTPTBillDate" />
					<AJX:MaskedEditExtender 
						ID = "MEETPTBillDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_TPTBillDate" />
					<AJX:MaskedEditValidator 
						ID = "MEVTPTBillDate"
						runat = "server"
						ControlToValidate = "F_TPTBillDate"
						ControlExtender = "MEETPTBillDate"
						InvalidValueMessage = "Invalid value for Transporter Bill Date."
						EmptyValueMessage = "Transporter Bill Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Transporter Bill Date."
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TPTBillReceivedOn" runat="server" Text="Tpt. Bill Received On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TPTBillReceivedOn"
						Text='<%# Bind("TPTBillReceivedOn") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpCreateTPTBill"
						runat="server" />
					<asp:Image ID="ImageButtonTPTBillReceivedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETPTBillReceivedOn"
            TargetControlID="F_TPTBillReceivedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTPTBillReceivedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEETPTBillReceivedOn"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_TPTBillReceivedOn" />
					<AJX:MaskedEditValidator 
						ID = "MEVTPTBillReceivedOn"
						runat = "server"
						ControlToValidate = "F_TPTBillReceivedOn"
						ControlExtender = "MEETPTBillReceivedOn"
						InvalidValueMessage = "Invalid value for Tpt. Bill Received On."
						EmptyValueMessage = "Tpt. Bill Received On is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Tpt. Bill Received On."
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GRNos" runat="server" Text="GR Nos. :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_GRNos"
						Text='<%# Bind("GRNos") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GR Nos.."
						MaxLength="500"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TPTCode" runat="server" Text="Transporter Code :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_TPTCode"
						CssClass = "myfktxt"
						Text='<%# Bind("TPTCode") %>'
						AutoCompleteType = "None"
            Width="63px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Transporter Code."
						ValidationGroup = "erpCreateTPTBill"
            onblur= "script_erpCreateTPTBill.validate_TPTCode(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_TPTCode_Display"
						Text='<%# Eval("VR_Transporters10_TransporterName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTPTCode"
						runat = "server"
						ControlToValidate = "F_TPTCode"
						Text = "Transporter Code is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACETPTCode"
            BehaviorID="B_ACETPTCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TPTCodeCompletionList"
            TargetControlID="F_TPTCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpCreateTPTBill.ACETPTCode_Selected"
            OnClientPopulating="script_erpCreateTPTBill.ACETPTCode_Populating"
            OnClientPopulated="script_erpCreateTPTBill.ACETPTCode_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PONumber" runat="server" Text="Purchase Order No. :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PONumber"
						Text='<%# Bind("PONumber") %>'
            Width="63px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpCreateTPTBill"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Purchase Order No.."
						MaxLength="9"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVPONumber"
						runat = "server"
						ControlToValidate = "F_PONumber"
						Text = "Purchase Order No. is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
						Text='<%# Bind("ProjectID") %>'
						AutoCompleteType = "None"
            Width="42px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
						ValidationGroup = "erpCreateTPTBill"
            onblur= "script_erpCreateTPTBill.validate_ProjectID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("IDM_Projects9_Description") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "Project ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpCreateTPTBill.ACEProjectID_Selected"
            OnClientPopulating="script_erpCreateTPTBill.ACEProjectID_Populating"
            OnClientPopulated="script_erpCreateTPTBill.ACEProjectID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TPTBillAmount" runat="server" Text="Tpt. Bill Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TPTBillAmount"
						Text='<%# Bind("TPTBillAmount") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="erpCreateTPTBill"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEETPTBillAmount"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_TPTBillAmount" />
					<AJX:MaskedEditValidator 
						ID = "MEVTPTBillAmount"
						runat = "server"
						ControlToValidate = "F_TPTBillAmount"
						ControlExtender = "MEETPTBillAmount"
						InvalidValueMessage = "Invalid value for Tpt. Bill Amount."
						EmptyValueMessage = "Tpt. Bill Amount is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Tpt. Bill Amount."
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Tpt. Bill Amount should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" runat="server" Text="Concerned Person [Materials] :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CreatedBy"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("CreatedBy") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Concerned Person [Materials]."
						ValidationGroup = "erpCreateTPTBill"
            onblur= "script_erpCreateTPTBill.validate_CreatedBy(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_CreatedBy_Display"
						Text='<%# Eval("aspnet_Users7_UserFullName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCreatedBy"
						runat = "server"
						ControlToValidate = "F_CreatedBy"
						Text = "Forwarded To [Accounts Emp.] is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACECreatedBy"
            BehaviorID="B_ACECreatedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CreatedByCompletionList"
            TargetControlID="F_CreatedBy"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpCreateTPTBill.ACECreatedBy_Selected"
            OnClientPopulating="script_erpCreateTPTBill.ACECreatedBy_Populating"
            OnClientPopulated="script_erpCreateTPTBill.ACECreatedBy_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiscReturnedToByAC" runat="server" Text="Forwarded To [Accounts Emp.] :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DiscReturnedToByAC"
						CssClass = "myfktxt"
						Text='<%# Bind("DiscReturnedToByAC") %>'
						AutoCompleteType = "None"
            Width="56px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Forwarded To [Accounts Emp.]."
						ValidationGroup = "erpCreateTPTBill"
            onblur= "script_erpCreateTPTBill.validate_DiscReturnedToByAC(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DiscReturnedToByAC_Display"
						Text='<%# Eval("aspnet_Users4_UserFullName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDiscReturnedToByAC"
						runat = "server"
						ControlToValidate = "F_DiscReturnedToByAC"
						Text = "Forwarded To [Accounts Emp.] is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpCreateTPTBill"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEDiscReturnedToByAC"
            BehaviorID="B_ACEDiscReturnedToByAC"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DiscReturnedToByACCompletionList"
            TargetControlID="F_DiscReturnedToByAC"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_erpCreateTPTBill.ACEDiscReturnedToByAC_Selected"
            OnClientPopulating="script_erpCreateTPTBill.ACEDiscReturnedToByAC_Populating"
            OnClientPopulated="script_erpCreateTPTBill.ACEDiscReturnedToByAC_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChequeNo" runat="server" Text="Cheque No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChequeNo"
						Text='<%# Bind("ChequeNo") %>'
            Width="140px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Cheque No."
						MaxLength="20"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LgstRemarks" runat="server" Text="Logistics Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LgstRemarks"
						Text='<%# Bind("LgstRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Logistics Remarks."
						MaxLength="500"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillStatus" runat="server" Text="Bill Status :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_BillStatus"
            Width="70px"
						Text='<%# Bind("BillStatus") %>'
            Enabled = "False"
            ToolTip="Value of Bill Status."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_BillStatus_Display"
						Text='<%# Eval("ERP_TPTBillStatus8_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			</table>
				</td>
				<td >
				<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BasicFreightValue" runat="server" Text="Basic Freight Charge :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BasicFreightValue"
						Text='<%# Bind("BasicFreightValue") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEBasicFreightValue"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_BasicFreightValue" />
					<AJX:MaskedEditValidator 
						ID = "MEVBasicFreightValue"
						runat = "server"
						ControlToValidate = "F_BasicFreightValue"
						ControlExtender = "MEEBasicFreightValue"
						InvalidValueMessage = "Invalid value for Basic Freight Value."
						EmptyValueMessage = "Basic Freight Value is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Basic Freight Value."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BasicFvODC" runat="server" Text="ODC Charges :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BasicFvODC"
						Text='<%# Bind("BasicFvODC") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEBasicFvODC"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_BasicFvODC" />
					<AJX:MaskedEditValidator 
						ID = "MEVBasicFvODC"
						runat = "server"
						ControlToValidate = "F_BasicFvODC"
						ControlExtender = "MEEBasicFvODC"
						InvalidValueMessage = "Invalid value for Basic Freight Value ODC."
						EmptyValueMessage = "Basic Freight Value ODC is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Basic Freight Value ODC."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DetentionatLP" runat="server" Text="Detention at Loading Point :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DetentionatLP"
						Text='<%# Bind("DetentionatLP") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEDetentionatLP"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_DetentionatLP" />
					<AJX:MaskedEditValidator 
						ID = "MEVDetentionatLP"
						runat = "server"
						ControlToValidate = "F_DetentionatLP"
						ControlExtender = "MEEDetentionatLP"
						InvalidValueMessage = "Invalid value for Detention at Loading Point."
						EmptyValueMessage = "Detention at Loading Point is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Detention at Loading Point."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DetentionatDaysLP" runat="server" Text="Detention Days at Loading Point :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_DetentionatDaysLP"
            Text='<%# Bind("DetentionatDaysLP") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEDetentionatDaysLP"
            runat = "server"
            mask = "9999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DetentionatDaysLP" />
          <AJX:MaskedEditValidator 
            ID = "MEVDetentionatDaysLP"
            runat = "server"
            ControlToValidate = "F_DetentionatDaysLP"
            ControlExtender = "MEEDetentionatDaysLP"
            InvalidValueMessage = "Invalid value for Detention days at Loading Point."
            EmptyValueMessage = "Detention days at Loading Point is required."
            EmptyValueBlurredText = "[Required!]"
            Display = "Dynamic"
            TooltipMessage = "Enter value for Detention days at Loading Point."
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="LabelLPisISGECWorks" runat="server" Text="Loading Point is ISGEC Works :" /></b>
        </td>
        <td>
            <asp:CheckBox ID="F_LPisISGECWorks"
              Checked='<%# Bind("LPisISGECWorks") %>'
              runat="server" />
        </td>
      </tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DetentionatULP" runat="server" Text="Detention at UnLoading Point :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DetentionatULP"
						Text='<%# Bind("DetentionatULP") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEDetentionatULP"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_DetentionatULP" />
					<AJX:MaskedEditValidator 
						ID = "MEVDetentionatULP"
						runat = "server"
						ControlToValidate = "F_DetentionatULP"
						ControlExtender = "MEEDetentionatULP"
						InvalidValueMessage = "Invalid value for Detention at UnLoading Point."
						EmptyValueMessage = "Detention at UnLoading Point is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Detention at UnLoading Point."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DetentionatDaysULP" runat="server" Text="Detention Days at Unloading Point :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_DetentionatDaysULP"
            Text='<%# Bind("DetentionatDaysULP") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEDetentionatDaysULP"
            runat = "server"
            mask = "9999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DetentionatDaysULP" />
          <AJX:MaskedEditValidator 
            ID = "MEVDetentionatDaysULP"
            runat = "server"
            ControlToValidate = "F_DetentionatDaysULP"
            ControlExtender = "MEEDetentionatDaysULP"
            InvalidValueMessage = "Invalid value for Detention days at Unloading Point."
            EmptyValueMessage = "Detention days at Unloading Point is required."
            EmptyValueBlurredText = "[Required!]"
            Display = "Dynamic"
            TooltipMessage = "Enter value for Detention days at Unloading Point."
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="LabelULPisICDCFSPort" runat="server" Text="Unloading Point is ICD/CFS/Port :" /></b>
        </td>
        <td>
            <asp:CheckBox ID="F_ULPisICDCFSPort"
              Checked='<%# Bind("ULPisICDCFSPort") %>'
              runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BackToTownCharges" runat="server" Text="Back to town charges :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_BackToTownCharges"
            Text='<%# Bind("BackToTownCharges") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEBackToTownCharges"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BackToTownCharges" />
          <AJX:MaskedEditValidator 
            ID = "MEVBackToTownCharges"
            runat = "server"
            ControlToValidate = "F_BackToTownCharges"
            ControlExtender = "MEEBackToTownCharges"
            InvalidValueMessage = "Invalid value for Back to town charges."
            EmptyValueMessage = "Back to town charges is required."
            EmptyValueBlurredText = "[Required!]"
            Display = "Dynamic"
            TooltipMessage = "Enter value for Back to town charges."
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TarpaulinCharges" runat="server" Text="Tarpaulin charges :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_TarpaulinCharges"
            Text='<%# Bind("TarpaulinCharges") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETarpaulinCharges"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TarpaulinCharges" />
          <AJX:MaskedEditValidator 
            ID = "MEVTarpaulinCharges"
            runat = "server"
            ControlToValidate = "F_TarpaulinCharges"
            ControlExtender = "MEETarpaulinCharges"
            InvalidValueMessage = "Invalid value for tarpaulin charges."
            EmptyValueMessage = "Tarpaulin charges is required."
            EmptyValueBlurredText = "[Required!]"
            Display = "Dynamic"
            TooltipMessage = "Enter value for Tarpaulin charges."
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WoodenSleeperCharges" runat="server" Text="Wooden Sleeper charges :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_WoodenSleeperCharges"
            Text='<%# Bind("WoodenSleeperCharges") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEWoodenSleeperCharges"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_WoodenSleeperCharges" />
          <AJX:MaskedEditValidator 
            ID = "MEVWoodenSleeperCharges"
            runat = "server"
            ControlToValidate = "F_WoodenSleeperCharges"
            ControlExtender = "MEEWoodenSleeperCharges"
            InvalidValueMessage = "Invalid value for wooden sleeper charges."
            EmptyValueMessage = "Wooden sleeper charges is required."
            EmptyValueBlurredText = "[Required!]"
            Display = "Dynamic"
            TooltipMessage = "Enter value for wooden sleeper charges."
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ODCChargesInContract" runat="server" Text="Additional ODC Charges In Contract :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ODCChargesInContract"
						Text='<%# Bind("ODCChargesInContract") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEODCChargesInContract"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ODCChargesInContract" />
					<AJX:MaskedEditValidator 
						ID = "MEVODCChargesInContract"
						runat = "server"
						ControlToValidate = "F_ODCChargesInContract"
						ControlExtender = "MEEODCChargesInContract"
						InvalidValueMessage = "Invalid value for ODC Charges In Contract."
						EmptyValueMessage = "ODC Charges In Contract is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for ODC Charges In Contract."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ODCChargesOutOfContract" runat="server" Text="Additional ODC Charges Out Of Contract :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ODCChargesOutOfContract"
						Text='<%# Bind("ODCChargesOutOfContract") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEODCChargesOutOfContract"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ODCChargesOutOfContract" />
					<AJX:MaskedEditValidator 
						ID = "MEVODCChargesOutOfContract"
						runat = "server"
						ControlToValidate = "F_ODCChargesOutOfContract"
						ControlExtender = "MEEODCChargesOutOfContract"
						InvalidValueMessage = "Invalid value for ODC Charges Out Of Contract."
						EmptyValueMessage = "ODC Charges Out Of Contract is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for ODC Charges Out Of Contract."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EmptyReturnCharges" runat="server" Text="Empty Return Charges :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EmptyReturnCharges"
						Text='<%# Bind("EmptyReturnCharges") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEEmptyReturnCharges"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_EmptyReturnCharges" />
					<AJX:MaskedEditValidator 
						ID = "MEVEmptyReturnCharges"
						runat = "server"
						ControlToValidate = "F_EmptyReturnCharges"
						ControlExtender = "MEEEmptyReturnCharges"
						InvalidValueMessage = "Invalid value for Empty Return Charges."
						EmptyValueMessage = "Empty Return Charges is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Empty Return Charges."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RTOChallanAmount" runat="server" Text="RTO Challan Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RTOChallanAmount"
						Text='<%# Bind("RTOChallanAmount") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEERTOChallanAmount"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_RTOChallanAmount" />
					<AJX:MaskedEditValidator 
						ID = "MEVRTOChallanAmount"
						runat = "server"
						ControlToValidate = "F_RTOChallanAmount"
						ControlExtender = "MEERTOChallanAmount"
						InvalidValueMessage = "Invalid value for RTO Challan Amount."
						EmptyValueMessage = "RTO Challan Amount is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for RTO Challan Amount."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_OtherAmount" runat="server" Text="Other Charges :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_OtherAmount"
						Text='<%# Bind("OtherAmount") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEOtherAmount"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_OtherAmount" />
					<AJX:MaskedEditValidator 
						ID = "MEVOtherAmount"
						runat = "server"
						ControlToValidate = "F_OtherAmount"
						ControlExtender = "MEEOtherAmount"
						InvalidValueMessage = "Invalid value for Other Amount."
						EmptyValueMessage = "Other Amount is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Other Amount."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ServiceTax" runat="server" Text="Service Tax :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ServiceTax"
						Text='<%# Bind("ServiceTax") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEServiceTax"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ServiceTax" />
					<AJX:MaskedEditValidator 
						ID = "MEVServiceTax"
						runat = "server"
						ControlToValidate = "F_ServiceTax"
						ControlExtender = "MEEServiceTax"
						InvalidValueMessage = "Invalid value for Service Tax."
						EmptyValueMessage = "Service Tax is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Service Tax."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TotalBillPassedAmount" runat="server" Text="Total Bill Passed Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TotalBillPassedAmount"
						Text='<%# Bind("TotalBillPassedAmount") %>'
            ToolTip="Value of Total Bill Passed Amount."
            Enabled = "False"
            BackColor="Aqua"
            Width="126px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedOn"
						Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			</table>
				</td>
			</tr>
			<tr>
				<td >
					<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FWDToAccountsOn" runat="server" Text="Forwarded To Accounts On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FWDToAccountsOn"
						Text='<%# Bind("FWDToAccountsOn") %>'
            ToolTip="Value of Forwarded To Accounts On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FWDToAccountsBy" runat="server" Text="Forwarded To Accounts By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_FWDToAccountsBy"
            Width="56px"
						Text='<%# Bind("FWDToAccountsBy") %>'
            Enabled = "False"
            ToolTip="Value of Forwarded To Accounts By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_FWDToAccountsBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RECDByAccountsOn" runat="server" Text="Received In Accounts On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RECDByAccountsOn"
						Text='<%# Bind("RECDByAccountsOn") %>'
            ToolTip="Value of Received In Accounts On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RECDinAccountsBy" runat="server" Text="Received In Accounts By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RECDinAccountsBy"
            Width="56px"
						Text='<%# Bind("RECDinAccountsBy") %>'
            Enabled = "False"
            ToolTip="Value of Received In Accounts By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RECDinAccountsBy_Display"
						Text='<%# Eval("aspnet_Users2_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiscReturnedByACOn" runat="server" Text="Disc.Doc. Returned By A/c On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DiscReturnedByACOn"
						Text='<%# Bind("DiscReturnedByACOn") %>'
            ToolTip="Value of Disc.Doc. Returned By A/c On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiscReturnedinAcBy" runat="server" Text="Disc.Doc. Returned By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DiscReturnedinAcBy"
            Width="56px"
						Text='<%# Bind("DiscReturnedinAcBy") %>'
            Enabled = "False"
            ToolTip="Value of Disc.Doc. Returned By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_DiscReturnedinAcBy_Display"
						Text='<%# Eval("aspnet_Users3_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiscRecdInLgstBy" runat="server" Text="Disc.Doc. Received in Logistics By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DiscRecdInLgstBy"
            Width="56px"
						Text='<%# Bind("DiscRecdInLgstBy") %>'
            Enabled = "False"
            ToolTip="Value of Disc.Doc. Received in Logistics By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_DiscRecdInLgstBy_Display"
						Text='<%# Eval("aspnet_Users5_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiscRecdInLgstOn" runat="server" Text="Disc.Doc. Received in Logistics On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DiscRecdInLgstOn"
						Text='<%# Bind("DiscRecdInLgstOn") %>'
            ToolTip="Value of Disc.Doc. Received in Logistics On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReFwdToAcBy" runat="server" Text="Re-Submitted to Accounts By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ReFwdToAcBy"
            Width="56px"
						Text='<%# Bind("ReFwdToAcBy") %>'
            Enabled = "False"
            ToolTip="Value of Re-Submitted to Accounts By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ReFwdToAcBy_Display"
						Text='<%# Eval("aspnet_Users6_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReFwdToACOn" runat="server" Text="Re-Submitted to Accounts On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReFwdToACOn"
						Text='<%# Bind("ReFwdToACOn") %>'
            ToolTip="Value of Re-Submitted to Accounts On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
					</table>
				</td>
				<td >
					<table >
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRNo" runat="server" Text="PTR No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRNo"
						Text='<%# Bind("PTRNo") %>'
            ToolTip="Value of PTR No."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRAmount" runat="server" Text="PTR Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRAmount"
						Text='<%# Bind("PTRAmount") %>'
            ToolTip="Value of PTR Amount."
            Enabled = "False"
            BackColor="Aqua"
            Width="126px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRDate" runat="server" Text="PTR Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRDate"
						Text='<%# Bind("PTRDate") %>'
            ToolTip="Value of PTR Date."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BankVCHNo" runat="server" Text="Bank Voucher No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BankVCHNo"
						Text='<%# Bind("BankVCHNo") %>'
            ToolTip="Value of Bank Voucher No."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BankVCHAmount" runat="server" Text="Bank Voucher Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BankVCHAmount"
						Text='<%# Bind("BankVCHAmount") %>'
            ToolTip="Value of Bank Voucher Amount."
            Enabled = "False"
            BackColor="Aqua"
            Width="126px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BankVCHDate" runat="server" Text="Bank Voucher Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BankVCHDate"
						Text='<%# Bind("BankVCHDate") %>'
            ToolTip="Value of Bank Voucher Date."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_AccountsRemarks" runat="server" Text="Accounts Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_AccountsRemarks"
						Text='<%# Bind("AccountsRemarks") %>'
            ToolTip="Value of Accounts Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
					</table>
				</td>
			</tr>
    </table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpCreateTPTBill"
  DataObjectTypeName = "SIS.ERP.erpCreateTPTBill"
  SelectMethod = "erpCreateTPTBillGetByID"
  UpdateMethod="UZ_erpCreateTPTBillUpdate"
  DeleteMethod="UZ_erpCreateTPTBillDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpCreateTPTBill"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
