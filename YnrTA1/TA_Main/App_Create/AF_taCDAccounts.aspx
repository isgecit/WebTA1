<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taCDAccounts.aspx.vb" Inherits="AF_taCDAccounts" title="Add: Debit / Credit By Accounts" %>
<asp:Content ID="CPHtaCDAccounts" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCDAccounts" runat="server" Text="&nbsp;Add: Debit / Credit By Accounts"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDAccounts" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCDAccounts"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taCDAccounts"
    runat = "server" />
<asp:FormView ID="FVtaCDAccounts"
  runat = "server"
  DataKeyNames = "TABillNo,SerialNo"
  DataSourceID = "ODStaCDAccounts"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaCDAccounts" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" ForeColor="#CC6633" runat="server" Text="TA Bill No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TABillNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("TABillNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for TA Bill No."
            ValidationGroup = "taCDAccounts"
            onblur= "script_taCDAccounts.validate_TABillNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTABillNo"
            runat = "server"
            ControlToValidate = "F_TABillNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCDAccounts"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_TABillNo_Display"
            Text='<%# Eval("TA_Bills5_PurposeOfJourney") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETABillNo"
            BehaviorID="B_ACETABillNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TABillNoCompletionList"
            TargetControlID="F_TABillNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taCDAccounts.ACETABillNo_Selected"
            OnClientPopulating="script_taCDAccounts.ACETABillNo_Populating"
            OnClientPopulated="script_taCDAccounts.ACETABillNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountRateOU" runat="server" Text="Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountRateOU"
            Text='<%# Bind("AmountRateOU") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="15"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmountRateOU"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_AmountRateOU" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmountRateOU"
            runat = "server"
            ControlToValidate = "F_AmountRateOU"
            ControlExtender = "MEEAmountRateOU"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCDAccounts"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr id="ouc" runat="server" ClientIDMode="Static">
        <td class="alignright">
          <asp:Label ID="L_CurrencyMain" runat="server" Text="Main Currency :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CurrencyMain"
            Text='<%# Bind("CurrencyMain") %>'
            Enabled = "False"
            ToolTip="Value of Main Currency."
            Width="56px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorOU" runat="server" Text="C.F. Main Currency :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorOU"
            Text='<%# Bind("ConversionFactorOU") %>'
            Width="104px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="taCDAccounts"
            MaxLength="13"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEConversionFactorOU"
            runat = "server"
            mask = "999999.999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ConversionFactorOU" />
          <AJX:MaskedEditValidator 
            ID = "MEVConversionFactorOU"
            runat = "server"
            ControlToValidate = "F_ConversionFactorOU"
            ControlExtender = "MEEConversionFactorOU"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCDAccounts"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks for Debit / Credit :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks for Debit / Credit."
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCDAccounts"
  DataObjectTypeName = "SIS.TA.taCDAccounts"
  InsertMethod="UZ_taCDAccountsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCDAccounts"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
