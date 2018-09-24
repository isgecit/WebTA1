<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_costProjectsInputAC.aspx.vb" Inherits="GF_costProjectsInputAC" title="Maintain List: Projects Input Data" %>
<asp:Content ID="CPHcostProjectsInputAC" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostProjectsInputAC" runat="server" Text="&nbsp;List: Projects Input Data"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectsInputAC" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostProjectsInputAC"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costProjectsInputAC.aspx"
      EnableAdd = "False"
      ValidationGroup = "costProjectsInputAC"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostProjectsInputAC" runat="server" AssociatedUpdatePanelID="UPNLcostProjectsInputAC" DisplayAfter="100">
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
    <asp:GridView ID="GVcostProjectsInputAC" SkinID="gv_silver" runat="server" DataSourceID="ODScostProjectsInputAC" DataKeyNames="ProjectGroupID,FinYear,Quarter">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Order Value [INR]" SortExpression="GroupOrderValueINR">
          <ItemTemplate>
            <asp:Label ID="LabelGroupOrderValueINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GroupOrderValueINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Revenue By AC [INR]" SortExpression="ProjectRevenueByACINR">
          <ItemTemplate>
            <asp:Label ID="LabelProjectRevenueByACINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectRevenueByACINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Margin By AC [INR]" SortExpression="ProjectMarginByACINR">
          <ItemTemplate>
            <asp:Label ID="LabelProjectMarginByACINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectMarginByACINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Export Incentive By AC [INR]" SortExpression="ExportIncentiveByACINR">
          <ItemTemplate>
            <asp:Label ID="LabelExportIncentiveByACINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExportIncentiveByACINR") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="Approved By" SortExpression="aspnet_users2_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ApprovedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ApprovedBy") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostProjectsInputAC"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costProjectsInputAC"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costProjectsInputACSelectList"
      TypeName = "SIS.COST.costProjectsInputAC"
      SelectCountMethod = "costProjectsInputACSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVcostProjectsInputAC" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectGroupID" />
    <asp:AsyncPostBackTrigger ControlID="F_FinYear" />
    <asp:AsyncPostBackTrigger ControlID="F_Quarter" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
