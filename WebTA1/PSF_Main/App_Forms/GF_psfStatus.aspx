<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_psfStatus.aspx.vb" Inherits="GF_psfStatus" title="Maintain List: PSF Status" %>
<asp:Content ID="CPHpsfStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpsfStatus" runat="server" Text="&nbsp;List: PSF Status"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpsfStatus" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpsfStatus"
      ToolType = "lgNMGrid"
      EditUrl = "~/PSF_Main/App_Edit/EF_psfStatus.aspx"
      AddUrl = "~/PSF_Main/App_Create/AF_psfStatus.aspx"
      ValidationGroup = "psfStatus"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpsfStatus" runat="server" AssociatedUpdatePanelID="UPNLpsfStatus" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpsfStatus" SkinID="gv_silver" runat="server" DataSourceID="ODSpsfStatus" DataKeyNames="PSFStatus">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PSF Status" SortExpression="PSFStatus">
          <ItemTemplate>
            <asp:Label ID="LabelPSFStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PSFStatus") %>'></asp:Label>
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
      ID = "ODSpsfStatus"
      runat = "server"
      DataObjectTypeName = "SIS.PSF.psfStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "psfStatusSelectList"
      TypeName = "SIS.PSF.psfStatus"
      SelectCountMethod = "psfStatusSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpsfStatus" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
