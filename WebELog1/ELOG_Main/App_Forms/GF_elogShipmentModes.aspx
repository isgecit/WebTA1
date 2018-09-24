<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogShipmentModes.aspx.vb" Inherits="GF_elogShipmentModes" title="Maintain List: Shipment Modes" %>
<asp:Content ID="CPHelogShipmentModes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogShipmentModes" runat="server" Text="&nbsp;List: Shipment Modes"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogShipmentModes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogShipmentModes"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogShipmentModes.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogShipmentModes.aspx"
      ValidationGroup = "elogShipmentModes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogShipmentModes" runat="server" AssociatedUpdatePanelID="UPNLelogShipmentModes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogShipmentModes" SkinID="gv_silver" runat="server" DataSourceID="ODSelogShipmentModes" DataKeyNames="ShipmentModeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Shipment Mode" SortExpression="ShipmentModeID">
          <ItemTemplate>
            <asp:Label ID="LabelShipmentModeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ShipmentModeID") %>'></asp:Label>
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
      ID = "ODSelogShipmentModes"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogShipmentModes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogShipmentModesSelectList"
      TypeName = "SIS.ELOG.elogShipmentModes"
      SelectCountMethod = "elogShipmentModesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVelogShipmentModes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
