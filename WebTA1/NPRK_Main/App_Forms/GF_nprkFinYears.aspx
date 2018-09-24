<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkFinYears.aspx.vb" Inherits="GF_nprkFinYears" title="Maintain List: Fin.Years" %>
<asp:Content ID="CPHnprkFinYears" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkFinYears" runat="server" Text="&nbsp;List: Fin.Years"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkFinYears" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkFinYears"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkFinYears.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkFinYears.aspx"
      ValidationGroup = "nprkFinYears"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkFinYears" runat="server" AssociatedUpdatePanelID="UPNLnprkFinYears" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVnprkFinYears" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkFinYears" DataKeyNames="FinYear">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fin. Year" SortExpression="FinYear">
          <ItemTemplate>
            <asp:Label ID="LabelFinYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FinYear") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate">
          <ItemTemplate>
            <asp:Label ID="LabelStartDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StartDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="End Date" SortExpression="EndDate">
          <ItemTemplate>
            <asp:Label ID="LabelEndDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EndDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="Status">
          <ItemTemplate>
            <asp:Label ID="LabelStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Status") %>'></asp:Label>
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
      ID = "ODSnprkFinYears"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkFinYears"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "nprkFinYearsSelectList"
      TypeName = "SIS.NPRK.nprkFinYears"
      SelectCountMethod = "nprkFinYearsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVnprkFinYears" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
