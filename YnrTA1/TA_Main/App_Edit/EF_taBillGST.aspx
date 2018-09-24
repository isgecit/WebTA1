<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taBillGST.aspx.vb" Inherits="EF_taBillGST" title="Edit: TA Bill GST" %>
<asp:Content ID="CPHtaBillGST" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBillGST" runat="server" Text="&nbsp;Edit: TA Bill GST"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillGST" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBillGST"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taBillGST"
    runat = "server" />
<asp:FormView ID="FVtaBillGST"
  runat = "server"
  DataKeyNames = "TABillNo,SerialNo"
  DataSourceID = "ODStaBillGST"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" runat="server" ForeColor="#CC6633" Text="TA Bill No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_TABillNo"
            Width="88px"
            Text='<%# Bind("TABillNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of TA Bill No."
            Runat="Server" />
          <asp:Label
            ID = "F_TABillNo_Display"
            Text='<%# Eval("TA_Bills6_PurposeOfJourney") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Serial No."
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("TA_BillDetails5_") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsgecGSTIN" runat="server" Text="Isgec GSTIN :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_spmtIsgecGSTIN
            ID="F_IsgecGSTIN"
            SelectedValue='<%# Bind("IsgecGSTIN") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taBillGST"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillNumber" runat="server" Text="Bill Number :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_BillNumber"
            Text='<%# Bind("BillNumber") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBillGST"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bill Number."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBillNumber"
            runat = "server"
            ControlToValidate = "F_BillNumber"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBillGST"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BillDate" runat="server" Text="Bill Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_BillDate"
            Text='<%# Bind("BillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBillGST"
            runat="server" />
          <asp:Image ID="ImageButtonBillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEBillDate"
            TargetControlID="F_BillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonBillDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEBillDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BillDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVBillDate"
            runat = "server"
            ControlToValidate = "F_BillDate"
            ControlExtender = "MEEBillDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBillGST"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BPID" runat="server" Text="Supplier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BPID"
            CssClass = "myfktxt"
            Text='<%# Bind("BPID") %>'
            AutoCompleteType = "None"
            Width="80px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier."
            onblur= "script_taBillGST.validate_BPID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_BPID_Display"
            Text='<%# Eval("VR_BusinessPartner8_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBPID"
            BehaviorID="B_ACEBPID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BPIDCompletionList"
            TargetControlID="F_BPID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBillGST.ACEBPID_Selected"
            OnClientPopulating="script_taBillGST.ACEBPID_Populating"
            OnClientPopulated="script_taBillGST.ACEBPID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierGSTIN" runat="server" Text="Supplier GSTIN :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierGSTIN"
            CssClass = "myfktxt"
            Text='<%# Bind("SupplierGSTIN") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier GSTIN."
            onblur= "script_taBillGST.validate_SupplierGSTIN(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierGSTIN_Display"
            Text='<%# Eval("VR_BPGSTIN7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierGSTIN"
            BehaviorID="B_ACESupplierGSTIN"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierGSTINCompletionList"
            TargetControlID="F_SupplierGSTIN"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBillGST.ACESupplierGSTIN_Selected"
            OnClientPopulating="script_taBillGST.ACESupplierGSTIN_Populating"
            OnClientPopulated="script_taBillGST.ACESupplierGSTIN_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierGSTINNo" runat="server" Text="Other Supplier  GSTIN No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierGSTINNo"
            Text='<%# Bind("SupplierGSTINNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other Supplier  GSTIN No."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_StateID" runat="server" Text="State ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_spmtERPStates
            ID="F_StateID"
            SelectedValue='<%# Bind("StateID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillType" runat="server" Text="Bill Type :" />&nbsp;
        </td>
        <td>
          <LGM:LC_spmtBillTypes
            ID="F_BillType"
            SelectedValue='<%# Bind("BillType") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_HSNSACCode" runat="server" Text="HSN / SAC Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_HSNSACCode"
            CssClass = "myfktxt"
            Text='<%# Bind("HSNSACCode") %>'
            AutoCompleteType = "None"
            Width="168px"
            onfocus = "return this.select();"
            ToolTip="Enter value for HSN / SAC Code."
            onblur= "script_taBillGST.validate_HSNSACCode(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_HSNSACCode_Display"
            Text='<%# Eval("SPMT_HSNSACCodes3_HSNSACCode") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEHSNSACCode"
            BehaviorID="B_ACEHSNSACCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="HSNSACCodeCompletionList"
            TargetControlID="F_HSNSACCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBillGST.ACEHSNSACCode_Selected"
            OnClientPopulating="script_taBillGST.ACEHSNSACCode_Populating"
            OnClientPopulated="script_taBillGST.ACEHSNSACCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AssessableValue" runat="server" Text="Assessable Value :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AssessableValue"
            Text='<%# Bind("AssessableValue") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup= "taBillGST"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAssessableValue"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_AssessableValue" />
          <AJX:MaskedEditValidator 
            ID = "MEVAssessableValue"
            runat = "server"
            ControlToValidate = "F_AssessableValue"
            ControlExtender = "MEEAssessableValue"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBillGST"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IGSTRate" runat="server" Text="IGST Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IGSTRate"
            Text='<%# Bind("IGSTRate") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEIGSTRate"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_IGSTRate" />
          <AJX:MaskedEditValidator 
            ID = "MEVIGSTRate"
            runat = "server"
            ControlToValidate = "F_IGSTRate"
            ControlExtender = "MEEIGSTRate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IGSTAmount" runat="server" Text="IGST Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IGSTAmount"
            Text='<%# Bind("IGSTAmount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEIGSTAmount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_IGSTAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVIGSTAmount"
            runat = "server"
            ControlToValidate = "F_IGSTAmount"
            ControlExtender = "MEEIGSTAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SGSTRate" runat="server" Text="SGST Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SGSTRate"
            Text='<%# Bind("SGSTRate") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEESGSTRate"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SGSTRate" />
          <AJX:MaskedEditValidator 
            ID = "MEVSGSTRate"
            runat = "server"
            ControlToValidate = "F_SGSTRate"
            ControlExtender = "MEESGSTRate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SGSTAmount" runat="server" Text="SGST Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SGSTAmount"
            Text='<%# Bind("SGSTAmount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEESGSTAmount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SGSTAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVSGSTAmount"
            runat = "server"
            ControlToValidate = "F_SGSTAmount"
            ControlExtender = "MEESGSTAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CGSTRate" runat="server" Text="CGST Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CGSTRate"
            Text='<%# Bind("CGSTRate") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECGSTRate"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CGSTRate" />
          <AJX:MaskedEditValidator 
            ID = "MEVCGSTRate"
            runat = "server"
            ControlToValidate = "F_CGSTRate"
            ControlExtender = "MEECGSTRate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CGSTAmount" runat="server" Text="CGST Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CGSTAmount"
            Text='<%# Bind("CGSTAmount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECGSTAmount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CGSTAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVCGSTAmount"
            runat = "server"
            ControlToValidate = "F_CGSTAmount"
            ControlExtender = "MEECGSTAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CessRate" runat="server" Text="Cess Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CessRate"
            Text='<%# Bind("CessRate") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECessRate"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CessRate" />
          <AJX:MaskedEditValidator 
            ID = "MEVCessRate"
            runat = "server"
            ControlToValidate = "F_CessRate"
            ControlExtender = "MEECessRate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CessAmount" runat="server" Text="Cess Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CessAmount"
            Text='<%# Bind("CessAmount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECessAmount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CessAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVCessAmount"
            runat = "server"
            ControlToValidate = "F_CessAmount"
            ControlExtender = "MEECessAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalGST" runat="server" Text="Total GST :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalGST"
            Text='<%# Bind("TotalGST") %>'
            ToolTip="Value of Total GST."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalAmount" runat="server" Text="Total Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalAmount"
            Text='<%# Bind("TotalAmount") %>'
            ToolTip="Value of Total Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
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
  ID = "ODStaBillGST"
  DataObjectTypeName = "SIS.TA.taBillGST"
  SelectMethod = "taBillGSTGetByID"
  UpdateMethod="UZ_taBillGSTUpdate"
  DeleteMethod="UZ_taBillGSTDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBillGST"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TABillNo" Name="TABillNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
