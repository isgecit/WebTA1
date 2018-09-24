<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taTravelModes.aspx.vb" Inherits="GF_taTravelModes" title="Maintain List: Travel Modes" %>
<asp:Content ID="CPHtaTravelModes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaTravelModes" runat="server" Text="&nbsp;List: Travel Modes"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaTravelModes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaTravelModes"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taTravelModes.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taTravelModes.aspx"
      ValidationGroup = "taTravelModes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaTravelModes" runat="server" AssociatedUpdatePanelID="UPNLtaTravelModes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaTravelModes" SkinID="gv_silver" runat="server" DataSourceID="ODStaTravelModes" DataKeyNames="ModeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Mode ID" SortExpression="ModeID">
          <ItemTemplate>
            <asp:Label ID="LabelModeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ModeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Mode Name" SortExpression="ModeName">
          <ItemTemplate>
            <asp:Label ID="LabelModeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ModeName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence">
          <ItemTemplate>
            <asp:Label ID="LabelSequence" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Sequence") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Out Of Sequence" SortExpression="OutOfSequence">
          <ItemTemplate>
            <asp:Label ID="LabelOutOfSequence" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OutOfSequence") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Under Mileage Claim" SortExpression="UnderMilageClaim">
          <ItemTemplate>
            <asp:Label ID="LabelUnderMilageClaim" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UnderMilageClaim") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaTravelModes"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taTravelModes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taTravelModesSelectList"
      TypeName = "SIS.TA.taTravelModes"
      SelectCountMethod = "taTravelModesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaTravelModes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
