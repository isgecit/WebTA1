<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakUnits.aspx.vb" Inherits="GF_pakUnits" title="Maintain List: Units" %>
<asp:Content ID="CPHpakUnits" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakUnits" runat="server" Text="&nbsp;List: Units"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakUnits" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakUnits"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakUnits.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakUnits.aspx"
      ValidationGroup = "pakUnits"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakUnits" runat="server" AssociatedUpdatePanelID="UPNLpakUnits" DisplayAfter="100">
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
          <b><asp:Label ID="L_UnitSetID" runat="server" Text="Unit Set ID :" /></b>
        </td>
        <td>
          <LGM:LC_pakUnitSets
            ID="F_UnitSetID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="UnitSetID"
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
    <asp:GridView ID="GVpakUnits" SkinID="gv_silver" runat="server" DataSourceID="ODSpakUnits" DataKeyNames="UnitID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Unit ID" SortExpression="UnitID">
          <ItemTemplate>
            <asp:Label ID="LabelUnitID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UnitID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Unit Set ID" SortExpression="PAK_UnitSets1_Description">
          <ItemTemplate>
             <asp:Label ID="L_UnitSetID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UnitSetID") %>' Text='<%# Eval("PAK_UnitSets1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Conversion Factor to Unit Set Base Unit" SortExpression="ConversionFactor">
          <ItemTemplate>
            <asp:Label ID="LabelConversionFactor" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ConversionFactor") %>'></asp:Label>
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
      ID = "ODSpakUnits"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakUnits"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakUnitsSelectList"
      TypeName = "SIS.PAK.pakUnits"
      SelectCountMethod = "pakUnitsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UnitSetID" PropertyName="SelectedValue" Name="UnitSetID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakUnits" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_UnitSetID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
