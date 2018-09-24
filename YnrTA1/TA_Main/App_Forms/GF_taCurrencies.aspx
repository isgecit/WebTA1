<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taCurrencies.aspx.vb" Inherits="GF_taCurrencies" title="Maintain List: Currencies" %>
<asp:Content ID="CPHtaCurrencies" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaCurrencies" runat="server" Text="&nbsp;List: Currencies"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCurrencies" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCurrencies"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCurrencies.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCurrencies.aspx"
      ValidationGroup = "taCurrencies"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCurrencies" runat="server" AssociatedUpdatePanelID="UPNLtaCurrencies" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCurrencies" SkinID="gv_silver" runat="server" DataSourceID="ODStaCurrencies" DataKeyNames="CurrencyID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency ID" SortExpression="CurrencyID">
          <ItemTemplate>
            <asp:Label ID="LabelCurrencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CurrencyID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency Name" SortExpression="CurrencyName">
          <ItemTemplate>
            <asp:Label ID="LabelCurrencyName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CurrencyName") %>'></asp:Label>
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
      ID = "ODStaCurrencies"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCurrencies"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taCurrenciesSelectList"
      TypeName = "SIS.TA.taCurrencies"
      SelectCountMethod = "taCurrenciesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaCurrencies" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
