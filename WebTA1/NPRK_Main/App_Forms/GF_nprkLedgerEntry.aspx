<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkLedgerEntry.aspx.vb" Inherits="GF_nprkLedgerEntry" title="Maintain List: Perk Ledger" %>
<asp:Content ID="CPHnprkLedgerEntry" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkLedgerEntry" runat="server" Text="&nbsp;List: Perk Ledger"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkLedgerEntry" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkLedgerEntry"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkLedgerEntry.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkLedgerEntry.aspx"
      ValidationGroup = "nprkLedgerEntry"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkLedgerEntry" runat="server" AssociatedUpdatePanelID="UPNLnprkLedgerEntry" DisplayAfter="100">
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
          <b><asp:Label ID="L_EmployeeID" runat="server" Text="EmployeeID :" /></b>
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
          <b><asp:Label ID="L_PerkID" runat="server" Text="PerkID :" /></b>
        </td>
        <td>
          <LGM:LC_nprkPerks
            ID="F_PerkID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="PerkID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVnprkLedgerEntry" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkLedgerEntry" DataKeyNames="DocumentID">
      <Columns>
        <asp:TemplateField HeaderText="DocumentID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EmployeeID" SortExpression="PRK_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_EmployeeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("EmployeeID") %>' Text='<%# Eval("PRK_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PerkID" SortExpression="PRK_Perks5_Description">
          <ItemTemplate>
             <asp:Label ID="L_PerkID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("PerkID") %>' Text='<%# Eval("PRK_Perks5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TranType" SortExpression="TranType">
          <ItemTemplate>
            <asp:Label ID="LabelTranType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TranType") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="UOM">
          <ItemTemplate>
            <asp:Label ID="LabelUOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UOM") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkLedgerEntry"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkLedgerEntry"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkLedgerEntrySelectList"
      TypeName = "SIS.NPRK.nprkLedgerEntry"
      SelectCountMethod = "nprkLedgerEntrySelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVnprkLedgerEntry" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_EmployeeID" />
    <asp:AsyncPostBackTrigger ControlID="F_PerkID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
