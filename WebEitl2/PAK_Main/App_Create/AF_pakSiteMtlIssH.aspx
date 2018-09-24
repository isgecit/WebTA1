<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSiteMtlIssH.aspx.vb" Inherits="AF_pakSiteMtlIssH" title="Add: Site Material Issue" %>
<asp:Content ID="CPHpakSiteMtlIssH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSiteMtlIssH" runat="server" Text="&nbsp;Add: Site Material Issue"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteMtlIssH" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSiteMtlIssH"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PAK_Main/App_Edit/EF_pakSiteMtlIssH.aspx"
    ValidationGroup = "pakSiteMtlIssH"
    runat = "server" />
<asp:FormView ID="FVpakSiteMtlIssH"
  runat = "server"
  DataKeyNames = "ProjectID,IssueNo"
  DataSourceID = "ODSpakSiteMtlIssH"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSiteMtlIssH" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "pakSiteMtlIssH"
            onblur= "script_pakSiteMtlIssH.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssH"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects3_Description") %>'
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
            OnClientItemSelected="script_pakSiteMtlIssH.ACEProjectID_Selected"
            OnClientPopulating="script_pakSiteMtlIssH.ACEProjectID_Populating"
            OnClientPopulated="script_pakSiteMtlIssH.ACEProjectID_Populated"
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
          <asp:TextBox ID="F_IssueNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RequestedBy"
            Width="72px"
            Text='<%# Bind("RequestedBy") %>'
            Enabled = "False"
            ToolTip="Value of Requested By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_RequestedBy_Display"
            Text='<%# Eval("aspnet_users6_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RequestedOn" runat="server" Text="Requested On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RequestedOn"
            Text='<%# Bind("RequestedOn") %>'
            Enabled = "False"
            ToolTip="Value of Requested On."
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequesterRemarks" runat="server" Text="Requester Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RequesterRemarks"
            Text='<%# Bind("RequesterRemarks") %>'
            Enabled = "False"
            ToolTip="Value of Requester Remarks."
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssueToName" runat="server" Text="Requester Name :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_IssueToName"
            Text='<%# Bind("IssueToName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSiteMtlIssH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Requester Name."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIssueToName"
            runat = "server"
            ControlToValidate = "F_IssueToName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssH"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IssueToCardNo" runat="server" Text="Issue To :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueToCardNo"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("IssueToCardNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Issue To."
            onblur= "script_pakSiteMtlIssH.validate_IssueToCardNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IssueToCardNo_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIssueToCardNo"
            BehaviorID="B_ACEIssueToCardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IssueToCardNoCompletionList"
            TargetControlID="F_IssueToCardNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSiteMtlIssH.ACEIssueToCardNo_Selected"
            OnClientPopulating="script_pakSiteMtlIssH.ACEIssueToCardNo_Populating"
            OnClientPopulated="script_pakSiteMtlIssH.ACEIssueToCardNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssueRemarks" runat="server" Text="Issue Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IssueRemarks"
            Text='<%# Bind("IssueRemarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Issue Remarks."
            MaxLength="100"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssueTypeID" runat="server" Text="Issue Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_pakIssueTypes
            ID="F_IssueTypeID"
            SelectedValue='<%# Bind("IssueTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pakSiteMtlIssH"
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
  ID = "ODSpakSiteMtlIssH"
  DataObjectTypeName = "SIS.PAK.pakSiteMtlIssH"
  InsertMethod="pakSiteMtlIssHInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSiteMtlIssH"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
