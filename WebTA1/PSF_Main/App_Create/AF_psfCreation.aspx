<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_psfCreation.aspx.vb" Inherits="AF_psfCreation" title="Add: Create PSF" %>
<asp:Content ID="CPHpsfCreation" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpsfCreation" runat="server" Text="&nbsp;Add: Create PSF"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpsfCreation" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpsfCreation"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "psfCreation"
    runat = "server" />
<asp:FormView ID="FVpsfCreation"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSpsfCreation"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpsfCreation" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PaymentRequestNo" runat="server" Text="Payment Request No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PaymentRequestNo"
            Text='<%# Bind("PaymentRequestNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Payment Request No."
            MaxLength="9"
            Width="63px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OurRefNo" runat="server" Text="Our Ref. No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_OurRefNo"
            Text='<%# Bind("OurRefNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfCreation"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Our Ref. No."
            MaxLength="7"
            Width="49px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVOurRefNo"
            runat = "server"
            ControlToValidate = "F_OurRefNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            SetFocusOnError="true" />
          <input type="button" id="getCqData" value="..." title="Get Cheque Details From ERP" onclick="script_psfCreation.getCqData('cph1_FVpsfCreation_F_OurRefNo');" />

        </td>
        <td class="alignright">
          <asp:Label ID="L_BankVoucherDate" runat="server" Text="Bank Voucher Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_BankVoucherDate"
            Text='<%# Bind("BankVoucherDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="psfCreation"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonBankVoucherDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEBankVoucherDate"
            TargetControlID="F_BankVoucherDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonBankVoucherDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEBankVoucherDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BankVoucherDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVBankVoucherDate"
            runat = "server"
            ControlToValidate = "F_BankVoucherDate"
            ControlExtender = "MEEBankVoucherDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierCode" runat="server" Text="Supplier Code :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierCode"
            CssClass = "myfktxt"
            Width="63px"
            Text='<%# Bind("SupplierCode") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier Code."
            ValidationGroup = "psfCreation"
            onblur= "script_psfCreation.validate_SupplierCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSupplierCode"
            runat = "server"
            ControlToValidate = "F_SupplierCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SupplierCode_Display"
            Text='<%# Eval("PSF_Supplier5_SupplierName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierCode"
            BehaviorID="B_ACESupplierCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierCodeCompletionList"
            TargetControlID="F_SupplierCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_psfCreation.ACESupplierCode_Selected"
            OnClientPopulating="script_psfCreation.ACESupplierCode_Populating"
            OnClientPopulated="script_psfCreation.ACESupplierCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IRN" runat="server" Text="IRN :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_IRN"
            Text='<%# Bind("IRN") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfCreation"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IRN."
            MaxLength="10"
            Width="70px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIRN"
            runat = "server"
            ControlToValidate = "F_IRN"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            SetFocusOnError="true" />
          <input type="button" id="getIRData" value="..." title="Get IR Details From ERP" onclick="script_psfCreation.getIRData('cph1_FVpsfCreation_F_IRN');" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InvoiceNumber" runat="server" Text="Invoice Number :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceNumber"
            Text='<%# Bind("InvoiceNumber") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfCreation"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Invoice Number."
            MaxLength="30"
            Width="210px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVInvoiceNumber"
            runat = "server"
            ControlToValidate = "F_InvoiceNumber"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InvoiceDate" runat="server" Text="Invoice Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceDate"
            Text='<%# Bind("InvoiceDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="psfCreation"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonInvoiceDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEInvoiceDate"
            TargetControlID="F_InvoiceDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonInvoiceDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEInvoiceDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_InvoiceDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVInvoiceDate"
            runat = "server"
            ControlToValidate = "F_InvoiceDate"
            ControlExtender = "MEEInvoiceDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InvoiceAmount" runat="server" Text="Invoice Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceAmount"
            Text='<%# Bind("InvoiceAmount") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            ValidationGroup="psfCreation"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEInvoiceAmount"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_InvoiceAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVInvoiceAmount"
            runat = "server"
            ControlToValidate = "F_InvoiceAmount"
            ControlExtender = "MEEInvoiceAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalAmountDisbursed" runat="server" Text="Total Amount Disbursed :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_TotalAmountDisbursed"
            Text='<%# Bind("TotalAmountDisbursed") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            ValidationGroup="psfCreation"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETotalAmountDisbursed"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TotalAmountDisbursed" />
          <AJX:MaskedEditValidator 
            ID = "MEVTotalAmountDisbursed"
            runat = "server"
            ControlToValidate = "F_TotalAmountDisbursed"
            ControlExtender = "MEETotalAmountDisbursed"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InterestForDays" runat="server" Text="Interest For Days :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_InterestForDays"
            Text='<%# Bind("InterestForDays") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            ValidationGroup="psfCreation"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEInterestForDays"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_InterestForDays" />
          <AJX:MaskedEditValidator 
            ID = "MEVInterestForDays"
            runat = "server"
            ControlToValidate = "F_InterestForDays"
            ControlExtender = "MEEInterestForDays"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InterestAmount" runat="server" Text="Interest Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_InterestAmount"
            Text='<%# Bind("InterestAmount") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            ValidationGroup="psfCreation"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEInterestAmount"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_InterestAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVInterestAmount"
            runat = "server"
            ControlToValidate = "F_InterestAmount"
            ControlExtender = "MEEInterestAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PDNNo" runat="server" Text="PDN No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_PDNNo"
            Text='<%# Bind("PDNNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfCreation"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PDN No."
            MaxLength="12"
            Width="84px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPDNNo"
            runat = "server"
            ControlToValidate = "F_PDNNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DueDate" runat="server" Text="Due Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DueDate"
            Text='<%# Bind("DueDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="psfCreation"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonDueDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDueDate"
            TargetControlID="F_DueDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDueDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEDueDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DueDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVDueDate"
            runat = "server"
            ControlToValidate = "F_DueDate"
            ControlExtender = "MEEDueDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfCreation"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TDSAmount" runat="server" Text="TDS Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TDSAmount"
            Text='<%# Bind("TDSAmount") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETDSAmount"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TDSAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVTDSAmount"
            runat = "server"
            ControlToValidate = "F_TDSAmount"
            ControlExtender = "MEETDSAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ServiceTax" runat="server" Text="Service Tax :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ServiceTax"
            Text='<%# Bind("ServiceTax") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEServiceTax"
            runat = "server"
            mask = "9999999999"
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
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpsfCreation"
  DataObjectTypeName = "SIS.PSF.psfCreation"
  InsertMethod="UZ_psfCreationInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PSF.psfCreation"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
