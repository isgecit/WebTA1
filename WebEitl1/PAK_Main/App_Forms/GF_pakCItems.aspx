<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakCItems.aspx.vb" Inherits="GF_pakCItems" title="Maintain List: Child Items" %>
<asp:Content ID="CPHpakCItems" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakCItems" runat="server" Text="&nbsp;List: Child Items"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakCItems" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakCItems"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakCItems.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakCItems.aspx"
      AddPostBack = "True"
      ValidationGroup = "pakCItems"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakCItems" runat="server" AssociatedUpdatePanelID="UPNLpakCItems" DisplayAfter="100">
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
          <b><asp:Label ID="L_RootItem" runat="server" Text="Root Item :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_RootItem"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_RootItem(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_RootItem_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERootItem"
            BehaviorID="B_ACERootItem"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RootItemCompletionList"
            TargetControlID="F_RootItem"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACERootItem_Selected"
            OnClientPopulating="ACERootItem_Populating"
            OnClientPopulated="ACERootItem_Populated"
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
    <asp:GridView ID="GVpakCItems" SkinID="gv_silver" runat="server" DataSourceID="ODSpakCItems" DataKeyNames="RootItem,ItemNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="ItemNo">
          <ItemTemplate>
            <asp:Label ID="LabelItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
          <ItemTemplate>
            <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element ID" SortExpression="PAK_Elements3_Description">
          <ItemTemplate>
             <asp:Label ID="L_ElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ElementID") %>' Text='<%# Eval("PAK_Elements3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Weight" SortExpression="PAK_Units6_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMWeight" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMWeight") %>' Text='<%# Eval("PAK_Units6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Parent Item No" SortExpression="PAK_Items4_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_ParentItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ParentItemNo") %>' Text='<%# Eval("PAK_Items4_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpakCItems"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakCItems"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakCItemsSelectList"
      TypeName = "SIS.PAK.pakCItems"
      SelectCountMethod = "pakCItemsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_RootItem" PropertyName="Text" Name="RootItem" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakCItems" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_RootItem" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
