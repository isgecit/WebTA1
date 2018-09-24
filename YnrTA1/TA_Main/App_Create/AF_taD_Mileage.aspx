<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taD_Mileage.aspx.vb" Inherits="AF_taD_Mileage" title="Add: Category-City Wise Mileage" %>
<asp:Content ID="CPHtaD_Mileage" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaD_Mileage" runat="server" Text="&nbsp;Add: Category-City Wise Mileage"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaD_Mileage" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaD_Mileage"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taD_Mileage"
    runat = "server" />
<asp:FormView ID="FVtaD_Mileage"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODStaD_Mileage"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaD_Mileage" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taCategories
            ID="F_CategoryID"
            SelectedValue='<%# Bind("CategoryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taD_Mileage"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CityID" runat="server" Text="City ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CityID"
            CssClass = "myfktxt"
            Width="210px"
            Text='<%# Bind("CityID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for City ID."
            onblur= "script_taD_Mileage.validate_CityID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CityID_Display"
            Text='<%# Eval("TA_Cities2_CityName") %>'
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECityID"
            BehaviorID="B_ACECityID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CityIDCompletionList"
            TargetControlID="F_CityID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taD_Mileage.ACECityID_Selected"
            OnClientPopulating="script_taD_Mileage.ACECityID_Populating"
            OnClientPopulated="script_taD_Mileage.ACECityID_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OtherCity" runat="server" Text="Other City :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_OtherCity"
           Checked='<%# Bind("OtherCity") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountPerKM" runat="server" Text="Amount Per KM :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AmountPerKM"
            Text='<%# Bind("AmountPerKM") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            ValidationGroup="taD_Mileage"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmountPerKM"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_AmountPerKM" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmountPerKM"
            runat = "server"
            ControlToValidate = "F_AmountPerKM"
            ControlExtender = "MEEAmountPerKM"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taD_Mileage"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FromDate" runat="server" Text="From Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FromDate"
            Text='<%# Bind("FromDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taD_Mileage"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonFromDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFromDate"
            TargetControlID="F_FromDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFromDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEFromDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FromDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVFromDate"
            runat = "server"
            ControlToValidate = "F_FromDate"
            ControlExtender = "MEEFromDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taD_Mileage"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TillDate" runat="server" Text="Till Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TillDate"
            Text='<%# Bind("TillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taD_Mileage"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonTillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETillDate"
            TargetControlID="F_TillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTillDate" />
          <AJX:MaskedEditExtender 
            ID = "MEETillDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TillDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVTillDate"
            runat = "server"
            ControlToValidate = "F_TillDate"
            ControlExtender = "MEETillDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taD_Mileage"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Active"
           Checked='<%# Bind("Active") %>'
           CssClass = "mychk"
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
  ID = "ODStaD_Mileage"
  DataObjectTypeName = "SIS.TA.taD_Mileage"
  InsertMethod="taD_MileageInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taD_Mileage"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
