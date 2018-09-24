<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogBreakbulkTypes.aspx.vb" Inherits="GF_elogBreakbulkTypes" title="Maintain List: Breakbulk Types" %>
<asp:Content ID="CPHelogBreakbulkTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogBreakbulkTypes" runat="server" Text="&nbsp;List: Breakbulk Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogBreakbulkTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogBreakbulkTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogBreakbulkTypes.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogBreakbulkTypes.aspx"
      ValidationGroup = "elogBreakbulkTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogBreakbulkTypes" runat="server" AssociatedUpdatePanelID="UPNLelogBreakbulkTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogBreakbulkTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSelogBreakbulkTypes" DataKeyNames="BreakbulkTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Breakbulk Type" SortExpression="BreakbulkTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelBreakbulkTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BreakbulkTypeID") %>'></asp:Label>
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
      ID = "ODSelogBreakbulkTypes"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogBreakbulkTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogBreakbulkTypesSelectList"
      TypeName = "SIS.ELOG.elogBreakbulkTypes"
      SelectCountMethod = "elogBreakbulkTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVelogBreakbulkTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
