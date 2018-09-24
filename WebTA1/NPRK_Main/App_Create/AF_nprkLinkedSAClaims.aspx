<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkLinkedSAClaims.aspx.vb" Inherits="AF_nprkLinkedSAClaims" title="Add: Selected Claims" %>
<asp:Content ID="CPHnprkLinkedSAClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkLinkedSAClaims" runat="server" Text="&nbsp;Add: Selected Claims"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkLinkedSAClaims" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkLinkedSAClaims"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "nprkLinkedSAClaims"
    runat = "server" />
<asp:FormView ID="FVnprkLinkedSAClaims"
  runat = "server"
  DataKeyNames = "FinYear,Quarter,EmployeeID"
  DataSourceID = "ODSnprkLinkedSAClaims"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkLinkedSAClaims" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin Year :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            Enabled = "False"
            ToolTip="Value of Fin Year."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear3_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="Label1" ForeColor="#CC6633" runat="server" Text="Advice No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_AdviceNo"
            Width="88px"
            Text='<%# Bind("AdviceNo") %>'
            Enabled = "False"
            CssClass = "dmypktxt"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" ForeColor="#CC6633" runat="server" Text="Quarter :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            Enabled = "False"
            ToolTip="Value of Quarter."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_EmployeeID" ForeColor="#CC6633" runat="server" Text="Employee :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            CssClass = "mypktxt"
            Width="72px"
            Text='<%# Bind("EmployeeID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Employee."
            ValidationGroup = "nprkLinkedSAClaims"
            onblur= "script_nprkLinkedSAClaims.validate_EmployeeID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVEmployeeID"
            runat = "server"
            ControlToValidate = "F_EmployeeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkLinkedSAClaims"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("HRM_Employees5_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEmployeeID"
            BehaviorID="B_ACEEmployeeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EmployeeIDCompletionList"
            TargetControlID="F_EmployeeID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_nprkLinkedSAClaims.ACEEmployeeID_Selected"
            OnClientPopulating="script_nprkLinkedSAClaims.ACEEmployeeID_Populating"
            OnClientPopulated="script_nprkLinkedSAClaims.ACEEmployeeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled1Days" runat="server" Text="Entitled Days [1] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled1Days"
            Text='<%# Bind("Entitled1Days") %>'
            Width="72px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled1Days"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled1Days" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled1Days"
            runat = "server"
            ControlToValidate = "F_Entitled1Days"
            ControlExtender = "MEEEntitled1Days"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled2Days" runat="server" Text="Entitled Days [2] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled2Days"
            Text='<%# Bind("Entitled2Days") %>'
            Width="72px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled2Days"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled2Days" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled2Days"
            runat = "server"
            ControlToValidate = "F_Entitled2Days"
            ControlExtender = "MEEEntitled2Days"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled3Days" runat="server" Text="Entitled Days [3] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled3Days"
            Text='<%# Bind("Entitled3Days") %>'
            Width="72px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled3Days"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled3Days" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled3Days"
            runat = "server"
            ControlToValidate = "F_Entitled3Days"
            ControlExtender = "MEEEntitled3Days"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled1Amount" runat="server" Text="Entitled Amount [1] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled1Amount"
            Text='<%# Bind("Entitled1Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled1Amount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled1Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled1Amount"
            runat = "server"
            ControlToValidate = "F_Entitled1Amount"
            ControlExtender = "MEEEntitled1Amount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled2Amount" runat="server" Text="Entitled Amount [2] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled2Amount"
            Text='<%# Bind("Entitled2Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled2Amount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled2Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled2Amount"
            runat = "server"
            ControlToValidate = "F_Entitled2Amount"
            ControlExtender = "MEEEntitled2Amount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled3Amount" runat="server" Text="Entitled Amount [3] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled3Amount"
            Text='<%# Bind("Entitled3Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled3Amount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled3Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled3Amount"
            runat = "server"
            ControlToValidate = "F_Entitled3Amount"
            ControlExtender = "MEEEntitled3Amount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverRemarks" runat="server" Text="Accounts Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Accounts Remarks."
            MaxLength="100"
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
  ID = "ODSnprkLinkedSAClaims"
  DataObjectTypeName = "SIS.NPRK.nprkLinkedSAClaims"
  InsertMethod="UZ_nprkLinkedSAClaimsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkLinkedSAClaims"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
