<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taCities.aspx.vb" Inherits="AF_taCities" title="Add: Cities" %>
<asp:Content ID="CPHtaCities" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCities" runat="server" Text="&nbsp;Add: Cities"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCities" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCities"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taCities"
    runat = "server" />
<asp:FormView ID="FVtaCities"
  runat = "server"
  DataKeyNames = "CityID"
  DataSourceID = "ODStaCities"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaCities" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CityID" ForeColor="#CC6633" runat="server" Text="City ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CityID"
            Text='<%# Bind("CityID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="taCities"
            onblur= "script_taCities.validate_CityID(this);"
            ToolTip="Enter value for City ID."
            MaxLength="30"
            Width="210px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCityID"
            runat = "server"
            ControlToValidate = "F_CityID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCities"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CityName" runat="server" Text="City Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CityName"
            Text='<%# Bind("CityName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCities"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City Name."
            MaxLength="80"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCityName"
            runat = "server"
            ControlToValidate = "F_CityName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCities"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CityTypeForDA" runat="server" Text="City Type For DA Entitlement :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taCityTypes
            ID="F_CityTypeForDA"
            SelectedValue='<%# Bind("CityTypeForDA") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCities"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CityTypeForHotel" runat="server" Text="City Type For Hotel Entitlement :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taCityTypes
            ID="F_CityTypeForHotel"
            SelectedValue='<%# Bind("CityTypeForHotel") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCities"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CountryID" runat="server" Text="Country ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CountryID"
            CssClass = "myfktxt"
            Width="210px"
            Text='<%# Bind("CountryID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Country ID."
            ValidationGroup = "taCities"
            onblur= "script_taCities.validate_CountryID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CountryID_Display"
            Text='<%# Eval("TA_Countries3_CountryName") %>'
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCountryID"
            runat = "server"
            ControlToValidate = "F_CountryID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCities"
            SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACECountryID"
            BehaviorID="B_ACECountryID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CountryIDCompletionList"
            TargetControlID="F_CountryID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taCities.ACECountryID_Selected"
            OnClientPopulating="script_taCities.ACECountryID_Populating"
            OnClientPopulated="script_taCities.ACECountryID_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
            ValidationGroup = "taCities"
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
            ValidationGroup = "taCities"
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
            ValidationGroup = "taCities"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCities"
  DataObjectTypeName = "SIS.TA.taCities"
  InsertMethod="UZ_taCitiesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCities"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
