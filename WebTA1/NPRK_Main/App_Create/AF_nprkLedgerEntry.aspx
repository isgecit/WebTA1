<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkLedgerEntry.aspx.vb" Inherits="AF_nprkLedgerEntry" title="Add: Perk Ledger" %>
<asp:Content ID="CPHnprkLedgerEntry" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkLedgerEntry" runat="server" Text="&nbsp;Add: Perk Ledger"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkLedgerEntry" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkLedgerEntry"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "nprkLedgerEntry"
    runat = "server" />
<asp:FormView ID="FVnprkLedgerEntry"
  runat = "server"
  DataKeyNames = "DocumentID"
  DataSourceID = "ODSnprkLedgerEntry"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkLedgerEntry" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DocumentID" ForeColor="#CC6633" runat="server" Text="DocumentID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocumentID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EmployeeID" runat="server" Text="EmployeeID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_EmployeeID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("EmployeeID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for EmployeeID."
            ValidationGroup = "nprkLedgerEntry"
            onblur= "script_nprkLedgerEntry.validate_EmployeeID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVEmployeeID"
            runat = "server"
            ControlToValidate = "F_EmployeeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkLedgerEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("PRK_Employees1_EmployeeName") %>'
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
            OnClientItemSelected="script_nprkLedgerEntry.ACEEmployeeID_Selected"
            OnClientPopulating="script_nprkLedgerEntry.ACEEmployeeID_Populating"
            OnClientPopulated="script_nprkLedgerEntry.ACEEmployeeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PerkID" runat="server" Text="PerkID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_nprkPerks
            ID="F_PerkID"
            SelectedValue='<%# Bind("PerkID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkLedgerEntry"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TranType" runat="server" Text="TranType :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_TranType"
            SelectedValue='<%# Bind("TranType") %>'
            Width="200px"
            ValidationGroup = "nprkLedgerEntry"
            CssClass = "myddl"
            onchange="enableCheckTransfer(this);"
            Runat="Server" >
            <asp:ListItem Value="OPB">Opening Balance</asp:ListItem>
            <asp:ListItem Value="ADJ">Adjustment Entry</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVTranType"
            runat = "server"
            ControlToValidate = "F_TranType"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkLedgerEntry"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PostedInBaaN" runat="server" Text="Interperk Transfer :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_PostedInBaaN"
           Checked='<%# Bind("PostedInBaaN") %>'
           CssClass = "mychk"
           ClientIDMode="static"
           Enabled="false"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="Label1" runat="server" Text="Target PerkID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_nprkPerks
            ID="F_TargetPerkID"
            SelectedValue='<%# Bind("TargetPerkID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ClientIDMode="static"
            Enabled="false"
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
            Width="104px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="nprkLedgerEntry"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmount"
            runat = "server"
            mask = "9999999999.99"
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
            ValidationGroup = "nprkLedgerEntry"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
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
            ValidationGroup="nprkLedgerEntry"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRemarks"
            runat = "server"
            ControlToValidate = "F_Remarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkLedgerEntry"
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
  ID = "ODSnprkLedgerEntry"
  DataObjectTypeName = "SIS.NPRK.nprkLedgerEntry"
  InsertMethod="UZ_nprkLedgerEntryInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkLedgerEntry"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
