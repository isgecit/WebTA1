<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taD_SwrDA.aspx.vb" Inherits="GF_taD_SwrDA" title="Maintain List: Category-City Type Wise DA- Hotel Stay OR Swr" %>
<asp:Content ID="CPHtaD_SwrDA" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaD_SwrDA" runat="server" Text="&nbsp;List: Category-City Type Wise DA- Hotel Stay OR Swr"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaD_SwrDA" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaD_SwrDA"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taD_SwrDA.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taD_SwrDA.aspx"
      ValidationGroup = "taD_SwrDA"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaD_SwrDA" runat="server" AssociatedUpdatePanelID="UPNLtaD_SwrDA" DisplayAfter="100">
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
          <b><asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" /></b>
        </td>
        <td>
          <LGM:LC_taCategories
            ID="F_CategoryID"
            SelectedValue=""
            OrderBy="cmba"
            DataTextField="cmba"
            DataValueField="CategoryID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CityTypeID" runat="server" Text="City Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_taCityTypes
            ID="F_CityTypeID"
            SelectedValue=""
            OrderBy="CityTypeName"
            DataTextField="CityTypeName"
            DataValueField="CityTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtaD_SwrDA" SkinID="gv_silver" runat="server" DataSourceID="ODStaD_SwrDA" DataKeyNames="SerialNo">
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
        <asp:TemplateField HeaderText="Category ID" SortExpression="TA_Categories1_cmba">
          <ItemTemplate>
             <asp:Label ID="L_CategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategoryID") %>' Text='<%# Eval("TA_Categories1_cmba") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City Type ID" SortExpression="TA_CityTypes2_CityTypeName">
          <ItemTemplate>
             <asp:Label ID="L_CityTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CityTypeID") %>' Text='<%# Eval("TA_CityTypes2_CityTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DA [Stayed in Hotel]" SortExpression="HotelStayDA">
          <ItemTemplate>
            <asp:Label ID="LabelHotelStayDA" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("HotelStayDA") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DA [Stayed with Relative]" SortExpression="SwrDA">
          <ItemTemplate>
            <asp:Label ID="LabelSwrDA" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SwrDA") %>'></asp:Label>
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
      ID = "ODStaD_SwrDA"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taD_SwrDA"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taD_SwrDASelectList"
      TypeName = "SIS.TA.taD_SwrDA"
      SelectCountMethod = "taD_SwrDASelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CategoryID" PropertyName="SelectedValue" Name="CategoryID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CityTypeID" PropertyName="SelectedValue" Name="CityTypeID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaD_SwrDA" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CategoryID" />
    <asp:AsyncPostBackTrigger ControlID="F_CityTypeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
