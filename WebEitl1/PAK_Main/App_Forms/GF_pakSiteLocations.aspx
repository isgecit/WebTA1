<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakSiteLocations.aspx.vb" Inherits="GF_pakSiteLocations" title="Maintain List: Site Locations" %>
<asp:Content ID="CPHpakSiteLocations" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakSiteLocations" runat="server" Text="&nbsp;List: Site Locations"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteLocations" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSiteLocations"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSiteLocations.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakSiteLocations.aspx"
      ValidationGroup = "pakSiteLocations"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSiteLocations" runat="server" AssociatedUpdatePanelID="UPNLpakSiteLocations" DisplayAfter="100">
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
          <b><asp:Label ID="L_LocationTypeID" runat="server" Text="Location Type :" /></b>
        </td>
        <td>
          <LGM:LC_pakSiteLocationTypes
            ID="F_LocationTypeID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="LocationTypeID"
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
    <asp:GridView ID="GVpakSiteLocations" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSiteLocations" DataKeyNames="LocationID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location" SortExpression="LocationID">
          <ItemTemplate>
            <asp:Label ID="LabelLocationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LocationID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location Type" SortExpression="PAK_SiteLocationTypes1_Description">
          <ItemTemplate>
             <asp:Label ID="L_LocationTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("LocationTypeID") %>' Text='<%# Eval("PAK_SiteLocationTypes1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GPS Location" SortExpression="GPSLocation">
          <ItemTemplate>
            <asp:Label ID="LabelGPSLocation" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GPSLocation") %>'></asp:Label>
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
      ID = "ODSpakSiteLocations"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSiteLocations"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakSiteLocationsSelectList"
      TypeName = "SIS.PAK.pakSiteLocations"
      SelectCountMethod = "pakSiteLocationsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_LocationTypeID" PropertyName="SelectedValue" Name="LocationTypeID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSiteLocations" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_LocationTypeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
