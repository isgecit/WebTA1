<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taCountries.aspx.vb" Inherits="GF_taCountries" title="Maintain List: Countries" %>
<asp:Content ID="CPHtaCountries" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaCountries" runat="server" Text="&nbsp;List: Countries"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCountries" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCountries"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCountries.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCountries.aspx"
      ValidationGroup = "taCountries"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCountries" runat="server" AssociatedUpdatePanelID="UPNLtaCountries" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCountries" SkinID="gv_silver" runat="server" DataSourceID="ODStaCountries" DataKeyNames="CountryID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Country ID" SortExpression="CountryID">
          <ItemTemplate>
            <asp:Label ID="LabelCountryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CountryID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Country Name" SortExpression="CountryName">
          <ItemTemplate>
            <asp:Label ID="LabelCountryName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CountryName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region ID" SortExpression="TA_Regions2_RegionName">
          <ItemTemplate>
             <asp:Label ID="L_RegionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RegionID") %>' Text='<%# Eval("TA_Regions2_RegionName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency ID" SortExpression="TA_Currencies1_CurrencyName">
          <ItemTemplate>
             <asp:Label ID="L_CurrencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CurrencyID") %>' Text='<%# Eval("TA_Currencies1_CurrencyName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region Type ID" SortExpression="TA_RegionTypes3_RegionTypeName">
          <ItemTemplate>
             <asp:Label ID="L_RegionTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RegionTypeID") %>' Text='<%# Eval("TA_RegionTypes3_RegionTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Contingency Amount" SortExpression="ContingencyAmount">
          <ItemTemplate>
            <asp:Label ID="LabelContingencyAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ContingencyAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCountries"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCountries"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taCountriesSelectList"
      TypeName = "SIS.TA.taCountries"
      SelectCountMethod = "taCountriesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaCountries" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
