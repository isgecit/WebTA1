<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taExpenseHeads.aspx.vb" Inherits="GF_taExpenseHeads" title="Maintain List: Expense Heads" %>
<asp:Content ID="CPHtaExpenseHeads" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaExpenseHeads" runat="server" Text="&nbsp;List: Expense Heads"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaExpenseHeads" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaExpenseHeads"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taExpenseHeads.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taExpenseHeads.aspx"
      ValidationGroup = "taExpenseHeads"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaExpenseHeads" runat="server" AssociatedUpdatePanelID="UPNLtaExpenseHeads" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaExpenseHeads" SkinID="gv_silver" runat="server" DataSourceID="ODStaExpenseHeads" DataKeyNames="ExpenseHeadID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Expense Head ID" SortExpression="ExpenseHeadID">
          <ItemTemplate>
            <asp:Label ID="LabelExpenseHeadID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExpenseHeadID") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="One Time In Tour" SortExpression="OneTimeInTour">
          <ItemTemplate>
            <asp:Label ID="LabelOneTimeInTour" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OneTimeInTour") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requires MD Approval" SortExpression="RequiresMDApproval">
          <ItemTemplate>
            <asp:Label ID="LabelRequiresMDApproval" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequiresMDApproval") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaExpenseHeads"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taExpenseHeads"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taExpenseHeadsSelectList"
      TypeName = "SIS.TA.taExpenseHeads"
      SelectCountMethod = "taExpenseHeadsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaExpenseHeads" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
