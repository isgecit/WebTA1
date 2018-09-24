<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_costERPGLCodes.aspx.vb" Inherits="GF_costERPGLCodes" title="Maintain List: ERP GL Codes" %>
<asp:Content ID="CPHcostERPGLCodes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostERPGLCodes" runat="server" Text="&nbsp;List: ERP GL Codes"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostERPGLCodes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostERPGLCodes"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costERPGLCodes.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costERPGLCodes.aspx"
      ValidationGroup = "costERPGLCodes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostERPGLCodes" runat="server" AssociatedUpdatePanelID="UPNLcostERPGLCodes" DisplayAfter="100">
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
          <b><asp:Label ID="L_GLCode" runat="server" Text="GL Code :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_GLCode"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="7"
            Width="64px"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVcostERPGLCodes" SkinID="gv_silver" runat="server" DataSourceID="ODScostERPGLCodes" DataKeyNames="GLCode">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Code" SortExpression="GLCode">
          <ItemTemplate>
            <asp:Label ID="LabelGLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GLCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Description" SortExpression="GLDescription">
          <ItemTemplate>
            <asp:Label ID="LabelGLDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GLDescription") %>'></asp:Label>
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
      ID = "ODScostERPGLCodes"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costERPGLCodes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costERPGLCodesSelectList"
      TypeName = "SIS.COST.costERPGLCodes"
      SelectCountMethod = "costERPGLCodesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_GLCode" PropertyName="Text" Name="GLCode" Type="String" Size="7" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostERPGLCodes" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_GLCode" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
