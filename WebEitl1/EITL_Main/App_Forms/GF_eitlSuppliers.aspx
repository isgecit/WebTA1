<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_eitlSuppliers.aspx.vb" Inherits="GF_eitlSuppliers" title="Maintain List: Suppliers" %>
<asp:Content ID="CPHeitlSuppliers" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeleitlSuppliers" runat="server" Text="&nbsp;List: Suppliers"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlSuppliers" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlSuppliers"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlSuppliers.aspx"
      AddUrl = "~/EITL_Main/App_Create/AF_eitlSuppliers.aspx"
      ValidationGroup = "eitlSuppliers"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlSuppliers" runat="server" AssociatedUpdatePanelID="UPNLeitlSuppliers" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVeitlSuppliers" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlSuppliers" DataKeyNames="SupplierID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier ID" SortExpression="SupplierID">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier Name" SortExpression="SupplierName">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Address [1]" SortExpression="Address1">
          <ItemTemplate>
            <asp:Label ID="LabelAddress1" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Address1") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City" SortExpression="City">
          <ItemTemplate>
            <asp:Label ID="LabelCity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("City") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="State" SortExpression="State">
          <ItemTemplate>
            <asp:Label ID="LabelState" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("State") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Country" SortExpression="Country">
          <ItemTemplate>
            <asp:Label ID="LabelCountry" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Country") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
          <ItemTemplate>
            <asp:Label ID="LabelZip" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Zip") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSeitlSuppliers"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlSuppliers"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "eitlSuppliersSelectList"
      TypeName = "SIS.EITL.eitlSuppliers"
      SelectCountMethod = "eitlSuppliersSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVeitlSuppliers" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
