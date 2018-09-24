<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_costProjectTypes.aspx.vb" Inherits="GF_costProjectTypes" title="Maintain List: Project Types" %>
<asp:Content ID="CPHcostProjectTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostProjectTypes" runat="server" Text="&nbsp;List: Project Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostProjectTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costProjectTypes.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costProjectTypes.aspx"
      ValidationGroup = "costProjectTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostProjectTypes" runat="server" AssociatedUpdatePanelID="UPNLcostProjectTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostProjectTypes" SkinID="gv_silver" runat="server" DataSourceID="ODScostProjectTypes" DataKeyNames="ProjectTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Type ID" SortExpression="ProjectTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelProjectTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Type Description" SortExpression="ProjectTypeDescription">
          <ItemTemplate>
            <asp:Label ID="LabelProjectTypeDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectTypeDescription") %>'></asp:Label>
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
      ID = "ODScostProjectTypes"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costProjectTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costProjectTypesSelectList"
      TypeName = "SIS.COST.costProjectTypes"
      SelectCountMethod = "costProjectTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVcostProjectTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
