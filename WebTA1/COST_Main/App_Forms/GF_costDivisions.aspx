<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_costDivisions.aspx.vb" Inherits="GF_costDivisions" title="Maintain List: Divisions" %>
<asp:Content ID="CPHcostDivisions" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostDivisions" runat="server" Text="&nbsp;List: Divisions"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostDivisions" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostDivisions"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costDivisions.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costDivisions.aspx"
      ValidationGroup = "costDivisions"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostDivisions" runat="server" AssociatedUpdatePanelID="UPNLcostDivisions" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostDivisions" SkinID="gv_silver" runat="server" DataSourceID="ODScostDivisions" DataKeyNames="DivisionID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Division ID" SortExpression="DivisionID">
          <ItemTemplate>
            <asp:Label ID="LabelDivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DivisionID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Division Name" SortExpression="DivisionName">
          <ItemTemplate>
            <asp:Label ID="LabelDivisionName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DivisionName") %>'></asp:Label>
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
      ID = "ODScostDivisions"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costDivisions"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costDivisionsSelectList"
      TypeName = "SIS.COST.costDivisions"
      SelectCountMethod = "costDivisionsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVcostDivisions" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
