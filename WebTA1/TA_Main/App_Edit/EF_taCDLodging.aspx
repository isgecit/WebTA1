<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taCDLodging.aspx.vb" Inherits="EF_taCDLodging" title="Edit: Lodging Charges" %>
<asp:Content ID="CPHtaCDLodging" ContentPlaceHolderID="cph1" Runat="Server">
  <script type="text/javascript">
    function validate_tots(o, p) {
      o.value = o.value.replace(new RegExp('_', 'g'), '');
      var dec = /^\d+(?:\.\d{0,6})?$/;
      var v = o.value;
      if (v.match(dec)) {
        o.value = parseFloat(v).toFixed(p);
      } else {
        o.value = parseFloat('0').toFixed(p);
      }
      var aVal = o.id.split('_F_');
      var Prefix = aVal[0] + '_F_';
      var AssessableValue = $get(Prefix + 'AssessableValue');
      var CessRate = $get(Prefix + 'CessRate');
      var CessAmount = $get(Prefix + 'CessAmount');
      var TotalGST = $get(Prefix + 'TotalGST');
      var TotalAmount = $get(Prefix + 'TotalAmount');
      var IGSTRate = $get(Prefix + 'IGSTRate');
      var IGSTAmount = $get(Prefix + 'IGSTAmount');
      var SGSTRate = $get(Prefix + 'SGSTRate');
      var SGSTAmount = $get(Prefix + 'SGSTAmount');
      var CGSTRate = $get(Prefix + 'CGSTRate');
      var CGSTAmount = $get(Prefix + 'CGSTAmount');
      try {
        if (parseFloat(CessRate.value) > 0)
          CessAmount.value = (parseFloat(CessRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(2);
        if (parseFloat(IGSTRate.value) > 0)
          IGSTAmount.value = (parseFloat(IGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(2);
        if (parseFloat(SGSTRate.value) > 0)
          SGSTAmount.value = (parseFloat(SGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(2);
        if (parseFloat(CGSTRate.value) > 0)
          CGSTAmount.value = (parseFloat(CGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(2);
        TotalGST.value = (parseFloat(CessAmount.value) + parseFloat(IGSTAmount.value) + parseFloat(SGSTAmount.value) + parseFloat(CGSTAmount.value)).toFixed(2);
        TotalAmount.value = (parseFloat(AssessableValue.value) + parseFloat(TotalGST.value)).toFixed(2);
      } catch (e) { }
    }
  </script>

<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCDLodging" runat="server" Text="&nbsp;Edit: Lodging Charges"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDLodging" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCDLodging"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taCDLodging"
    runat = "server" />
<asp:FormView ID="FVtaCDLodging"
  runat = "server"
  DataKeyNames = "TABillNo,SerialNo"
  DataSourceID = "ODStaCDLodging"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" runat="server" ForeColor="#CC6633" Text="TA Bill No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
            Text='<%# Eval("TA_Bills5_PurposeOfJourney") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_City1ID" runat="server" Text="Stayed in City :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_City1ID"
            Width="248px"
            Text='<%# Bind("City1ID") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_City1ID_Display"
            Text='<%# Eval("TA_Cities6_CityName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_City1Text" runat="server" Text="Other City Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_City1Text"
            Text='<%# Bind("City1Text") %>'
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Date1Time" runat="server" Text="From Date & Time :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Date1Time"
            Text='<%# Bind("Date1Time") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Date2Time" runat="server" Text="To Date & Time :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Date2Time"
            Text='<%# Bind("Date2Time") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModeText" runat="server" Text="Hotel Name / Stay Details :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ModeText"
            Text='<%# Bind("ModeText") %>'
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BoardingProvided" runat="server" Text="Boarding Provided :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_BoardingProvided"
            Checked='<%# Bind("BoardingProvided") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_LodgingProvided" runat="server" Text="Lodging Provided :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_LodgingProvided"
            Checked='<%# Bind("LodgingProvided") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StayedWithRelative" runat="server" Text="Stayed With Relative :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_StayedWithRelative"
            Checked='<%# Bind("StayedWithRelative") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_StayedInHotel" runat="server" Text="Stayed In Hotel :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_StayedInHotel"
            Checked='<%# Bind("StayedInHotel") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StayedAtSite" runat="server" Text="Stayed At Site :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_StayedAtSite"
            Checked='<%# Bind("StayedAtSite") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_StayedInGuestHouse" runat="server" Text="Stayed In Guest House :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_StayedInGuestHouse"
            Checked='<%# Bind("StayedInGuestHouse") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NotStayedAnyWhere" runat="server" Text="Not Stayed Any Where :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_NotStayedAnyWhere"
            Checked='<%# Bind("NotStayedAnyWhere") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountFactor" runat="server" Text="Hotel Charges Paid Days :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountFactor"
            Text='<%# Bind("AmountFactor") %>'
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AmountRate" runat="server" Text="Hotel Charges Per Day [Without Tax] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountRate"
            Text='<%# Bind("AmountRate") %>'
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountBasic" runat="server" Text="Paid Basic [Days x Rate] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountBasic"
            Text='<%# Bind("AmountBasic") %>'
            ToolTip="Value of Paid Basic [Days x Rate]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AmountTax" runat="server" Text="Total Tax Paid :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AmountTax"
            Text='<%# Bind("AmountTax") %>'
            ToolTip="Value of Total Tax Paid."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountTotal" runat="server" Text="NET Amount Paid [Basic + Tax] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountTotal"
            Text='<%# Bind("AmountTotal") %>'
            ToolTip="Value of NET Amount Paid [Basic + Tax]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AmountInINR" runat="server" Text="NET Claimed [INR] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AmountInINR"
            Text='<%# Bind("AmountInINR") %>'
            ToolTip="Value of NET Claimed [INR]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OOERemarks" runat="server" Text="OOE Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OOERemarks"
            Text='<%# Bind("OOERemarks") %>'
            ToolTip="Value of OOE Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taCDLodging_0"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Accounts Section</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovalWFTypeID" runat="server" Text="Approval Work Flow Type ID :" />
        </td>
        <td>
          <LGM:LC_taApprovalWFTypes
            ID="F_ApprovalWFTypeID"
            SelectedValue='<%# Bind("ApprovalWFTypeID") %>'
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
          <asp:Label ID="L_OOEReasonID" runat="server" Text="OOE Reason ID :" />
        </td>
        <td>
          <LGM:LC_taOOEReasons
            ID="F_OOEReasonID"
            SelectedValue='<%# Bind("OOEReasonID") %>'
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
          <asp:Label ID="L_CostCenterID" runat="server" Text="Cost Center :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taDepartments
            ID="F_CostCenterID"
            SelectedValue='<%# Bind("CostCenterID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCDLodging"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            onblur= "script_taCDLodging.validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            OnClientItemSelected="script_taCDLodging.ACEProjectID_Selected"
            OnClientPopulating="script_taCDLodging.ACEProjectID_Populating"
            OnClientPopulated="script_taCDLodging.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
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
            ValidationGroup = "taCDLodging"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor [INR] :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorINR"
            Text='<%# Bind("ConversionFactorINR") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup= "taCDLodging"
            MaxLength="13"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEConversionFactorINR"
            runat = "server"
            mask = "999999.999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ConversionFactorINR" />
          <AJX:MaskedEditValidator 
            ID = "MEVConversionFactorINR"
            runat = "server"
            ControlToValidate = "F_ConversionFactorINR"
            ControlExtender = "MEEConversionFactorINR"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCDLodging"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PassedAmountFactor" runat="server" Text="Passed Days :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmountFactor"
            Text='<%# Bind("PassedAmountFactor") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPassedAmountFactor"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PassedAmountFactor" />
          <AJX:MaskedEditValidator 
            ID = "MEVPassedAmountFactor"
            runat = "server"
            ControlToValidate = "F_PassedAmountFactor"
            ControlExtender = "MEEPassedAmountFactor"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PassedAmountRate" runat="server" Text="Passed Per Day Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmountRate"
            Text='<%# Bind("PassedAmountRate") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPassedAmountRate"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PassedAmountRate" />
          <AJX:MaskedEditValidator 
            ID = "MEVPassedAmountRate"
            runat = "server"
            ControlToValidate = "F_PassedAmountRate"
            ControlExtender = "MEEPassedAmountRate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PassedAmountBasic" runat="server" Text="Passed Basic [Days x Rate] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmountBasic"
            Text='<%# Bind("PassedAmountBasic") %>'
            ToolTip="Value of Passed Basic [Unit x Rate]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PassedAmountTax" runat="server" Text="Passed Tax :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PassedAmountTax"
            Text='<%# Bind("PassedAmountTax") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPassedAmountTax"
            runat = "server"
            mask = "999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PassedAmountTax" />
          <AJX:MaskedEditValidator 
            ID = "MEVPassedAmountTax"
            runat = "server"
            ControlToValidate = "F_PassedAmountTax"
            ControlExtender = "MEEPassedAmountTax"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PassedAmountTotal" runat="server" Text="Passed NET Amount [Basic + Tax] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmountTotal"
            Text='<%# Bind("PassedAmountTotal") %>'
            ToolTip="Value of Passed NET Amount [Basic + Tax]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PassedAmountInINR" runat="server" Text="NET Passed [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmountInINR"
            Text='<%# Bind("PassedAmountInINR") %>'
            ToolTip="Value of NET Passed [INR]."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AccountsRemarks" runat="server" Text="Accounts Remarks :" />
        </td>
        <td>
          <asp:TextBox ID="F_AccountsRemarks"
            Text='<%# Bind("AccountsRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Accounts Remarks."
            MaxLength="500"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Setteled" runat="server" Text="Setteled :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Setteled"
            Checked='<%# Bind("Setteled") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taCDLodging_1"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Approval Status</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            Width="72px"
            Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            ToolTip="Value of Approved By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            ToolTip="Value of Approved On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovalRemarks" runat="server" Text="Approval Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApprovalRemarks"
            Text='<%# Bind("ApprovalRemarks") %>'
            ToolTip="Value of Approval Remarks."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
      <asp:Panel ID="pnlGST" runat="server">
        <fieldset class="ui-widget-content page">
          <legend>
            <asp:Label ID="LabeltaBDLodging" runat="server" Text="&nbsp;GST Data"></asp:Label>
          </legend>
          <div class="pagedata">

            <table style="margin: auto; border: solid 1pt lightgrey">
            <tr>
              <td class="alignright">
                <asp:Label ID="L_PurchaseType" runat="server" Text="Purchase Type :" /><span style="color:red">*</span>
              </td>
              <td colspan="3">
                <asp:DropDownList
                  ID="F_PurchaseType"
                  SelectedValue='<%# Bind("PurchaseType") %>'
                  Width="200px"
                  ValidationGroup = "taBDLodging"
                  CssClass = "myddl"
                  Runat="Server" >
                  <asp:ListItem Value="">---Select---</asp:ListItem>
                  <asp:ListItem Value="Purchase from Registered Dealer">Registered Dealer-ITC</asp:ListItem>
                  <asp:ListItem Value="Purchase from Registered Dealer-No ITC">Registered Dealer-No ITC</asp:ListItem>
                  <asp:ListItem Value="Purchase from Composition Dealer">Composition Dealer</asp:ListItem>
                  <asp:ListItem Value="Purchase from Unregistered Dealer">Unregistered Dealer</asp:ListItem>
                  <asp:ListItem Value="Non GST expenses bill">Non GST expenses bill</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator 
                  ID = "RFVPurchaseType"
                  runat = "server"
                  ControlToValidate = "F_PurchaseType"
                  ErrorMessage = "<div class='errorLG'>Required!</div>"
                  Display = "Dynamic"
                  EnableClientScript = "true"
                  ValidationGroup = "taBDLodging"
                  SetFocusOnError="true" />
               </td>
            </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_IsgecGSTIN" runat="server" Text="Isgec GSTIN :" /><span style="color: red">*</span>
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
                    ValidationGroup = "taBDLodging"
                    RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                    Runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_BillNumber" runat="server" Text="Bill Number :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox ID="F_BillNumber"
                    Text='<%# Bind("BillNumber") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup = "taBDLodging"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Bill Number."
                    MaxLength="50"
                    Width="408px"
                    runat="server" />
                  <asp:RequiredFieldValidator
                    ID="RFVBillNumber"
                    runat="server"
                    ControlToValidate="F_BillNumber"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup = "taBDLodging"
                    SetFocusOnError="true" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_BillDate" runat="server" Text="Bill Date :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox ID="F_BillDate"
                    Text='<%# Bind("BillDate") %>'
                    Width="80px"
                    CssClass="mytxt"
                    ValidationGroup = "taBDLodging"
                    onfocus="return this.select();"
                    runat="server" />
                  <asp:Image ID="ImageButtonBillDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                  <AJX:CalendarExtender
                    ID="CEBillDate"
                    TargetControlID="F_BillDate"
                    Format="dd/MM/yyyy"
                    runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonBillDate" />
                  <AJX:MaskedEditExtender
                    ID="MEEBillDate"
                    runat="server"
                    Mask="99/99/9999"
                    MaskType="Date"
                    CultureName="en-GB"
                    MessageValidatorTip="true"
                    InputDirection="LeftToRight"
                    ErrorTooltipEnabled="true"
                    TargetControlID="F_BillDate" />
                  <AJX:MaskedEditValidator
                    ID="MEVBillDate"
                    runat="server"
                    ControlToValidate="F_BillDate"
                    ControlExtender="MEEBillDate"
                    EmptyValueBlurredText="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup = "taBDLodging"
                    IsValidEmpty="false"
                    SetFocusOnError="true" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_SupplierGSTINNo" runat="server" Text="Supplier  GSTIN No :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_SupplierGSTINNo"
                    Text='<%# Bind("SupplierGSTINNo") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Supplier  GSTIN No."
                    MaxLength="50"
                    Width="408px"
                    ValidationGroup = "taBDLodging"
                    runat="server" />
                  <asp:RequiredFieldValidator
                    ID="RFVSupplierGSTINNo"
                    runat="server"
                    ControlToValidate="F_SupplierGSTINNo"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup = "taBDLodging"
                    SetFocusOnError="true" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_StateID" runat="server" Text="State ID of Hotel/Stayed Place :" />&nbsp;
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
                    ValidationGroup = "taBDLodging"
                    RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
                    Runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_AssessableValue" runat="server" Text="Basic / Assessable Value :" /><span style="color: red">*</span>
                </td>
                <td colspan="3">
                  <asp:TextBox ID="F_AssessableValue"
                    Text='<%# Bind("AssessableValue") %>'
                    Width="168px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_IGSTRate" runat="server" Text="IGST Rate :" />
                </td>
                <td>
                  <asp:TextBox ID="F_IGSTRate"
                    Text='<%# Bind("IGSTRate") %>'
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: Right"
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    Enabled="false"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_IGSTAmount" runat="server" Text="IGST Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_IGSTAmount"
                    Text='<%# Bind("IGSTAmount") %>'
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    Enabled="false"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_CGSTRate" runat="server" Text="CGST Rate :" />
                </td>
                <td>
                  <asp:TextBox ID="F_CGSTRate"
                    Text='<%# Bind("CGSTRate") %>'
                    Width="168px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_CGSTAmount" runat="server" Text="CGST Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_CGSTAmount"
                    Text='<%# Bind("CGSTAmount") %>'
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    Width="168px"
                    CssClass="mytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_SGSTRate" runat="server" Text="SGST Rate :" />
                </td>
                <td>
                  <asp:TextBox ID="F_SGSTRate"
                    Text='<%# Bind("SGSTRate") %>'
                    Width="168px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_SGSTAmount" runat="server" Text="SGST Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_SGSTAmount"
                    Text='<%# Bind("SGSTAmount") %>'
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    Width="168px"
                    CssClass="mytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_CessRate" runat="server" Text="Cess Rate :" />
                </td>
                <td>
                  <asp:TextBox ID="F_CessRate"
                    Text='<%# Bind("CessRate") %>'
                    Width="168px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_CessAmount" runat="server" Text="Cess Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_CessAmount"
                    Text='<%# Bind("CessAmount") %>'
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    onfocus="return this.select();"
                    onblur="return validate_tots(this,2);"
                    Width="168px"
                    CssClass="mytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_TotalGST" runat="server" Text="Total GST :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TotalGST"
                    Text='<%# Bind("TotalGST") %>'
                    Enabled="False"
                    ToolTip="Value of Total GST."
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_TotalAmount" runat="server" Text="Total Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TotalAmount"
                    Text='<%# Bind("TotalAmount") %>'
                    Enabled="False"
                    ToolTip="Value of Total Amount."
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
            </table>
          </div>
        </fieldset>
      </asp:Panel>

<%--      <asp:Panel ID="pnlGST" runat="server">
        <fieldset class="ui-widget-content page">
          <legend>
            <asp:Label ID="LabeltaBDFare" runat="server" Text="&nbsp;GST Data"></asp:Label>
          </legend>
          <div class="pagedata">
            <table style="margin: auto; border: solid 1pt lightgrey">
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_IsgecGSTIN" runat="server" Text="Isgec GSTIN :" /><span style="color: red">*</span>
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
                    CssClass="dmyddl"
                    Enabled="false"
                    Runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_BillNumber" runat="server" Text="Bill Number :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox ID="F_BillNumber"
                    Text='<%# Bind("BillNumber") %>'
                    CssClass="dmytxt"
                    onfocus="return this.select();"
                    MaxLength="50"
                    Width="408px"
                    Enabled="false"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_BillDate" runat="server" Text="Bill Date :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox ID="F_BillDate"
                    Text='<%# Bind("BillDate") %>'
                    Width="80px"
                    CssClass="dmytxt"
                    Enabled="false"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_AssessableValue" runat="server" Text="Basic / Assessable Value :" /><span style="color: red">*</span>
                </td>
                <td colspan="3">
                  <asp:TextBox ID="F_AssessableValue"
                    Text='<%# Bind("AssessableValue") %>'
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: Right"
                    Enabled="false"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_CGSTRate" runat="server" Text="CGST Rate :" />
                </td>
                <td>
                  <asp:TextBox ID="F_CGSTRate"
                    Text='<%# Bind("CGSTRate") %>'
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: Right"
                    Enabled="false"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_CGSTAmount" runat="server" Text="CGST Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_CGSTAmount"
                    Text='<%# Bind("CGSTAmount") %>'
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    Enabled="false"
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_SGSTRate" runat="server" Text="SGST Rate :" />
                </td>
                <td>
                  <asp:TextBox ID="F_SGSTRate"
                    Text='<%# Bind("SGSTRate") %>'
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: Right"
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    Enabled="false"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_SGSTAmount" runat="server" Text="SGST Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_SGSTAmount"
                    Text='<%# Bind("SGSTAmount") %>'
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    Enabled="false"
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_CessRate" runat="server" Text="Cess Rate :" />
                </td>
                <td>
                  <asp:TextBox ID="F_CessRate"
                    Text='<%# Bind("CessRate") %>'
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: Right"
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    Enabled="false"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_CessAmount" runat="server" Text="Cess Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_CessAmount"
                    Text='<%# Bind("CessAmount") %>'
                    ValidationGroup="spmtSupplierBill"
                    MaxLength="20"
                    Enabled="false"
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_TotalGST" runat="server" Text="Total GST :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TotalGST"
                    Text='<%# Bind("TotalGST") %>'
                    Enabled="False"
                    ToolTip="Value of Total GST."
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_TotalAmount" runat="server" Text="Total Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TotalAmount"
                    Text='<%# Bind("TotalAmount") %>'
                    Enabled="False"
                    ToolTip="Value of Total Amount."
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
            </table>
          </div>
        </fieldset>
      </asp:Panel>--%>
    </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCDLodging"
  DataObjectTypeName = "SIS.TA.taCDLodging"
  SelectMethod = "taCDLodgingGetByID"
  UpdateMethod="UZ_taCDLodgingUpdate"
  DeleteMethod="taCDLodgingDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCDLodging"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TABillNo" Name="TABillNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
