<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkRules.aspx.vb" Inherits="GF_nprkRules" title="Maintain List: Perk Rules" %>
<asp:Content ID="CPHnprkRules" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkRules" runat="server" Text="&nbsp;List: Perk Rules"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkRules" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkRules"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkRules.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkRules.aspx"
      ValidationGroup = "nprkRules"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkRules" runat="server" AssociatedUpdatePanelID="UPNLnprkRules" DisplayAfter="100">
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
          <b><asp:Label ID="L_PerkID" runat="server" Text="Perk Type :" /></b>
        </td>
        <td>
          <LGM:LC_nprkPerks
            ID="F_PerkID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="PerkID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategoryID" runat="server" Text="Category :" /></b>
        </td>
        <td>
          <LGM:LC_nprkCategories
            ID="F_CategoryID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CategoryID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVnprkRules" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkRules" DataKeyNames="RuleID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rule ID" SortExpression="RuleID">
          <ItemTemplate>
            <asp:Label ID="LabelRuleID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RuleID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Perk Type" SortExpression="PRK_Perks2_Description">
          <ItemTemplate>
             <asp:Label ID="L_PerkID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("PerkID") %>' Text='<%# Eval("PRK_Perks2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category" SortExpression="PRK_Categories1_Description">
          <ItemTemplate>
             <asp:Label ID="L_CategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategoryID") %>' Text='<%# Eval("PRK_Categories1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Effective Date" SortExpression="EffectiveDate">
          <ItemTemplate>
            <asp:Label ID="LabelEffectiveDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EffectiveDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Percentage Of Basic" SortExpression="PercentageOfBasic">
          <ItemTemplate>
            <asp:Label ID="LabelPercentageOfBasic" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PercentageOfBasic") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Percentage" SortExpression="Percentage">
          <ItemTemplate>
            <asp:Label ID="LabelPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Percentage") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fixed Value" SortExpression="FixedValue">
          <ItemTemplate>
            <asp:Label ID="LabelFixedValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FixedValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Posted At" SortExpression="PostedAt">
          <ItemTemplate>
            <asp:Label ID="LabelPostedAt" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PostedAt") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vehicle Type" SortExpression="VehicleType">
          <ItemTemplate>
            <asp:Label ID="LabelVehicleType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleType") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="In Salary" SortExpression="InSalary">
          <ItemTemplate>
            <asp:Label ID="LabelInSalary" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("InSalary") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkRules"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkRules"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "nprkRulesSelectList"
      TypeName = "SIS.NPRK.nprkRules"
      SelectCountMethod = "nprkRulesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_PerkID" PropertyName="SelectedValue" Name="PerkID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CategoryID" PropertyName="SelectedValue" Name="CategoryID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkRules" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_PerkID" />
    <asp:AsyncPostBackTrigger ControlID="F_CategoryID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
