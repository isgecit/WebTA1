<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkVerifyByAdmin.aspx.vb" Inherits="GF_nprkVerifyByAdmin" title="List: Verify By Admin" %>
<asp:Content ID="CPHnprkRECUserClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkRECUserClaims" runat="server" Text="&nbsp;List: Verify By Admin"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkRECUserClaims" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkRECUserClaims"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkRECUserClaims.aspx"
      EnableAdd = "False"
      ValidationGroup = "nprkRECUserClaims"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkRECUserClaims" runat="server" AssociatedUpdatePanelID="UPNLnprkRECUserClaims" DisplayAfter="100">
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
          <b><asp:Label ID="L_CardNo" runat="server" Text="Card No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CardNo"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CardNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECardNo_Selected"
            OnClientPopulating="ACECardNo_Populating"
            OnClientPopulated="ACECardNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
        var url = self.location.href.replace('App_Forms/GF_nprkVerifyByAdmin', 'App_Print/RP_nprkUserClaims');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <script type="text/javascript"> 
   var script_AccountsRemarks = {
    temp: function() {
    }
    }
    </script>
<%--      <asp:Button ID="cmdMigrate" runat="server" Text="Migrate" />--%>
    <asp:GridView ID="GVnprkRECUserClaims" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkRECUserClaims" DataKeyNames="ClaimID">
      <Columns>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claim Ref.No" SortExpression="ClaimID">
          <ItemTemplate>
            <asp:Label ID="LabelClaimID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ClaimRefNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CardNo") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="TotalAmount">
          <ItemTemplate>
            <asp:Label ID="LabelTotalAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submitted On" SortExpression="SubmittedOn">
          <ItemTemplate>
            <asp:Label ID="LabelSubmittedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SubmittedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claim Status" SortExpression="PRK_ClaimStatus4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ClaimStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ClaimStatusID") %>' Text='<%# Eval("PRK_ClaimStatus4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks [If Returned]" SortExpression="AccountsRemarks">
          <ItemTemplate>
          <asp:TextBox ID="F_AccountsRemarks"
            Text='<%# Bind("AccountsRemarks") %>'
            Width="250px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAccountsRemarks"
            runat = "server"
            ControlToValidate = "F_AccountsRemarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "Reject" & Container.DataItemIndex %>'
            SetFocusOnError="true" />
            <asp:Label ID="F_ClaimID" runat="server" Text='<%# Eval("ClaimID") %>' ></asp:Label>
            <asp:gridview id="GVBills" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="1pt" AllowPaging="False" AllowSorting="False" AutoGenerateColumns="False" DataSourceID="ODSBills" DataKeyNames="ClaimID,ApplicationID,AttachmentID" >
              <columns>
                <asp:TemplateField HeaderText="Details">
                   <itemtemplate>
                     <asp:Label ID="L_particular" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                   </itemtemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="Amount">
                  <ItemTemplate>
                    <asp:Label ID="L_Amount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Driver Attendance Verified">
                  <ItemTemplate>
                    <asp:DropDownList
                      id="F_Verify"
                      CssClass="myddl"
                      runat="server">
                      <asp:ListItem Selected="True" Value="" Text="-Select-"></asp:ListItem>
                      <asp:ListItem Value="YES" Text="YES"></asp:ListItem>
                      <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                    </asp:DropDownList>
                  </ItemTemplate>
                  <ItemStyle CssClass="alignCenter" />
                </asp:TemplateField>
              </columns>
            </asp:gridview>
            <asp:ObjectDataSource 
              ID = "ODSBills"
              runat = "server"
              DataObjectTypeName = "SIS.NPRK.nprkBillDetails"
              OldValuesParameterFormatString = "original_{0}"
              SelectMethod = "UZ_DriverBillsByClaimID"
              TypeName = "SIS.NPRK.nprkBillDetails">
              <SelectParameters >
                <asp:ControlParameter ControlID="F_ClaimID" PropertyName="Text" Name="ClaimID" Type="String" Direction="Input" DefaultValue="" />
              </SelectParameters>
            </asp:ObjectDataSource>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="250px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Receive" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Return">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSnprkRECUserClaims"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkRECUserClaims"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkVerifyByAdminSelectList"
      TypeName = "SIS.NPRK.nprkRECUserClaims"
      SelectCountMethod = "nprkVerifyByAdminSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkRECUserClaims" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
