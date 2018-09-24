<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_psfSupplier.aspx.vb" Inherits="GF_psfSupplier" title="Maintain List: Supplier" %>
<asp:Content ID="CPHpsfSupplier" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpsfSupplier" runat="server" Text="&nbsp;List: Supplier"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpsfSupplier" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpsfSupplier"
      ToolType = "lgNMGrid"
      EditUrl = "~/PSF_Main/App_Edit/EF_psfSupplier.aspx"
      AddUrl = "~/PSF_Main/App_Create/AF_psfSupplier.aspx"
      ValidationGroup = "psfSupplier"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpsfSupplier" runat="server" AssociatedUpdatePanelID="UPNLpsfSupplier" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_SupplierID"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="9"
            Width="63px"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVpsfSupplier" SkinID="gv_silver" runat="server" DataSourceID="ODSpsfSupplier" DataKeyNames="SupplierID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier ID" SortExpression="SupplierID">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier Name" SortExpression="SupplierName">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank Name" SortExpression="BankName">
          <ItemTemplate>
            <asp:Label ID="LabelBankName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BankName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Branch Address" SortExpression="BranchAddress">
          <ItemTemplate>
            <asp:Label ID="LabelBranchAddress" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BranchAddress") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank Account No" SortExpression="BankAccountNo">
          <ItemTemplate>
            <asp:Label ID="LabelBankAccountNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BankAccountNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IFSC Code" SortExpression="IFSCCode">
          <ItemTemplate>
            <asp:Label ID="LabelIFSCCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IFSCCode") %>'></asp:Label>
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
      ID = "ODSpsfSupplier"
      runat = "server"
      DataObjectTypeName = "SIS.PSF.psfSupplier"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "psfSupplierSelectList"
      TypeName = "SIS.PSF.psfSupplier"
      SelectCountMethod = "psfSupplierSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="9" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpsfSupplier" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
