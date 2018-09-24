<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_psfApproved.aspx.vb" Inherits="EF_psfApproved" title="Edit: Approved PSF" %>
<asp:Content ID="CPHpsfApproved" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpsfApproved" runat="server" Text="&nbsp;Edit: Approved PSF"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpsfApproved" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpsfApproved"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_psfApproved.aspx?pk="
    ValidationGroup = "psfApproved"
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
<asp:FormView ID="FVpsfApproved"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSpsfApproved"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
            Width="70px"
            CssClass = "dmypktxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PaymentRequestNo" runat="server" Text="Payment Request No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PaymentRequestNo"
            Text='<%# Bind("PaymentRequestNo") %>'
            ToolTip="Value of Payment Request No."
            Enabled = "False"
            Width="63px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OurRefNo" runat="server" Text="Our Ref. No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OurRefNo"
            Text='<%# Bind("OurRefNo") %>'
            ToolTip="Value of Our Ref. No."
            Enabled = "False"
            Width="49px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BankVoucherDate" runat="server" Text="Bank Voucher Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BankVoucherDate"
            Text='<%# Bind("BankVoucherDate") %>'
            ToolTip="Value of Bank Voucher Date."
            Enabled = "False"
            Width="140px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierCode" runat="server" Text="Supplier Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierCode"
            Width="63px"
            Text='<%# Bind("SupplierCode") %>'
            Enabled = "False"
            ToolTip="Value of Supplier Code."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierCode_Display"
            Text='<%# Eval("PSF_Supplier5_SupplierName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IRN" runat="server" Text="IRN :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IRN"
            Text='<%# Bind("IRN") %>'
            ToolTip="Value of IRN."
            Enabled = "False"
            Width="70px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InvoiceNumber" runat="server" Text="Invoice Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceNumber"
            Text='<%# Bind("InvoiceNumber") %>'
            ToolTip="Value of Invoice Number."
            Enabled = "False"
            Width="210px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InvoiceDate" runat="server" Text="Invoice Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceDate"
            Text='<%# Bind("InvoiceDate") %>'
            ToolTip="Value of Invoice Date."
            Enabled = "False"
            Width="140px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InvoiceAmount" runat="server" Text="Invoice Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceAmount"
            Text='<%# Bind("InvoiceAmount") %>'
            ToolTip="Value of Invoice Amount."
            Enabled = "False"
            Width="70px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalAmountDisbursed" runat="server" Text="Total Amount Disbursed :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalAmountDisbursed"
            Text='<%# Bind("TotalAmountDisbursed") %>'
            ToolTip="Value of Total Amount Disbursed."
            Enabled = "False"
            Width="70px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InterestForDays" runat="server" Text="Interest For Days :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InterestForDays"
            Text='<%# Bind("InterestForDays") %>'
            ToolTip="Value of Interest For Days."
            Enabled = "False"
            Width="70px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InterestAmount" runat="server" Text="Interest Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InterestAmount"
            Text='<%# Bind("InterestAmount") %>'
            ToolTip="Value of Interest Amount."
            Enabled = "False"
            Width="70px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PDNNo" runat="server" Text="PDN No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PDNNo"
            Text='<%# Bind("PDNNo") %>'
            ToolTip="Value of PDN No."
            Enabled = "False"
            Width="84px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DueDate" runat="server" Text="Due Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DueDate"
            Text='<%# Bind("DueDate") %>'
            ToolTip="Value of Due Date."
            Enabled = "False"
            Width="140px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountInWords" runat="server" Text="Amount In Words :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountInWords"
            Text='<%# Bind("AmountInWords") %>'
            ToolTip="Value of Amount In Words."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TDSAmount" runat="server" Text="TDS Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TDSAmount"
            Text='<%# Bind("TDSAmount") %>'
            ToolTip="Value of TDS Amount."
            Enabled = "False"
            Width="70px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ServiceTax" runat="server" Text="Service Tax :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ServiceTax"
            Text='<%# Bind("ServiceTax") %>'
            ToolTip="Value of Service Tax."
            Enabled = "False"
            Width="70px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="56px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("HRM_Employees1_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
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
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            Width="56px"
            Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            ToolTip="Value of Approved By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("HRM_Employees2_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            ToolTip="Value of Approved On."
            Enabled = "False"
            Width="140px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PSFStatus" runat="server" Text="PSF Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PSFStatus"
            Width="70px"
            Text='<%# Bind("PSFStatus") %>'
            Enabled = "False"
            ToolTip="Value of PSF Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PSFStatus_Display"
            Text='<%# Eval("PSF_Status4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PaymentDateToBank" runat="server" Text="Payment Date To Bank :" />
        </td>
        <td>
          <asp:TextBox ID="F_PaymentDateToBank"
            Text='<%# Bind("PaymentDateToBank") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfApproved"
            runat="server" />
          <asp:Image ID="ImageButtonPaymentDateToBank" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEPaymentDateToBank"
            TargetControlID="F_PaymentDateToBank"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonPaymentDateToBank" />
          <AJX:MaskedEditExtender 
            ID = "MEEPaymentDateToBank"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PaymentDateToBank" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ChequeNoPaidToBank" runat="server" Text="Cheque No. Paid To Bank :" />
        </td>
        <td>
          <asp:TextBox ID="F_ChequeNoPaidToBank"
            Text='<%# Bind("ChequeNoPaidToBank") %>'
            Width="70px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfApproved"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Cheque No. Paid To Bank."
            MaxLength="10"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_HSBCToVendor" runat="server" Text="HSBC To Vendor :" />
        </td>
        <td>
          <asp:TextBox ID="F_HSBCToVendor"
            Text='<%# Bind("HSBCToVendor") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfApproved"
            runat="server" />
          <asp:Image ID="ImageButtonHSBCToVendor" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEHSBCToVendor"
            TargetControlID="F_HSBCToVendor"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonHSBCToVendor" />
          <AJX:MaskedEditExtender 
            ID = "MEEHSBCToVendor"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_HSBCToVendor" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_HSBCInterestDays" runat="server" Text="HSBC Interest Days :" />
        </td>
        <td>
          <asp:TextBox ID="F_HSBCInterestDays"
            Text='<%# Bind("HSBCInterestDays") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="psfApproved"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEHSBCInterestDays"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_HSBCInterestDays" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_HSBCInterestAmountInStatement" runat="server" Text="HSBC Interest Amount As Per Statement :" />
        </td>
        <td>
          <asp:TextBox ID="F_HSBCInterestAmountInStatement"
            Text='<%# Bind("HSBCInterestAmountInStatement") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="psfApproved"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEHSBCInterestAmountInStatement"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_HSBCInterestAmountInStatement" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModifiedBy" runat="server" Text="Modified By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ModifiedBy"
            Width="56px"
            Text='<%# Bind("ModifiedBy") %>'
            Enabled = "False"
            ToolTip="Value of Modified By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ModifiedBy_Display"
            Text='<%# Eval("HRM_Employees3_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ModifiedOn" runat="server" Text="Modified On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ModifiedOn"
            Text='<%# Bind("ModifiedOn") %>'
            ToolTip="Value of Modified On."
            Enabled = "False"
            Width="140px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpsfApproved"
  DataObjectTypeName = "SIS.PSF.psfApproved"
  SelectMethod = "psfApprovedGetByID"
  UpdateMethod="UZ_psfApprovedUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PSF.psfApproved"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
