<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogChargeCategories.aspx.vb" Inherits="EF_elogChargeCategories" title="Edit: ELOG_ChargeCategories" %>
<asp:Content ID="CPHelogChargeCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogChargeCategories" runat="server" Text="&nbsp;Edit: ELOG_ChargeCategories"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeCategories" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogChargeCategories"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogChargeCategories"
    runat = "server" />
<asp:FormView ID="FVelogChargeCategories"
  runat = "server"
  DataKeyNames = "ChargeCategoryID"
  DataSourceID = "ODSelogChargeCategories"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ChargeCategoryID" runat="server" ForeColor="#CC6633" Text="Charge Category ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ChargeCategoryID"
            Text='<%# Bind("ChargeCategoryID") %>'
            ToolTip="Value of Charge Category ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogChargeCategories"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelelogChargeCodes" runat="server" Text="&nbsp;List: ELOG_ChargeCodes"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeCodes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogChargeCodes"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogChargeCodes.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogChargeCodes.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "elogChargeCodes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogChargeCodes" runat="server" AssociatedUpdatePanelID="UPNLelogChargeCodes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogChargeCodes" SkinID="gv_silver" runat="server" DataSourceID="ODSelogChargeCodes" DataKeyNames="ChargeCategoryID,ChargeCodeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Category ID" SortExpression="ELOG_ChargeCategories1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ChargeCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ChargeCategoryID") %>' Text='<%# Eval("ELOG_ChargeCategories1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Code ID" SortExpression="ChargeCodeID">
          <ItemTemplate>
            <asp:Label ID="LabelChargeCodeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ChargeCodeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
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
      ID = "ODSelogChargeCodes"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogChargeCodes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_elogChargeCodesSelectList"
      TypeName = "SIS.ELOG.elogChargeCodes"
      SelectCountMethod = "elogChargeCodesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ChargeCategoryID" PropertyName="Text" Name="ChargeCategoryID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVelogChargeCodes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogChargeCategories"
  DataObjectTypeName = "SIS.ELOG.elogChargeCategories"
  SelectMethod = "elogChargeCategoriesGetByID"
  UpdateMethod="elogChargeCategoriesUpdate"
  DeleteMethod="elogChargeCategoriesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogChargeCategories"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ChargeCategoryID" Name="ChargeCategoryID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
