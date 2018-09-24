<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_eitlProjects.aspx.vb" Inherits="GF_eitlProjects" title="Maintain List: Projects" %>
<asp:Content ID="CPHeitlProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeleitlProjects" runat="server" Text="&nbsp;List: Projects"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlProjects" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlProjects"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlProjects.aspx"
      AddUrl = "~/EITL_Main/App_Create/AF_eitlProjects.aspx"
      ValidationGroup = "eitlProjects"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlProjects" runat="server" AssociatedUpdatePanelID="UPNLeitlProjects" DisplayAfter="100">
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
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVeitlProjects" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlProjects" DataKeyNames="ProjectID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="ProjectID">
          <ItemTemplate>
            <asp:Label ID="LabelProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Business Partner ID" SortExpression="EITL_Suppliers1_SupplierName">
          <ItemTemplate>
             <asp:Label ID="L_BusinessPartnerID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BusinessPartnerID") %>' Text='<%# Eval("EITL_Suppliers1_SupplierName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSeitlProjects"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlProjects"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "eitlProjectsSelectList"
      TypeName = "SIS.EITL.eitlProjects"
      SelectCountMethod = "eitlProjectsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVeitlProjects" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
