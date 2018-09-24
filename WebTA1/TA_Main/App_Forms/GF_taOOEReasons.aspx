<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taOOEReasons.aspx.vb" Inherits="GF_taOOEReasons" title="Maintain List: O. O. E. Reasons" %>
<asp:Content ID="CPHtaOOEReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaOOEReasons" runat="server" Text="&nbsp;List: O. O. E. Reasons"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaOOEReasons" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaOOEReasons"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taOOEReasons.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taOOEReasons.aspx"
      ValidationGroup = "taOOEReasons"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaOOEReasons" runat="server" AssociatedUpdatePanelID="UPNLtaOOEReasons" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaOOEReasons" SkinID="gv_silver" runat="server" DataSourceID="ODStaOOEReasons" DataKeyNames="ReasonID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reason ID" SortExpression="ReasonID">
          <ItemTemplate>
            <asp:Label ID="LabelReasonID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReasonID") %>'></asp:Label>
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
      ID = "ODStaOOEReasons"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taOOEReasons"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taOOEReasonsSelectList"
      TypeName = "SIS.TA.taOOEReasons"
      SelectCountMethod = "taOOEReasonsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaOOEReasons" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
