<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogICDCFSs.aspx.vb" Inherits="GF_elogICDCFSs" title="Maintain List: ICD-CFS" %>
<asp:Content ID="CPHelogICDCFSs" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogICDCFSs" runat="server" Text="&nbsp;List: ICD-CFS"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogICDCFSs" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogICDCFSs"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogICDCFSs.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogICDCFSs.aspx"
      ValidationGroup = "elogICDCFSs"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogICDCFSs" runat="server" AssociatedUpdatePanelID="UPNLelogICDCFSs" DisplayAfter="100">
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
          <b><asp:Label ID="L_StuffingPointID" runat="server" Text="Stuffing Point ID :" /></b>
        </td>
        <td>
          <LGM:LC_elogStuffingPoints
            ID="F_StuffingPointID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="StuffingPointID"
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
    <asp:GridView ID="GVelogICDCFSs" SkinID="gv_silver" runat="server" DataSourceID="ODSelogICDCFSs" DataKeyNames="ICDCFSID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ICD-CFS ID" SortExpression="ICDCFSID">
          <ItemTemplate>
            <asp:Label ID="LabelICDCFSID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ICDCFSID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stuffing Point ID" SortExpression="ELOG_StuffingPoints1_Description">
          <ItemTemplate>
             <asp:Label ID="L_StuffingPointID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StuffingPointID") %>' Text='<%# Eval("ELOG_StuffingPoints1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
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
      ID = "ODSelogICDCFSs"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogICDCFSs"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_elogICDCFSsSelectList"
      TypeName = "SIS.ELOG.elogICDCFSs"
      SelectCountMethod = "elogICDCFSsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_StuffingPointID" PropertyName="SelectedValue" Name="StuffingPointID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVelogICDCFSs" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_StuffingPointID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
