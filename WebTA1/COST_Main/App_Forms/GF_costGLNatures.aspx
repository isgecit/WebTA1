<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_costGLNatures.aspx.vb" Inherits="GF_costGLNatures" title="Maintain List: GL Natures" %>
<asp:Content ID="CPHcostGLNatures" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostGLNatures" runat="server" Text="&nbsp;List: GL Natures"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLNatures" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostGLNatures"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costGLNatures.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costGLNatures.aspx"
      ValidationGroup = "costGLNatures"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostGLNatures" runat="server" AssociatedUpdatePanelID="UPNLcostGLNatures" DisplayAfter="100">
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
          <b><asp:Label ID="L_GLNatureID" runat="server" Text="GL Nature ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_GLNatureID"
            Text=""
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEGLNatureID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_GLNatureID" />
          <AJX:MaskedEditValidator 
            ID = "MEVGLNatureID"
            runat = "server"
            ControlToValidate = "F_GLNatureID"
            ControlExtender = "MEEGLNatureID"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVcostGLNatures" SkinID="gv_silver" runat="server" DataSourceID="ODScostGLNatures" DataKeyNames="GLNatureID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Nature ID" SortExpression="GLNatureID">
          <ItemTemplate>
            <asp:Label ID="LabelGLNatureID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GLNatureID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Nature Description" SortExpression="GLNatureDescription">
          <ItemTemplate>
            <asp:Label ID="LabelGLNatureDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GLNatureDescription") %>'></asp:Label>
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
      ID = "ODScostGLNatures"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costGLNatures"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costGLNaturesSelectList"
      TypeName = "SIS.COST.costGLNatures"
      SelectCountMethod = "costGLNaturesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_GLNatureID" PropertyName="Text" Name="GLNatureID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostGLNatures" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_GLNatureID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
