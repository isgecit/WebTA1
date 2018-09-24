<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costCostSheet.aspx.vb" Inherits="AF_costCostSheet" title="Add: Cost Sheet" %>
<asp:Content ID="CPHcostCostSheet" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostCostSheet" runat="server" Text="&nbsp;Add: Cost Sheet"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostCostSheet" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostCostSheet"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/COST_Main/App_Edit/EF_costCostSheet.aspx"
    ValidationGroup = "costCostSheet"
    runat = "server" />
<asp:FormView ID="FVcostCostSheet"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,Revision"
  DataSourceID = "ODScostCostSheet"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostCostSheet" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "costCostSheet"
            onblur= "script_costCostSheet.validate_ProjectGroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectGroupID"
            runat = "server"
            ControlToValidate = "F_ProjectGroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCostSheet"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups5_ProjectGroupDescription") %>'
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
            OnClientItemSelected="script_costCostSheet.ACEProjectGroupID_Selected"
            OnClientPopulating="script_costCostSheet.ACEProjectGroupID_Populating"
            OnClientPopulated="script_costCostSheet.ACEProjectGroupID_Populated"
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
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Fin. Year."
            ValidationGroup = "costCostSheet"
            onblur= "script_costCostSheet.validate_FinYear(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFinYear"
            runat = "server"
            ControlToValidate = "F_FinYear"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCostSheet"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear4_Descpription") %>'
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
            OnClientItemSelected="script_costCostSheet.ACEFinYear_Selected"
            OnClientPopulating="script_costCostSheet.ACEFinYear_Populating"
            OnClientPopulated="script_costCostSheet.ACEFinYear_Populated"
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
            ValidationGroup = "costCostSheet"
            onblur= "script_costCostSheet.validate_Quarter(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVQuarter"
            runat = "server"
            ControlToValidate = "F_Quarter"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCostSheet"
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
            OnClientItemSelected="script_costCostSheet.ACEQuarter_Selected"
            OnClientPopulating="script_costCostSheet.ACEQuarter_Populating"
            OnClientPopulated="script_costCostSheet.ACEQuarter_Populated"
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
        <td>
          <asp:TextBox ID="F_Revision"
            Text='<%# Bind("Revision") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="costCostSheet"
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
            ValidationGroup = "costCostSheet"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostCostSheet"
  DataObjectTypeName = "SIS.COST.costCostSheet"
  InsertMethod="UZ_costCostSheetInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costCostSheet"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
