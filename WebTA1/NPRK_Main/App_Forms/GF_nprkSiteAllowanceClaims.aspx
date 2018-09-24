<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkSiteAllowanceClaims.aspx.vb" Inherits="GF_nprkSiteAllowanceClaims" title="Maintain List: Claim Site Allowance" %>
<asp:Content ID="CPHnprkSiteAllowanceClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkSiteAllowanceClaims" runat="server" Text="&nbsp;List: Claim Site Allowance"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkSiteAllowanceClaims" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkSiteAllowanceClaims"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkSiteAllowanceClaims.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkSiteAllowanceClaims.aspx"
      ValidationGroup = "nprkSiteAllowanceClaims"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkSiteAllowanceClaims" runat="server" AssociatedUpdatePanelID="UPNLnprkSiteAllowanceClaims" DisplayAfter="100">
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
          <b><asp:Label ID="L_FinYear" runat="server" Text="Fin Year :" /></b>
        </td>
        <td>
          <LGM:LC_costFinYear
            ID="F_FinYear"
            OrderBy="Descpription"
            DataTextField="Descpription"
            DataValueField="FinYear"
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
          <b><asp:Label ID="L_Quarter" runat="server" Text="Quarter :" /></b>
        </td>
        <td>
          <LGM:LC_costQuarters
            ID="F_Quarter"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="Quarter"
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
    <asp:GridView ID="GVnprkSiteAllowanceClaims" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkSiteAllowanceClaims" DataKeyNames="FinYear,Quarter,EmployeeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fin Year" SortExpression="COST_FinYear3_Descpription">
          <ItemTemplate>
             <asp:Label ID="L_FinYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FinYear") %>' Text='<%# Eval("COST_FinYear3_Descpription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quarter" SortExpression="COST_Quarters4_Description">
          <ItemTemplate>
             <asp:Label ID="L_Quarter" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("Quarter") %>' Text='<%# Eval("COST_Quarters4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Entitled Amount for 1st Month of Quarter" SortExpression="Entitled1Amount">
          <ItemTemplate>
            <asp:Label ID="LabelEntitled1Amount" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Entitled1Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Entitled Amount for 2nd Month of Quarter" SortExpression="Entitled2Amount">
          <ItemTemplate>
            <asp:Label ID="LabelEntitled2Amount" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Entitled2Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Entitled Amount for 3rd Month of Quarter" SortExpression="Entitled3Amount">
          <ItemTemplate>
            <asp:Label ID="LabelEntitled3Amount" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Entitled3Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Applied Amount" SortExpression="TotalAppliedAmount">
          <ItemTemplate>
            <asp:Label ID="LabelTotalAppliedAmount" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("TotalAppliedAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="PRK_SAClaimStatus6_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("PRK_SAClaimStatus6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkSiteAllowanceClaims"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkSiteAllowanceClaims"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkSiteAllowanceClaimsSelectList"
      TypeName = "SIS.NPRK.nprkSiteAllowanceClaims"
      SelectCountMethod = "nprkSiteAllowanceClaimsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="SelectedValue" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="SelectedValue" Name="Quarter" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkSiteAllowanceClaims" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_FinYear" />
    <asp:AsyncPostBackTrigger ControlID="F_Quarter" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
