<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taCountries.aspx.vb" Inherits="EF_taCountries" title="Edit: Countries" %>
<asp:Content ID="CPHtaCountries" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCountries" runat="server" Text="&nbsp;Edit: Countries"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCountries" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCountries"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taCountries"
    runat = "server" />
<asp:FormView ID="FVtaCountries"
  runat = "server"
  DataKeyNames = "CountryID"
  DataSourceID = "ODStaCountries"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CountryID" runat="server" ForeColor="#CC6633" Text="Country ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CountryID"
            Text='<%# Bind("CountryID") %>'
            ToolTip="Value of Country ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="210px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CountryName" runat="server" Text="Country Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CountryName"
            Text='<%# Bind("CountryName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCountries"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Country Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCountryName"
            runat = "server"
            ControlToValidate = "F_CountryName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCountries"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RegionID" runat="server" Text="Region ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taRegions
            ID="F_RegionID"
            SelectedValue='<%# Bind("RegionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCountries"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCountries"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RegionTypeID" runat="server" Text="Region Type ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taRegionTypes
            ID="F_RegionTypeID"
            SelectedValue='<%# Bind("RegionTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCountries"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ContingencyAmount" runat="server" Text="Contingency Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ContingencyAmount"
            Text='<%# Bind("ContingencyAmount") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="taCountries"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEContingencyAmount"
            runat = "server"
            mask = "9999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ContingencyAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVContingencyAmount"
            runat = "server"
            ControlToValidate = "F_ContingencyAmount"
            ControlExtender = "MEEContingencyAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCountries"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCountries"
  DataObjectTypeName = "SIS.TA.taCountries"
  SelectMethod = "taCountriesGetByID"
  UpdateMethod="UZ_taCountriesUpdate"
  DeleteMethod="taCountriesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCountries"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CountryID" Name="CountryID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
