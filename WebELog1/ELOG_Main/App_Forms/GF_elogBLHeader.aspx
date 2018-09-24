<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogBLHeader.aspx.vb" Inherits="GF_elogBLHeader" title="Maintain List: BL Header" %>
<asp:Content ID="CPHelogBLHeader" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogBLHeader" runat="server" Text="&nbsp;List: BL Header"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogBLHeader" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogBLHeader"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogBLHeader.aspx"
      EnableAdd = "False"
      ValidationGroup = "elogBLHeader"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogBLHeader" runat="server" AssociatedUpdatePanelID="UPNLelogBLHeader" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogBLHeader" SkinID="gv_silver" runat="server" DataSourceID="ODSelogBLHeader" DataKeyNames="BLID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BL ID" SortExpression="BLID">
          <ItemTemplate>
            <asp:Label ID="LabelBLID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BLID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BL Number" SortExpression="BLNumber">
          <ItemTemplate>
            <asp:Label ID="LabelBLNumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BLNumber") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BL Date" SortExpression="BLDate">
          <ItemTemplate>
            <asp:Label ID="LabelBLDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BLDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vessel Or Flight No" SortExpression="VesselOrFlightNo">
          <ItemTemplate>
            <asp:Label ID="LabelVesselOrFlightNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VesselOrFlightNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MBL No" SortExpression="MBLNo">
          <ItemTemplate>
            <asp:Label ID="LabelMBLNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MBLNo") %>'></asp:Label>
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
      ID = "ODSelogBLHeader"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogBLHeader"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogBLHeaderSelectList"
      TypeName = "SIS.ELOG.elogBLHeader"
      SelectCountMethod = "elogBLHeaderSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVelogBLHeader" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
