<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkChequePayment.aspx.vb" Inherits="GF_nprkChequePayment" title="Maintain List: Cheque Payment" %>
<asp:Content ID="CPHnprkChequePayment" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkChequePayment" runat="server" Text="&nbsp;List: Cheque Payment"></asp:Label>
    <div style="float:right">
      <LGM:LC_YearDate id="lc_yeardate1" runat="server"></LGM:LC_YearDate>
    </div>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkChequePayment" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkChequePayment"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkChequePayment.aspx"
      EnableAdd = "False"
      ValidationGroup = "nprkChequePayment"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkChequePayment" runat="server" AssociatedUpdatePanelID="UPNLnprkChequePayment" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_EmployeeID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEmployeeID"
            BehaviorID="B_ACEEmployeeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EmployeeIDCompletionList"
            TargetControlID="F_EmployeeID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEmployeeID_Selected"
            OnClientPopulating="ACEEmployeeID_Populating"
            OnClientPopulated="ACEEmployeeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PerkID" runat="server" Text="Perk :" /></b>
        </td>
        <td>
          <LGM:LC_nprkPerks
            ID="F_PerkID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="PerkID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript"> 
   var script_UpdatedInLedger = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVnprkChequePayment" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkChequePayment" DataKeyNames="ClaimID,ApplicationID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee" SortExpression="PRK_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_EmployeeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("EmployeeID") %>' Text='<%# Eval("PRK_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Perk" SortExpression="PRK_Perks7_Description">
          <ItemTemplate>
             <%# Eval("Notification") %>
             <asp:Label ID="L_PerkID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("PerkID") %>' Text='<%# Eval("PRK_Perks7_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Applied On" SortExpression="AppliedOn">
          <ItemTemplate>
            <asp:Label ID="LabelAppliedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AppliedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Doc.OK" SortExpression="Documents">
          <ItemTemplate>
            <asp:Label ID="LabelDocuments" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Documents") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verified" SortExpression="Verified">
          <ItemTemplate>
            <asp:Label ID="LabelVerified" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Verified") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Method" SortExpression="PaymentMethod">
          <ItemTemplate>
            <asp:Label ID="LabelPaymentMethod" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PaymentMethod") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approved" SortExpression="Approved">
          <ItemTemplate>
            <asp:Label ID="LabelApproved" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Approved") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approved Amt" SortExpression="ApprovedAmt">
          <ItemTemplate>
            <asp:Label ID="LabelApprovedAmt" runat="server" ForeColor="Red" Font-Bold="true" Text='<%# Bind("ApprovedAmt") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approver Remark" SortExpression="ApproverRemark">
          <ItemTemplate>
            <asp:Label ID="LabelApproverRemark" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApproverRemark") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Paid" SortExpression="UpdatedInLedger">
          <ItemTemplate>
          <asp:DropDownList
            ID="F_UpdatedInLedger"
            SelectedValue='<%# Bind("UpdatedInLedger") %>'
            CssClass = "myddl"
            Width="50px"
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVUpdatedInLedger"
            runat = "server"
            ControlToValidate = "F_UpdatedInLedger"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Return">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkChequePayment"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkChequePayment"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkChequePaymentSelectList"
      TypeName = "SIS.NPRK.nprkChequePayment"
      SelectCountMethod = "nprkChequePaymentSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_EmployeeID" PropertyName="Text" Name="EmployeeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_PerkID" PropertyName="SelectedValue" Name="PerkID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkChequePayment" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_EmployeeID" />
    <asp:AsyncPostBackTrigger ControlID="F_PerkID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
