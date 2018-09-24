<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taBDMileage.aspx.vb" Inherits="EF_taBDMileage" title="Edit: Mileage Claim" %>
<asp:Content ID="CPHtaBDMileage" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDMileage" runat="server" Text="&nbsp;Edit: Mileage Claim"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDMileage" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBDMileage"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taBDMileage"
    runat = "server" />
<asp:FormView ID="FVtaBDMileage"
  runat = "server"
  DataKeyNames = "TABillNo,SerialNo"
  DataSourceID = "ODStaBDMileage"
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
          <asp:Label ID="L_City1ID" runat="server" Text="From City :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_City1ID"
            CssClass = "myfktxt"
            Text='<%# Bind("City1ID") %>'
            AutoCompleteType = "None"
            Width="248px"
            onfocus = "return this.select();"
            ToolTip="Enter value for From City."
            onblur= "script_taBDMileage.validate_City1ID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_City1ID_Display"
            Text='<%# Eval("TA_Cities6_CityName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECity1ID"
            BehaviorID="B_ACECity1ID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="City1IDCompletionList"
            TargetControlID="F_City1ID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBDMileage.ACECity1ID_Selected"
            OnClientPopulating="script_taBDMileage.ACECity1ID_Populating"
            OnClientPopulated="script_taBDMileage.ACECity1ID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_City1Text" runat="server" Text="City Name [ If not found in List ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_City1Text"
            Text='<%# Bind("City1Text") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City Name [ If not found in List ]."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_City2ID" runat="server" Text="To City :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_City2ID"
            CssClass = "myfktxt"
            Text='<%# Bind("City2ID") %>'
            AutoCompleteType = "None"
            Width="248px"
            onfocus = "return this.select();"
            ToolTip="Enter value for To City."
            onblur= "script_taBDMileage.validate_City2ID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_City2ID_Display"
            Text='<%# Eval("TA_Cities7_CityName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECity2ID"
            BehaviorID="B_ACECity2ID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="City2IDCompletionList"
            TargetControlID="F_City2ID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBDMileage.ACECity2ID_Selected"
            OnClientPopulating="script_taBDMileage.ACECity2ID_Populating"
            OnClientPopulated="script_taBDMileage.ACECity2ID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_City2Text" runat="server" Text="City Name [ If not found in List ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_City2Text"
            Text='<%# Bind("City2Text") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City Name [ If not found in List ]."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Date1Time" runat="server" Text="Start Date & Time :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Date1Time"
            Text='<%# Bind("Date1Time") %>'
            Width="110px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBDMileage"
            runat="server" />
          <asp:Image ID="ImageButtonDate1Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate1Time"
            TargetControlID="F_Date1Time"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate1Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate1Time"
            runat = "server"
            mask = "99/99/9999 99:99"
            MaskType="DateTime"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Date1Time" />
          <AJX:MaskedEditValidator 
            ID = "MEVDate1Time"
            runat = "server"
            ControlToValidate = "F_Date1Time"
            ControlExtender = "MEEDate1Time"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDMileage"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Date2Time" runat="server" Text="End Date & Time :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Date2Time"
            Text='<%# Bind("Date2Time") %>'
            Width="110px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBDMileage"
            runat="server" />
          <asp:Image ID="ImageButtonDate2Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate2Time"
            TargetControlID="F_Date2Time"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate2Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate2Time"
            runat = "server"
            mask = "99/99/9999 99:99"
            MaskType="DateTime"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Date2Time" />
          <AJX:MaskedEditValidator 
            ID = "MEVDate2Time"
            runat = "server"
            ControlToValidate = "F_Date2Time"
            ControlExtender = "MEEDate2Time"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDMileage"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
            ValidationGroup = "taBDMileage"
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
            onblur= "script_taBDMileage.validate_ProjectID(this);"
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
            OnClientItemSelected="script_taBDMileage.ACEProjectID_Selected"
            OnClientPopulating="script_taBDMileage.ACEProjectID_Populating"
            OnClientPopulated="script_taBDMileage.ACEProjectID_Populated"
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
          <asp:Label ID="L_AmountFactor" runat="server" Text="Distance in KM :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountFactor"
            Text='<%# Bind("AmountFactor") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AmountRate" runat="server" Text="Claimed Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountRate"
            Text='<%# Bind("AmountRate") %>'
            ToolTip="Value of Claimed Rate."
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
          <asp:Label ID="L_AmountBasic" runat="server" Text="Claimed Basic [Unit x Rate] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AmountBasic"
            Text='<%# Bind("AmountBasic") %>'
            ToolTip="Value of Claimed Basic [Unit x Rate]."
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
          <asp:Label ID="L_AmountTax" runat="server" Text="Claimed Tax :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AmountTax"
            Text='<%# Bind("AmountTax") %>'
            ToolTip="Value of Claimed Tax."
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
          <asp:Label ID="L_AmountTotal" runat="server" Text="Claimed NET Amount [Basic + Tax] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AmountTotal"
            Text='<%# Bind("AmountTotal") %>'
            ToolTip="Value of Claimed NET Amount [Basic + Tax]."
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
            ValidationGroup = "taBDMileage"
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
            ValidationGroup= "taBDMileage"
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
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
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
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
      <tr id="taBDMileage_0"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Accounts Section</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovalWFTypeID" runat="server" Text="Approval Work Flow Type ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovalWFTypeID"
            Width="88px"
            Text='<%# Bind("ApprovalWFTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Approval Work Flow Type ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovalWFTypeID_Display"
            Text='<%# Eval("TA_ApprovalWFTypes4_WFTypeDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OOEReasonID" runat="server" Text="OOE Reason ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_OOEReasonID"
            Width="88px"
            Text='<%# Bind("OOEReasonID") %>'
            Enabled = "False"
            ToolTip="Value of OOE Reason ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_OOEReasonID_Display"
            Text='<%# Eval("TA_OOEReasons14_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PassedAmountFactor" runat="server" Text="Passed Unit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmountFactor"
            Text='<%# Bind("PassedAmountFactor") %>'
            ToolTip="Value of Passed Unit."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PassedAmountRate" runat="server" Text="Passed Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmountRate"
            Text='<%# Bind("PassedAmountRate") %>'
            ToolTip="Value of Passed Rate."
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
          <asp:Label ID="L_PassedAmountBasic" runat="server" Text="Passed Basic [Unit x Rate] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PassedAmountBasic"
            Text='<%# Bind("PassedAmountBasic") %>'
            ToolTip="Value of Passed Basic [Unit x Rate]."
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
          <asp:Label ID="L_PassedAmountTax" runat="server" Text="Passed Tax :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PassedAmountTax"
            Text='<%# Bind("PassedAmountTax") %>'
            ToolTip="Value of Passed Tax."
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
          <asp:Label ID="L_AccountsRemarks" runat="server" Text="Accounts Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AccountsRemarks"
            Text='<%# Bind("AccountsRemarks") %>'
            ToolTip="Value of Accounts Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taBDMileage_1"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Approval Status</td></tr>
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
            Width="350px" Height="40px"
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
  ID = "ODStaBDMileage"
  DataObjectTypeName = "SIS.TA.taBDMileage"
  SelectMethod = "taBDMileageGetByID"
  UpdateMethod="UZ_taBDMileageUpdate"
  DeleteMethod="UZ_taBDMileageDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBDMileage"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TABillNo" Name="TABillNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
