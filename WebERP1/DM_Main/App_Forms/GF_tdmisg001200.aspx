<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tdmisg001200.aspx.vb" Inherits="GF_tdmisg001200" title="Maintain List: Document Master" %>
<asp:Content ID="CPHtdmisg001200" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLtdmisg001200" runat="server">
  <ContentTemplate>
    <asp:Label ID="Labeltdmisg001200" runat="server" Text="&nbsp;List: Document Master" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtdmisg001200"
      ToolType = "lgNMGrid"
      EditUrl = "~/DM_Main/App_Edit/EF_tdmisg001200.aspx"
      AddUrl = "~/DM_Main/App_Create/AF_tdmisg001200.aspx"
      ValidationGroup = "tdmisg001200"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStdmisg001200" runat="server" AssociatedUpdatePanelID="UPNLtdmisg001200" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtdmisg001200" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODStdmisg001200" DataKeyNames="t_docn,t_revn">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_docn" SortExpression="t_docn">
          <ItemTemplate>
            <asp:Label ID="Labelt_docn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_docn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_revn" SortExpression="t_revn">
          <ItemTemplate>
            <asp:Label ID="Labelt_revn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_revn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_dttl" SortExpression="t_dttl">
          <ItemTemplate>
            <asp:Label ID="Labelt_dttl" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_dttl") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_cspa" SortExpression="t_cspa">
          <ItemTemplate>
            <asp:Label ID="Labelt_cspa" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_cspa") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_wght" SortExpression="t_wght">
          <ItemTemplate>
            <asp:Label ID="Labelt_wght" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_wght") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_cprj" SortExpression="t_cprj">
          <ItemTemplate>
            <asp:Label ID="Labelt_cprj" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_cprj") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStdmisg001200"
      runat = "server"
      DataObjectTypeName = "SIS.DM.tdmisg001200"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tdmisg001200SelectList"
      TypeName = "SIS.DM.tdmisg001200"
      SelectCountMethod = "tdmisg001200SelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtdmisg001200" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
