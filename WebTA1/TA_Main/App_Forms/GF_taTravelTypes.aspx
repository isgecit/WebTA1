<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taTravelTypes.aspx.vb" Inherits="GF_taTravelTypes" title="Maintain List: Travel Types" %>
<asp:Content ID="CPHtaTravelTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaTravelTypes" runat="server" Text="&nbsp;List: Travel Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaTravelTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaTravelTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taTravelTypes.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taTravelTypes.aspx"
      ValidationGroup = "taTravelTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaTravelTypes" runat="server" AssociatedUpdatePanelID="UPNLtaTravelTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaTravelTypes" SkinID="gv_silver" runat="server" DataSourceID="ODStaTravelTypes" DataKeyNames="TravelTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Type ID" SortExpression="TravelTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelTravelTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TravelTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Type Description" SortExpression="TravelTypeDescription">
          <ItemTemplate>
            <asp:Label ID="LabelTravelTypeDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TravelTypeDescription") %>'></asp:Label>
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
      ID = "ODStaTravelTypes"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taTravelTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taTravelTypesSelectList"
      TypeName = "SIS.TA.taTravelTypes"
      SelectCountMethod = "taTravelTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaTravelTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
