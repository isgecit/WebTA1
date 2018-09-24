<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkSiteAllowanceAdvice.aspx.vb" Inherits="AF_nprkSiteAllowanceAdvice" title="Add: SA Advice" %>
<asp:Content ID="CPHnprkSiteAllowanceAdvice" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkSiteAllowanceAdvice" runat="server" Text="&nbsp;Add: SA Advice"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkSiteAllowanceAdvice" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkSiteAllowanceAdvice"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/NPRK_Main/App_Edit/EF_nprkSiteAllowanceAdvice.aspx"
    ValidationGroup = "nprkSiteAllowanceAdvice"
    runat = "server" />
<asp:FormView ID="FVnprkSiteAllowanceAdvice"
  runat = "server"
  DataKeyNames = "FinYear,Quarter,AdviceNo"
  DataSourceID = "ODSnprkSiteAllowanceAdvice"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkSiteAllowanceAdvice" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Fin Year."
            ValidationGroup = "nprkSiteAllowanceAdvice"
            onblur= "script_nprkSiteAllowanceAdvice.validate_FinYear(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFinYear"
            runat = "server"
            ControlToValidate = "F_FinYear"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkSiteAllowanceAdvice"
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
            OnClientItemSelected="script_nprkSiteAllowanceAdvice.ACEFinYear_Selected"
            OnClientPopulating="script_nprkSiteAllowanceAdvice.ACEFinYear_Populating"
            OnClientPopulated="script_nprkSiteAllowanceAdvice.ACEFinYear_Populated"
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
            ValidationGroup = "nprkSiteAllowanceAdvice"
            onblur= "script_nprkSiteAllowanceAdvice.validate_Quarter(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVQuarter"
            runat = "server"
            ControlToValidate = "F_Quarter"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkSiteAllowanceAdvice"
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
            OnClientItemSelected="script_nprkSiteAllowanceAdvice.ACEQuarter_Selected"
            OnClientPopulating="script_nprkSiteAllowanceAdvice.ACEQuarter_Populating"
            OnClientPopulated="script_nprkSiteAllowanceAdvice.ACEQuarter_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AdviceNo" ForeColor="#CC6633" runat="server" Text="Advice No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AdviceNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
  ID = "ODSnprkSiteAllowanceAdvice"
  DataObjectTypeName = "SIS.NPRK.nprkSiteAllowanceAdvice"
  InsertMethod="UZ_nprkSiteAllowanceAdviceInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkSiteAllowanceAdvice"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
