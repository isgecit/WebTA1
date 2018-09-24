<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSitePkgDLocation.aspx.vb" Inherits="AF_pakSitePkgDLocation" title="Add: Received Packing List Item Location" %>
<asp:Content ID="CPHpakSitePkgDLocation" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSitePkgDLocation" runat="server" Text="&nbsp;Add: Received Packing List Item Location"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSitePkgDLocation" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSitePkgDLocation"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakSitePkgDLocation"
    runat = "server" />
<asp:FormView ID="FVpakSitePkgDLocation"
  runat = "server"
  DataKeyNames = "ProjectID,RecNo,RecSrNo,RecSrLNo"
  DataSourceID = "ODSpakSitePkgDLocation"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSitePkgDLocation" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "pakSitePkgDLocation"
            onblur= "script_pakSitePkgDLocation.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgDLocation"
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
            OnClientItemSelected="script_pakSitePkgDLocation.ACEProjectID_Selected"
            OnClientPopulating="script_pakSitePkgDLocation.ACEProjectID_Populating"
            OnClientPopulated="script_pakSitePkgDLocation.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_RecNo" ForeColor="#CC6633" runat="server" Text="Receipt No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_RecNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("RecNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Receipt No."
            ValidationGroup = "pakSitePkgDLocation"
            onblur= "script_pakSitePkgDLocation.validate_RecNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRecNo"
            runat = "server"
            ControlToValidate = "F_RecNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgDLocation"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_RecNo_Display"
            Text='<%# Eval("PAK_SitePkgH8_SupplierRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERecNo"
            BehaviorID="B_ACERecNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RecNoCompletionList"
            TargetControlID="F_RecNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgDLocation.ACERecNo_Selected"
            OnClientPopulating="script_pakSitePkgDLocation.ACERecNo_Populating"
            OnClientPopulated="script_pakSitePkgDLocation.ACERecNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecSrNo" ForeColor="#CC6633" runat="server" Text="Receipt Line No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_RecSrNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("RecSrNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Receipt Line No."
            ValidationGroup = "pakSitePkgDLocation"
            onblur= "script_pakSitePkgDLocation.validate_RecSrNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRecSrNo"
            runat = "server"
            ControlToValidate = "F_RecSrNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgDLocation"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_RecSrNo_Display"
            Text='<%# Eval("PAK_SitePkgD7_SiteMarkNo") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERecSrNo"
            BehaviorID="B_ACERecSrNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RecSrNoCompletionList"
            TargetControlID="F_RecSrNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgDLocation.ACERecSrNo_Selected"
            OnClientPopulating="script_pakSitePkgDLocation.ACERecSrNo_Populating"
            OnClientPopulated="script_pakSitePkgDLocation.ACERecSrNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_RecSrLNo" ForeColor="#CC6633" runat="server" Text="Receipt Line Location No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_RecSrLNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            Enabled = "False"
            ToolTip="Value of Serial No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO4_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PkgNo" runat="server" Text="Packing List No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PkgNo"
            Width="88px"
            Text='<%# Bind("PkgNo") %>'
            Enabled = "False"
            ToolTip="Value of Packing List No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PkgNo_Display"
            Text='<%# Eval("PAK_PkgListH3_SupplierRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BOMNo" runat="server" Text="BOM No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BOMNo"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            Enabled = "False"
            ToolTip="Value of BOM No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_PkgListD2_PackingMark") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemNo" runat="server" Text="Item No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemNo"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            Enabled = "False"
            ToolTip="Value of Item No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_PkgListD2_PackingMark") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SiteMarkNo" runat="server" Text="Site Mark No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SiteMarkNo"
            Width="248px"
            Text='<%# Bind("SiteMarkNo") %>'
            Enabled = "False"
            ToolTip="Value of Site Mark No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SiteMarkNo_Display"
            Text='<%# Eval("PAK_SiteItemMaster5_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_LocationID" runat="server" Text="Location :" /><span style="color:red">*</span>
        </td>
        <td>
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
            ValidationGroup = "pakSitePkgDLocation"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMQuantity" runat="server" Text="UOM Quantity :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMQuantity"
            Width="88px"
            Text='<%# Bind("UOMQuantity") %>'
            Enabled = "False"
            ToolTip="Value of UOM Quantity."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMQuantity_Display"
            Text='<%# Eval("PAK_Units9_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="pakSitePkgDLocation"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEQuantity"
            runat = "server"
            mask = "9999999999999999.9999"
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
            ValidationGroup = "pakSitePkgDLocation"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="100"
            Width="350px"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSitePkgDLocation"
  DataObjectTypeName = "SIS.PAK.pakSitePkgDLocation"
  InsertMethod="UZ_pakSitePkgDLocationInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSitePkgDLocation"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
