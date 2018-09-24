<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogStuffingTypes.aspx.vb" Inherits="GF_elogStuffingTypes" title="Maintain List: Stuffing Types" %>
<asp:Content ID="CPHelogStuffingTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogStuffingTypes" runat="server" Text="&nbsp;List: Stuffing Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogStuffingTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogStuffingTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogStuffingTypes.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogStuffingTypes.aspx"
      ValidationGroup = "elogStuffingTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogStuffingTypes" runat="server" AssociatedUpdatePanelID="UPNLelogStuffingTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogStuffingTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSelogStuffingTypes" DataKeyNames="StuffingTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stuffing Type" SortExpression="StuffingTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelStuffingTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StuffingTypeID") %>'></asp:Label>
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
      ID = "ODSelogStuffingTypes"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogStuffingTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogStuffingTypesSelectList"
      TypeName = "SIS.ELOG.elogStuffingTypes"
      SelectCountMethod = "elogStuffingTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVelogStuffingTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
