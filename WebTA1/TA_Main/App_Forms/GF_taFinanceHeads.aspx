<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taFinanceHeads.aspx.vb" Inherits="GF_taFinanceHeads" title="Maintain List: Finance Heads" %>
<asp:Content ID="CPHtaFinanceHeads" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaFinanceHeads" runat="server" Text="&nbsp;List: Finance Heads"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaFinanceHeads" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaFinanceHeads"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taFinanceHeads.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taFinanceHeads.aspx"
      ValidationGroup = "taFinanceHeads"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaFinanceHeads" runat="server" AssociatedUpdatePanelID="UPNLtaFinanceHeads" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaFinanceHeads" SkinID="gv_silver" runat="server" DataSourceID="ODStaFinanceHeads" DataKeyNames="FinanceHeadID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Finance Head" SortExpression="FinanceHeadID">
          <ItemTemplate>
            <asp:Label ID="LabelFinanceHeadID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FinanceHeadID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
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
      ID = "ODStaFinanceHeads"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taFinanceHeads"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taFinanceHeadsSelectList"
      TypeName = "SIS.TA.taFinanceHeads"
      SelectCountMethod = "taFinanceHeadsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaFinanceHeads" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
