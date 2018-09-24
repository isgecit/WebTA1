<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkVrfrApplications.aspx.vb" Inherits="GF_nprkVrfrApplications" title="Maintain List: Verify Application" %>
<asp:Content ID="CPHnprkVrfrApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkVrfrApplications" runat="server" Text="&nbsp;List: Verify Application"></asp:Label>
    <div style="float:right">
    <table>
      <tr>
        <td>
          <input type="button" value="Entitlement Sheet" class="myfktxt" style="vertical-align: top; padding-top: 0px;" title="Click to view entitlement sheet" onclick="show_entitlement();" />
        </td>
        <td>
          <LGM:LC_YearDate id="lc_yeardate1" runat="server"></LGM:LC_YearDate>
        </td>
      </tr>
    </table>
    </div>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkVrfrApplications" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkVrfrApplications"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkVrfrApplications.aspx"
      EnableAdd = "False"
      ValidationGroup = "nprkVrfrApplications"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkVrfrApplications" runat="server" AssociatedUpdatePanelID="UPNLnprkVrfrApplications" DisplayAfter="100">
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
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
      function show_entitlement() {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_nprkVrfrApplications', 'App_Print/RP_nprkEntitlementSheet');
        window.open(url, nam, 'left=20,top=20,width=700,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <script type="text/javascript"> 
   var script_Documents = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_Verified = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_PaymentMethod = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_VerifiedAmt = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_VerifierRemark = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVnprkVrfrApplications" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkVrfrApplications" DataKeyNames="ClaimID,ApplicationID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
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
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="Value">
          <ItemTemplate>
            <asp:Label ID="LabelValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User Remark" SortExpression="UserRemark">
          <ItemTemplate>
            <asp:Label ID="LabelUserRemark" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UserRemark") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Doc.OK" SortExpression="Documents">
          <ItemTemplate>
          <asp:DropDownList
            ID="F_Documents"
            SelectedValue='<%# Bind("Documents") %>'
            CssClass = "myddl"
            Width="50px"
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            Runat="Server" >
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVDocuments"
            runat = "server"
            ControlToValidate = "F_Documents"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verified" SortExpression="Verified">
          <ItemTemplate>
          <asp:DropDownList
            ID="F_Verified"
            SelectedValue='<%# Bind("Verified") %>'
            CssClass = "myddl"
            Width="50px"
            Runat="Server" >
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Method" SortExpression="PaymentMethod">
          <ItemTemplate>
          <asp:DropDownList
            ID="F_PaymentMethod"
            SelectedValue='<%# Bind("PaymentMethod") %>'
            CssClass = "myddl"
            Width="80px"
            ValidationGroup='<%# "Approve" & Container.DataItemIndex %>'
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="Cash">Cash</asp:ListItem>
            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
            <asp:ListItem Value="Imprest">Imprest</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVPaymentMethod"
            runat = "server"
            ControlToValidate = "F_PaymentMethod"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup='<%# "Approve" & Container.DataItemIndex %>'
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verified Amt" SortExpression="VerifiedAmt">
          <ItemTemplate>
          <asp:TextBox ID="F_VerifiedAmt"
            Text='<%# Bind("VerifiedAmt") %>'
            style="text-align: right"
            Width="104px"
            CssClass = "mytxt"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEVerifiedAmt"
            runat = "server"
            mask = "9999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_VerifiedAmt" />
          <AJX:MaskedEditValidator 
            ID = "MEVVerifiedAmt"
            runat = "server"
            ControlToValidate = "F_VerifiedAmt"
            ControlExtender = "MEEVerifiedAmt"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="VerifierRemark">
          <ItemTemplate>
          <asp:TextBox ID="F_VerifierRemark"
            Text='<%# Bind("VerifierRemark") %>'
            Width="100px" 
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="100"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verify">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Verify record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reject">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reject" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Reject record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSnprkVrfrApplications"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkVrfrApplications"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkVrfrApplicationsSelectList"
      TypeName = "SIS.NPRK.nprkVrfrApplications"
      SelectCountMethod = "nprkVrfrApplicationsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVnprkVrfrApplications" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_EmployeeID" />
    <asp:AsyncPostBackTrigger ControlID="F_PerkID" />
    <asp:AsyncPostBackTrigger ControlID="lc_yeardate1" EventName="YearDateChanged"  />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
