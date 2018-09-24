<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkMobileBillPlans.aspx.vb" Inherits="GF_nprkMobileBillPlans" title="Maintain List: Bill Plan" %>
<asp:Content ID="CPHnprkMobileBillPlans" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkMobileBillPlans" runat="server" Text="&nbsp;List: Bill Plan"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkMobileBillPlans" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkMobileBillPlans"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkMobileBillPlans.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkMobileBillPlans.aspx"
      ValidationGroup = "nprkMobileBillPlans"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkMobileBillPlans" runat="server" AssociatedUpdatePanelID="UPNLnprkMobileBillPlans" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVnprkMobileBillPlans" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkMobileBillPlans" DataKeyNames="MobileBillPlanID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Mobile Bill Plan ID" SortExpression="MobileBillPlanID">
          <ItemTemplate>
            <asp:Label ID="LabelMobileBillPlanID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MobileBillPlanID") %>'></asp:Label>
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
      ID = "ODSnprkMobileBillPlans"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkMobileBillPlans"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "nprkMobileBillPlansSelectList"
      TypeName = "SIS.NPRK.nprkMobileBillPlans"
      SelectCountMethod = "nprkMobileBillPlansSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVnprkMobileBillPlans" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
