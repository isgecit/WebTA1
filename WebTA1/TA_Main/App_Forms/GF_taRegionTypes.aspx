<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taRegionTypes.aspx.vb" Inherits="GF_taRegionTypes" title="Maintain List: Region Types" %>
<asp:Content ID="CPHtaRegionTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaRegionTypes" runat="server" Text="&nbsp;List: Region Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaRegionTypes" runat="server">
  <ContentTemplate>
    <asp:TextBox ID="F_lgCombo" runat="server"></asp:TextBox>
    <LGM:lgCombo ID="lgCombo1" runat="server" TargetField="F_lgCombo" />
    <table style="width:100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaRegionTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taRegionTypes.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taRegionTypes.aspx"
      ValidationGroup = "taRegionTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaRegionTypes" runat="server" AssociatedUpdatePanelID="UPNLtaRegionTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaRegionTypes" SkinID="gv_silver" runat="server" DataSourceID="ODStaRegionTypes" DataKeyNames="RegionTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region Type ID" SortExpression="RegionTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelRegionTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RegionTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region Type Name" SortExpression="RegionTypeName">
          <ItemTemplate>
            <asp:Label ID="LabelRegionTypeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RegionTypeName") %>'></asp:Label>
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
      ID = "ODStaRegionTypes"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taRegionTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taRegionTypesSelectList"
      TypeName = "SIS.TA.taRegionTypes"
      SelectCountMethod = "taRegionTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaRegionTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
