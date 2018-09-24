<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakPkgListH.aspx.vb" Inherits="AF_pakPkgListH" title="Add: Packing List" %>
<asp:Content ID="CPHpakPkgListH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakPkgListH" runat="server" Text="&nbsp;Add: Packing List"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakPkgListH" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakPkgListH"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakPkgListH"
    runat = "server" />
<asp:FormView ID="FVpakPkgListH"
  runat = "server"
  DataKeyNames = "SerialNo,PkgNo"
  DataSourceID = "ODSpakPkgListH"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakPkgListH" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "pakPkgListH"
            onblur= "script_pakPkgListH.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakPkgListH"
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
            OnClientItemSelected="script_pakPkgListH.ACESerialNo_Selected"
            OnClientPopulating="script_pakPkgListH.ACESerialNo_Populating"
            OnClientPopulated="script_pakPkgListH.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PkgNo" ForeColor="#CC6633" runat="server" Text="Pkg. No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PkgNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierRefNo" runat="server" Text="Supplier Ref. No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierRefNo"
            Text='<%# Bind("SupplierRefNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Ref. No."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TransporterID"
            CssClass = "myfktxt"
            Width="80px"
            Text='<%# Bind("TransporterID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Transporter."
            onblur= "script_pakPkgListH.validate_TransporterID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TransporterID_Display"
            Text='<%# Eval("VR_BusinessPartner4_BPName") %>'
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
            OnClientItemSelected="script_pakPkgListH.ACETransporterID_Selected"
            OnClientPopulating="script_pakPkgListH.ACETransporterID_Populating"
            OnClientPopulated="script_pakPkgListH.ACETransporterID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" />&nbsp;
        </td>
        <td colspan="3">
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
          <asp:Label ID="L_VehicleNo" runat="server" Text="Vehicle No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_VehicleNo"
            Text='<%# Bind("VehicleNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakPkgListH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Vehicle No."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVVehicleNo"
            runat = "server"
            ControlToValidate = "F_VehicleNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakPkgListH"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GRNo" runat="server" Text="GR No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_GRNo"
            Text='<%# Bind("GRNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakPkgListH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GR No."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGRNo"
            runat = "server"
            ControlToValidate = "F_GRNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakPkgListH"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GRDate" runat="server" Text="GR Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_GRDate"
            Text='<%# Bind("GRDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="pakPkgListH"
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
            ValidationGroup = "pakPkgListH"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VRExecutionNo" runat="server" Text="Vehicle Execution No. :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_VRExecutionNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("VRExecutionNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Vehicle Execution No.."
            onblur= "script_pakPkgListH.validate_VRExecutionNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_VRExecutionNo_Display"
            Text='<%# Eval("VR_RequestExecution5_ExecutionDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEVRExecutionNo"
            BehaviorID="B_ACEVRExecutionNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="VRExecutionNoCompletionList"
            TargetControlID="F_VRExecutionNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakPkgListH.ACEVRExecutionNo_Selected"
            OnClientPopulating="script_pakPkgListH.ACEVRExecutionNo_Populating"
            OnClientPopulated="script_pakPkgListH.ACEVRExecutionNo_Populated"
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
  ID = "ODSpakPkgListH"
  DataObjectTypeName = "SIS.PAK.pakPkgListH"
  InsertMethod="UZ_pakPkgListHInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakPkgListH"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
