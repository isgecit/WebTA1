<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakSiteLocationTypes.aspx.vb" Inherits="GF_pakSiteLocationTypes" title="Maintain List: Site Location Types" %>
<asp:Content ID="CPHpakSiteLocationTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakSiteLocationTypes" runat="server" Text="&nbsp;List: Site Location Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteLocationTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSiteLocationTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSiteLocationTypes.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakSiteLocationTypes.aspx"
      ValidationGroup = "pakSiteLocationTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSiteLocationTypes" runat="server" AssociatedUpdatePanelID="UPNLpakSiteLocationTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakSiteLocationTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSiteLocationTypes" DataKeyNames="LocationTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location Type" SortExpression="LocationTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelLocationTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LocationTypeID") %>'></asp:Label>
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
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakSiteLocationTypes"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSiteLocationTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakSiteLocationTypesSelectList"
      TypeName = "SIS.PAK.pakSiteLocationTypes"
      SelectCountMethod = "pakSiteLocationTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpakSiteLocationTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
