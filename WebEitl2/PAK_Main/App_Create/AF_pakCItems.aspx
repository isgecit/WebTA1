<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakCItems.aspx.vb" Inherits="AF_pakCItems" title="Add: Child Items" %>
<asp:Content ID="CPHpakCItems" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakCItems" runat="server" Text="&nbsp;Add: Child Items"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakCItems" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakCItems"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakCItems"
    runat = "server" />
<asp:FormView ID="FVpakCItems"
  runat = "server"
  DataKeyNames = "RootItem,ItemNo"
  DataSourceID = "ODSpakCItems"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakCItems" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RootItem" ForeColor="#CC6633" runat="server" Text="Root Item :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_RootItem"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("RootItem") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Root Item."
            ValidationGroup = "pakCItems"
            onblur= "script_pakCItems.validate_RootItem(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRootItem"
            runat = "server"
            ControlToValidate = "F_RootItem"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakCItems"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_RootItem_Display"
            Text='<%# Eval("PAK_Items7_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERootItem"
            BehaviorID="B_ACERootItem"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RootItemCompletionList"
            TargetControlID="F_RootItem"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakCItems.ACERootItem_Selected"
            OnClientPopulating="script_pakCItems.ACERootItem_Populating"
            OnClientPopulated="script_pakCItems.ACERootItem_Populated"
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
          <asp:TextBox ID="F_ItemNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemCode"
            Text='<%# Bind("ItemCode") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakCItems"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Code."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCode"
            runat = "server"
            ControlToValidate = "F_ItemCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakCItems"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemDescription"
            Text='<%# Bind("ItemDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakCItems"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Description."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemDescription"
            runat = "server"
            ControlToValidate = "F_ItemDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakCItems"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ElementID" runat="server" Text="Element ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ElementID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("ElementID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Element ID."
            onblur= "script_pakCItems.validate_ElementID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ElementID_Display"
            Text='<%# Eval("PAK_Elements3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEElementID"
            BehaviorID="B_ACEElementID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ElementIDCompletionList"
            TargetControlID="F_ElementID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakCItems.ACEElementID_Selected"
            OnClientPopulating="script_pakCItems.ACEElementID_Populating"
            OnClientPopulated="script_pakCItems.ACEElementID_Populated"
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
          <asp:Label ID="L_DocumentNo" runat="server" Text="Document No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DocumentNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("DocumentNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Document No."
            onblur= "script_pakCItems.validate_DocumentNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DocumentNo_Display"
            Text='<%# Eval("PAK_Documents2_cmba") %>'
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
            OnClientItemSelected="script_pakCItems.ACEDocumentNo_Selected"
            OnClientPopulating="script_pakCItems.ACEDocumentNo_Populating"
            OnClientPopulated="script_pakCItems.ACEDocumentNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ParentItemNo" runat="server" Text="Parent Item No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ParentItemNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("ParentItemNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Parent Item No."
            ValidationGroup = "pakCItems"
            onblur= "script_pakCItems.validate_ParentItemNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVParentItemNo"
            runat = "server"
            ControlToValidate = "F_ParentItemNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakCItems"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ParentItemNo_Display"
            Text='<%# Eval("PAK_Items4_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEParentItemNo"
            BehaviorID="B_ACEParentItemNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ParentItemNoCompletionList"
            TargetControlID="F_ParentItemNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakCItems.ACEParentItemNo_Selected"
            OnClientPopulating="script_pakCItems.ACEParentItemNo_Populating"
            OnClientPopulated="script_pakCItems.ACEParentItemNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
  ID = "ODSpakCItems"
  DataObjectTypeName = "SIS.PAK.pakCItems"
  InsertMethod="UZ_pakCItemsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakCItems"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
