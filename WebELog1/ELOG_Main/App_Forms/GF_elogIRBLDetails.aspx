<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogIRBLDetails.aspx.vb" Inherits="GF_elogIRBLDetails" title="Maintain List: IR BL Charge Codes" %>
<asp:Content ID="CPHelogIRBLDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogIRBLDetails" runat="server" Text="&nbsp;List: IR BL Charge Codes"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogIRBLDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogIRBLDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogIRBLDetails.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogIRBLDetails.aspx"
      AddPostBack = "True"
      ValidationGroup = "elogIRBLDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogIRBLDetails" runat="server" AssociatedUpdatePanelID="UPNLelogIRBLDetails" DisplayAfter="100">
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
          <b><asp:Label ID="L_IRNo" runat="server" Text="IR No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IRNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_IRNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IRNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIRNo"
            BehaviorID="B_ACEIRNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IRNoCompletionList"
            TargetControlID="F_IRNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEIRNo_Selected"
            OnClientPopulating="ACEIRNo_Populating"
            OnClientPopulated="ACEIRNo_Populated"
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
    <asp:GridView ID="GVelogIRBLDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSelogIRBLDetails" DataKeyNames="IRNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stuffing Type" SortExpression="ELOG_StuffingTypes8_Description">
          <ItemTemplate>
             <asp:Label ID="L_StuffingTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StuffingTypeID") %>' Text='<%# Eval("ELOG_StuffingTypes8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ICD / CFS" SortExpression="ELOG_ICDCFSs5_Description">
          <ItemTemplate>
             <asp:Label ID="L_ICDCFSID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ICDCFSID") %>' Text='<%# Eval("ELOG_ICDCFSs5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Break Bulk" SortExpression="ELOG_BreakbulkTypes1_Description">
          <ItemTemplate>
             <asp:Label ID="L_BreakBulkID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BreakBulkID") %>' Text='<%# Eval("ELOG_BreakbulkTypes1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Type" SortExpression="ELOG_ChargeTypes4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ChargeTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ChargeTypeID") %>' Text='<%# Eval("ELOG_ChargeTypes4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Category" SortExpression="ELOG_ChargeCategories2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ChargeCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ChargeCategoryID") %>' Text='<%# Eval("ELOG_ChargeCategories2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSelogIRBLDetails"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogIRBLDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogIRBLDetailsSelectList"
      TypeName = "SIS.ELOG.elogIRBLDetails"
      SelectCountMethod = "elogIRBLDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IRNo" PropertyName="Text" Name="IRNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVelogIRBLDetails" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_IRNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
