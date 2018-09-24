<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taF_ForeignTravel.aspx.vb" Inherits="GF_taF_ForeignTravel" title="Maintain List: Foreign Travel DA" %>
<asp:Content ID="CPHtaF_ForeignTravel" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaF_ForeignTravel" runat="server" Text="&nbsp;List: Foreign Travel DA"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaF_ForeignTravel" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaF_ForeignTravel"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taF_ForeignTravel.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taF_ForeignTravel.aspx"
      ValidationGroup = "taF_ForeignTravel"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaF_ForeignTravel" runat="server" AssociatedUpdatePanelID="UPNLtaF_ForeignTravel" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaF_ForeignTravel" SkinID="gv_silver" runat="server" DataSourceID="ODStaF_ForeignTravel" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="S.N." SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DA Percent [Boarding and Lodging provided]" SortExpression="Bord_Lodg_DA_Percent">
          <ItemTemplate>
            <asp:Label ID="LabelBord_Lodg_DA_Percent" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Bord_Lodg_DA_Percent") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DA Percent [Lodging Provided]" SortExpression="Lodg_DA_Percent">
          <ItemTemplate>
            <asp:Label ID="LabelLodg_DA_Percent" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Lodg_DA_Percent") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DA Percent [Adjested with Local Conveyance]" SortExpression="DA_Adjested_LC_Percent">
          <ItemTemplate>
            <asp:Label ID="LabelDA_Adjested_LC_Percent" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DA_Adjested_LC_Percent") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Date" SortExpression="FromDate">
          <ItemTemplate>
            <asp:Label ID="LabelFromDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FromDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Till Date" SortExpression="TillDate">
          <ItemTemplate>
            <asp:Label ID="LabelTillDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TillDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="Active">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaF_ForeignTravel"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taF_ForeignTravel"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taF_ForeignTravelSelectList"
      TypeName = "SIS.TA.taF_ForeignTravel"
      SelectCountMethod = "taF_ForeignTravelSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaF_ForeignTravel" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
