<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSitePkgH.aspx.vb" Inherits="EF_pakSitePkgH" title="Edit: Received Packing List" %>
<asp:Content ID="CPHpakSitePkgH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSitePkgH" runat="server" Text="&nbsp;Edit: Received Packing List"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSitePkgH" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSitePkgH"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakSitePkgH"
    runat = "server" />
<asp:FormView ID="FVpakSitePkgH"
  runat = "server"
  DataKeyNames = "ProjectID,RecNo"
  DataSourceID = "ODSpakSitePkgH"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_RecNo" runat="server" ForeColor="#CC6633" Text="Receipt No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_RecNo"
            Text='<%# Bind("RecNo") %>'
            ToolTip="Value of Receipt No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MRNNo" runat="server" Text="MRN No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_MRNNo"
            CssClass = "myfktxt"
            Text='<%# Bind("MRNNo") %>'
            AutoCompleteType = "None"
            Width="88px"
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
          <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TransporterID"
            CssClass = "myfktxt"
            Text='<%# Bind("TransporterID") %>'
            AutoCompleteType = "None"
            Width="80px"
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
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TransporterName"
            Text='<%# Bind("TransporterName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Transporter Name."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleNo" runat="server" Text="Vehicle No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleNo"
            Text='<%# Bind("VehicleNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Vehicle No."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GRNo" runat="server" Text="GR No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GRNo"
            Text='<%# Bind("GRNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GR No."
            MaxLength="50"
            runat="server" />
        </td>
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
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMTotalWeight" runat="server" Text="UOM Weight :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMTotalWeight"
            CssClass = "myfktxt"
            Text='<%# Bind("UOMTotalWeight") %>'
            AutoCompleteType = "None"
            Width="88px"
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
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner8_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            ToolTip="Value of Supplier Name."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierRefNo" runat="server" Text="Supplier Reference No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierRefNo"
            Text='<%# Bind("SupplierRefNo") %>'
            ToolTip="Value of Supplier Reference No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ReceiveStatusID" runat="server" Text="Receipt Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceiveStatusID"
            Width="88px"
            Text='<%# Bind("ReceiveStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Receipt Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ReceiveStatusID_Display"
            Text='<%# Eval("PAK_ReceiveStatus5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakSitePkgD" runat="server" Text="&nbsp;List: Received Packing List Item"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSitePkgD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSitePkgD"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSitePkgD.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "pakSitePkgD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSitePkgD" runat="server" AssociatedUpdatePanelID="UPNLpakSitePkgD" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakSitePkgD" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSitePkgD" DataKeyNames="ProjectID,RecNo,RecSrNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receipt Line No" SortExpression="RecSrNo">
          <ItemTemplate>
            <asp:Label ID="LabelRecSrNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RecSrNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="PAK_PkgListD6_PackingMark">
          <ItemTemplate>
             <asp:Label ID="L_ItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemNo") %>' Text='<%# Eval("PAK_PkgListD6_PackingMark") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Site Mark No" SortExpression="PAK_SiteItemMaster9_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_SiteMarkNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SiteMarkNo") %>' Text='<%# Eval("PAK_SiteItemMaster9_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pack Type" SortExpression="PAK_PakTypes5_Description">
          <ItemTemplate>
             <asp:Label ID="L_PackTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("PackTypeID") %>' Text='<%# Eval("PAK_PakTypes5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PACKAGE Receive">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Receive the package." SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Quantity not confirmed, only package is received ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Quantity" SortExpression="PAK_Units11_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMQuantity") %>' Text='<%# Eval("PAK_Units11_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
          <ItemTemplate>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup='<%# "Approve" & Container.DataItemIndex %>'
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
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location" SortExpression="PAK_SiteLocations6_Description">
          <ItemTemplate>
          <LGM:LC_pakSiteLocations
            ID="F_LocationID"
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />

          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Only Package Received" SortExpression="OnlyPackageReceived">
          <ItemTemplate>
            <asp:Label ID="LabelOnlyPackageReceived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OnlyPackageReceived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Inventory Status" SortExpression="PAK_InventoryStatus4_Description">
          <ItemTemplate>
             <asp:Label ID="L_InventoryStatusID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("InventoryStatusID") %>' Text='<%# Eval("PAK_InventoryStatus4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ITEM Receive">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Receive the material" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Receive the material ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakSitePkgD"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSitePkgD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakSitePkgDSelectList"
      TypeName = "SIS.PAK.pakSitePkgD"
      SelectCountMethod = "pakSitePkgDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_RecNo" PropertyName="Text" Name="RecNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSitePkgD" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSitePkgH"
  DataObjectTypeName = "SIS.PAK.pakSitePkgH"
  SelectMethod = "pakSitePkgHGetByID"
  UpdateMethod="UZ_pakSitePkgHUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSitePkgH"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecNo" Name="RecNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
