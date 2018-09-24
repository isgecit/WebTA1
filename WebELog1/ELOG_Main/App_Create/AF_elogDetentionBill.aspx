<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogDetentionBill.aspx.vb" Inherits="AF_elogDetentionBill" title="Add: Detention Bill" %>
<asp:Content ID="CPHelogDetentionBill" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogDetentionBill" runat="server" Text="&nbsp;Add: Detention Bill"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogDetentionBill" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogDetentionBill"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogDetentionBill"
    runat = "server" />
<asp:FormView ID="FVelogDetentionBill"
  runat = "server"
  DataKeyNames = "IRNo"
  DataSourceID = "ODSelogDetentionBill"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogDetentionBill" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table>
      <tr>
        <td style="vertical-align:top;">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IRNo" ForeColor="#CC6633" runat="server" Text="IR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IRNo"
            Text='<%# Bind("IRNo") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            onblur= "script_elogDetentionBill.validate_IRNo(this);"
            ValidationGroup="elogDetentionBill"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RequiredFieldValidator1"
            runat = "server"
            ControlToValidate = "F_IRNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogDetentionBill"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IRDate" runat="server" Text="IR Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IRDate"
            Text='<%# Bind("IRDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="elogDetentionBill"
            onfocus = "return this.select();"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierID" runat="server" Text="Business Partner ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SupplierID"
            CssClass = "myfktxt"
            Width="80px"
            Text='<%# Bind("SupplierID") %>'
            AutoCompleteType = "None"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierBillNo" runat="server" Text="Bill No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SupplierBillNo"
            Text='<%# Bind("SupplierBillNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogDetentionBill"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bill No."
            MaxLength="50"
            Width="408px"
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
            ValidationGroup="elogDetentionBill"
            onfocus = "return this.select();"
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
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="elogDetentionBill"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogDetentionBill"
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
            ValidationGroup="elogDetentionBill"
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
            ValidationGroup = "elogDetentionBill"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PO Number."
            MaxLength="9"
            Width="80px"
            runat="server" />
        </td>
      </tr>
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other Bill Type."
            MaxLength="20"
            Width="168px"
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
            Width="88px"
            style="text-align: Right"
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
            Width="88px"
            style="text-align: Right"
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
    </table>

        </td>
        <td style="vertical-align:top;">
          <table>
            <tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" ForeColor="#CC6633" runat="server" Text="GR No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="S_IRNo"
            Width="70px"
						style="text-align: right"
						CssClass = "mypktxt"
            onblur= "script_vrTransporterBill.validate_IRNo(this);"
						ValidationGroup="vrTransporterBill"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
				</td>
            </tr>
			<tr>
			<td></td>
			<td style="height:200px; width:400px; background-color:Aqua" id="divIR">
			</td>
			</tr>
          </table>
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogDetentionBill"
  DataObjectTypeName = "SIS.ELOG.elogDetentionBill"
  InsertMethod="UZ_elogDetentionBillInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogDetentionBill"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
