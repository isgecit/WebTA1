<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSiteItemMasterLocation.aspx.vb" Inherits="AF_pakSiteItemMasterLocation" title="Add: Site Item Master Location" %>
<asp:Content ID="CPHpakSiteItemMasterLocation" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSiteItemMasterLocation" runat="server" Text="&nbsp;Add: Site Item Master Location"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteItemMasterLocation" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSiteItemMasterLocation"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakSiteItemMasterLocation"
    runat = "server" />
<asp:FormView ID="FVpakSiteItemMasterLocation"
  runat = "server"
  DataKeyNames = "ProjectID,SiteMarkNo,LocationID"
  DataSourceID = "ODSpakSiteItemMasterLocation"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSiteItemMasterLocation" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "pakSiteItemMasterLocation"
            onblur= "script_pakSiteItemMasterLocation.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteItemMasterLocation"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSiteItemMasterLocation.ACEProjectID_Selected"
            OnClientPopulating="script_pakSiteItemMasterLocation.ACEProjectID_Populating"
            OnClientPopulated="script_pakSiteItemMasterLocation.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SiteMarkNo" ForeColor="#CC6633" runat="server" Text="SiteMarkNo :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SiteMarkNo"
            CssClass = "mypktxt"
            Width="248px"
            Text='<%# Bind("SiteMarkNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for SiteMarkNo."
            ValidationGroup = "pakSiteItemMasterLocation"
            onblur= "script_pakSiteItemMasterLocation.validate_SiteMarkNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSiteMarkNo"
            runat = "server"
            ControlToValidate = "F_SiteMarkNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteItemMasterLocation"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SiteMarkNo_Display"
            Text='<%# Eval("PAK_SiteItemMaster2_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESiteMarkNo"
            BehaviorID="B_ACESiteMarkNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SiteMarkNoCompletionList"
            TargetControlID="F_SiteMarkNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSiteItemMasterLocation.ACESiteMarkNo_Selected"
            OnClientPopulating="script_pakSiteItemMasterLocation.ACESiteMarkNo_Populating"
            OnClientPopulated="script_pakSiteItemMasterLocation.ACESiteMarkNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationID" ForeColor="#CC6633" runat="server" Text="Location :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_pakSiteLocations
            ID="F_LocationID"
            SelectedValue='<%# Bind("LocationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pakSiteItemMasterLocation"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMQuantity" runat="server" Text="UOM Quantity :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_pakUnits
            ID="F_UOMQuantity"
            SelectedValue='<%# Bind("UOMQuantity") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pakSiteItemMasterLocation"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="pakSiteItemMasterLocation"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEQuantity"
            runat = "server"
            mask = "99999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Quantity" />
          <AJX:MaskedEditValidator 
            ID = "MEVQuantity"
            runat = "server"
            ControlToValidate = "F_Quantity"
            ControlExtender = "MEEQuantity"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteItemMasterLocation"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
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
  ID = "ODSpakSiteItemMasterLocation"
  DataObjectTypeName = "SIS.PAK.pakSiteItemMasterLocation"
  InsertMethod="UZ_pakSiteItemMasterLocationInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSiteItemMasterLocation"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
