<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSitePkgH.aspx.vb" Inherits="AF_pakSitePkgH" title="Add: Received Packing List" %>
<asp:Content ID="CPHpakSitePkgH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSitePkgH" runat="server" Text="&nbsp;Add: Received Packing List"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSitePkgH" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSitePkgH"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PAK_Main/App_Edit/EF_pakSitePkgH.aspx"
    ValidationGroup = "pakSitePkgH"
    runat = "server" />
<asp:FormView ID="FVpakSitePkgH"
  runat = "server"
  DataKeyNames = "ProjectID,RecNo"
  DataSourceID = "ODSpakSitePkgH"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSitePkgH" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "pakSitePkgH"
            onblur= "script_pakSitePkgH.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgH"
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
            OnClientItemSelected="script_pakSitePkgH.ACEProjectID_Selected"
            OnClientPopulating="script_pakSitePkgH.ACEProjectID_Populating"
            OnClientPopulated="script_pakSitePkgH.ACEProjectID_Populated"
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
          <asp:TextBox ID="F_RecNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
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
            ValidationGroup = "pakSitePkgH"
            onblur= "script_pakSitePkgH.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgH"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO4_PODescription") %>'
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
            OnClientItemSelected="script_pakSitePkgH.ACESerialNo_Selected"
            OnClientPopulating="script_pakSitePkgH.ACESerialNo_Populating"
            OnClientPopulated="script_pakSitePkgH.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
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
            ValidationGroup = "pakSitePkgH"
            onblur= "script_pakSitePkgH.validate_PkgNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPkgNo"
            runat = "server"
            ControlToValidate = "F_PkgNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSitePkgH"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_PkgNo_Display"
            Text='<%# Eval("PAK_PkgListH3_SupplierRefNo") %>'
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
            OnClientItemSelected="script_pakSitePkgH.ACEPkgNo_Selected"
            OnClientPopulating="script_pakSitePkgH.ACEPkgNo_Populating"
            OnClientPopulated="script_pakSitePkgH.ACEPkgNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MRNNo" runat="server" Text="MRN No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_MRNNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("MRNNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for MRN No."
            onblur= "script_pakSitePkgH.validate_MRNNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_MRNNo_Display"
            Text='<%# Eval("VR_LorryReceipts9_TransporterName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEMRNNo"
            BehaviorID="B_ACEMRNNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="MRNNoCompletionList"
            TargetControlID="F_MRNNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgH.ACEMRNNo_Selected"
            OnClientPopulating="script_pakSitePkgH.ACEMRNNo_Populating"
            OnClientPopulated="script_pakSitePkgH.ACEMRNNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierID"
            CssClass = "myfktxt"
            Width="80px"
            Text='<%# Bind("SupplierID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier."
            onblur= "script_pakSitePkgH.validate_SupplierID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner8_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierID"
            BehaviorID="B_ACESupplierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierIDCompletionList"
            TargetControlID="F_SupplierID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgH.ACESupplierID_Selected"
            OnClientPopulating="script_pakSitePkgH.ACESupplierID_Populating"
            OnClientPopulated="script_pakSitePkgH.ACESupplierID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Name."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierRefNo" runat="server" Text="Supplier Reference No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierRefNo"
            Text='<%# Bind("SupplierRefNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Reference No."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TransporterID"
            CssClass = "myfktxt"
            Width="80px"
            Text='<%# Bind("TransporterID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Transporter."
            onblur= "script_pakSitePkgH.validate_TransporterID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TransporterID_Display"
            Text='<%# Eval("VR_BusinessPartner7_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETransporterID"
            BehaviorID="B_ACETransporterID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TransporterIDCompletionList"
            TargetControlID="F_TransporterID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgH.ACETransporterID_Selected"
            OnClientPopulating="script_pakSitePkgH.ACETransporterID_Populating"
            OnClientPopulated="script_pakSitePkgH.ACETransporterID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TransporterName"
            Text='<%# Bind("TransporterName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Transporter Name."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VehicleNo" runat="server" Text="Vehicle No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleNo"
            Text='<%# Bind("VehicleNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Vehicle No."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GRNo" runat="server" Text="GR No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GRNo"
            Text='<%# Bind("GRNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GR No."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GRDate" runat="server" Text="GR Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GRDate"
            Text='<%# Bind("GRDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonGRDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEGRDate"
            TargetControlID="F_GRDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonGRDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEGRDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_GRDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVGRDate"
            runat = "server"
            ControlToValidate = "F_GRDate"
            ControlExtender = "MEEGRDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMTotalWeight" runat="server" Text="UOM Weight :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMTotalWeight"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("UOMTotalWeight") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for UOM Weight."
            onblur= "script_pakSitePkgH.validate_UOMTotalWeight(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMTotalWeight_Display"
            Text='<%# Eval("PAK_Units6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUOMTotalWeight"
            BehaviorID="B_ACEUOMTotalWeight"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UOMTotalWeightCompletionList"
            TargetControlID="F_UOMTotalWeight"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgH.ACEUOMTotalWeight_Selected"
            OnClientPopulating="script_pakSitePkgH.ACEUOMTotalWeight_Populating"
            OnClientPopulated="script_pakSitePkgH.ACEUOMTotalWeight_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalWeight" runat="server" Text="Total Weight :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalWeight"
            Text='<%# Bind("TotalWeight") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETotalWeight"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TotalWeight" />
          <AJX:MaskedEditValidator 
            ID = "MEVTotalWeight"
            runat = "server"
            ControlToValidate = "F_TotalWeight"
            ControlExtender = "MEETotalWeight"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ODC" runat="server" Text="ODC :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ODC"
           Checked='<%# Bind("ODC") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MaterialStatusID" runat="server" Text="Status of Material Received :" />&nbsp;
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
            MaxLength="500"
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
  ID = "ODSpakSitePkgH"
  DataObjectTypeName = "SIS.PAK.pakSitePkgH"
  InsertMethod="pakSitePkgHInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSitePkgH"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
