<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakElements.aspx.vb" Inherits="GF_pakElements" title="Maintain List: Elements" %>
<asp:Content ID="CPHpakElements" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakElements" runat="server" Text="&nbsp;List: Elements"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakElements" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakElements"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakElements.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakElements.aspx"
      ValidationGroup = "pakElements"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakElements" runat="server" AssociatedUpdatePanelID="UPNLpakElements" DisplayAfter="100">
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
          <b><asp:Label ID="L_ElementID" runat="server" Text="Element ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_ElementID"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="8"
            Width="72px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ResponsibleAgencyID" runat="server" Text="Responsible Agency ID :" /></b>
        </td>
        <td>
          <LGM:LC_pakResponsibleAgencies
            ID="F_ResponsibleAgencyID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="ResponsibleAgencyID"
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
    <asp:GridView ID="GVpakElements" SkinID="gv_silver" runat="server" DataSourceID="ODSpakElements" DataKeyNames="ElementID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element ID" SortExpression="ElementID">
          <ItemTemplate>
            <asp:Label ID="LabelElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ElementID") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="Responsible Agency ID" SortExpression="PAK_ResponsibleAgencies2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ResponsibleAgencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ResponsibleAgencyID") %>' Text='<%# Eval("PAK_ResponsibleAgencies2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Parent Element ID" SortExpression="PAK_Elements1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ParentElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ParentElementID") %>' Text='<%# Eval("PAK_Elements1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakElements"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakElements"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakElementsSelectList"
      TypeName = "SIS.PAK.pakElements"
      SelectCountMethod = "pakElementsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ElementID" PropertyName="Text" Name="ElementID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_ResponsibleAgencyID" PropertyName="SelectedValue" Name="ResponsibleAgencyID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakElements" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ElementID" />
    <asp:AsyncPostBackTrigger ControlID="F_ResponsibleAgencyID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
