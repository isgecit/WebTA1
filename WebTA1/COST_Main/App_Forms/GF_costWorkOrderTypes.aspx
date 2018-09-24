<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_costWorkOrderTypes.aspx.vb" Inherits="GF_costWorkOrderTypes" title="Maintain List: Work Order Types" %>
<asp:Content ID="CPHcostWorkOrderTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostWorkOrderTypes" runat="server" Text="&nbsp;List: Work Order Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostWorkOrderTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostWorkOrderTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costWorkOrderTypes.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costWorkOrderTypes.aspx"
      ValidationGroup = "costWorkOrderTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostWorkOrderTypes" runat="server" AssociatedUpdatePanelID="UPNLcostWorkOrderTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostWorkOrderTypes" SkinID="gv_silver" runat="server" DataSourceID="ODScostWorkOrderTypes" DataKeyNames="WorkOrderTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Work Order Type ID" SortExpression="WorkOrderTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelWorkOrderTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WorkOrderTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Work Order Type Description" SortExpression="WorkOrderTypeDescription">
          <ItemTemplate>
            <asp:Label ID="LabelWorkOrderTypeDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WorkOrderTypeDescription") %>'></asp:Label>
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
      ID = "ODScostWorkOrderTypes"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costWorkOrderTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costWorkOrderTypesSelectList"
      TypeName = "SIS.COST.costWorkOrderTypes"
      SelectCountMethod = "costWorkOrderTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVcostWorkOrderTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
