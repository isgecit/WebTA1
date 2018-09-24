<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkApplications.aspx.vb" Inherits="AF_nprkApplications" title="Perk Entry Form" %>
<asp:Content ID="CPHnprkApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkApplications" runat="server" Text="&nbsp;Perk Entry Form"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkApplications" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkApplications"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/NPRK_Main/App_Edit/EF_nprkApplications.aspx"
    ValidationGroup = "nprkApplications"
    runat = "server" />
<asp:FormView ID="FVnprkApplications"
  runat = "server"
  DataKeyNames = "ApplicationID,ClaimID"
  DataSourceID = "ODSnprkApplications"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkApplications" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" ForeColor="#CC6633" runat="server" Text="Claim Ref.No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ClaimRefNo"
            Text='<%# Bind("ClaimRefNo") %>'
            ToolTip="Value of Claim ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
          <asp:TextBox
            ID = "F_ClaimID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ClaimID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Claim Number."
            ValidationGroup = "nprkApplications"
            onblur= "script_nprkApplications.validate_ClaimID(this);"
            style="display:none;"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVClaimID"
            runat = "server"
            ControlToValidate = "F_ClaimID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkApplications"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ClaimID_Display"
            Text='<%# Eval("PRK_UserClaims9_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEClaimID"
            BehaviorID="B_ACEClaimID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ClaimIDCompletionList"
            TargetControlID="F_ClaimID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_nprkApplications.ACEClaimID_Selected"
            OnClientPopulating="script_nprkApplications.ACEClaimID_Populating"
            OnClientPopulated="script_nprkApplications.ACEClaimID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ApplicationID" ForeColor="#CC6633" style="display:none" runat="server" Text="Application ID :" /></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApplicationID" Enabled="False" style="display:none" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PerkID" runat="server" Text="Perk Type :" /><span style="color:red">*</span>
        </td>
        <td >
          <LGM:LC_nprkPerksClaimable
            ID="F_PerkID"
            SelectedValue='<%# Bind("PerkID") %>'
            OrderBy="Sequence"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkApplications" 
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            OnSelectedIndexChanged="ShowBalance"
            AutoPostBack="true"
            Runat="Server" />
          </td>
        <td>
          <b><asp:Label ID="Label1" runat="server" Text="Ledger Balance: " /></b>
        </td>
        <td>
          <b>
            <asp:Label ID="L_Balance" runat="server" Text="0.00" />
          </b>
        </td>
      </tr>
      <tr>
        <td colspan="4" style="background-color:aliceblue;" >
            <LGM:LC_PrkBalanceAsOn ID="LC_PrkBalance1" runat="server" />
        </td>
      </tr>
      <tr>
        <td colspan="4" style="background-color:aliceblue;text-align:center;border: solid 1pt blue;" >
          <asp:Label ID="L_ErrorMsg" ForeColor="red" Visible="false" runat="server" Text="NOTE: Application for this PERK is already under processing. You can not APPLY till that is PAID or REJECTED." />
        </td>
      </tr>
      <tr>
        <td colspan="4" style="background-color:aliceblue; text-align:center;border: solid 1pt blue;" >
           <asp:Label ID="L_crn" ForeColor="Blue" Font-Bold="true" Visible="false" runat="server" Text="" />
        </td>
      </tr>
<%--      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserRemark" runat="server" Text="User Remark :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UserRemark"
            Text='<%# Bind("UserRemark") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for User Remark."
            MaxLength="200"
            Width="350px" 
            runat="server" />
        </td>
      </tr>--%>
      <tr>
        <td colspan="4">
          <br />
          <b>INSTRUCTIONS: </b>First select the Perk Type then SAVE this Perk Entry Form to enter Bill Details.
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkApplications"
  DataObjectTypeName = "SIS.NPRK.nprkApplications"
  InsertMethod="UZ_nprkApplicationsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkApplications"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
