<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakQCListD.aspx.vb" Inherits="AF_pakQCListD" title="Add: Quality Clearance Items" %>
<asp:Content ID="CPHpakQCListD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakQCListD" runat="server" Text="&nbsp;Add: Quality Clearance Items"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakQCListD" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakQCListD"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakQCListD"
    runat = "server" />
<asp:FormView ID="FVpakQCListD"
  runat = "server"
  DataKeyNames = "SerialNo,QCLNo,BOMNo,ItemNo"
  DataSourceID = "ODSpakQCListD"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakQCListD" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            ValidationGroup = "pakQCListD"
            onblur= "script_pakQCListD.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakQCListD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO2_PODescription") %>'
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
            OnClientItemSelected="script_pakQCListD.ACESerialNo_Selected"
            OnClientPopulating="script_pakQCListD.ACESerialNo_Populating"
            OnClientPopulated="script_pakQCListD.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_QCLNo" ForeColor="#CC6633" runat="server" Text="QCL No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_QCLNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("QCLNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for QCL No."
            ValidationGroup = "pakQCListD"
            onblur= "script_pakQCListD.validate_QCLNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVQCLNo"
            runat = "server"
            ControlToValidate = "F_QCLNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakQCListD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_QCLNo_Display"
            Text='<%# Eval("PAK_QCListH5_SupplierRef") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEQCLNo"
            BehaviorID="B_ACEQCLNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="QCLNoCompletionList"
            TargetControlID="F_QCLNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakQCListD.ACEQCLNo_Selected"
            OnClientPopulating="script_pakQCListD.ACEQCLNo_Populating"
            OnClientPopulated="script_pakQCListD.ACEQCLNo_Populated"
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
        <td colspan="3">
          <asp:TextBox
            ID = "F_BOMNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for BOM No."
            ValidationGroup = "pakQCListD"
            onblur= "script_pakQCListD.validate_BOMNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBOMNo"
            runat = "server"
            ControlToValidate = "F_BOMNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakQCListD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_POBOM4_ItemDescription") %>'
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
            OnClientItemSelected="script_pakQCListD.ACEBOMNo_Selected"
            OnClientPopulating="script_pakQCListD.ACEBOMNo_Populating"
            OnClientPopulated="script_pakQCListD.ACEBOMNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" ForeColor="#CC6633" runat="server" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item No."
            ValidationGroup = "pakQCListD"
            onblur= "script_pakQCListD.validate_ItemNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemNo"
            runat = "server"
            ControlToValidate = "F_ItemNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakQCListD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_POBItems3_ItemDescription") %>'
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
            OnClientItemSelected="script_pakQCListD.ACEItemNo_Selected"
            OnClientPopulating="script_pakQCListD.ACEItemNo_Populating"
            OnClientPopulated="script_pakQCListD.ACEItemNo_Populated"
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
        <td colspan="3">
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
            Text='<%# Eval("PAK_Units6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            Width="184px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="pakQCListD"
            MaxLength="22"
            onfocus = "return this.select();"
            onblur ="return dc(this,4);"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InspectionStageID" runat="server" Text="Inspection Stage :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_qcmInspectionStages
            ID="F_InspectionStageID"
            SelectedValue='<%# Bind("InspectionStageID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pakQCListD"
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
  ID = "ODSpakQCListD"
  DataObjectTypeName = "SIS.PAK.pakQCListD"
  InsertMethod="pakQCListDInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakQCListD"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
