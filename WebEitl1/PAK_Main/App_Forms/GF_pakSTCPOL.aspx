<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakSTCPOL.aspx.vb" Inherits="GF_pakSTCPOL" title="Maintain List: PO Items" %>
<asp:Content ID="CPHpakSTCPOL" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakSTCPOL" runat="server" Text="&nbsp;List: PO Items"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSTCPOL" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSTCPOL"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSTCPOL.aspx"
      EnableAdd = "False"
      ValidationGroup = "pakSTCPOL"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSTCPOL" runat="server" AssociatedUpdatePanelID="UPNLpakSTCPOL" DisplayAfter="100">
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
          <b><asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_SerialNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESerialNo_Selected"
            OnClientPopulating="ACESerialNo_Populating"
            OnClientPopulated="ACESerialNo_Populated"
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
    <asp:GridView ID="GVpakSTCPOL" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSTCPOL" DataKeyNames="SerialNo,ItemNo">
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
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
          <ItemTemplate>
            <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="ItemQuantity">
          <ItemTemplate>
            <asp:Label ID="LabelItemQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemQuantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element" SortExpression="IDM_WBS1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ItemElement" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemElement") %>' Text='<%# Eval("IDM_WBS1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="PAK_POLineStatus3_Description">
          <ItemTemplate>
             <asp:Label ID="L_ItemStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemStatusID") %>' Text='<%# Eval("PAK_POLineStatus3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakSTCPOL"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSTCPOL"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakSTCPOLSelectList"
      TypeName = "SIS.PAK.pakSTCPOL"
      SelectCountMethod = "pakSTCPOLSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSTCPOL" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
