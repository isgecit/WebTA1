<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taCities.aspx.vb" Inherits="GF_taCities" title="Maintain List: Cities" %>
<asp:Content ID="CPHtaCities" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaCities" runat="server" Text="&nbsp;List: Cities"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCities" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCities"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCities.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCities.aspx"
      ValidationGroup = "taCities"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCities" runat="server" AssociatedUpdatePanelID="UPNLtaCities" DisplayAfter="100">
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
          <b><asp:Label ID="L_CountryID" runat="server" Text="Country ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CountryID"
            CssClass = "myfktxt"
            Width="210px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CountryID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CountryID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECountryID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CountryIDCompletionList"
            TargetControlID="F_CountryID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECountryID_Selected"
            OnClientPopulating="ACECountryID_Populating"
            OnClientPopulated="ACECountryID_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RegionID" runat="server" Text="Region ID :" /></b>
        </td>
        <td>
          <LGM:LC_taRegions
            ID="F_RegionID"
            SelectedValue=""
            OrderBy="RegionName"
            DataTextField="RegionName"
            DataValueField="RegionID"
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
          <b><asp:Label ID="L_CurrencyID" runat="server" Text="Currency ID :" /></b>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue=""
            OrderBy="CurrencyName"
            DataTextField="CurrencyName"
            DataValueField="CurrencyID"
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
          <b><asp:Label ID="L_RegionTypeID" runat="server" Text="Region Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_taRegionTypes
            ID="F_RegionTypeID"
            SelectedValue=""
            OrderBy="RegionTypeName"
            DataTextField="RegionTypeName"
            DataValueField="RegionTypeID"
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
    <asp:GridView ID="GVtaCities" SkinID="gv_silver" runat="server" DataSourceID="ODStaCities" DataKeyNames="CityID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Button ID="cmdedit" runat="server" CommandName="edit" Text="Edit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <EditItemTemplate></EditItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City ID" SortExpression="CityID">
          <ItemTemplate>
            <asp:Label ID="LabelCityID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CityID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
          <EditItemTemplate>

          </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City Name" SortExpression="CityName">
          <ItemTemplate>
            <asp:Label ID="LabelCityName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CityName") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate></EditItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City Type For DA Entitlement" SortExpression="TA_CityTypes1_CityTypeName">
          <ItemTemplate>
             <asp:Label ID="L_CityTypeForDA" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CityTypeForDA") %>' Text='<%# Eval("TA_CityTypes1_CityTypeName") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate></EditItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City Type For Hotel Entitlement" SortExpression="TA_CityTypes2_CityTypeName">
          <ItemTemplate>
             <asp:Label ID="L_CityTypeForHotel" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CityTypeForHotel") %>' Text='<%# Eval("TA_CityTypes2_CityTypeName") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate></EditItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Country ID" SortExpression="TA_Countries3_CountryName">
          <ItemTemplate>
             <asp:Label ID="L_CountryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CountryID") %>' Text='<%# Eval("TA_Countries3_CountryName") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate></EditItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region ID" SortExpression="TA_Regions5_RegionName">
          <ItemTemplate>
             <asp:Label ID="L_RegionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RegionID") %>' Text='<%# Eval("TA_Regions5_RegionName") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate></EditItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency ID" SortExpression="TA_Currencies4_CurrencyName">
          <ItemTemplate>
             <asp:Label ID="L_CurrencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CurrencyID") %>' Text='<%# Eval("TA_Currencies4_CurrencyName") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate></EditItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Region Type ID" SortExpression="TA_RegionTypes6_RegionTypeName">
          <ItemTemplate>
             <asp:Label ID="L_RegionTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RegionTypeID") %>' Text='<%# Eval("TA_RegionTypes6_RegionTypeName") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate></EditItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="D">
          <ItemTemplate>

          </ItemTemplate>
          <headerstyle Width="10px" />
          <EditItemTemplate>
            </td>
            </tr>
            <tr>
              <td colspan="10" style="text-align:center; background-color:aquamarine">
                <asp:Label ID="LabelCityID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CityID") %>'></asp:Label>
                Hellow I am Here
<%--<asp:FormView ID="FVtaCities"
  runat = "server"
  DataKeyNames = "CityID"
  DataSourceID = "ODStaCities"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>--%>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CityID" runat="server" ForeColor="#CC6633" Text="City ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CityID"
            Text='<%# Bind("CityID") %>'
            ToolTip="Value of City ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="210px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CityName" runat="server" Text="City Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CityName"
            Text='<%# Bind("CityName") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCities"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City Name."
            MaxLength="80"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CountryID" runat="server" Text="Country ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CountryID"
            CssClass = "myfktxt"
            Text='<%# Bind("CountryID") %>'
            AutoCompleteType = "None"
            Width="210px"
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
            ValidationGroup = "taCities"
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
            ValidationGroup = "taCities"
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
            ValidationGroup = "taCities"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="2">
          <asp:Button ID="cmdSave" runat="server" Text="Save" ValidationGroup="taCities" CommandName="update" />
        </td>
        <td colspan="2">
          <asp:Button ID="cmdCancel" runat="server" Text="Cancel" CommandName="cancel" />
        </td>
      </tr>
    </table>
  </div>
<%--  </EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ODStaCities"
  DataObjectTypeName = "SIS.TA.taCities"
  SelectMethod = "taCitiesGetByID"
  UpdateMethod="UZ_taCitiesUpdate"
  DeleteMethod="taCitiesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCities"
  runat = "server" >
<SelectParameters>
  <asp:ControlParameter ControlID="LabelCityID" Name="CityID" PropertyName="Text" />
</SelectParameters>
</asp:ObjectDataSource>--%>
              </td>
            </tr>
          </EditItemTemplate>
          <FooterTemplate>
                        </td>
            </tr>
            <tr>
              <td colspan="10" style="text-align:center; background-color:aquamarine">
              </td>
            </tr>
          </FooterTemplate>
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCities"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCities"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taCitiesSelectList"
      UpdateMethod="UZ_taCitiesUpdate"
      TypeName = "SIS.TA.taCities"
      SelectCountMethod = "taCitiesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CountryID" PropertyName="Text" Name="CountryID" Type="String" Size="30" />
        <asp:ControlParameter ControlID="F_RegionID" PropertyName="SelectedValue" Name="RegionID" Type="String" Size="10" />
        <asp:ControlParameter ControlID="F_CurrencyID" PropertyName="SelectedValue" Name="CurrencyID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_RegionTypeID" PropertyName="SelectedValue" Name="RegionTypeID" Type="String" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCities" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CountryID" />
    <asp:AsyncPostBackTrigger ControlID="F_RegionID" />
    <asp:AsyncPostBackTrigger ControlID="F_CurrencyID" />
    <asp:AsyncPostBackTrigger ControlID="F_RegionTypeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
