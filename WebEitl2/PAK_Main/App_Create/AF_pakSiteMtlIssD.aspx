<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSiteMtlIssD.aspx.vb" Inherits="AF_pakSiteMtlIssD" title="Add: Site Material Issue Item" %>
<asp:Content ID="CPHpakSiteMtlIssD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSiteMtlIssD" runat="server" Text="&nbsp;Add: Site Material Issue Item"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteMtlIssD" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSiteMtlIssD"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakSiteMtlIssD"
    runat = "server" />
<asp:FormView ID="FVpakSiteMtlIssD"
  runat = "server"
  DataKeyNames = "ProjectID,IssueNo,IssueSrNo"
  DataSourceID = "ODSpakSiteMtlIssD"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSiteMtlIssD" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "pakSiteMtlIssD"
            onblur= "script_pakSiteMtlIssD.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects1_Description") %>'
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
            OnClientItemSelected="script_pakSiteMtlIssD.ACEProjectID_Selected"
            OnClientPopulating="script_pakSiteMtlIssD.ACEProjectID_Populating"
            OnClientPopulated="script_pakSiteMtlIssD.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueNo" ForeColor="#CC6633" runat="server" Text="Request No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_IssueNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("IssueNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Request No."
            ValidationGroup = "pakSiteMtlIssD"
            onblur= "script_pakSiteMtlIssD.validate_IssueNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIssueNo"
            runat = "server"
            ControlToValidate = "F_IssueNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_IssueNo_Display"
            Text='<%# Eval("PAK_SiteIssueH2_RequesterRemarks") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIssueNo"
            BehaviorID="B_ACEIssueNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IssueNoCompletionList"
            TargetControlID="F_IssueNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSiteMtlIssD.ACEIssueNo_Selected"
            OnClientPopulating="script_pakSiteMtlIssD.ACEIssueNo_Populating"
            OnClientPopulated="script_pakSiteMtlIssD.ACEIssueNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueSrNo" ForeColor="#CC6633" runat="server" Text="Request Line No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IssueSrNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SiteMarkNo" runat="server" Text="Site Mark No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SiteMarkNo"
            CssClass = "myfktxt"
            Width="248px"
            Text='<%# Bind("SiteMarkNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Site Mark No."
            ValidationGroup = "pakSiteMtlIssD"
            onblur= "script_pakSiteMtlIssD.validate_SiteMarkNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSiteMarkNo"
            runat = "server"
            ControlToValidate = "F_SiteMarkNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SiteMarkNo_Display"
            Text='<%# Eval("PAK_SiteItemMaster3_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESiteMarkNo"
            BehaviorID="B_ACESiteMarkNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SiteMarkNoCompletionList"
            TargetControlID="F_SiteMarkNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSiteMtlIssD.ACESiteMarkNo_Selected"
            OnClientPopulating="script_pakSiteMtlIssD.ACESiteMarkNo_Populating"
            OnClientPopulated="script_pakSiteMtlIssD.ACESiteMarkNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_QuantityRequired" runat="server" Text="Quantity Required :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_QuantityRequired"
            Text='<%# Bind("QuantityRequired") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="pakSiteMtlIssD"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEQuantityRequired"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_QuantityRequired" />
          <AJX:MaskedEditValidator 
            ID = "MEVQuantityRequired"
            runat = "server"
            ControlToValidate = "F_QuantityRequired"
            ControlExtender = "MEEQuantityRequired"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssD"
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
  ID = "ODSpakSiteMtlIssD"
  DataObjectTypeName = "SIS.PAK.pakSiteMtlIssD"
  InsertMethod="pakSiteMtlIssDInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSiteMtlIssD"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
