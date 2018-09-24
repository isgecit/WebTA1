<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="GF_psfReport.aspx.vb" Inherits="AF_psfReport" title="Add: PSF Report" %>
<asp:Content ID="CPHpsfReport" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpsfReport" runat="server" Text="&nbsp;Add: PSF Report"></asp:Label>
</div>
<div id="div3" class="pagedata" >
<%--<asp:UpdatePanel ID="UPNLpsfReport" runat="server" >
  <ContentTemplate>--%>
  <LGM:ToolBar0 
    ID = "TBLpsfReport"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "psfReport"
    runat = "server" />
<asp:FormView ID="FVpsfReport"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSpsfReport"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage" style="min-height:300px; max-width:600px">
    <asp:Label ID="L_ErrMsgpsfReport" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
        <script type="text/javascript">
            function cp(o) {
                var p = $get(o.id.replace('_F', '_T'));
                if (p.value == '')
                    p.value = o.value;
            }
        </script>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FOurRefNo" runat="server" Text="Our Ref. No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FOurRefNo"
            Text='<%# Bind("FOurRefNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');cp(this);"
            ToolTip="Enter value for Our Ref. No."
            MaxLength="7"
            Width="49px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TOurRefNo" runat="server" Text="Our Ref. No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TOurRefNo"
            Text='<%# Bind("TOurRefNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Our Ref. No."
            MaxLength="7"
            Width="49px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FSupplierCode" runat="server" Text="Supplier Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_FSupplierCode"
            CssClass = "myfktxt"
            Width="63px"
            Text='<%# Bind("FSupplierCode") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier Code."
            onblur= "script_psfReport.validate_FSupplierCode(this);cp(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_FSupplierCode_Display"
            Text='<%# Eval("PSF_Supplier5_SupplierName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFSupplierCode"
            BehaviorID="B_ACEFSupplierCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FSupplierCodeCompletionList"
            TargetControlID="F_FSupplierCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_psfReport.ACEFSupplierCode_Selected"
            OnClientPopulating="script_psfReport.ACEFSupplierCode_Populating"
            OnClientPopulated="script_psfReport.ACEFSupplierCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TSupplierCode" runat="server" Text="Supplier Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TSupplierCode"
            CssClass = "myfktxt"
            Width="63px"
            Text='<%# Bind("TSupplierCode") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier Code."
            onblur= "script_psfReport.validate_TSupplierCode(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TSupplierCode_Display"
            Text='<%# Eval("PSF_Supplier6_SupplierName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETSupplierCode"
            BehaviorID="B_ACETSupplierCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TSupplierCodeCompletionList"
            TargetControlID="F_TSupplierCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_psfReport.ACETSupplierCode_Selected"
            OnClientPopulating="script_psfReport.ACETSupplierCode_Populating"
            OnClientPopulated="script_psfReport.ACETSupplierCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FIRN" runat="server" Text="IRN :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FIRN"
            Text='<%# Bind("FIRN") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');cp(this);"
            ToolTip="Enter value for IRN."
            MaxLength="10"
            Width="70px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TIRN" runat="server" Text="IRN :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TIRN"
            Text='<%# Bind("TIRN") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IRN."
            MaxLength="10"
            Width="70px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FBankVoucherDate" runat="server" Text="Bank Voucher Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FBankVoucherDate"
            Text='<%# Bind("FBankVoucherDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
              onblur="cp(this);"
            runat="server" />
          <asp:Image ID="ImageButtonFBankVoucherDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFBankVoucherDate"
            TargetControlID="F_FBankVoucherDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFBankVoucherDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEFBankVoucherDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FBankVoucherDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVFBankVoucherDate"
            runat = "server"
            ControlToValidate = "F_FBankVoucherDate"
            ControlExtender = "MEEFBankVoucherDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TBankVoucherDate" runat="server" Text="Bank Voucher Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TBankVoucherDate"
            Text='<%# Bind("TBankVoucherDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonTBankVoucherDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETBankVoucherDate"
            TargetControlID="F_TBankVoucherDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTBankVoucherDate" />
          <AJX:MaskedEditExtender 
            ID = "MEETBankVoucherDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TBankVoucherDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVTBankVoucherDate"
            runat = "server"
            ControlToValidate = "F_TBankVoucherDate"
            ControlExtender = "MEETBankVoucherDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FDueDate" runat="server" Text="Due Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FDueDate"
            Text='<%# Bind("FDueDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
              onblur="cp(this);"
            runat="server" />
          <asp:Image ID="ImageButtonFDueDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFDueDate"
            TargetControlID="F_FDueDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFDueDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEFDueDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FDueDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVFDueDate"
            runat = "server"
            ControlToValidate = "F_FDueDate"
            ControlExtender = "MEEFDueDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TDueDate" runat="server" Text="Due Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TDueDate"
            Text='<%# Bind("TDueDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonTDueDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETDueDate"
            TargetControlID="F_TDueDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTDueDate" />
          <AJX:MaskedEditExtender 
            ID = "MEETDueDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TDueDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVTDueDate"
            runat = "server"
            ControlToValidate = "F_TDueDate"
            ControlExtender = "MEETDueDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FPaymentDateToBank" runat="server" Text="Payment Date To Bank :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FPaymentDateToBank"
            Text='<%# Bind("FPaymentDateToBank") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
              onblur="cp(this);"
            runat="server" />
          <asp:Image ID="ImageButtonFPaymentDateToBank" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFPaymentDateToBank"
            TargetControlID="F_FPaymentDateToBank"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFPaymentDateToBank" />
          <AJX:MaskedEditExtender 
            ID = "MEEFPaymentDateToBank"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FPaymentDateToBank" />
          <AJX:MaskedEditValidator 
            ID = "MEVFPaymentDateToBank"
            runat = "server"
            ControlToValidate = "F_FPaymentDateToBank"
            ControlExtender = "MEEFPaymentDateToBank"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TPaymentDateToBank" runat="server" Text="Payment Date To Bank :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TPaymentDateToBank"
            Text='<%# Bind("TPaymentDateToBank") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonTPaymentDateToBank" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETPaymentDateToBank"
            TargetControlID="F_TPaymentDateToBank"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTPaymentDateToBank" />
          <AJX:MaskedEditExtender 
            ID = "MEETPaymentDateToBank"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TPaymentDateToBank" />
          <AJX:MaskedEditValidator 
            ID = "MEVTPaymentDateToBank"
            runat = "server"
            ControlToValidate = "F_TPaymentDateToBank"
            ControlExtender = "MEETPaymentDateToBank"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FHSBCToVendor" runat="server" Text="HSBC To Vendor :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FHSBCToVendor"
            Text='<%# Bind("FHSBCToVendor") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
              onblur="cp(this);"
            runat="server" />
          <asp:Image ID="ImageButtonFHSBCToVendor" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFHSBCToVendor"
            TargetControlID="F_FHSBCToVendor"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFHSBCToVendor" />
          <AJX:MaskedEditExtender 
            ID = "MEEFHSBCToVendor"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FHSBCToVendor" />
          <AJX:MaskedEditValidator 
            ID = "MEVFHSBCToVendor"
            runat = "server"
            ControlToValidate = "F_FHSBCToVendor"
            ControlExtender = "MEEFHSBCToVendor"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_THSBCToVendor" runat="server" Text="HSBC To Vendor :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_THSBCToVendor"
            Text='<%# Bind("THSBCToVendor") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonTHSBCToVendor" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETHSBCToVendor"
            TargetControlID="F_THSBCToVendor"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTHSBCToVendor" />
          <AJX:MaskedEditExtender 
            ID = "MEETHSBCToVendor"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_THSBCToVendor" />
          <AJX:MaskedEditValidator 
            ID = "MEVTHSBCToVendor"
            runat = "server"
            ControlToValidate = "F_THSBCToVendor"
            ControlExtender = "MEETHSBCToVendor"
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
<%--  </ContentTemplate>
</asp:UpdatePanel>--%>
<asp:ObjectDataSource 
  ID = "ODSpsfReport"
  DataObjectTypeName = "SIS.PSF.psfReport"
  InsertMethod="psfReportInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PSF.psfReport"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
