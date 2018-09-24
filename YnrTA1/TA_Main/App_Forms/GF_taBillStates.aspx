<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taBillStates.aspx.vb" Inherits="GF_taBillStates" title="Maintain List: Bill States" %>
<asp:Content ID="CPHtaBillStates" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaBillStates" runat="server" Text="&nbsp;List: Bill States"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillStates" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillStates"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillStates.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBillStates.aspx"
      ValidationGroup = "taBillStates"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillStates" runat="server" AssociatedUpdatePanelID="UPNLtaBillStates" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBillStates" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillStates" DataKeyNames="BillStatusID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Status ID" SortExpression="BillStatusID">
          <ItemTemplate>
            <asp:Label ID="LabelBillStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillStatusID") %>'></asp:Label>
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
      ID = "ODStaBillStates"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillStates"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taBillStatesSelectList"
      TypeName = "SIS.TA.taBillStates"
      SelectCountMethod = "taBillStatesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaBillStates" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
