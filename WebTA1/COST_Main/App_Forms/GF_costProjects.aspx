<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_costProjects.aspx.vb" Inherits="GF_costProjects" title="Maintain List: Projects" %>
<asp:Content ID="CPHcostProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostProjects" runat="server" Text="&nbsp;List: Projects"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjects" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostProjects"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costProjects.aspx"
      EnableAdd = "False"
      ValidationGroup = "costProjects"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostProjects" runat="server" AssociatedUpdatePanelID="UPNLcostProjects" DisplayAfter="100">
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
          <b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_ProjectID"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="6"
            Width="56px"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVcostProjects" SkinID="gv_silver" runat="server" DataSourceID="ODScostProjects" DataKeyNames="ProjectID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="ProjectID">
          <ItemTemplate>
            <asp:Label ID="LabelProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectID") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="Work Order Type" SortExpression="COST_WorkOrderTypes3_WorkOrderTypeDescription">
          <ItemTemplate>
             <asp:Label ID="L_WorkOrderTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("WorkOrderTypeID") %>' Text='<%# Eval("COST_WorkOrderTypes3_WorkOrderTypeDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Division" SortExpression="COST_Divisions1_DivisionName">
          <ItemTemplate>
             <asp:Label ID="L_DivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DivisionID") %>' Text='<%# Eval("COST_Divisions1_DivisionName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Order Value INR" SortExpression="ProjectOrderValueINR">
          <ItemTemplate>
            <asp:Label ID="LabelProjectOrderValueINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectOrderValueINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Warranty Percentage [INR]" SortExpression="WarrantyPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelWarrantyPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WarrantyPercentage") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostProjects"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costProjects"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costProjectsSelectList"
      TypeName = "SIS.COST.costProjects"
      SelectCountMethod = "costProjectsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostProjects" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
