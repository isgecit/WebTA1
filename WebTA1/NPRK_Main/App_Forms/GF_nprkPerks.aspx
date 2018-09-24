<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkPerks.aspx.vb" Inherits="GF_nprkPerks" title="Maintain List: Perk Heads" %>
<asp:Content ID="CPHnprkPerks" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkPerks" runat="server" Text="&nbsp;List: Perk Heads"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkPerks" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkPerks"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkPerks.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkPerks.aspx"
      ValidationGroup = "nprkPerks"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkPerks" runat="server" AssociatedUpdatePanelID="UPNLnprkPerks" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVnprkPerks" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkPerks" DataKeyNames="PerkID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Perk Code" SortExpression="PerkCode">
          <ItemTemplate>
            <asp:Label ID="LabelPerkCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PerkCode") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="Advance Applicable" SortExpression="AdvanceApplicable">
          <ItemTemplate>
            <asp:Label ID="LabelAdvanceApplicable" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AdvanceApplicable") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Advance Months" SortExpression="AdvanceMonths">
          <ItemTemplate>
            <asp:Label ID="LabelAdvanceMonths" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AdvanceMonths") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Locked Months" SortExpression="LockedMonths">
          <ItemTemplate>
            <asp:Label ID="LabelLockedMonths" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LockedMonths") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No Of Payments" SortExpression="NoOfPayments">
          <ItemTemplate>
            <asp:Label ID="LabelNoOfPayments" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NoOfPayments") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Carry Forward" SortExpression="CarryForward">
          <ItemTemplate>
            <asp:Label ID="LabelCarryForward" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CarryForward") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="UOM">
          <ItemTemplate>
            <asp:Label ID="LabelUOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UOM") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="Active">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
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
      ID = "ODSnprkPerks"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkPerks"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "nprkPerksSelectList"
      TypeName = "SIS.NPRK.nprkPerks"
      SelectCountMethod = "nprkPerksSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVnprkPerks" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
