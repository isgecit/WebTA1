<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogDetentionBill.aspx.vb" Inherits="EF_elogDetentionBill" title="Edit: Detention Bill" %>
<asp:Content ID="CPHelogDetentionBill" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogDetentionBill" runat="server" Text="&nbsp;Edit: Detention Bill"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogDetentionBill" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogDetentionBill"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_elogDetentionBill.aspx?pk="
    ValidationGroup = "elogDetentionBill"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVelogDetentionBill"
  runat = "server"
  DataKeyNames = "IRNo"
  DataSourceID = "ODSelogDetentionBill"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IRNo" runat="server" ForeColor="#CC6633" Text="IR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IRNo"
            Text='<%# Bind("IRNo") %>'
            ToolTip="Value of IR No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IRDate" runat="server" Text="IR Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IRDate"
            Text='<%# Bind("IRDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogDetentionBill"
            runat="server" />
          <asp:Image ID="ImageButtonIRDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEIRDate"
            TargetControlID="F_IRDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonIRDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEIRDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_IRDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVIRDate"
            runat = "server"
            ControlToValidate = "F_IRDate"
            ControlExtender = "MEEIRDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogDetentionBill"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierID" runat="server" Text="Business Partner ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SupplierID"
            CssClass = "myfktxt"
            Text='<%# Bind("SupplierID") %>'
            AutoCompleteType = "None"
            Width="80px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Business Partner ID."
            ValidationGroup = "elogDetentionBill"
            onblur= "script_elogDetentionBill.validate_SupplierID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSupplierID"
            runat = "server"
            ControlToValidate = "F_SupplierID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogDetentionBill"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner5_BPName") %>'
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
            OnClientItemSelected="script_elogDetentionBill.ACESupplierID_Selected"
            OnClientPopulating="script_elogDetentionBill.ACESupplierID_Populating"
            OnClientPopulated="script_elogDetentionBill.ACESupplierID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierBillNo" runat="server" Text="Bill No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SupplierBillNo"
            Text='<%# Bind("SupplierBillNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogDetentionBill"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bill No."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSupplierBillNo"
            runat = "server"
            ControlToValidate = "F_SupplierBillNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogDetentionBill"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierBillDate" runat="server" Text="Bill Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SupplierBillDate"
            Text='<%# Bind("SupplierBillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogDetentionBill"
            runat="server" />
          <asp:Image ID="ImageButtonSupplierBillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CESupplierBillDate"
            TargetControlID="F_SupplierBillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonSupplierBillDate" />
          <AJX:MaskedEditExtender 
            ID = "MEESupplierBillDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SupplierBillDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVSupplierBillDate"
            runat = "server"
            ControlToValidate = "F_SupplierBillDate"
            ControlExtender = "MEESupplierBillDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogDetentionBill"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillAmount" runat="server" Text="Bill Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_BillAmount"
            Text='<%# Bind("BillAmount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup= "elogDetentionBill"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEBillAmount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BillAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVBillAmount"
            runat = "server"
            ControlToValidate = "F_BillAmount"
            ControlExtender = "MEEBillAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogDetentionBill"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GRNo" runat="server" Text="GR No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_GRNo"
            Text='<%# Bind("GRNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogDetentionBill"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GR No."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGRNo"
            runat = "server"
            ControlToValidate = "F_GRNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogDetentionBill"
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
            onfocus = "return this.select();"
            ValidationGroup="elogDetentionBill"
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
            ValidationGroup = "elogDetentionBill"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "elogDetentionBill"
            onblur= "script_elogDetentionBill.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogDetentionBill"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects4_Description") %>'
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
            OnClientItemSelected="script_elogDetentionBill.ACEProjectID_Selected"
            OnClientPopulating="script_elogDetentionBill.ACEProjectID_Populating"
            OnClientPopulated="script_elogDetentionBill.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PONumber" runat="server" Text="PO Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PONumber"
            Text='<%# Bind("PONumber") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PO Number."
            MaxLength="9"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillTypeID" runat="server" Text="Bill Type :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_elogDetentionBillTypes
            ID="F_BillTypeID"
            SelectedValue='<%# Bind("BillTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogDetentionBill"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_OtherBillType" runat="server" Text="Other Bill Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherBillType"
            Text='<%# Bind("OtherBillType") %>'
            Width="168px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other Bill Type."
            MaxLength="20"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VehicleExeNo" runat="server" Text="Vehicle Execution No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleExeNo"
            Text='<%# Bind("VehicleExeNo") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEVehicleExeNo"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_VehicleExeNo" />
          <AJX:MaskedEditValidator 
            ID = "MEVVehicleExeNo"
            runat = "server"
            ControlToValidate = "F_VehicleExeNo"
            ControlExtender = "MEEVehicleExeNo"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MRNNo" runat="server" Text="Site MRN No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MRNNo"
            Text='<%# Bind("MRNNo") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEMRNNo"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MRNNo" />
          <AJX:MaskedEditValidator 
            ID = "MEVMRNNo"
            runat = "server"
            ControlToValidate = "F_MRNNo"
            ControlExtender = "MEEMRNNo"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            Width="88px"
            Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("ELOG_DetentionBillStatus2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogDetentionBill"
  DataObjectTypeName = "SIS.ELOG.elogDetentionBill"
  SelectMethod = "elogDetentionBillGetByID"
  UpdateMethod="UZ_elogDetentionBillUpdate"
  DeleteMethod="UZ_elogDetentionBillDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogDetentionBill"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IRNo" Name="IRNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
