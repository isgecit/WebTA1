<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_tarTravelRequest.aspx.vb" Inherits="GF_tarTravelRequest" title="Maintain List: Travel Request" %>
<asp:Content ID="CPHtarTravelRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltarTravelRequest" runat="server" Text="&nbsp;List: Travel Request"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtarTravelRequest" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtarTravelRequest"
      ToolType = "lgNMGrid"
      EditUrl = "~/TAR_Main/App_Edit/EF_tarTravelRequest.aspx"
      AddUrl = "~/TAR_Main/App_Create/AF_tarTravelRequest.aspx"
      ValidationGroup = "tarTravelRequest"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStarTravelRequest" runat="server" AssociatedUpdatePanelID="UPNLtarTravelRequest" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVtarTravelRequest" SkinID="gv_silver" runat="server" DataSourceID="ODStarTravelRequest" DataKeyNames="RequestID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Req.ID" SortExpression="RequestID">
          <ItemTemplate>
            <asp:Label ID="LabelRequestID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Type" SortExpression="TA_TravelTypes13_TravelTypeDescription">
          <ItemTemplate>
             <asp:Label ID="L_TravelTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TravelTypeID") %>' Text='<%# Eval("TA_TravelTypes13_TravelTypeDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects9_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects9_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cost Center" SortExpression="HRM_Departments8_Description">
          <ItemTemplate>
             <asp:Label ID="L_CostCenterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CostCenterID") %>' Text='<%# Eval("HRM_Departments8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Itinerary" SortExpression="TravelItinerary">
          <ItemTemplate>
            <asp:Label ID="LabelTravelItinerary" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TravelItinerary") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle CssClass="alignCenter" Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested Amount" SortExpression="TotalRequestedAmount">
          <ItemTemplate>
            <asp:Label ID="LabelTotalRequestedAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalRequestedAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency" SortExpression="TA_Currencies10_CurrencyName">
          <ItemTemplate>
             <asp:Label ID="L_RequestedCurrencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestedCurrencyID") %>' Text='<%# Eval("TA_Currencies10_CurrencyName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="TA_TravelRequestStatus12_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("TA_TravelRequestStatus12_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Budget">
          <ItemTemplate>
            <asp:ImageButton ID="cmdBudget" runat="server" AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="Check Project Budget" SkinID="info" CommandName="BudgetWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FWD">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStarTravelRequest"
      runat = "server"
      DataObjectTypeName = "SIS.TAR.tarTravelRequest"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tarTravelRequestSelectList"
      TypeName = "SIS.TAR.tarTravelRequest"
      SelectCountMethod = "tarTravelRequestSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtarTravelRequest" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
