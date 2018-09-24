<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taApprovalWFTypes.aspx.vb" Inherits="GF_taApprovalWFTypes" title="Maintain List: Approval WF Types" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;List: Approval WF Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaApprovalWFTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taApprovalWFTypes.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taApprovalWFTypes.aspx"
      ValidationGroup = "taApprovalWFTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaApprovalWFTypes" SkinID="gv_silver" runat="server" DataSourceID="ODStaApprovalWFTypes" DataKeyNames="WFTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WF Type ID" SortExpression="WFTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelWFTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WFTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WF Type Description" SortExpression="WFTypeDescription">
          <ItemTemplate>
            <asp:Label ID="LabelWFTypeDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WFTypeDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Required Division Head Approval" SortExpression="RequiredDivisionHeadApproval">
          <ItemTemplate>
            <asp:Label ID="LabelRequiredDivisionHeadApproval" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequiredDivisionHeadApproval") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Required MD Approval" SortExpression="RequiredMDApproval">
          <ItemTemplate>
            <asp:Label ID="LabelRequiredMDApproval" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequiredMDApproval") %>'></asp:Label>
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
      ID = "ODStaApprovalWFTypes"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taApprovalWFTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taApprovalWFTypesSelectList"
      TypeName = "SIS.TA.taApprovalWFTypes"
      SelectCountMethod = "taApprovalWFTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaApprovalWFTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
