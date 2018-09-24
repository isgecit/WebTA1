<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogChargeCategories.aspx.vb" Inherits="AF_elogChargeCategories" title="Add: ELOG_ChargeCategories" %>
<asp:Content ID="CPHelogChargeCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogChargeCategories" runat="server" Text="&nbsp;Add: ELOG_ChargeCategories"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeCategories" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogChargeCategories"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/ELOG_Main/App_Edit/EF_elogChargeCategories.aspx"
    ValidationGroup = "elogChargeCategories"
    runat = "server" />
<asp:FormView ID="FVelogChargeCategories"
  runat = "server"
  DataKeyNames = "ChargeCategoryID"
  DataSourceID = "ODSelogChargeCategories"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogChargeCategories" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ChargeCategoryID" ForeColor="#CC6633" runat="server" Text="Charge Category ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ChargeCategoryID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ShipmentModeID" runat="server" Text="Shipment Mode ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_elogShipmentModes
            ID="F_ShipmentModeID"
            SelectedValue='<%# Bind("ShipmentModeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_LocationCountryID" runat="server" Text="Location Country ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_elogLocationCountries
            ID="F_LocationCountryID"
            SelectedValue='<%# Bind("LocationCountryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CargoTypeID" runat="server" Text="Cargo Type ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_elogCargoTypes
            ID="F_CargoTypeID"
            SelectedValue='<%# Bind("CargoTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StuffingTypeID" runat="server" Text="Stuffing Type ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_elogStuffingTypes
            ID="F_StuffingTypeID"
            SelectedValue='<%# Bind("StuffingTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StuffingPointID" runat="server" Text="Stuffing Point ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_elogStuffingPoints
            ID="F_StuffingPointID"
            SelectedValue='<%# Bind("StuffingPointID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BreakbulkTypeID" runat="server" Text="Breakbulk Type ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_elogBreakbulkTypes
            ID="F_BreakbulkTypeID"
            SelectedValue='<%# Bind("BreakbulkTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ChargeTypeID" runat="server" Text="Charge Type ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_elogChargeTypes
            ID="F_ChargeTypeID"
            SelectedValue='<%# Bind("ChargeTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogChargeCategories"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogChargeCategories"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogChargeCategories"
  DataObjectTypeName = "SIS.ELOG.elogChargeCategories"
  InsertMethod="elogChargeCategoriesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogChargeCategories"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
