<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogIRBL.aspx.vb" Inherits="AF_elogIRBL" title="Add: IR BL" %>
<asp:Content ID="CPHelogIRBL" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogIRBL" runat="server" Text="&nbsp;Add: IR BL"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogIRBL" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogIRBL"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/ELOG_Main/App_Edit/EF_elogIRBL.aspx"
    ValidationGroup = "elogIRBL"
    runat = "server" />
<asp:FormView ID="FVelogIRBL"
  runat = "server"
  DataKeyNames = "IRNo"
  DataSourceID = "ODSelogIRBL"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogIRBL" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td colspan="4">
          <asp:Label ID="L_ErrMsg" runat="server" ClientIDMode="Static" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IRNo" ForeColor="#CC6633" runat="server" Text="IR No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_IRNo"
            Text='<%# Bind("IRNo") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="elogIRBL"
            MaxLength="10"
            onfocus = "return this.select();"
            ClientIDMode="Static"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEIRNo"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_IRNo" />
          <AJX:MaskedEditValidator 
            ID = "MEVIRNo"
            runat = "server"
            ControlToValidate = "F_IRNo"
            ControlExtender = "MEEIRNo"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogIRBL"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
        <td colspan="2">
          <asp:Button ID="cmdIR" runat="server" ClientIDMode="Static" Text="Get IR Details from ERP" OnClientClick="return script_elogIRBL.getIRData('F_IRNo');" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierID"
            Width="80px"
            Text='<%# Bind("SupplierID") %>'
            Enabled = "False"
            ToolTip="Value of Supplier."
            CssClass = "dmyfktxt"
            ClientIDMode="Static"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner10_BPName") %>'
            CssClass="myLbl"
            ClientIDMode="Static"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project."
            CssClass = "dmyfktxt"
            ClientIDMode="Static"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects9_Description") %>'
            CssClass="myLbl"
            ClientIDMode="Static"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PONo" runat="server" Text="PO No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PONo"
            Text='<%# Bind("PONo") %>'
            Enabled = "False"
            ToolTip="Value of PO No."
            Width="80px"
            CssClass = "dmytxt"
            ClientIDMode="Static"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierBillNo" runat="server" Text="Supplier Bill No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierBillNo"
            Text='<%# Bind("SupplierBillNo") %>'
            Enabled = "False"
            ToolTip="Value of Supplier Bill No."
            Width="408px"
            CssClass = "dmytxt"
            ClientIDMode="Static"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_supplierBillDate" runat="server" Text="Supplier Bill Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_supplierBillDate"
            Text='<%# Bind("supplierBillDate") %>'
            Enabled = "False"
            ToolTip="Value of Supplier Bill Date."
            Width="168px"
            CssClass = "dmytxt"
            ClientIDMode="Static"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierBillAmount" runat="server" Text="Supplier Bill Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierBillAmount"
            Text='<%# Bind("SupplierBillAmount") %>'
            Enabled = "False"
            ToolTip="Value of Supplier Bill Amount."
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            ClientIDMode="Static"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IRDate" runat="server" Text="IR Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IRDate"
            Text='<%# Bind("IRDate") %>'
            Enabled = "False"
            ToolTip="Value of IR Date."
            Width="168px"
            CssClass = "dmytxt"
            ClientIDMode="Static"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BLID" runat="server" Text="BL ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_BLID"
            CssClass = "myfktxt"
            Width="80px"
            Text='<%# Bind("BLID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for BL ID."
            ValidationGroup = "elogIRBL"
            onblur= "script_elogIRBL.validate_BLID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBLID"
            runat = "server"
            ControlToValidate = "F_BLID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogIRBL"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_BLID_Display"
            Text='<%# Eval("ELOG_BLHeader2_BLNumber") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBLID"
            BehaviorID="B_ACEBLID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BLIDCompletionList"
            TargetControlID="F_BLID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_elogIRBL.ACEBLID_Selected"
            OnClientPopulating="script_elogIRBL.ACEBLID_Populating"
            OnClientPopulated="script_elogIRBL.ACEBLID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BLType" runat="server" Text="BL Type :" />&nbsp;
        </td>
        <td>
          <LGM:LC_elogBLTypes
            ID="F_BLType"
            SelectedValue='<%# Bind("BLType") %>'
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
          <asp:Label ID="L_MBLNo" runat="server" Text="MBL No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MBLNo"
            Text='<%# Bind("MBLNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for MBL No."
            MaxLength="50"
            Width="408px"
            runat="server" />
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="row1" runat="server" ClientIDMode="static" >
        <td class="alignright">
          <asp:Label ID="L_ShipmentModeID" runat="server" Text="Shipment Mode :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogShipmentModes
            ID="F_ShipmentModeID"
            SelectedValue='<%# Bind("ShipmentModeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBL"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr  id="row2" runat="server" ClientIDMode="static" >
        <td class="alignright">
          <asp:Label ID="L_CarrierID" runat="server"  Text="Carrier :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_elogCarriers
            ID="F_CarrierID"
            SelectedValue='<%# Bind("CarrierID") %>'
            OrderBy="1"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBL"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_OtherCarrier" runat="server" Text="Other Carrier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherCarrier"
            Text='<%# Bind("OtherCarrier") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other Carrier."
            MaxLength="100"
            Width="350px" 
            runat="server" />
        </td>
      </tr>
      <tr  id="row3" runat="server" ClientIDMode="static" >
        <td class="alignright">
          <asp:Label ID="L_LocationCountryID" runat="server" Text="Location Country :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_elogLocationCountries
            ID="F_LocationCountryID"
            SelectedValue='<%# Bind("LocationCountryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBL"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_OtherCountry" runat="server" Text="Other Country :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherCountry"
            Text='<%# Bind("OtherCountry") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other Country."
            MaxLength="100"
            Width="350px" 
            runat="server" />
        </td>
      </tr>
      <tr  id="row4" runat="server" ClientIDMode="static" >
        <td class="alignright">
          <asp:Label ID="L_CargoTypeID" runat="server" Text="Cargo Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogCargoTypes
            ID="F_CargoTypeID"
            SelectedValue='<%# Bind("CargoTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBL"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr  id="row5" runat="server" ClientIDMode="static" >
        <td class="alignright">
          <asp:Label ID="L_PortID" runat="server" Text="Port :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogPorts
            ID="F_PortID"
            SelectedValue='<%# Bind("PortID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBL"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr  id="row6" runat="server" ClientIDMode="static" >
        <td class="alignright">
          <asp:Label ID="L_OtherPortLoadingOrigin" runat="server" Text="Other Port / Port Of Loading / Origin Point :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OtherPortLoadingOrigin"
            Text='<%# Bind("OtherPortLoadingOrigin") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other Port Loading Origin."
            MaxLength="100"
            Width="350px" 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td></td>
        <td style="text-align:center">
          <asp:Button ID="cmdNext" runat="server" BackColor="lime" Text="Next" CommandName="lgNext" />
        </td>
        <td  style="text-align:center">
          <asp:Button ID="cmdBack" runat="server" BackColor="Yellow" Text="Back" CommandName="lgBack" />
        </td>
        <td>
          <asp:HiddenField ID="state" runat="server" Value="1" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
    <table>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogIRBL"
  DataObjectTypeName = "SIS.ELOG.elogIRBL"
  InsertMethod="UZ_elogIRBLInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogIRBL"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
