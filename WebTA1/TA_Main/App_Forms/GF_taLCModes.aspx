<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taLCModes.aspx.vb" Inherits="GF_taLCModes" title="Maintain List: Local Conveyance Modes" %>
<asp:Content ID="CPHtaLCModes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaLCModes" runat="server" Text="&nbsp;List: Local Conveyance Modes"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaLCModes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaLCModes"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taLCModes.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taLCModes.aspx"
      ValidationGroup = "taLCModes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaLCModes" runat="server" AssociatedUpdatePanelID="UPNLtaLCModes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaLCModes" SkinID="gv_silver" runat="server" DataSourceID="ODStaLCModes" DataKeyNames="ModeID">
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
        <asp:TemplateField HeaderText="L C Mode Name" SortExpression="ModeName">
          <ItemTemplate>
            <asp:Label ID="LabelModeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ModeName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Out Of Sequence" SortExpression="OutOfSequence">
          <ItemTemplate>
            <asp:Label ID="LabelOutOfSequence" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OutOfSequence") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence">
          <ItemTemplate>
            <asp:Label ID="LabelSequence" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Sequence") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Under Milage Claim" SortExpression="UnderMilageClaim">
          <ItemTemplate>
            <asp:Label ID="LabelUnderMilageClaim" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UnderMilageClaim") %>'></asp:Label>
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
      ID = "ODStaLCModes"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taLCModes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taLCModesSelectList"
      TypeName = "SIS.TA.taLCModes"
      SelectCountMethod = "taLCModesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaLCModes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
