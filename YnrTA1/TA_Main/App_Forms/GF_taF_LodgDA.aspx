<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taF_LodgDA.aspx.vb" Inherits="GF_taF_LodgDA" title="Maintain List: Category Region Type Wise Foreign Lodging & DA" %>
<asp:Content ID="CPHtaF_LodgDA" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaF_LodgDA" runat="server" Text="&nbsp;List: Category Region Type Wise Foreign Lodging & DA"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaF_LodgDA" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaF_LodgDA"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taF_LodgDA.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taF_LodgDA.aspx"
      ValidationGroup = "taF_LodgDA"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaF_LodgDA" runat="server" AssociatedUpdatePanelID="UPNLtaF_LodgDA" DisplayAfter="100">
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
          <b><asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" /></b>
        </td>
        <td>
          <LGM:LC_taCategories
            ID="F_CategoryID"
            SelectedValue=""
            OrderBy="cmba"
            DataTextField="cmba"
            DataValueField="CategoryID"
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
          <b><asp:Label ID="L_RegionID" runat="server" Text="Region ID :" /></b>
        </td>
        <td>
          <LGM:LC_taRegions
            ID="F_RegionID"
            SelectedValue=""
            OrderBy="RegionName"
            DataTextField="RegionName"
            DataValueField="RegionID"
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
    <asp:GridView ID="GVtaF_LodgDA" SkinID="gv_silver" runat="server" DataSourceID="ODStaF_LodgDA" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="S.N." SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category ID" SortExpression="TA_Categories1_cmba">
          <ItemTemplate>
             <asp:Label ID="L_CategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategoryID") %>' Text='<%# Eval("TA_Categories1_cmba") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region ID" SortExpression="TA_Regions1_RegionName">
          <ItemTemplate>
             <asp:Label ID="L_RegionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RegionID") %>' Text='<%# Eval("TA_Regions1_RegionName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Lodging" SortExpression="Lodging">
          <ItemTemplate>
            <asp:Label ID="LabelLodging" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Lodging") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DA" SortExpression="DA">
          <ItemTemplate>
            <asp:Label ID="LabelDA" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DA") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Date" SortExpression="FromDate">
          <ItemTemplate>
            <asp:Label ID="LabelFromDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FromDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Till Date" SortExpression="TillDate">
          <ItemTemplate>
            <asp:Label ID="LabelTillDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TillDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="Active">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaF_LodgDA"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taF_LodgDA"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taF_LodgDASelectList"
      TypeName = "SIS.TA.taF_LodgDA"
      SelectCountMethod = "taF_LodgDASelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CategoryID" PropertyName="SelectedValue" Name="CategoryID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RegionID" PropertyName="SelectedValue" Name="RegionID" Type="String" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaF_LodgDA" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CategoryID" />
    <asp:AsyncPostBackTrigger ControlID="F_RegionID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
