<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakTCPOLR.aspx.vb" Inherits="GF_pakTCPOLR" title="Maintain List: Submitted for TC" %>
<asp:Content ID="CPHpakTCPOLR" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakTCPOLR" runat="server" Text="&nbsp;List: Submitted for TC"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakTCPOLR" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakTCPOLR"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakTCPOLR.aspx"
      EnableAdd = "False"
      ValidationGroup = "pakTCPOLR"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakTCPOLR" runat="server" AssociatedUpdatePanelID="UPNLpakTCPOLR" DisplayAfter="100">
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
          <b><asp:Label ID="L_ItemNo" runat="server" Text="Item No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ItemNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEItemNo"
            BehaviorID="B_ACEItemNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ItemNoCompletionList"
            TargetControlID="F_ItemNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEItemNo_Selected"
            OnClientPopulating="ACEItemNo_Populating"
            OnClientPopulated="ACEItemNo_Populated"
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
    <asp:GridView ID="GVpakTCPOLR" SkinID="gv_silver" runat="server" DataSourceID="ODSpakTCPOLR" DataKeyNames="SerialNo,ItemNo,UploadNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Upload No" SortExpression="UploadNo">
          <ItemTemplate>
            <asp:Label ID="LabelUploadNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UploadNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document Category" SortExpression="PAK_POLineRecCategory4_Description">
          <ItemTemplate>
             <asp:Label ID="L_DocumentCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DocumentCategoryID") %>' Text='<%# Eval("PAK_POLineRecCategory4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submitted On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Receipt No" SortExpression="ReceiptNo">
          <ItemTemplate>
            <asp:Label ID="LabelReceiptNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReceiptNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Rev. No" SortExpression="RevisionNo">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="PAK_POLineRecStatus5_Description">
          <ItemTemplate>
             <asp:Label ID="L_UploadStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UploadStatusID") %>' Text='<%# Eval("PAK_POLineRecStatus5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakTCPOLR"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakTCPOLR"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakTCPOLRSelectList"
      TypeName = "SIS.PAK.pakTCPOLR"
      SelectCountMethod = "pakTCPOLRSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ItemNo" PropertyName="Text" Name="ItemNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakTCPOLR" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
    <asp:AsyncPostBackTrigger ControlID="F_ItemNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
