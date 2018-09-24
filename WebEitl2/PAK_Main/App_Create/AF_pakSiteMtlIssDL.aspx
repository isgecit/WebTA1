<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSiteMtlIssDL.aspx.vb" Inherits="AF_pakSiteMtlIssDL" title="Add: Site Material Issue Item Location" %>
<asp:Content ID="CPHpakSiteMtlIssDL" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSiteMtlIssDL" runat="server" Text="&nbsp;Add: Site Material Issue Item Location"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteMtlIssDL" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSiteMtlIssDL"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakSiteMtlIssDL"
    runat = "server" />
<asp:FormView ID="FVpakSiteMtlIssDL"
  runat = "server"
  DataKeyNames = "ProjectID,IssueNo,IssueSrNo,IssueSrLNo"
  DataSourceID = "ODSpakSiteMtlIssDL"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSiteMtlIssDL" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "pakSiteMtlIssDL"
            onblur= "script_pakSiteMtlIssDL.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssDL"
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
            OnClientItemSelected="script_pakSiteMtlIssDL.ACEProjectID_Selected"
            OnClientPopulating="script_pakSiteMtlIssDL.ACEProjectID_Populating"
            OnClientPopulated="script_pakSiteMtlIssDL.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_IssueNo" ForeColor="#CC6633" runat="server" Text="Issue No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("IssueNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Issue No."
            ValidationGroup = "pakSiteMtlIssDL"
            onblur= "script_pakSiteMtlIssDL.validate_IssueNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIssueNo"
            runat = "server"
            ControlToValidate = "F_IssueNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssDL"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_IssueNo_Display"
            Text='<%# Eval("PAK_SiteIssueH3_RequesterRemarks") %>'
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
            OnClientItemSelected="script_pakSiteMtlIssDL.ACEIssueNo_Selected"
            OnClientPopulating="script_pakSiteMtlIssDL.ACEIssueNo_Populating"
            OnClientPopulated="script_pakSiteMtlIssDL.ACEIssueNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueSrNo" ForeColor="#CC6633" runat="server" Text="Issue Sr No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueSrNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("IssueSrNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Issue Sr No."
            ValidationGroup = "pakSiteMtlIssDL"
            onblur= "script_pakSiteMtlIssDL.validate_IssueSrNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIssueSrNo"
            runat = "server"
            ControlToValidate = "F_IssueSrNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssDL"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_IssueSrNo_Display"
            Text='<%# Eval("PAK_SiteIssueD2_SiteMarkNo") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIssueSrNo"
            BehaviorID="B_ACEIssueSrNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IssueSrNoCompletionList"
            TargetControlID="F_IssueSrNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSiteMtlIssDL.ACEIssueSrNo_Selected"
            OnClientPopulating="script_pakSiteMtlIssDL.ACEIssueSrNo_Populating"
            OnClientPopulated="script_pakSiteMtlIssDL.ACEIssueSrNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_IssueSrLNo" ForeColor="#CC6633" runat="server" Text="Issue Sr L No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_IssueSrLNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
            ValidationGroup = "pakSiteMtlIssDL"
            onblur= "script_pakSiteMtlIssDL.validate_SiteMarkNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSiteMarkNo"
            runat = "server"
            ControlToValidate = "F_SiteMarkNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssDL"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SiteMarkNo_Display"
            Text='<%# Eval("PAK_SiteItemMaster4_ItemDescription") %>'
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
            OnClientItemSelected="script_pakSiteMtlIssDL.ACESiteMarkNo_Selected"
            OnClientPopulating="script_pakSiteMtlIssDL.ACESiteMarkNo_Populating"
            OnClientPopulated="script_pakSiteMtlIssDL.ACESiteMarkNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_QuantityIssued" runat="server" Text="Quantity Issued :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_QuantityIssued"
            Text='<%# Bind("QuantityIssued") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="pakSiteMtlIssDL"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEQuantityIssued"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_QuantityIssued" />
          <AJX:MaskedEditValidator 
            ID = "MEVQuantityIssued"
            runat = "server"
            ControlToValidate = "F_QuantityIssued"
            ControlExtender = "MEEQuantityIssued"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssDL"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_LocationID" runat="server" Text="Location :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_pakSiteLocations
            ID="F_LocationID"
            SelectedValue='<%# Bind("LocationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pakSiteMtlIssDL"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
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
  ID = "ODSpakSiteMtlIssDL"
  DataObjectTypeName = "SIS.PAK.pakSiteMtlIssDL"
  InsertMethod="UZ_pakSiteMtlIssDLInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSiteMtlIssDL"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
