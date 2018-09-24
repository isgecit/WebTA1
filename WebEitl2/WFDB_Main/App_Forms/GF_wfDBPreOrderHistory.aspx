<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_wfDBPreOrderHistory.aspx.vb" Inherits="GF_wfDBPreOrderHistory" title="Maintain List: Pre Order History" %>
<asp:Content ID="CPHwfDBPreOrderHistory" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelwfDBPreOrderHistory" runat="server" Text="&nbsp;List: Pre Order History"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLwfDBPreOrderHistory" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLwfDBPreOrderHistory"
      ToolType = "lgNMGrid"
      EditUrl = "~/WFDB_Main/App_Edit/EF_wfDBPreOrderHistory.aspx"
      AddUrl = "~/WFDB_Main/App_Create/AF_wfDBPreOrderHistory.aspx?skip=1"
      ValidationGroup = "wfDBPreOrderHistory"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSwfDBPreOrderHistory" runat="server" AssociatedUpdatePanelID="UPNLwfDBPreOrderHistory" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVwfDBPreOrderHistory" SkinID="gv_silver" runat="server" DataSourceID="ODSwfDBPreOrderHistory" DataKeyNames="WFID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WFID" SortExpression="WFID">
          <ItemTemplate>
            <asp:Label ID="LabelWFID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WFID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="Project">
          <ItemTemplate>
            <asp:Label ID="LabelProject" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Project") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element" SortExpression="Element">
          <ItemTemplate>
            <asp:Label ID="LabelElement" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Element") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SpecificationNo" SortExpression="SpecificationNo">
          <ItemTemplate>
            <asp:Label ID="LabelSpecificationNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SpecificationNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Buyer" SortExpression="Buyer">
          <ItemTemplate>
            <asp:Label ID="LabelBuyer" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Buyer") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier" SortExpression="Supplier">
          <ItemTemplate>
            <asp:Label ID="LabelSupplier" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Supplier") %>'></asp:Label>
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
      ID = "ODSwfDBPreOrderHistory"
      runat = "server"
      DataObjectTypeName = "SIS.WFDB.wfDBPreOrderHistory"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_wfDBPreOrderHistorySelectList"
      TypeName = "SIS.WFDB.wfDBPreOrderHistory"
      SelectCountMethod = "wfDBPreOrderHistorySelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVwfDBPreOrderHistory" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
