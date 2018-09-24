<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_ediWTmtlD.aspx.vb" Inherits="GF_ediWTmtlD" title="Maintain List: Transmittal Detail" %>
<asp:Content ID="CPHediWTmtlD" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelediWTmtlD" runat="server" Text="&nbsp;List: Transmittal Detail"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLediWTmtlD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLediWTmtlD"
      ToolType = "lgNMGrid"
      EditUrl = "~/EDI_Main/App_Edit/EF_ediWTmtlD.aspx"
      EnableAdd = "False"
      ValidationGroup = "ediWTmtlD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSediWTmtlD" runat="server" AssociatedUpdatePanelID="UPNLediWTmtlD" DisplayAfter="100">
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
    <asp:GridView ID="GVediWTmtlD" SkinID="gv_silver" runat="server" DataSourceID="ODSediWTmtlD" DataKeyNames="t_tran,t_docn,t_revn">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document ID" SortExpression="t_docn">
          <ItemTemplate>
            <asp:Label ID="Labelt_docn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_docn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revision No." SortExpression="t_revn">
          <ItemTemplate>
            <asp:Label ID="Labelt_revn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_revn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send Status" SortExpression="t_stid">
          <ItemTemplate>
            <asp:Label ID="Labelt_stid" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_stid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="t_remk">
          <ItemTemplate>
            <asp:Label ID="Labelt_remk" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_remk") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Download">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" ValidationGroup='<%# "Download" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DownloadWFVisible") %>' Enabled='<%# EVal("DownloadWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download" SkinID="Download" OnClientClick='<%# "return Page_ClientValidate(""Download" & Container.DataItemIndex & """) && confirm(""Download record ?"");" %>' CommandName="DownloadWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSediWTmtlD"
      runat = "server"
      DataObjectTypeName = "SIS.EDI.ediWTmtlD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_ediWTmtlDSelectList"
      TypeName = "SIS.EDI.ediWTmtlD"
      SelectCountMethod = "ediWTmtlDSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVediWTmtlD" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_t_tran" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
