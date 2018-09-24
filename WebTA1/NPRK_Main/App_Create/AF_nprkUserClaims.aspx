<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkUserClaims.aspx.vb" Inherits="AF_nprkUserClaims" title="Add: Claims" %>
<asp:Content ID="CPHnprkUserClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkUserClaims" runat="server" Text="&nbsp;Add: Claims"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkUserClaims" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkUserClaims"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/NPRK_Main/App_Edit/EF_nprkUserClaims.aspx"
    ValidationGroup = "nprkUserClaims"
    runat = "server" />
<asp:FormView ID="FVnprkUserClaims"
  runat = "server"
  DataKeyNames = "ClaimID"
  DataSourceID = "ODSnprkUserClaims"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkUserClaims" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" ForeColor="#CC6633" runat="server" Text="Claim ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ClaimID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkUserClaims"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CardNo" runat="server" Text="Card No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CardNo"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("CardNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Card No."
            ValidationGroup = "nprkUserClaims"
            onblur= "script_nprkUserClaims.validate_CardNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCardNo"
            runat = "server"
            ControlToValidate = "F_CardNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_nprkUserClaims.ACECardNo_Selected"
            OnClientPopulating="script_nprkUserClaims.ACECardNo_Populating"
            OnClientPopulated="script_nprkUserClaims.ACECardNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PassedAmount" runat="server" Text="Passed Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_PassedAmount"
            Text='<%# Bind("PassedAmount") %>'
            Width="120px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="nprkUserClaims"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPassedAmount"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PassedAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVPassedAmount"
            runat = "server"
            ControlToValidate = "F_PassedAmount"
            ControlExtender = "MEEPassedAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalAmount" runat="server" Text="Claimed Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_TotalAmount"
            Text='<%# Bind("TotalAmount") %>'
            Width="120px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="nprkUserClaims"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETotalAmount"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TotalAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVTotalAmount"
            runat = "server"
            ControlToValidate = "F_TotalAmount"
            ControlExtender = "MEETotalAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DeclarationAccepted" runat="server" Text="Declaration Accepted :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DeclarationAccepted"
           Checked='<%# Bind("DeclarationAccepted") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SubmittedOn" runat="server" Text="Submitted On :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SubmittedOn"
            Text='<%# Bind("SubmittedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="nprkUserClaims"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonSubmittedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CESubmittedOn"
            TargetControlID="F_SubmittedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonSubmittedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEESubmittedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SubmittedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVSubmittedOn"
            runat = "server"
            ControlToValidate = "F_SubmittedOn"
            ControlExtender = "MEESubmittedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ReceivedOn" runat="server" Text="Received On :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ReceivedOn"
            Text='<%# Bind("ReceivedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="nprkUserClaims"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonReceivedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEReceivedOn"
            TargetControlID="F_ReceivedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonReceivedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEEReceivedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ReceivedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVReceivedOn"
            runat = "server"
            ControlToValidate = "F_ReceivedOn"
            ControlExtender = "MEEReceivedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReceivedBy" runat="server" Text="Received By :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceivedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("ReceivedBy") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Received By."
            ValidationGroup = "nprkUserClaims"
            onblur= "script_nprkUserClaims.validate_ReceivedBy(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVReceivedBy"
            runat = "server"
            ControlToValidate = "F_ReceivedBy"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ReceivedBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEReceivedBy"
            BehaviorID="B_ACEReceivedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ReceivedByCompletionList"
            TargetControlID="F_ReceivedBy"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_nprkUserClaims.ACEReceivedBy_Selected"
            OnClientPopulating="script_nprkUserClaims.ACEReceivedBy_Populating"
            OnClientPopulated="script_nprkUserClaims.ACEReceivedBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ReturnedOn" runat="server" Text="Returned On :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ReturnedOn"
            Text='<%# Bind("ReturnedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="nprkUserClaims"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonReturnedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEReturnedOn"
            TargetControlID="F_ReturnedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonReturnedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEEReturnedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ReturnedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVReturnedOn"
            runat = "server"
            ControlToValidate = "F_ReturnedOn"
            ControlExtender = "MEEReturnedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReturnedBy" runat="server" Text="Returned By :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReturnedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("ReturnedBy") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Returned By."
            ValidationGroup = "nprkUserClaims"
            onblur= "script_nprkUserClaims.validate_ReturnedBy(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVReturnedBy"
            runat = "server"
            ControlToValidate = "F_ReturnedBy"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ReturnedBy_Display"
            Text='<%# Eval("aspnet_users3_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEReturnedBy"
            BehaviorID="B_ACEReturnedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ReturnedByCompletionList"
            TargetControlID="F_ReturnedBy"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_nprkUserClaims.ACEReturnedBy_Selected"
            OnClientPopulating="script_nprkUserClaims.ACEReturnedBy_Populating"
            OnClientPopulated="script_nprkUserClaims.ACEReturnedBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CompletedOn" runat="server" Text="Completed On :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CompletedOn"
            Text='<%# Bind("CompletedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="nprkUserClaims"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonCompletedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CECompletedOn"
            TargetControlID="F_CompletedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonCompletedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEECompletedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CompletedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVCompletedOn"
            runat = "server"
            ControlToValidate = "F_CompletedOn"
            ControlExtender = "MEECompletedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AccountsRemarks" runat="server" Text="Accounts Remarks :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_AccountsRemarks"
            Text='<%# Bind("AccountsRemarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkUserClaims"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Accounts Remarks."
            MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAccountsRemarks"
            runat = "server"
            ControlToValidate = "F_AccountsRemarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkUserClaims"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ClaimStatusID" runat="server" Text="Claim Status :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_nprkClaimStatus
            ID="F_ClaimStatusID"
            SelectedValue='<%# Bind("ClaimStatusID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkUserClaims"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkUserClaims"
  DataObjectTypeName = "SIS.NPRK.nprkUserClaims"
  InsertMethod="UZ_nprkUserClaimsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkUserClaims"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
