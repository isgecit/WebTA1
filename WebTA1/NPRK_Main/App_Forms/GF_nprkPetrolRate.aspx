<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkPetrolRate.aspx.vb" Inherits="GF_nprkPetrolRate" title="Maintain List: Petrol Rates" %>
<asp:Content ID="CPHnprkPetrolRate" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkPetrolRate" runat="server" Text="&nbsp;List: Petrol Rates"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkPetrolRate" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkPetrolRate"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkPetrolRate.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkPetrolRate.aspx"
      ValidationGroup = "nprkPetrolRate"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkPetrolRate" runat="server" AssociatedUpdatePanelID="UPNLnprkPetrolRate" DisplayAfter="100">
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
          <b><asp:Label ID="L_FinYear" runat="server" Text="Fin. Year :" /></b>
        </td>
        <td>
          <LGM:LC_nprkFinYears
            ID="F_FinYear"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="FinYear"
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
          <b><asp:Label ID="L_MonthID" runat="server" Text="Month ID :" /></b>
        </td>
        <td>
          <LGM:LC_nprkMonths
            ID="F_MonthID"
            SelectedValue=""
            OrderBy="MonthName"
            DataTextField="MonthName"
            DataValueField="MonthID"
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
          <b><asp:Label ID="L_LocationID" runat="server" Text="Location ID :" /></b>
        </td>
        <td>
          <LGM:LC_hrmLocations
            ID="F_LocationID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="LocationID"
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
    <asp:GridView ID="GVnprkPetrolRate" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkPetrolRate" DataKeyNames="FinYear,MonthID,LocationID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fin. Year" SortExpression="PRK_FinYears2_Description">
          <ItemTemplate>
             <asp:Label ID="L_FinYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FinYear") %>' Text='<%# Eval("PRK_FinYears2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Month ID" SortExpression="PRK_Months3_MonthName">
          <ItemTemplate>
             <asp:Label ID="L_MonthID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("MonthID") %>' Text='<%# Eval("PRK_Months3_MonthName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location ID" SortExpression="HRM_Locations1_Description">
          <ItemTemplate>
             <asp:Label ID="L_LocationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("LocationID") %>' Text='<%# Eval("HRM_Locations1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Petrol Rate" SortExpression="PetrolRate">
          <ItemTemplate>
            <asp:Label ID="LabelPetrolRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PetrolRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkPetrolRate"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkPetrolRate"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "nprkPetrolRateSelectList"
      TypeName = "SIS.NPRK.nprkPetrolRate"
      SelectCountMethod = "nprkPetrolRateSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="SelectedValue" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_MonthID" PropertyName="SelectedValue" Name="MonthID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_LocationID" PropertyName="SelectedValue" Name="LocationID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkPetrolRate" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_FinYear" />
    <asp:AsyncPostBackTrigger ControlID="F_MonthID" />
    <asp:AsyncPostBackTrigger ControlID="F_LocationID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
