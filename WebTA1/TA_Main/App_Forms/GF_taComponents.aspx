<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taComponents.aspx.vb" Inherits="GF_taComponents" title="Maintain List: Bill Components" %>
<asp:Content ID="CPHtaComponents" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaComponents" runat="server" Text="&nbsp;List: Bill Components"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaComponents" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaComponents"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taComponents.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taComponents.aspx"
      ValidationGroup = "taComponents"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaComponents" runat="server" AssociatedUpdatePanelID="UPNLtaComponents" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaComponents" SkinID="gv_silver" runat="server" DataSourceID="ODStaComponents" DataKeyNames="ComponentID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Component ID" SortExpression="ComponentID">
          <ItemTemplate>
            <asp:Label ID="LabelComponentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ComponentID") %>'></asp:Label>
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
      ID = "ODStaComponents"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taComponents"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taComponentsSelectList"
      TypeName = "SIS.TA.taComponents"
      SelectCountMethod = "taComponentsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaComponents" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
