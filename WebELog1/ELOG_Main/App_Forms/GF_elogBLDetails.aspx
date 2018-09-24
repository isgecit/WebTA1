<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogBLDetails.aspx.vb" Inherits="GF_elogBLDetails" title="Maintain List: BL Details" %>
<asp:Content ID="CPHelogBLDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogBLDetails" runat="server" Text="&nbsp;List: BL Details"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogBLDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogBLDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogBLDetails.aspx"
      EnableAdd = "False"
      ValidationGroup = "elogBLDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogBLDetails" runat="server" AssociatedUpdatePanelID="UPNLelogBLDetails" DisplayAfter="100">
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
          <b><asp:Label ID="L_BLID" runat="server" Text="BL ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BLID"
            CssClass = "mypktxt"
            Width="80px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_BLID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_BLID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBLID"
            BehaviorID="B_ACEBLID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BLIDCompletionList"
            TargetControlID="F_BLID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEBLID_Selected"
            OnClientPopulating="ACEBLID_Populating"
            OnClientPopulated="ACEBLID_Populated"
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
    <asp:GridView ID="GVelogBLDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSelogBLDetails" DataKeyNames="BLID,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BL ID" SortExpression="ELOG_BLHeader1_BLNumber">
          <ItemTemplate>
             <asp:Label ID="L_BLID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BLID") %>' Text='<%# Eval("ELOG_BLHeader1_BLNumber") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Size And Type Of Container" SortExpression="SizeAndTypeOfContainer">
          <ItemTemplate>
            <asp:Label ID="LabelSizeAndTypeOfContainer" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SizeAndTypeOfContainer") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Container Number" SortExpression="ContainerNumber">
          <ItemTemplate>
            <asp:Label ID="LabelContainerNumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ContainerNumber") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Remarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSelogBLDetails"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogBLDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogBLDetailsSelectList"
      TypeName = "SIS.ELOG.elogBLDetails"
      SelectCountMethod = "elogBLDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_BLID" PropertyName="Text" Name="BLID" Type="String" Size="9" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVelogBLDetails" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_BLID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
