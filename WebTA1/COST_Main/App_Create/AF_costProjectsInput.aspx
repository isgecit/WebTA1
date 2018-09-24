<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costProjectsInput.aspx.vb" Inherits="AF_costProjectsInput" title="Add: Projects Input" %>
<asp:Content ID="CPHcostProjectsInput" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectsInput" runat="server" Text="&nbsp;Add: Projects Input"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectsInput" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectsInput"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/COST_Main/App_Edit/EF_costProjectsInput.aspx"
    ValidationGroup = "costProjectsInput"
    runat = "server" />
<asp:FormView ID="FVcostProjectsInput"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter"
  DataSourceID = "ODScostProjectsInput"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostProjectsInput" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "costProjectsInput"
            onblur= "script_costProjectsInput.validate_ProjectGroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectGroupID"
            runat = "server"
            ControlToValidate = "F_ProjectGroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInput"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups4_ProjectGroupDescription") %>'
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
            OnClientItemSelected="script_costProjectsInput.ACEProjectGroupID_Selected"
            OnClientPopulating="script_costProjectsInput.ACEProjectGroupID_Populating"
            OnClientPopulated="script_costProjectsInput.ACEProjectGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Fin Year."
            ValidationGroup = "costProjectsInput"
            onblur= "script_costProjectsInput.validate_FinYear(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFinYear"
            runat = "server"
            ControlToValidate = "F_FinYear"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInput"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear3_Descpription") %>'
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
            OnClientItemSelected="script_costProjectsInput.ACEFinYear_Selected"
            OnClientPopulating="script_costProjectsInput.ACEFinYear_Populating"
            OnClientPopulated="script_costProjectsInput.ACEFinYear_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" ForeColor="#CC6633" runat="server" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Quarter."
            ValidationGroup = "costProjectsInput"
            onblur= "script_costProjectsInput.validate_Quarter(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVQuarter"
            runat = "server"
            ControlToValidate = "F_Quarter"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInput"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters6_Description") %>'
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
            OnClientItemSelected="script_costProjectsInput.ACEQuarter_Selected"
            OnClientPopulating="script_costProjectsInput.ACEQuarter_Populating"
            OnClientPopulated="script_costProjectsInput.ACEQuarter_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyPR" runat="server" Text="Currency for Project Input :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_CurrencyPR"
            SelectedValue='<%# Bind("CurrencyPR") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costProjectsInput"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_CFforPR" runat="server" Text="Conversion Factor [INR] :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CFforPR"
            Text='<%# Bind("CFforPR") %>'
            Width="120px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costProjectsInput"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECFforPR"
            runat = "server"
            mask = "99999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CFforPR" />
          <AJX:MaskedEditValidator 
            ID = "MEVCFforPR"
            runat = "server"
            ControlToValidate = "F_CFforPR"
            ControlExtender = "MEECFforPR"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInput"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectRevenue" runat="server" Text="Project Revenue :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectRevenue"
            Text='<%# Bind("ProjectRevenue") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costProjectsInput"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectRevenue"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectRevenue" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectRevenue"
            runat = "server"
            ControlToValidate = "F_ProjectRevenue"
            ControlExtender = "MEEProjectRevenue"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInput"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectMargin" runat="server" Text="Project Margin :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectMargin"
            Text='<%# Bind("ProjectMargin") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costProjectsInput"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectMargin"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectMargin" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectMargin"
            runat = "server"
            ControlToValidate = "F_ProjectMargin"
            ControlExtender = "MEEProjectMargin"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInput"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ExportIncentive" runat="server" Text="Export Incentive :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ExportIncentive"
            Text='<%# Bind("ExportIncentive") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEExportIncentive"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ExportIncentive" />
          <AJX:MaskedEditValidator 
            ID = "MEVExportIncentive"
            runat = "server"
            ControlToValidate = "F_ExportIncentive"
            ControlExtender = "MEEExportIncentive"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
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
            MaxLength="250"
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
  ID = "ODScostProjectsInput"
  DataObjectTypeName = "SIS.COST.costProjectsInput"
  InsertMethod="UZ_costProjectsInputInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectsInput"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
