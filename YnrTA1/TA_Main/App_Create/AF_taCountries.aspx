<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taCountries.aspx.vb" Inherits="AF_taCountries" title="Add: Countries" %>
<asp:Content ID="CPHtaCountries" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCountries" runat="server" Text="&nbsp;Add: Countries"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCountries" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCountries"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taCountries"
    runat = "server" />
<asp:FormView ID="FVtaCountries"
  runat = "server"
  DataKeyNames = "CountryID"
  DataSourceID = "ODStaCountries"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaCountries" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CountryID" ForeColor="#CC6633" runat="server" Text="Country ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CountryID"
            Text='<%# Bind("CountryID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="taCountries"
            onblur= "script_taCountries.validate_CountryID(this);"
            ToolTip="Enter value for Country ID."
            MaxLength="30"
            Width="210px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCountryID"
            runat = "server"
            ControlToValidate = "F_CountryID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCountries"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CountryName" runat="server" Text="Country Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CountryName"
            Text='<%# Bind("CountryName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCountries"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Country Name."
            MaxLength="50"
            Width="350px"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ContingencyAmount" runat="server" Text="Contingency Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ContingencyAmount"
            Text='<%# Bind("ContingencyAmount") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            ValidationGroup="taCountries"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEContingencyAmount"
            runat = "server"
            mask = "99999999"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCountries"
  DataObjectTypeName = "SIS.TA.taCountries"
  InsertMethod="UZ_taCountriesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCountries"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
