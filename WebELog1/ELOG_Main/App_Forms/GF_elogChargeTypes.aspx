<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogChargeTypes.aspx.vb" Inherits="GF_elogChargeTypes" title="Maintain List: Charge Types" %>
<asp:Content ID="CPHelogChargeTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogChargeTypes" runat="server" Text="&nbsp;List: Charge Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogChargeTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogChargeTypes.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogChargeTypes.aspx"
      ValidationGroup = "elogChargeTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogChargeTypes" runat="server" AssociatedUpdatePanelID="UPNLelogChargeTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogChargeTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSelogChargeTypes" DataKeyNames="ChargeTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Type" SortExpression="ChargeTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelChargeTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ChargeTypeID") %>'></asp:Label>
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
      ID = "ODSelogChargeTypes"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogChargeTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogChargeTypesSelectList"
      TypeName = "SIS.ELOG.elogChargeTypes"
      SelectCountMethod = "elogChargeTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVelogChargeTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
