<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_hrmOfficeLocation.aspx.vb" Inherits="GF_hrmOfficeLocation" title="Maintain List: Office Location" %>
<asp:Content ID="CPHhrmOfficeLocation" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelhrmOfficeLocation" runat="server" Text="&nbsp;List: Office Location"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLhrmOfficeLocation" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLhrmOfficeLocation"
      ToolType = "lgNMGrid"
      EditUrl = "~/HRM_Main/App_Edit/EF_hrmOfficeLocation.aspx"
      AddUrl = "~/HRM_Main/App_Create/AF_hrmOfficeLocation.aspx"
      AddPostBack = "True"
      ValidationGroup = "hrmOfficeLocation"
      runat = "server" />
    <asp:UpdateProgress ID="UPGShrmOfficeLocation" runat="server" AssociatedUpdatePanelID="UPNLhrmOfficeLocation" DisplayAfter="100">
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
          <b><asp:Label ID="L_LocationID" runat="server" Text="Location ID :" /></b>
        </td>
        <td>
          <LGM:LC_hrmLocations
            ID="F_LocationID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="LocationID"
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
    <asp:GridView ID="GVhrmOfficeLocation" SkinID="gv_silver" runat="server" DataSourceID="ODShrmOfficeLocation" DataKeyNames="LocationID,OfficeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location ID" SortExpression="HRM_Locations1_Description">
          <ItemTemplate>
             <asp:Label ID="L_LocationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("LocationID") %>' Text='<%# Eval("HRM_Locations1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Office ID" SortExpression="HRM_Offices2_Description">
          <ItemTemplate>
             <asp:Label ID="L_OfficeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("OfficeID") %>' Text='<%# Eval("HRM_Offices2_Description") %>'></asp:Label>
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
      ID = "ODShrmOfficeLocation"
      runat = "server"
      DataObjectTypeName = "SIS.HRM.hrmOfficeLocation"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "hrmOfficeLocationSelectList"
      TypeName = "SIS.HRM.hrmOfficeLocation"
      SelectCountMethod = "hrmOfficeLocationSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_LocationID" PropertyName="SelectedValue" Name="LocationID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVhrmOfficeLocation" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_LocationID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
