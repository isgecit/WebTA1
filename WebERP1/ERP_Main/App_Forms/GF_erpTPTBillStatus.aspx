<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_erpTPTBillStatus.aspx.vb" Inherits="GF_erpTPTBillStatus" title="Maintain List: TPT. Bill Status" %>
<asp:Content ID="CPHerpTPTBillStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpTPTBillStatus" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelerpTPTBillStatus" runat="server" Text="&nbsp;List: TPT. Bill Status" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLerpTPTBillStatus"
      ToolType = "lgNMGrid"
      EditUrl = "~/ERP_Main/App_Edit/EF_erpTPTBillStatus.aspx"
      AddUrl = "~/ERP_Main/App_Create/AF_erpTPTBillStatus.aspx"
      ValidationGroup = "erpTPTBillStatus"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSerpTPTBillStatus" runat="server" AssociatedUpdatePanelID="UPNLerpTPTBillStatus" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVerpTPTBillStatus" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSerpTPTBillStatus" DataKeyNames="BillStatusID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Status ID" SortExpression="BillStatusID">
          <ItemTemplate>
            <asp:Label ID="LabelBillStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillStatusID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSerpTPTBillStatus"
      runat = "server"
      DataObjectTypeName = "SIS.ERP.erpTPTBillStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "erpTPTBillStatusSelectList"
      TypeName = "SIS.ERP.erpTPTBillStatus"
      SelectCountMethod = "erpTPTBillStatusSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVerpTPTBillStatus" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
