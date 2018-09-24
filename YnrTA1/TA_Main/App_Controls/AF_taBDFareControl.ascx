<%@ Control Language="VB" AutoEventWireup="true" CodeFile="AF_taBDFareControl.ascx.vb" Inherits="AF_taBDFareControl" %>
<asp:panel runat="server" id="div1" style="display:none" class="ui-widget-content page">
<asp:panel runat="server" id="div2" class="caption">
  <table style="width:100%">
    <tr>
      <td>
        <asp:Label ID="LabeltaBDFare" runat="server" Text="&nbsp;Add: S-Fare"></asp:Label>
      </td>
      <td style="text-align:right">
        <asp:ImageButton ID="closeaFare" runat="server"  AlternateText="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
      </td>
    </tr>
  </table>
</asp:panel>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDFare" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBDFare"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taBDFare"
    runat = "server" />
<asp:FormView ID="FVtaBDFare"
  runat = "server"
  DataKeyNames = "TABillNo,SerialNo"
  DataSourceID = "ODStaBDFare"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaBDFare" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "taBDFare"
            onblur= "script_taBDFare.validate_TABillNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTABillNo"
            runat = "server"
            ControlToValidate = "F_TABillNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDFare"
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
            OnClientItemSelected="script_taBDFare.ACETABillNo_Selected"
            OnClientPopulating="script_taBDFare.ACETABillNo_Populating"
            OnClientPopulated="script_taBDFare.ACETABillNo_Populated"
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
          <asp:Label ID="L_City1ID" runat="server" Text="From City :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_City1ID"
            CssClass = "myfktxt"
            Width="248px"
            Text='<%# Bind("City1ID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for From City."
            onblur= "script_taBDFare.validate_City1ID(this);"
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
            OnClientItemSelected="script_taBDFare.ACECity1ID_Selected"
            OnClientPopulating="script_taBDFare.ACECity1ID_Populating"
            OnClientPopulated="script_taBDFare.ACECity1ID_Populated"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City Name [ If not found in List ]."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
            Width="248px"
            Text='<%# Bind("City2ID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for To City."
            onblur= "script_taBDFare.validate_City2ID(this);"
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
            OnClientItemSelected="script_taBDFare.ACECity2ID_Selected"
            OnClientPopulating="script_taBDFare.ACECity2ID_Populating"
            OnClientPopulated="script_taBDFare.ACECity2ID_Populated"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City Name [ If not found in List ]."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
            ValidationGroup="taBDFare"
            onfocus = "return this.select();"
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
            ValidationGroup = "taBDFare"
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
            ValidationGroup="taBDFare"
            onfocus = "return this.select();"
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
            ValidationGroup = "taBDFare"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModeTravelID" runat="server" Text="Travel Mode :" />&nbsp;
        </td>
        <td>
          <LGM:LC_taTravelModes
            ID="F_ModeTravelID"
            SelectedValue='<%# Bind("ModeTravelID") %>'
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
          <asp:Label ID="L_ModeText" runat="server" Text="Travel Mode [ If not found in List ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ModeText"
            Text='<%# Bind("ModeText") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Travel Mode [ If not found in List ]."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountFactor" runat="server" Text="Claimed Unit :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AmountFactor"
            Text='<%# Bind("AmountFactor") %>'
            Width="88px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="taBDFare"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmountFactor"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_AmountFactor" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmountFactor"
            runat = "server"
            ControlToValidate = "F_AmountFactor"
            ControlExtender = "MEEAmountFactor"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDFare"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
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
  ID = "ODStaBDFare"
  DataObjectTypeName = "SIS.TA.taBDFare"
  InsertMethod="UZ_taBDFareInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBDFare"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:panel>
<asp:Label ID="dummy" runat="server" Style="display: none"></asp:Label>
<AJX:ModalPopupExtender ID="pPopup" TargetControlID="dummy" 
  BackgroundCssClass="modalBackground" 
  PopupControlID="div1" 
  CancelControlID="closeaFare"
  PopupDragHandleControlID="div2" runat="server">
</AJX:ModalPopupExtender>
