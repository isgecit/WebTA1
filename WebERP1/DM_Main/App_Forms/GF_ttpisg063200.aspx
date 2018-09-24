<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_ttpisg063200.aspx.vb" Inherits="GF_ttpisg063200" title="Maintain List: Element Status" %>
<asp:Content ID="CPHttpisg063200" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLttpisg063200" runat="server">
  <ContentTemplate>
    <asp:Label ID="Labelttpisg063200" runat="server" Text="&nbsp;List: Element Status" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLttpisg063200"
      ToolType = "lgNMGrid"
      EditUrl = "~/DM_Main/App_Edit/EF_ttpisg063200.aspx"
      AddUrl = "~/DM_Main/App_Create/AF_ttpisg063200.aspx"
      ValidationGroup = "ttpisg063200"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSttpisg063200" runat="server" AssociatedUpdatePanelID="UPNLttpisg063200" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVttpisg063200" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSttpisg063200" DataKeyNames="t_cprj,t_cspa">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_cprj" SortExpression="t_cprj">
          <ItemTemplate>
            <asp:Label ID="Labelt_cprj" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_cprj") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_cspa" SortExpression="t_cspa">
          <ItemTemplate>
            <asp:Label ID="Labelt_cspa" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_cspa") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_appl" SortExpression="t_appl">
          <ItemTemplate>
            <asp:Label ID="Labelt_appl" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_appl") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_engs" SortExpression="t_engs">
          <ItemTemplate>
            <asp:Label ID="Labelt_engs" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_engs") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_Refcntd" SortExpression="t_Refcntd">
          <ItemTemplate>
            <asp:Label ID="Labelt_Refcntd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_Refcntd") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_Refcntu" SortExpression="t_Refcntu">
          <ItemTemplate>
            <asp:Label ID="Labelt_Refcntu" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_Refcntu") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSttpisg063200"
      runat = "server"
      DataObjectTypeName = "SIS.DM.ttpisg063200"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_ttpisg063200SelectList"
      TypeName = "SIS.DM.ttpisg063200"
      SelectCountMethod = "ttpisg063200SelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVttpisg063200" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
