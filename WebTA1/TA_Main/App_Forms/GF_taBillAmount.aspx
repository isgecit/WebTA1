<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taBillAmount.aspx.vb" Inherits="GF_taBillAmount" title="Maintain List: Bill Amounts" %>
<asp:Content ID="CPHtaBillAmount" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaBillAmount" runat="server" Text="&nbsp;List: Bill Amounts"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillAmount" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillAmount"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillAmount.aspx"
      EnableAdd = "False"
      ValidationGroup = "taBillAmount"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillAmount" runat="server" AssociatedUpdatePanelID="UPNLtaBillAmount" DisplayAfter="100">
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
          <b><asp:Label ID="L_TABillNo" runat="server" Text="TA Bill No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_TABillNo"
            CssClass = "mypktxt"
            Width="70px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_TABillNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TABillNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETABillNo"
            BehaviorID="B_ACETABillNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TABillNoCompletionList"
            TargetControlID="F_TABillNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACETABillNo_Selected"
            OnClientPopulating="ACETABillNo_Populating"
            OnClientPopulated="ACETABillNo_Populated"
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
    <asp:GridView ID="GVtaBillAmount" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillAmount" DataKeyNames="TABillNo,ComponentID,CurrencyID,CostCenterID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COMPONENT" SortExpression="TA_Components4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ComponentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ComponentID") %>' Text='<%# Eval("TA_Components4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CURRENCY" SortExpression="TA_Currencies5_CurrencyName">
          <ItemTemplate>
             <asp:Label ID="L_CurrencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CurrencyID") %>' Text='<%# Eval("TA_Currencies5_CurrencyName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COST CENTER" SortExpression="HRM_Departments1_Description">
          <ItemTemplate>
             <asp:Label ID="L_CostCenterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CostCenterID") %>' Text='<%# Eval("HRM_Departments1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TOTAL" SortExpression="TotalInCurrency">
          <ItemTemplate>
            <asp:Label ID="LabelTotalInCurrency" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalInCurrency") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TOTAL [INR]" SortExpression="TotalInINR">
          <ItemTemplate>
            <asp:Label ID="LabelTotalInINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalInINR") %>'></asp:Label>
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
      ID = "ODStaBillAmount"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillAmount"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBillAmountSelectList"
      TypeName = "SIS.TA.taBillAmount"
      SelectCountMethod = "taBillAmountSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBillAmount" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_TABillNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
