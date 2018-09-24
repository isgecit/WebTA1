<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taCalcMethod.aspx.vb" Inherits="GF_taCalcMethod" title="Maintain List: Calculation Method" %>
<asp:Content ID="CPHtaCalcMethod" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaCalcMethod" runat="server" Text="&nbsp;List: Calculation Method"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCalcMethod" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCalcMethod"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCalcMethod.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCalcMethod.aspx"
      ValidationGroup = "taCalcMethod"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCalcMethod" runat="server" AssociatedUpdatePanelID="UPNLtaCalcMethod" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCalcMethod" SkinID="gv_silver" runat="server" DataSourceID="ODStaCalcMethod" DataKeyNames="CalculationTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Calculation Type ID" SortExpression="CalculationTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelCalculationTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CalculationTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Calculation Description" SortExpression="CalculationDescription">
          <ItemTemplate>
            <asp:Label ID="LabelCalculationDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CalculationDescription") %>'></asp:Label>
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
      ID = "ODStaCalcMethod"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCalcMethod"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taCalcMethodSelectList"
      TypeName = "SIS.TA.taCalcMethod"
      SelectCountMethod = "taCalcMethodSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaCalcMethod" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
