<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_wfdbAttachments.aspx.vb" Inherits="GF_wfdbAttachments" title="Maintain List: Attachments" %>
<asp:Content ID="CPHwfdbAttachments" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelwfdbAttachments" runat="server" Text="&nbsp;List: Attachments"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLwfdbAttachments" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLwfdbAttachments"
      ToolType = "lgNMGrid"
      EditUrl = "~/WFDB_Main/App_Edit/EF_wfdbAttachments.aspx"
      AddUrl = "~/WFDB_Main/App_Create/AF_wfdbAttachments.aspx"
      ValidationGroup = "wfdbAttachments"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSwfdbAttachments" runat="server" AssociatedUpdatePanelID="UPNLwfdbAttachments" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVwfdbAttachments" SkinID="gv_silver" runat="server" DataSourceID="ODSwfdbAttachments" DataKeyNames="t_indx,t_dcid">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_drid" SortExpression="t_drid">
          <ItemTemplate>
            <asp:Label ID="Labelt_drid" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_drid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_dcid" SortExpression="t_dcid">
          <ItemTemplate>
            <asp:Label ID="Labelt_dcid" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_dcid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_indx" SortExpression="t_indx">
          <ItemTemplate>
            <asp:Label ID="Labelt_indx" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_indx") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_prcd" SortExpression="t_prcd">
          <ItemTemplate>
            <asp:Label ID="Labelt_prcd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_prcd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_fnam" SortExpression="t_fnam">
          <ItemTemplate>
            <asp:Label ID="Labelt_fnam" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_fnam") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_lbcd" SortExpression="t_lbcd">
          <ItemTemplate>
            <asp:Label ID="Labelt_lbcd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_lbcd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_atby" SortExpression="t_atby">
          <ItemTemplate>
            <asp:Label ID="Labelt_atby" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_atby") %>'></asp:Label>
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
      ID = "ODSwfdbAttachments"
      runat = "server"
      DataObjectTypeName = "SIS.WFDB.wfdbAttachments"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_wfdbAttachmentsSelectList"
      TypeName = "SIS.WFDB.wfdbAttachments"
      SelectCountMethod = "wfdbAttachmentsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVwfdbAttachments" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
