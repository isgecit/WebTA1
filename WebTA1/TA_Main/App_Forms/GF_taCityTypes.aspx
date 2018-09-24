<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taCityTypes.aspx.vb" Inherits="GF_taCityTypes" title="Maintain List: City Types" %>
<asp:Content ID="CPHtaCityTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaCityTypes" runat="server" Text="&nbsp;List: City Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCityTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCityTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCityTypes.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCityTypes.aspx"
      ValidationGroup = "taCityTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCityTypes" runat="server" AssociatedUpdatePanelID="UPNLtaCityTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCityTypes" SkinID="gv_silver" runat="server" DataSourceID="ODStaCityTypes" DataKeyNames="CityTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City Type ID" SortExpression="CityTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelCityTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CityTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City Type Name" SortExpression="CityTypeName">
          <ItemTemplate>
            <asp:Label ID="LabelCityTypeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CityTypeName") %>'></asp:Label>
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
      ID = "ODStaCityTypes"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCityTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taCityTypesSelectList"
      TypeName = "SIS.TA.taCityTypes"
      SelectCountMethod = "taCityTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaCityTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
