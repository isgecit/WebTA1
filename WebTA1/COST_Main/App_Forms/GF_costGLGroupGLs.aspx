<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_costGLGroupGLs.aspx.vb" Inherits="GF_costGLGroupGLs" title="Maintain List: GL Group GLs" %>
<asp:Content ID="CPHcostGLGroupGLs" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostGLGroupGLs" runat="server" Text="&nbsp;List: GL Group GLs"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLGroupGLs" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostGLGroupGLs"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costGLGroupGLs.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costGLGroupGLs.aspx"
      AddPostBack = "True"
      ValidationGroup = "costGLGroupGLs"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostGLGroupGLs" runat="server" AssociatedUpdatePanelID="UPNLcostGLGroupGLs" DisplayAfter="100">
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
          <b><asp:Label ID="L_GLGroupID" runat="server" Text="GL Group ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_GLGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_GLGroupID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_GLGroupID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEGLGroupID"
            BehaviorID="B_ACEGLGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="GLGroupIDCompletionList"
            TargetControlID="F_GLGroupID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEGLGroupID_Selected"
            OnClientPopulating="ACEGLGroupID_Populating"
            OnClientPopulated="ACEGLGroupID_Populated"
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
    <asp:GridView ID="GVcostGLGroupGLs" SkinID="gv_silver" runat="server" DataSourceID="ODScostGLGroupGLs" DataKeyNames="GLGroupID,GLCode">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Group ID" SortExpression="COST_GLGroups1_GLGroupDescriptions">
          <ItemTemplate>
             <asp:Label ID="L_GLGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GLGroupID") %>' Text='<%# Eval("COST_GLGroups1_GLGroupDescriptions") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Code [ERP]" SortExpression="COST_ERPGLCodes2_GLDescription">
          <ItemTemplate>
             <asp:Label ID="L_GLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GLCode") %>' Text='<%# Eval("COST_ERPGLCodes2_GLDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Effective Start Date" SortExpression="EffectiveStartDate">
          <ItemTemplate>
            <asp:Label ID="LabelEffectiveStartDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EffectiveStartDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Effective End Date" SortExpression="EffectiveEndDate">
          <ItemTemplate>
            <asp:Label ID="LabelEffectiveEndDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EffectiveEndDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostGLGroupGLs"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costGLGroupGLs"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costGLGroupGLsSelectList"
      TypeName = "SIS.COST.costGLGroupGLs"
      SelectCountMethod = "costGLGroupGLsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_GLGroupID" PropertyName="Text" Name="GLGroupID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostGLGroupGLs" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_GLGroupID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
