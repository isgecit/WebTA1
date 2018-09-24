<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taD_GuestHouseDA.aspx.vb" Inherits="GF_taD_GuestHouseDA" title="Maintain List: Category-City Wise DA- Guest House Stay" %>
<asp:Content ID="CPHtaD_GuestHouseDA" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaD_GuestHouseDA" runat="server" Text="&nbsp;List: Category-City Wise DA- Guest House Stay"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaD_GuestHouseDA" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaD_GuestHouseDA"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taD_GuestHouseDA.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taD_GuestHouseDA.aspx"
      ValidationGroup = "taD_GuestHouseDA"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaD_GuestHouseDA" runat="server" AssociatedUpdatePanelID="UPNLtaD_GuestHouseDA" DisplayAfter="100">
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
          <b><asp:Label ID="L_CityID" runat="server" Text="City ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CityID"
            CssClass = "myfktxt"
            Width="210px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CityID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CityID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECityID"
            BehaviorID="B_ACECityID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CityIDCompletionList"
            TargetControlID="F_CityID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECityID_Selected"
            OnClientPopulating="ACECityID_Populating"
            OnClientPopulated="ACECityID_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtaD_GuestHouseDA" SkinID="gv_silver" runat="server" DataSourceID="ODStaD_GuestHouseDA" DataKeyNames="SerialNo">
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
        <asp:TemplateField HeaderText="City ID" SortExpression="TA_Cities2_CityName">
          <ItemTemplate>
             <asp:Label ID="L_CityID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CityID") %>' Text='<%# Eval("TA_Cities2_CityName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Other City" SortExpression="OtherCity">
          <ItemTemplate>
            <asp:Label ID="LabelOtherCity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OtherCity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DA" SortExpression="DA">
          <ItemTemplate>
            <asp:Label ID="LabelDA" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DA") %>'></asp:Label>
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
      ID = "ODStaD_GuestHouseDA"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taD_GuestHouseDA"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taD_GuestHouseDASelectList"
      TypeName = "SIS.TA.taD_GuestHouseDA"
      SelectCountMethod = "taD_GuestHouseDASelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CategoryID" PropertyName="SelectedValue" Name="CategoryID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CityID" PropertyName="Text" Name="CityID" Type="String" Size="30" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaD_GuestHouseDA" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CategoryID" />
    <asp:AsyncPostBackTrigger ControlID="F_CityID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
