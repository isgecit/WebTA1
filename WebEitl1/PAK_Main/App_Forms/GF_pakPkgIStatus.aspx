<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakPkgIStatus.aspx.vb" Inherits="GF_pakPkgIStatus" title="Maintain List: Packing List States" %>
<asp:Content ID="CPHpakPkgIStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakPkgIStatus" runat="server" Text="&nbsp;List: Packing List States"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakPkgIStatus" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakPkgIStatus"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakPkgIStatus.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakPkgIStatus.aspx"
      ValidationGroup = "pakPkgIStatus"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakPkgIStatus" runat="server" AssociatedUpdatePanelID="UPNLpakPkgIStatus" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakPkgIStatus" SkinID="gv_silver" runat="server" DataSourceID="ODSpakPkgIStatus" DataKeyNames="StatusID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status ID" SortExpression="StatusID">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusID") %>'></asp:Label>
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
      ID = "ODSpakPkgIStatus"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakPkgIStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakPkgIStatusSelectList"
      TypeName = "SIS.PAK.pakPkgIStatus"
      SelectCountMethod = "pakPkgIStatusSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpakPkgIStatus" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
