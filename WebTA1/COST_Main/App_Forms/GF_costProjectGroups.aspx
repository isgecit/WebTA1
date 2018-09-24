<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_costProjectGroups.aspx.vb" Inherits="GF_costProjectGroups" title="Maintain List: Project Groups" %>
<asp:Content ID="CPHcostProjectGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostProjectGroups" runat="server" Text="&nbsp;List: Project Groups"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectGroups" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostProjectGroups"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costProjectGroups.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costProjectGroups.aspx?skip=1"
      ValidationGroup = "costProjectGroups"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostProjectGroups" runat="server" AssociatedUpdatePanelID="UPNLcostProjectGroups" DisplayAfter="100">
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
          <b><asp:Label ID="L_ProjectGroupID" runat="server" Text="Project Group ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_ProjectGroupID"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectGroupID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectGroupID" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectGroupID"
            runat = "server"
            ControlToValidate = "F_ProjectGroupID"
            ControlExtender = "MEEProjectGroupID"
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
    <asp:GridView ID="GVcostProjectGroups" SkinID="gv_silver" runat="server" DataSourceID="ODScostProjectGroups" DataKeyNames="ProjectGroupID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Group ID" SortExpression="ProjectGroupID">
          <ItemTemplate>
            <asp:Label ID="LabelProjectGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectGroupID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Group Description" SortExpression="ProjectGroupDescription">
          <ItemTemplate>
            <asp:Label ID="LabelProjectGroupDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectGroupDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Type" SortExpression="COST_ProjectTypes1_ProjectTypeDescription">
          <ItemTemplate>
             <asp:Label ID="L_ProjectTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectTypeID") %>' Text='<%# Eval("COST_ProjectTypes1_ProjectTypeDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostProjectGroups"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costProjectGroups"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costProjectGroupsSelectList"
      TypeName = "SIS.COST.costProjectGroups"
      SelectCountMethod = "costProjectGroupsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostProjectGroups" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectGroupID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
