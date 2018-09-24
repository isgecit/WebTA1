<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogBLTypes.aspx.vb" Inherits="GF_elogBLTypes" title="Maintain List: BL Types" %>
<asp:Content ID="CPHelogBLTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogBLTypes" runat="server" Text="&nbsp;List: BL Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogBLTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogBLTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogBLTypes.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogBLTypes.aspx"
      ValidationGroup = "elogBLTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogBLTypes" runat="server" AssociatedUpdatePanelID="UPNLelogBLTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogBLTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSelogBLTypes" DataKeyNames="BLTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BL Type" SortExpression="BLTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelBLTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BLTypeID") %>'></asp:Label>
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
      ID = "ODSelogBLTypes"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogBLTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogBLTypesSelectList"
      TypeName = "SIS.ELOG.elogBLTypes"
      SelectCountMethod = "elogBLTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVelogBLTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
