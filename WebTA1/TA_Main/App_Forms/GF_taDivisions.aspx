<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taDivisions.aspx.vb" Inherits="GF_taDivisions" title="Maintain List: Divisions" %>
<asp:Content ID="CPHtaDivisions" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaDivisions" runat="server" Text="&nbsp;List: Divisions"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaDivisions" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaDivisions"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taDivisions.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taDivisions.aspx"
      ValidationGroup = "taDivisions"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaDivisions" runat="server" AssociatedUpdatePanelID="UPNLtaDivisions" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaDivisions" SkinID="gv_silver" runat="server" DataSourceID="ODStaDivisions" DataKeyNames="DivisionID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DivisionID" SortExpression="DivisionID">
          <ItemTemplate>
            <asp:Label ID="LabelDivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DivisionID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Division Head" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_DivisionHead" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DivisionHead") %>' Text='<%# Eval("HRM_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Enterprice Unit" SortExpression="ERP_EU">
          <ItemTemplate>
            <asp:Label ID="LabelERP_EU" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ERP_EU") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Division" SortExpression="ERP_Div">
          <ItemTemplate>
            <asp:Label ID="LabelERP_Div" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ERP_Div") %>'></asp:Label>
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
      ID = "ODStaDivisions"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taDivisions"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taDivisionsSelectList"
      TypeName = "SIS.TA.taDivisions"
      SelectCountMethod = "taDivisionsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaDivisions" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
