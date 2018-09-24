<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogCargoTypes.aspx.vb" Inherits="GF_elogCargoTypes" title="Maintain List: Cargo Types" %>
<asp:Content ID="CPHelogCargoTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogCargoTypes" runat="server" Text="&nbsp;List: Cargo Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogCargoTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogCargoTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogCargoTypes.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogCargoTypes.aspx"
      ValidationGroup = "elogCargoTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogCargoTypes" runat="server" AssociatedUpdatePanelID="UPNLelogCargoTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogCargoTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSelogCargoTypes" DataKeyNames="CargoTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cargo Type" SortExpression="CargoTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelCargoTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CargoTypeID") %>'></asp:Label>
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
      ID = "ODSelogCargoTypes"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogCargoTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogCargoTypesSelectList"
      TypeName = "SIS.ELOG.elogCargoTypes"
      SelectCountMethod = "elogCargoTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVelogCargoTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
