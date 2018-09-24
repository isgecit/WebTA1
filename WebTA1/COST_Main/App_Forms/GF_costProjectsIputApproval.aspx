<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_costProjectsIputApproval.aspx.vb" Inherits="GF_costProjectsIputApproval" title="Maintain List: Approve Projects Input" %>
<asp:Content ID="CPHcostProjectsIputApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostProjectsIputApproval" runat="server" Text="&nbsp;List: Approve Projects Input"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectsIputApproval" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostProjectsIputApproval"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costProjectsIputApproval.aspx"
      EnableAdd = "False"
      ValidationGroup = "costProjectsIputApproval"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostProjectsIputApproval" runat="server" AssociatedUpdatePanelID="UPNLcostProjectsIputApproval" DisplayAfter="100">
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
          <b><asp:Label ID="L_ProjectGroupID" runat="server" Text="Project Group ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ProjectGroupID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectGroupID"
            BehaviorID="B_ACEProjectGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectGroupIDCompletionList"
            TargetControlID="F_ProjectGroupID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectGroupID_Selected"
            OnClientPopulating="ACEProjectGroupID_Populating"
            OnClientPopulated="ACEProjectGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" Text="Fin Year :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_FinYear(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFinYear"
            BehaviorID="B_ACEFinYear"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FinYearCompletionList"
            TargetControlID="F_FinYear"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEFinYear_Selected"
            OnClientPopulating="ACEFinYear_Populating"
            OnClientPopulated="ACEFinYear_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" Text="Quarter :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_Quarter(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEQuarter"
            BehaviorID="B_ACEQuarter"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="QuarterCompletionList"
            TargetControlID="F_Quarter"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEQuarter_Selected"
            OnClientPopulating="ACEQuarter_Populating"
            OnClientPopulated="ACEQuarter_Populated"
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
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <script type="text/javascript"> 
   var script_ApproverRemarks = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVcostProjectsIputApproval" SkinID="gv_silver" runat="server" DataSourceID="ODScostProjectsIputApproval" DataKeyNames="ProjectGroupID,FinYear,Quarter">
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
        <asp:TemplateField HeaderText="Project Group ID" SortExpression="COST_ProjectGroups4_ProjectGroupDescription">
          <ItemTemplate>
             <asp:Label ID="L_ProjectGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectGroupID") %>' Text='<%# Eval("COST_ProjectGroups4_ProjectGroupDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fin Year" SortExpression="COST_FinYear3_Descpription">
          <ItemTemplate>
             <asp:Label ID="L_FinYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FinYear") %>' Text='<%# Eval("COST_FinYear3_Descpription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quarter" SortExpression="COST_Quarters6_Description">
          <ItemTemplate>
             <asp:Label ID="L_Quarter" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("Quarter") %>' Text='<%# Eval("COST_Quarters6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Order Value [INR]" SortExpression="GroupOrderValueINR">
          <ItemTemplate>
            <asp:Label ID="LabelGroupOrderValueINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GroupOrderValueINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Revenue [INR]" SortExpression="ProjectRevenueINR">
          <ItemTemplate>
            <asp:Label ID="LabelProjectRevenueINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectRevenueINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Margin [INR]" SortExpression="ProjectMarginINR">
          <ItemTemplate>
            <asp:Label ID="LabelProjectMarginINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectMarginINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Export Incentive [INR]" SortExpression="ExportIncentiveINR">
          <ItemTemplate>
            <asp:Label ID="LabelExportIncentiveINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExportIncentiveINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approver Remarks" SortExpression="ApproverRemarks">
          <ItemTemplate>
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Approver Remarks."
            MaxLength="250"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODScostProjectsIputApproval"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costProjectsIputApproval"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costProjectsIputApprovalSelectList"
      TypeName = "SIS.COST.costProjectsIputApproval"
      SelectCountMethod = "costProjectsIputApprovalSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="Text" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="Text" Name="Quarter" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostProjectsIputApproval" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectGroupID" />
    <asp:AsyncPostBackTrigger ControlID="F_FinYear" />
    <asp:AsyncPostBackTrigger ControlID="F_Quarter" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
