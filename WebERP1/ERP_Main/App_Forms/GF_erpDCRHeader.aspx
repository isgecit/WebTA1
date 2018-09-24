<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_erpDCRHeader.aspx.vb" Inherits="GF_erpDCRHeader" title="Maintain List: DCR Header" %>
<asp:Content ID="CPHerpDCRHeader" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpDCRHeader" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelerpDCRHeader" runat="server" Text="&nbsp;List: DCR Header" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLerpDCRHeader"
      ToolType = "lgNMGrid"
      EditUrl = "~/ERP_Main/App_Edit/EF_erpDCRHeader.aspx"
      AddUrl = "~/ERP_Main/App_Create/AF_erpDCRHeader.aspx"
      ValidationGroup = "erpDCRHeader"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSerpDCRHeader" runat="server" AssociatedUpdatePanelID="UPNLerpDCRHeader" DisplayAfter="100">
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
    <asp:GridView ID="GVerpDCRHeader" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSerpDCRHeader" DataKeyNames="DCRNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCRNo" SortExpression="DCRNo">
          <ItemTemplate>
            <asp:Label ID="LabelDCRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCRDate" SortExpression="DCRDate">
          <ItemTemplate>
            <asp:Label ID="LabelDCRDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCRDescription" SortExpression="DCRDescription">
          <ItemTemplate>
            <asp:Label ID="LabelDCRDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DCRDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CreatedBy" SortExpression="CreatedBy">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedBy") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CreatedName" SortExpression="CreatedName">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CreatedEMail" SortExpression="CreatedEMail">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedEMail" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedEMail") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ProjectID" SortExpression="ProjectID">
          <ItemTemplate>
            <asp:Label ID="LabelProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ProjectDescription" SortExpression="ProjectDescription">
          <ItemTemplate>
            <asp:Label ID="LabelProjectDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSerpDCRHeader"
      runat = "server"
      DataObjectTypeName = "SIS.ERP.erpDCRHeader"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "erpDCRHeaderSelectList"
      TypeName = "SIS.ERP.erpDCRHeader"
      SelectCountMethod = "erpDCRHeaderSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVerpDCRHeader" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
