<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costAdjustmentEntry.aspx.vb" Inherits="AF_costAdjustmentEntry" title="Add: Adjustment Entry" %>
<asp:Content ID="CPHcostAdjustmentEntry" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostAdjustmentEntry" runat="server" Text="&nbsp;Add: Adjustment Entry"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostAdjustmentEntry" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostAdjustmentEntry"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costAdjustmentEntry"
    runat = "server" />
<asp:FormView ID="FVcostAdjustmentEntry"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,Revision,AdjustmentSerialNo"
  DataSourceID = "ODScostAdjustmentEntry"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostAdjustmentEntry" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" ForeColor="#CC6633" runat="server" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project Group ID."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_ProjectGroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectGroupID"
            runat = "server"
            ControlToValidate = "F_ProjectGroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups6_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectGroupID"
            BehaviorID="B_ACEProjectGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectGroupIDCompletionList"
            TargetControlID="F_ProjectGroupID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costAdjustmentEntry.ACEProjectGroupID_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACEProjectGroupID_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACEProjectGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin. Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Fin. Year."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_FinYear(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFinYear"
            runat = "server"
            ControlToValidate = "F_FinYear"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear5_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFinYear"
            BehaviorID="B_ACEFinYear"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FinYearCompletionList"
            TargetControlID="F_FinYear"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costAdjustmentEntry.ACEFinYear_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACEFinYear_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACEFinYear_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" ForeColor="#CC6633" runat="server" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_Quarter"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Quarter."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_Quarter(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVQuarter"
            runat = "server"
            ControlToValidate = "F_Quarter"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEQuarter"
            BehaviorID="B_ACEQuarter"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="QuarterCompletionList"
            TargetControlID="F_Quarter"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costAdjustmentEntry.ACEQuarter_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACEQuarter_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACEQuarter_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Revision" ForeColor="#CC6633" runat="server" Text="Revision :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Revision"
            Text='<%# Bind("Revision") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            onblur= "script_costAdjustmentEntry.validate_Revision(this);"
            ValidationGroup="costAdjustmentEntry"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEERevision"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Revision" />
          <AJX:MaskedEditValidator 
            ID = "MEVRevision"
            runat = "server"
            ControlToValidate = "F_Revision"
            ControlExtender = "MEERevision"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AdjustmentSerialNo" ForeColor="#CC6633" runat="server" Text="Adjustment Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AdjustmentSerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects8_Description") %>'
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
            OnClientItemSelected="script_costAdjustmentEntry.ACEProjectID_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACEProjectID_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CrGLCode" runat="server" Text="Cr. GL Code :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CrGLCode"
            CssClass = "myfktxt"
            Width="64px"
            Text='<%# Bind("CrGLCode") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Cr. GL Code."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_CrGLCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCrGLCode"
            runat = "server"
            ControlToValidate = "F_CrGLCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_CrGLCode_Display"
            Text='<%# Eval("COST_ERPGLCodes3_GLDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECrGLCode"
            BehaviorID="B_ACECrGLCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CrGLCodeCompletionList"
            TargetControlID="F_CrGLCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costAdjustmentEntry.ACECrGLCode_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACECrGLCode_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACECrGLCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DrGLCode" runat="server" Text="Dr. GL Code :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_DrGLCode"
            CssClass = "myfktxt"
            Width="64px"
            Text='<%# Bind("DrGLCode") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Dr. GL Code."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_DrGLCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDrGLCode"
            runat = "server"
            ControlToValidate = "F_DrGLCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_DrGLCode_Display"
            Text='<%# Eval("COST_ERPGLCodes4_GLDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDrGLCode"
            BehaviorID="B_ACEDrGLCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DrGLCodeCompletionList"
            TargetControlID="F_DrGLCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costAdjustmentEntry.ACEDrGLCode_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACEDrGLCode_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACEDrGLCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Amount" runat="server" Text="Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costAdjustmentEntry"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmount"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmount"
            runat = "server"
            ControlToValidate = "F_Amount"
            ControlExtender = "MEEAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costAdjustmentEntry"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRemarks"
            runat = "server"
            ControlToValidate = "F_Remarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostAdjustmentEntry"
  DataObjectTypeName = "SIS.COST.costAdjustmentEntry"
  InsertMethod="UZ_costAdjustmentEntryInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costAdjustmentEntry"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
