<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_costFinYear.aspx.vb" Inherits="GF_costFinYear" title="Maintain List: Financial Year" %>
<asp:Content ID="CPHcostFinYear" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostFinYear" runat="server" Text="&nbsp;List: Financial Year"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostFinYear" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostFinYear"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costFinYear.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costFinYear.aspx"
      ValidationGroup = "costFinYear"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostFinYear" runat="server" AssociatedUpdatePanelID="UPNLcostFinYear" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostFinYear" SkinID="gv_silver" runat="server" DataSourceID="ODScostFinYear" DataKeyNames="FinYear">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fin Year" SortExpression="FinYear">
          <ItemTemplate>
            <asp:Label ID="LabelFinYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FinYear") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descpription" SortExpression="Descpription">
          <ItemTemplate>
            <asp:Label ID="LabelDescpription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Descpription") %>'></asp:Label>
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
      ID = "ODScostFinYear"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costFinYear"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costFinYearSelectList"
      TypeName = "SIS.COST.costFinYear"
      SelectCountMethod = "costFinYearSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVcostFinYear" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
