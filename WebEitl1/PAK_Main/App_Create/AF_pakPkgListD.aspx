<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakPkgListD.aspx.vb" Inherits="AF_pakPkgListD" title="Add: Packing List Items" %>
<asp:Content ID="CPHpakPkgListD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakPkgListD" runat="server" Text="&nbsp;Add: Packing List Items"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakPkgListD" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakPkgListD"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakPkgListD"
    runat = "server" />
<asp:FormView ID="FVpakPkgListD"
  runat = "server"
  DataKeyNames = "SerialNo,PkgNo,BOMNo,ItemNo"
  DataSourceID = "ODSpakPkgListD"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakPkgListD" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            ValidationGroup = "pakPkgListD"
            onblur= "script_pakPkgListD.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakPkgListD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO3_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakPkgListD.ACESerialNo_Selected"
            OnClientPopulating="script_pakPkgListD.ACESerialNo_Populating"
            OnClientPopulated="script_pakPkgListD.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_PkgNo" ForeColor="#CC6633" runat="server" Text="Pkg No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_PkgNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("PkgNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Pkg No."
            ValidationGroup = "pakPkgListD"
            onblur= "script_pakPkgListD.validate_PkgNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPkgNo"
            runat = "server"
            ControlToValidate = "F_PkgNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakPkgListD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_PkgNo_Display"
            Text='<%# Eval("PAK_PkgListH2_SupplierRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEPkgNo"
            BehaviorID="B_ACEPkgNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="PkgNoCompletionList"
            TargetControlID="F_PkgNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakPkgListD.ACEPkgNo_Selected"
            OnClientPopulating="script_pakPkgListD.ACEPkgNo_Populating"
            OnClientPopulated="script_pakPkgListD.ACEPkgNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BOMNo" ForeColor="#CC6633" runat="server" Text="BOM No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BOMNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for BOM No."
            ValidationGroup = "pakPkgListD"
            onblur= "script_pakPkgListD.validate_BOMNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBOMNo"
            runat = "server"
            ControlToValidate = "F_BOMNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakPkgListD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_POBOM5_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBOMNo"
            BehaviorID="B_ACEBOMNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BOMNoCompletionList"
            TargetControlID="F_BOMNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakPkgListD.ACEBOMNo_Selected"
            OnClientPopulating="script_pakPkgListD.ACEBOMNo_Populating"
            OnClientPopulated="script_pakPkgListD.ACEBOMNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" ForeColor="#CC6633" runat="server" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item No."
            ValidationGroup = "pakPkgListD"
            onblur= "script_pakPkgListD.validate_ItemNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemNo"
            runat = "server"
            ControlToValidate = "F_ItemNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakPkgListD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_POBItems4_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEItemNo"
            BehaviorID="B_ACEItemNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ItemNoCompletionList"
            TargetControlID="F_ItemNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakPkgListD.ACEItemNo_Selected"
            OnClientPopulating="script_pakPkgListD.ACEItemNo_Populating"
            OnClientPopulated="script_pakPkgListD.ACEItemNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMQuantity" runat="server" Text="UOM Quantity :" />&nbsp;
        </td>
        <td>
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
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
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
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMWeight" runat="server" Text="UOM Weight :" />&nbsp;
        </td>
        <td>
          <LGM:LC_pakUnits
            ID="F_UOMWeight"
            SelectedValue='<%# Bind("UOMWeight") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_WeightPerUnit" runat="server" Text="Weight Per Unit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WeightPerUnit"
            Text='<%# Bind("WeightPerUnit") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEWeightPerUnit"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_WeightPerUnit" />
          <AJX:MaskedEditValidator 
            ID = "MEVWeightPerUnit"
            runat = "server"
            ControlToValidate = "F_WeightPerUnit"
            ControlExtender = "MEEWeightPerUnit"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackTypeID" runat="server" Text="Pack Type :" />&nbsp;
        </td>
        <td>
          <LGM:LC_pakPakTypes
            ID="F_PackTypeID"
            SelectedValue='<%# Bind("PackTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_PackingMark" runat="server" Text="Packing Mark :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackingMark"
            Text='<%# Bind("PackingMark") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Packing Mark."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackLength" runat="server" Text="Pack Length :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackLength"
            Text='<%# Bind("PackLength") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPackLength"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PackLength" />
          <AJX:MaskedEditValidator 
            ID = "MEVPackLength"
            runat = "server"
            ControlToValidate = "F_PackLength"
            ControlExtender = "MEEPackLength"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PackWidth" runat="server" Text="Pack Width :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackWidth"
            Text='<%# Bind("PackWidth") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPackWidth"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PackWidth" />
          <AJX:MaskedEditValidator 
            ID = "MEVPackWidth"
            runat = "server"
            ControlToValidate = "F_PackWidth"
            ControlExtender = "MEEPackWidth"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackHeight" runat="server" Text="Pack Height :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackHeight"
            Text='<%# Bind("PackHeight") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPackHeight"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PackHeight" />
          <AJX:MaskedEditValidator 
            ID = "MEVPackHeight"
            runat = "server"
            ControlToValidate = "F_PackHeight"
            ControlExtender = "MEEPackHeight"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_UOMPack" runat="server" Text="UOM Pack :" />&nbsp;
        </td>
        <td>
          <LGM:LC_pakUnits
            ID="F_UOMPack"
            SelectedValue='<%# Bind("UOMPack") %>'
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
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
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
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakPkgListD"
  DataObjectTypeName = "SIS.PAK.pakPkgListD"
  InsertMethod="UZ_pakPkgListDInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakPkgListD"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
