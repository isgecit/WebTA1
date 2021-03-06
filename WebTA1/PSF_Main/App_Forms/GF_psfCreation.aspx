<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_psfCreation.aspx.vb" Inherits="GF_psfCreation" title="Maintain List: Create PSF" %>
<asp:Content ID="CPHpsfCreation" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpsfCreation" runat="server" Text="&nbsp;List: Create PSF"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpsfCreation" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpsfCreation"
      ToolType = "lgNMGrid"
      EditUrl = "~/PSF_Main/App_Edit/EF_psfCreation.aspx"
      AddUrl = "~/PSF_Main/App_Create/AF_psfCreation.aspx"
      ValidationGroup = "psfCreation"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpsfCreation" runat="server" AssociatedUpdatePanelID="UPNLpsfCreation" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_SerialNo"
            Text=""
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
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
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SupplierCode" runat="server" Text="Supplier Code :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierCode"
            CssClass = "myfktxt"
            Width="63px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_SupplierCode(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierCode_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierCode"
            BehaviorID="B_ACESupplierCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierCodeCompletionList"
            TargetControlID="F_SupplierCode"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESupplierCode_Selected"
            OnClientPopulating="ACESupplierCode_Populating"
            OnClientPopulated="ACESupplierCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PSFStatus" runat="server" Text="PSF Status :" /></b>
        </td>
        <td>
          <LGM:LC_psfStatus
            ID="F_PSFStatus"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="PSFStatus"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVpsfCreation" SkinID="gv_silver" runat="server" DataSourceID="ODSpsfCreation" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COPY">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCopyPage" ValidationGroup="Copy" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Copy" ToolTip="Copy the record." SkinID="copy" CommandName="lgCopy" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return confirm('Copy Record ?');" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Request No" SortExpression="PaymentRequestNo">
          <ItemTemplate>
            <asp:Label ID="LabelPaymentRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PaymentRequestNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Our Ref. No" SortExpression="OurRefNo">
          <ItemTemplate>
            <asp:Label ID="LabelOurRefNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OurRefNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank Voucher Date" SortExpression="BankVoucherDate">
          <ItemTemplate>
            <asp:Label ID="LabelBankVoucherDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BankVoucherDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier Code" SortExpression="PSF_Supplier5_SupplierName">
          <ItemTemplate>
             <asp:Label ID="L_SupplierCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierCode") %>' Text='<%# Eval("PSF_Supplier5_SupplierName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Invoice Number" SortExpression="InvoiceNumber">
          <ItemTemplate>
            <asp:Label ID="LabelInvoiceNumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("InvoiceNumber") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Invoice Date" SortExpression="InvoiceDate">
          <ItemTemplate>
            <asp:Label ID="LabelInvoiceDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("InvoiceDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Amount Disbursed" SortExpression="TotalAmountDisbursed">
          <ItemTemplate>
            <asp:Label ID="LabelTotalAmountDisbursed" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalAmountDisbursed") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("HRM_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PSF Status" SortExpression="PSF_Status4_Description">
          <ItemTemplate>
             <asp:Label ID="L_PSFStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("PSFStatus") %>' Text='<%# Eval("PSF_Status4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpsfCreation"
      runat = "server"
      DataObjectTypeName = "SIS.PSF.psfCreation"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_psfCreationSelectList"
      TypeName = "SIS.PSF.psfCreation"
      SelectCountMethod = "psfCreationSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_SupplierCode" PropertyName="Text" Name="SupplierCode" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_PSFStatus" PropertyName="SelectedValue" Name="PSFStatus" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpsfCreation" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
    <asp:AsyncPostBackTrigger ControlID="F_SupplierCode" />
    <asp:AsyncPostBackTrigger ControlID="F_PSFStatus" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
