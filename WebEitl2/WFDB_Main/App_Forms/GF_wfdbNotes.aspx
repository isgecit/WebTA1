<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_wfdbNotes.aspx.vb" Inherits="GF_wfdbNotes" title="Maintain List: Notes" %>
<asp:Content ID="CPHwfdbNotes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelwfdbNotes" runat="server" Text="&nbsp;List: Notes"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLwfdbNotes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLwfdbNotes"
      ToolType = "lgNMGrid"
      EditUrl = "~/WFDB_Main/App_Edit/EF_wfdbNotes.aspx"
      AddUrl = "~/WFDB_Main/App_Create/AF_wfdbNotes.aspx"
      ValidationGroup = "wfdbNotes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSwfdbNotes" runat="server" AssociatedUpdatePanelID="UPNLwfdbNotes" DisplayAfter="100">
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
          <b><asp:Label ID="L_IndexValue" runat="server" Text="IndexValue :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_IndexValue"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="200"
            Width="350px"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVwfdbNotes" SkinID="gv_silver" runat="server" DataSourceID="ODSwfdbNotes" DataKeyNames="IndexValue,NotesId">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndexValue" SortExpression="IndexValue">
          <ItemTemplate>
            <asp:Label ID="LabelIndexValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndexValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="Title">
          <ItemTemplate>
            <asp:Label ID="LabelTitle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Title") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserId" SortExpression="UserId">
          <ItemTemplate>
            <asp:Label ID="LabelUserId" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UserId") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created_Date" SortExpression="Created_Date">
          <ItemTemplate>
            <asp:Label ID="LabelCreated_Date" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Created_Date") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SendEmailTo" SortExpression="SendEmailTo">
          <ItemTemplate>
            <asp:Label ID="LabelSendEmailTo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SendEmailTo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSwfdbNotes"
      runat = "server"
      DataObjectTypeName = "SIS.WFDB.wfdbNotes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_wfdbNotesSelectList"
      TypeName = "SIS.WFDB.wfdbNotes"
      SelectCountMethod = "wfdbNotesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IndexValue" PropertyName="Text" Name="IndexValue" Type="String" Size="200" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVwfdbNotes" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_IndexValue" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
