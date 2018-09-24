<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taPrjCalcMethod.aspx.vb" Inherits="GF_taPrjCalcMethod" title="Maintain List: Project wise calculation method" %>
<asp:Content ID="CPHtaPrjCalcMethod" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaPrjCalcMethod" runat="server" Text="&nbsp;List: Project wise calculation method"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaPrjCalcMethod" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaPrjCalcMethod"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taPrjCalcMethod.aspx"
      EnableAdd = "False"
      ValidationGroup = "taPrjCalcMethod"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaPrjCalcMethod" runat="server" AssociatedUpdatePanelID="UPNLtaPrjCalcMethod" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaPrjCalcMethod" SkinID="gv_silver" runat="server" DataSourceID="ODStaPrjCalcMethod" DataKeyNames="ProjectCalcID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Calculation Type " SortExpression="ProjectCalcID">
          <ItemTemplate>
            <asp:Label ID="LabelProjectCalcID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectCalcID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Calculation Method" SortExpression="Description">
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
      ID = "ODStaPrjCalcMethod"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taPrjCalcMethod"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taPrjCalcMethodSelectList"
      TypeName = "SIS.TA.taPrjCalcMethod"
      SelectCountMethod = "taPrjCalcMethodSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaPrjCalcMethod" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
