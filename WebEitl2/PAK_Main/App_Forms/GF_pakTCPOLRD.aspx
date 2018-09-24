<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakTCPOLRD.aspx.vb" Inherits="GF_pakTCPOLRD" title="Maintain List: Documents" %>
<asp:Content ID="CPHpakTCPOLRD" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakTCPOLRD" runat="server" Text="&nbsp;List: Documents"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakTCPOLRD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakTCPOLRD"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakTCPOLRD.aspx"
      EnableAdd = "False"
      ValidationGroup = "pakTCPOLRD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakTCPOLRD" runat="server" AssociatedUpdatePanelID="UPNLpakTCPOLRD" DisplayAfter="100">
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
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UploadNo" runat="server" Text="Upload No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UploadNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_UploadNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UploadNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUploadNo"
            BehaviorID="B_ACEUploadNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UploadNoCompletionList"
            TargetControlID="F_UploadNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEUploadNo_Selected"
            OnClientPopulating="ACEUploadNo_Populating"
            OnClientPopulated="ACEUploadNo_Populated"
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
    <asp:GridView ID="GVpakTCPOLRD" SkinID="gv_silver" runat="server" DataSourceID="ODSpakTCPOLRD" DataKeyNames="SerialNo,ItemNo,UploadNo,DocSerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Upload No" SortExpression="PAK_POLineRec3_UploadNo">
          <ItemTemplate>
             <asp:Label ID="L_UploadNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UploadNo") %>' Text='<%# Eval("PAK_POLineRec3_UploadNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document" SortExpression="DocSerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelDocSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocSerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rev." SortExpression="DocumentRev">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentRev" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentRev") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="DocumentDescription">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Receipt" SortExpression="ReceiptNo">
          <ItemTemplate>
            <asp:Label ID="LabelReceiptNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReceiptNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Rev" SortExpression="RevisionNo">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Name" SortExpression="FileName">
          <ItemTemplate>
            <asp:Label ID="LabelFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileName") %>'></asp:Label>
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
      ID = "ODSpakTCPOLRD"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakTCPOLRD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakTCPOLRDSelectList"
      TypeName = "SIS.PAK.pakTCPOLRD"
      SelectCountMethod = "pakTCPOLRDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UploadNo" PropertyName="Text" Name="UploadNo" Type="Int32" Size="10" />
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
    <asp:AsyncPostBackTrigger ControlID="GVpakTCPOLRD" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_UploadNo" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
    <asp:AsyncPostBackTrigger ControlID="F_ItemNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
