<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_elogChargeCategories.aspx.vb" Inherits="GF_elogChargeCategories" title="Maintain List: ELOG_ChargeCategories" %>
<asp:Content ID="CPHelogChargeCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelelogChargeCategories" runat="server" Text="&nbsp;List: ELOG_ChargeCategories"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeCategories" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogChargeCategories"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogChargeCategories.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogChargeCategories.aspx?skip=1"
      ValidationGroup = "elogChargeCategories"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogChargeCategories" runat="server" AssociatedUpdatePanelID="UPNLelogChargeCategories" DisplayAfter="100">
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
          <b><asp:Label ID="L_ShipmentModeID" runat="server" Text="Shipment Mode ID :" /></b>
        </td>
        <td>
          <LGM:LC_elogShipmentModes
            ID="F_ShipmentModeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="ShipmentModeID"
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
          <b><asp:Label ID="L_LocationCountryID" runat="server" Text="Location Country ID :" /></b>
        </td>
        <td>
          <LGM:LC_elogLocationCountries
            ID="F_LocationCountryID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="LocationCountryID"
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
          <b><asp:Label ID="L_CargoTypeID" runat="server" Text="Cargo Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_elogCargoTypes
            ID="F_CargoTypeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CargoTypeID"
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
          <b><asp:Label ID="L_StuffingTypeID" runat="server" Text="Stuffing Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_elogStuffingTypes
            ID="F_StuffingTypeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="StuffingTypeID"
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
          <b><asp:Label ID="L_StuffingPointID" runat="server" Text="Stuffing Point ID :" /></b>
        </td>
        <td>
          <LGM:LC_elogStuffingPoints
            ID="F_StuffingPointID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="StuffingPointID"
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
          <b><asp:Label ID="L_BreakbulkTypeID" runat="server" Text="Breakbulk Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_elogBreakbulkTypes
            ID="F_BreakbulkTypeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="BreakbulkTypeID"
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
          <b><asp:Label ID="L_ChargeTypeID" runat="server" Text="Charge Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_elogChargeTypes
            ID="F_ChargeTypeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="ChargeTypeID"
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
    <asp:GridView ID="GVelogChargeCategories" SkinID="gv_silver" runat="server" DataSourceID="ODSelogChargeCategories" DataKeyNames="ChargeCategoryID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Category ID" SortExpression="ChargeCategoryID">
          <ItemTemplate>
            <asp:Label ID="LabelChargeCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ChargeCategoryID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Shipment Mode ID" SortExpression="ELOG_ShipmentModes5_Description">
          <ItemTemplate>
             <asp:Label ID="L_ShipmentModeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ShipmentModeID") %>' Text='<%# Eval("ELOG_ShipmentModes5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location Country ID" SortExpression="ELOG_LocationCountries4_Description">
          <ItemTemplate>
             <asp:Label ID="L_LocationCountryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("LocationCountryID") %>' Text='<%# Eval("ELOG_LocationCountries4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cargo Type ID" SortExpression="ELOG_CargoTypes2_Description">
          <ItemTemplate>
             <asp:Label ID="L_CargoTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CargoTypeID") %>' Text='<%# Eval("ELOG_CargoTypes2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stuffing Type ID" SortExpression="ELOG_StuffingTypes7_Description">
          <ItemTemplate>
             <asp:Label ID="L_StuffingTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StuffingTypeID") %>' Text='<%# Eval("ELOG_StuffingTypes7_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stuffing Point ID" SortExpression="ELOG_StuffingPoints6_Description">
          <ItemTemplate>
             <asp:Label ID="L_StuffingPointID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StuffingPointID") %>' Text='<%# Eval("ELOG_StuffingPoints6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Breakbulk Type ID" SortExpression="ELOG_BreakbulkTypes1_Description">
          <ItemTemplate>
             <asp:Label ID="L_BreakbulkTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BreakbulkTypeID") %>' Text='<%# Eval("ELOG_BreakbulkTypes1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Type ID" SortExpression="ELOG_ChargeTypes3_Description">
          <ItemTemplate>
             <asp:Label ID="L_ChargeTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ChargeTypeID") %>' Text='<%# Eval("ELOG_ChargeTypes3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSelogChargeCategories"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogChargeCategories"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_elogChargeCategoriesSelectList"
      TypeName = "SIS.ELOG.elogChargeCategories"
      SelectCountMethod = "elogChargeCategoriesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ShipmentModeID" PropertyName="SelectedValue" Name="ShipmentModeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_LocationCountryID" PropertyName="SelectedValue" Name="LocationCountryID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CargoTypeID" PropertyName="SelectedValue" Name="CargoTypeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_StuffingTypeID" PropertyName="SelectedValue" Name="StuffingTypeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_StuffingPointID" PropertyName="SelectedValue" Name="StuffingPointID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_BreakbulkTypeID" PropertyName="SelectedValue" Name="BreakbulkTypeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ChargeTypeID" PropertyName="SelectedValue" Name="ChargeTypeID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVelogChargeCategories" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ShipmentModeID" />
    <asp:AsyncPostBackTrigger ControlID="F_LocationCountryID" />
    <asp:AsyncPostBackTrigger ControlID="F_CargoTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_StuffingTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_StuffingPointID" />
    <asp:AsyncPostBackTrigger ControlID="F_BreakbulkTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_ChargeTypeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
