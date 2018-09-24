<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taRegions.aspx.vb" Inherits="GF_taRegions" title="Maintain List: Regions" %>
<asp:Content ID="CPHtaRegions" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaRegions" runat="server" Text="&nbsp;List: Regions"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaRegions" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaRegions"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taRegions.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taRegions.aspx"
      ValidationGroup = "taRegions"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaRegions" runat="server" AssociatedUpdatePanelID="UPNLtaRegions" DisplayAfter="100">
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
          <b><asp:Label ID="L_RegionTypeID" runat="server" Text="Region Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_taRegionTypes
            ID="F_RegionTypeID"
            SelectedValue=""
            OrderBy="RegionTypeName"
            DataTextField="RegionTypeName"
            DataValueField="RegionTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CurrencyID" runat="server" Text="Currency ID :" /></b>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue=""
            OrderBy="CurrencyName"
            DataTextField="CurrencyName"
            DataValueField="CurrencyID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtaRegions" SkinID="gv_silver" runat="server" DataSourceID="ODStaRegions" DataKeyNames="RegionID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region ID" SortExpression="RegionID">
          <ItemTemplate>
            <asp:Label ID="LabelRegionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RegionID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region Name" SortExpression="RegionName">
          <ItemTemplate>
            <asp:Label ID="LabelRegionName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RegionName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region Type ID" SortExpression="TA_RegionTypes2_RegionTypeName">
          <ItemTemplate>
             <asp:Label ID="L_RegionTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RegionTypeID") %>' Text='<%# Eval("TA_RegionTypes2_RegionTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency ID" SortExpression="TA_Currencies1_CurrencyName">
          <ItemTemplate>
             <asp:Label ID="L_CurrencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CurrencyID") %>' Text='<%# Eval("TA_Currencies1_CurrencyName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaRegions"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taRegions"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taRegionsSelectList"
      TypeName = "SIS.TA.taRegions"
      SelectCountMethod = "taRegionsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_RegionTypeID" PropertyName="SelectedValue" Name="RegionTypeID" Type="String" Size="10" />
        <asp:ControlParameter ControlID="F_CurrencyID" PropertyName="SelectedValue" Name="CurrencyID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaRegions" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_RegionTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_CurrencyID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
