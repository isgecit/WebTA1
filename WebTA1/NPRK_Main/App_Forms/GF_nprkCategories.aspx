<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkCategories.aspx.vb" Inherits="GF_nprkCategories" title="Maintain List: Perk Categories" %>
<asp:Content ID="CPHnprkCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkCategories" runat="server" Text="&nbsp;List: Perk Categories"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkCategories" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkCategories"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkCategories.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkCategories.aspx"
      ValidationGroup = "nprkCategories"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkCategories" runat="server" AssociatedUpdatePanelID="UPNLnprkCategories" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVnprkCategories" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkCategories" DataKeyNames="CategoryID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category ID" SortExpression="CategoryID">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category Code" SortExpression="CategoryCode">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="Active">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STD Category" SortExpression="STDCategory">
          <ItemTemplate>
            <asp:Label ID="LabelSTDCategory" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("STDCategory") %>'></asp:Label>
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
      ID = "ODSnprkCategories"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkCategories"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "nprkCategoriesSelectList"
      TypeName = "SIS.NPRK.nprkCategories"
      SelectCountMethod = "nprkCategoriesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVnprkCategories" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
