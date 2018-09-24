<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakIQCListD.aspx.vb" Inherits="GF_pakIQCListD" title="Maintain List: Offered QC List Items" %>
<asp:Content ID="CPHpakIQCListD" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakIQCListD" runat="server" Text="&nbsp;List: Offered QC List Items"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakIQCListD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakIQCListD"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakIQCListD.aspx"
      EnableAdd = "False"
      ValidationGroup = "pakIQCListD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakIQCListD" runat="server" AssociatedUpdatePanelID="UPNLpakIQCListD" DisplayAfter="100">
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
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_QCLNo" runat="server" Text="QCL No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_QCLNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_QCLNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_QCLNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEQCLNo"
            BehaviorID="B_ACEQCLNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="QCLNoCompletionList"
            TargetControlID="F_QCLNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEQCLNo_Selected"
            OnClientPopulating="ACEQCLNo_Populating"
            OnClientPopulated="ACEQCLNo_Populated"
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
    <asp:GridView ID="GVpakIQCListD" SkinID="gv_silver" runat="server" DataSourceID="ODSpakIQCListD" DataKeyNames="SerialNo,QCLNo,BOMNo,ItemNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BOM No" SortExpression="PAK_POBOM4_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_BOMNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BOMNo") %>' Text='<%# Eval("PAK_POBOM4_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="PAK_POBItems3_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_ItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemNo") %>' Text='<%# Eval("PAK_POBItems3_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Quantity" SortExpression="PAK_Units6_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMQuantity") %>' Text='<%# Eval("PAK_Units6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quality Cleared Qty" SortExpression="QualityClearedQty">
          <ItemTemplate>
            <asp:Label ID="LabelQualityClearedQty" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QualityClearedQty") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cleared On" SortExpression="ClearedOn">
          <ItemTemplate>
            <asp:Label ID="LabelClearedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ClearedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakIQCListD"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakIQCListD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakIQCListDSelectList"
      TypeName = "SIS.PAK.pakIQCListD"
      SelectCountMethod = "pakIQCListDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_QCLNo" PropertyName="Text" Name="QCLNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakIQCListD" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
    <asp:AsyncPostBackTrigger ControlID="F_QCLNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
