<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkClaimStatus.aspx.vb" Inherits="GF_nprkClaimStatus" title="Maintain List: Claim States" %>
<asp:Content ID="CPHnprkClaimStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkClaimStatus" runat="server" Text="&nbsp;List: Claim States"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkClaimStatus" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkClaimStatus"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkClaimStatus.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkClaimStatus.aspx"
      ValidationGroup = "nprkClaimStatus"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkClaimStatus" runat="server" AssociatedUpdatePanelID="UPNLnprkClaimStatus" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVnprkClaimStatus" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkClaimStatus" DataKeyNames="ClaimStatusID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claim Status ID" SortExpression="ClaimStatusID">
          <ItemTemplate>
            <asp:Label ID="LabelClaimStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ClaimStatusID") %>'></asp:Label>
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
      ID = "ODSnprkClaimStatus"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkClaimStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "nprkClaimStatusSelectList"
      TypeName = "SIS.NPRK.nprkClaimStatus"
      SelectCountMethod = "nprkClaimStatusSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVnprkClaimStatus" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
