<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSitePkgD.aspx.vb" Inherits="AF_pakSitePkgD" title="Add: Received Packing List Item" %>
<asp:Content ID="CPHpakSitePkgD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSitePkgD" runat="server" Text="&nbsp;Add: Received Packing List Item"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSitePkgD" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSitePkgD"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PAK_Main/App_Edit/EF_pakSitePkgD.aspx"
    ValidationGroup = "pakSitePkgD"
    runat = "server" />
<asp:FormView ID="FVpakSitePkgD"
  runat = "server"
  DataKeyNames = "ProjectID,RecNo,RecSrNo"
  DataSourceID = "ODSpakSitePkgD"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSitePkgD" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "pakSitePkgD"
            onblur= "script_pakSitePkgD.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
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
            OnClientItemSelected="script_pakSitePkgD.ACEProjectID_Selected"
            OnClientPopulating="script_pakSitePkgD.ACEProjectID_Populating"
            OnClientPopulated="script_pakSitePkgD.ACEProjectID_Populated"
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
            ValidationGroup = "pakSitePkgD"
            onblur= "script_pakSitePkgD.validate_RecNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRecNo"
            runat = "server"
            ControlToValidate = "F_RecNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_RecNo_Display"
            Text='<%# Eval("PAK_SitePkgH10_SupplierRefNo") %>'
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
            OnClientItemSelected="script_pakSitePkgD.ACERecNo_Selected"
            OnClientPopulating="script_pakSitePkgD.ACERecNo_Populating"
            OnClientPopulated="script_pakSitePkgD.ACERecNo_Populated"
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
          <asp:TextBox ID="F_RecSrNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            ValidationGroup = "pakSitePkgD"
            onblur= "script_pakSitePkgD.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO8_PODescription") %>'
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
            OnClientItemSelected="script_pakSitePkgD.ACESerialNo_Selected"
            OnClientPopulating="script_pakSitePkgD.ACESerialNo_Populating"
            OnClientPopulated="script_pakSitePkgD.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PkgNo" runat="server" Text="Packing List No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_PkgNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("PkgNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Packing List No."
            ValidationGroup = "pakSitePkgD"
            onblur= "script_pakSitePkgD.validate_PkgNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPkgNo"
            runat = "server"
            ControlToValidate = "F_PkgNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_PkgNo_Display"
            Text='<%# Eval("PAK_PkgListH7_SupplierRefNo") %>'
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
            OnClientItemSelected="script_pakSitePkgD.ACEPkgNo_Selected"
            OnClientPopulating="script_pakSitePkgD.ACEPkgNo_Populating"
            OnClientPopulated="script_pakSitePkgD.ACEPkgNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BOMNo" runat="server" Text="BOM No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BOMNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for BOM No."
            ValidationGroup = "pakSitePkgD"
            onblur= "script_pakSitePkgD.validate_BOMNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBOMNo"
            runat = "server"
            ControlToValidate = "F_BOMNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_PkgListD6_PackingMark") %>'
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
            OnClientItemSelected="script_pakSitePkgD.ACEBOMNo_Selected"
            OnClientPopulating="script_pakSitePkgD.ACEBOMNo_Populating"
            OnClientPopulated="script_pakSitePkgD.ACEBOMNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemNo" runat="server" Text="Item No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item No."
            ValidationGroup = "pakSitePkgD"
            onblur= "script_pakSitePkgD.validate_ItemNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemNo"
            runat = "server"
            ControlToValidate = "F_ItemNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_PkgListD6_PackingMark") %>'
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
            OnClientItemSelected="script_pakSitePkgD.ACEItemNo_Selected"
            OnClientPopulating="script_pakSitePkgD.ACEItemNo_Populating"
            OnClientPopulated="script_pakSitePkgD.ACEItemNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SiteMarkNo" runat="server" Text="Site Mark No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SiteMarkNo"
            CssClass = "myfktxt"
            Width="248px"
            Text='<%# Bind("SiteMarkNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Site Mark No."
            onblur= "script_pakSitePkgD.validate_SiteMarkNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SiteMarkNo_Display"
            Text='<%# Eval("PAK_SiteItemMaster9_ItemDescription") %>'
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
            OnClientItemSelected="script_pakSitePkgD.ACESiteMarkNo_Selected"
            OnClientPopulating="script_pakSitePkgD.ACESiteMarkNo_Populating"
            OnClientPopulated="script_pakSitePkgD.ACESiteMarkNo_Populated"
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
          <asp:TextBox
            ID = "F_UOMQuantity"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("UOMQuantity") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for UOM Quantity."
            onblur= "script_pakSitePkgD.validate_UOMQuantity(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMQuantity_Display"
            Text='<%# Eval("PAK_Units11_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUOMQuantity"
            BehaviorID="B_ACEUOMQuantity"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UOMQuantityCompletionList"
            TargetControlID="F_UOMQuantity"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgD.ACEUOMQuantity_Selected"
            OnClientPopulating="script_pakSitePkgD.ACEUOMQuantity_Populating"
            OnClientPopulated="script_pakSitePkgD.ACEUOMQuantity_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
          <asp:Label ID="L_DocumentNo" runat="server" Text="Document No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DocumentNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("DocumentNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Document No."
            onblur= "script_pakSitePkgD.validate_DocumentNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DocumentNo_Display"
            Text='<%# Eval("PAK_Documents3_cmba") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDocumentNo"
            BehaviorID="B_ACEDocumentNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DocumentNoCompletionList"
            TargetControlID="F_DocumentNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgD.ACEDocumentNo_Selected"
            OnClientPopulating="script_pakSitePkgD.ACEDocumentNo_Populating"
            OnClientPopulated="script_pakSitePkgD.ACEDocumentNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DocumentRevision" runat="server" Text="Document Revision :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DocumentRevision"
            Text='<%# Bind("DocumentRevision") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document Revision."
            MaxLength="10"
            Width="88px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackTypeID" runat="server" Text="Pack Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PackTypeID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("PackTypeID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Pack Type."
            onblur= "script_pakSitePkgD.validate_PackTypeID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_PackTypeID_Display"
            Text='<%# Eval("PAK_PakTypes5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEPackTypeID"
            BehaviorID="B_ACEPackTypeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="PackTypeIDCompletionList"
            TargetControlID="F_PackTypeID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgD.ACEPackTypeID_Selected"
            OnClientPopulating="script_pakSitePkgD.ACEPackTypeID_Populating"
            OnClientPopulated="script_pakSitePkgD.ACEPackTypeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
          <asp:Label ID="L_PackLength" runat="server" Text="Package Length :" />&nbsp;
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
          <asp:Label ID="L_PackWidth" runat="server" Text="Package Width :" />&nbsp;
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
          <asp:Label ID="L_PackHeight" runat="server" Text="Package Height :" />&nbsp;
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
          <asp:Label ID="L_UOMPack" runat="server" Text="UOM Packing :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMPack"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("UOMPack") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for UOM Packing."
            onblur= "script_pakSitePkgD.validate_UOMPack(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMPack_Display"
            Text='<%# Eval("PAK_Units12_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUOMPack"
            BehaviorID="B_ACEUOMPack"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UOMPackCompletionList"
            TargetControlID="F_UOMPack"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgD.ACEUOMPack_Selected"
            OnClientPopulating="script_pakSitePkgD.ACEUOMPack_Populating"
            OnClientPopulated="script_pakSitePkgD.ACEUOMPack_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
        <td class="alignright">
          <asp:Label ID="L_DocumentReceived" runat="server" Text="Document Received :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DocumentReceived"
           Checked='<%# Bind("DocumentReceived") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NotFromPackingList" runat="server" Text="Not From Packing List :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_NotFromPackingList"
           Checked='<%# Bind("NotFromPackingList") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OnlyPackageReceived" runat="server" Text="Only Package Received :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_OnlyPackageReceived"
           Checked='<%# Bind("OnlyPackageReceived") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaterialStatusID" runat="server" Text="Status of Material / Package :" />&nbsp;
        </td>
        <td>
          <LGM:LC_pakMaterialStates
            ID="F_MaterialStatusID"
            SelectedValue='<%# Bind("MaterialStatusID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
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
  ID = "ODSpakSitePkgD"
  DataObjectTypeName = "SIS.PAK.pakSitePkgD"
  InsertMethod="UZ_pakSitePkgDInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSitePkgD"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
