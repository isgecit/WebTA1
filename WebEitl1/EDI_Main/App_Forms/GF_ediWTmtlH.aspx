<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_ediWTmtlH.aspx.vb" Inherits="GF_ediWTmtlH" title="Maintain List: Transmittal Header" %>
<asp:Content ID="CPHediWTmtlH" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelediWTmtlH" runat="server" Text="&nbsp;List: Transmittal Header"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLediWTmtlH" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLediWTmtlH"
      ToolType = "lgNMGrid"
      EditUrl = "~/EDI_Main/App_Edit/EF_ediWTmtlH.aspx"
      EnableAdd = "False"
      ValidationGroup = "ediWTmtlH"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSediWTmtlH" runat="server" AssociatedUpdatePanelID="UPNLediWTmtlH" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_tran" runat="server" Text="Transmittal No. :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_t_tran"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="9"
            Width="80px"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
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
    <asp:GridView ID="GVediWTmtlH" SkinID="gv_silver" runat="server" DataSourceID="ODSediWTmtlH" DataKeyNames="t_tran">
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
        <asp:TemplateField HeaderText="Transmittal No." SortExpression="t_tran">
          <ItemTemplate>
            <asp:Label ID="Labelt_tran" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_tran") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reference No." SortExpression="t_refr">
          <ItemTemplate>
            <asp:Label ID="Labelt_refr" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_refr") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tmtl. Type" SortExpression="t_type">
          <ItemTemplate>
            <asp:Label ID="Labelt_type" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_type") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tmtl. Project" SortExpression="t_cprj">
          <ItemTemplate>
            <asp:Label ID="Labelt_cprj" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_cprj") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Issued Via" SortExpression="t_issu">
          <ItemTemplate>
            <asp:Label ID="Labelt_issu" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_issu") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Customer" SortExpression="t_bpid">
          <ItemTemplate>
            <asp:Label ID="Labelt_bpid" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_bpid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vendor" SortExpression="t_ofbp">
          <ItemTemplate>
            <asp:Label ID="Labelt_ofbp" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_ofbp") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee" SortExpression="t_logn">
          <ItemTemplate>
            <asp:Label ID="Labelt_logn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_logn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="t_dprj">
          <ItemTemplate>
            <asp:Label ID="Labelt_dprj" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_dprj") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Issued On" SortExpression="t_isdt">
          <ItemTemplate>
            <asp:Label ID="Labelt_isdt" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_isdt") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSediWTmtlH"
      runat = "server"
      DataObjectTypeName = "SIS.EDI.ediWTmtlH"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_ediWTmtlHSelectList"
      TypeName = "SIS.EDI.ediWTmtlH"
      SelectCountMethod = "ediWTmtlHSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_t_tran" PropertyName="Text" Name="t_tran" Type="String" Size="9" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVediWTmtlH" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_t_tran" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
