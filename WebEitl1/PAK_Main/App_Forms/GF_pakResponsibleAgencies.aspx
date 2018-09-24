<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakResponsibleAgencies.aspx.vb" Inherits="GF_pakResponsibleAgencies" title="Maintain List: Responsible Agencies" %>
<asp:Content ID="CPHpakResponsibleAgencies" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakResponsibleAgencies" runat="server" Text="&nbsp;List: Responsible Agencies"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakResponsibleAgencies" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakResponsibleAgencies"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakResponsibleAgencies.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakResponsibleAgencies.aspx"
      ValidationGroup = "pakResponsibleAgencies"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakResponsibleAgencies" runat="server" AssociatedUpdatePanelID="UPNLpakResponsibleAgencies" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakResponsibleAgencies" SkinID="gv_silver" runat="server" DataSourceID="ODSpakResponsibleAgencies" DataKeyNames="ResponsibleAgencyID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responsible Agency ID" SortExpression="ResponsibleAgencyID">
          <ItemTemplate>
            <asp:Label ID="LabelResponsibleAgencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ResponsibleAgencyID") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="External Agency" SortExpression="ExternalAgency">
          <ItemTemplate>
            <asp:Label ID="LabelExternalAgency" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExternalAgency") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakResponsibleAgencies"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakResponsibleAgencies"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakResponsibleAgenciesSelectList"
      TypeName = "SIS.PAK.pakResponsibleAgencies"
      SelectCountMethod = "pakResponsibleAgenciesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakResponsibleAgencies" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
