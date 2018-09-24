<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taCH.aspx.vb" Inherits="EF_taCH" title="Edit: Travel Expense Statements" %>
<asp:Content ID="CPHtaCH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCH" runat="server" Text="&nbsp;Edit: Travel Expense Statements"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCH" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCH"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_taBH.aspx?pk="
    ValidationGroup = "taCH"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVtaCH"
  runat = "server"
  DataKeyNames = "TABillNo"
  DataSourceID = "ODStaCH"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" runat="server" ForeColor="#CC6633" Text="TA Bill No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_TABillNo"
            Text='<%# Bind("TABillNo") %>'
            ToolTip="Value of TA Bill No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BillStatusID" runat="server" Text="Bill Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BillStatusID"
            Width="88px"
            Text='<%# Bind("BillStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Bill Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BillStatusID_Display"
            Text='<%# Eval("TA_BillStates16_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr >
        <td class="alignright">
          <asp:Label ID="Label1" runat="server" Text="TA Bill Verifier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TAVerifier"
            Width="88px"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.TAVerifier") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "Label2"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.HRM_Employees6_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label3" runat="server" Text="TA Bill Approver :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TAApprover"
            Width="88px"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.TAApprover") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "Label4"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.HRM_Employees7_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr >
        <td class="alignright">
          <asp:Label ID="Label5" runat="server" Text="TA Bill Sanctioning Authority :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TASanctioningAuthority"
            Width="88px"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.TASanctioningAuthority") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "Label6"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.HRM_Employees9_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td></td>
        <td >
        <script type="text/javascript">
          var pcnt = 0;
          function show_attach(o) {
            pcnt = pcnt + 1;
            var nam = 'wTask' + pcnt;
            var url = o.getAttribute('CommandValue');
            window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
            return false;
          }
        </script>
          <asp:Button ID="cmdAttach" runat="server" CommandValue='<%# Eval("GetAttachLink") %>' Text="Show MD Approval" OnClientClick="return show_attach(this);" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taCH_0"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Employee Details</td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_EmployeeID" runat="server" Text="Employee ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            Width="72px"
            Text='<%# Bind("EmployeeID") %>'
            Enabled = "False"
            ToolTip="Value of Employee ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("HRM_Employees5_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CompanyID" runat="server" Text="Company ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CompanyID"
            Width="56px"
            Text='<%# Bind("CompanyID") %>'
            Enabled = "False"
            ToolTip="Value of Company ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CompanyID_Display"
            Text='<%# Eval("HRM_Companies1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="Division ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DivisionID"
            Width="56px"
            Text='<%# Bind("DivisionID") %>'
            Enabled = "False"
            ToolTip="Value of Division ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DivisionID_Display"
            Text='<%# Eval("HRM_Divisions4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DepartmentID" runat="server" Text="Department ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DepartmentID"
            Width="56px"
            Text='<%# Bind("DepartmentID") %>'
            Enabled = "False"
            ToolTip="Value of Department ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DepartmentID_Display"
            Text='<%# Eval("HRM_Departments2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_DesignationID" runat="server" Text="Designation ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DesignationID"
            Width="88px"
            Text='<%# Bind("DesignationID") %>'
            Enabled = "False"
            ToolTip="Value of Designation ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DesignationID_Display"
            Text='<%# Eval("HRM_Designations3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TACategoryID" runat="server" Text="TA Category ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TACategoryID"
            Width="88px"
            Text='<%# Bind("TACategoryID") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            style="display:none"
            Runat="Server" />
          <asp:Label
            ID = "F_TACategoryID_Display"
            Text='<%# Eval("TA_Categories13_cmba") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_Contractual" runat="server" Text="Contractual :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Contractual"
            Checked='<%# Bind("Contractual") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_NonTechnical" runat="server" Text="Non Technical :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_NonTechnical"
            Checked='<%# Bind("NonTechnical") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taCH_1"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Travel Details</td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_TravelTypeID" runat="server" Text="Travel Type ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TravelTypeID"
            Width="88px"
            Text='<%# Bind("TravelTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Travel Type ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_TravelTypeID_Display"
            Text='<%# Eval("TA_TravelTypes17_TravelTypeDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_CityOfOrigin" runat="server" Text="City Of Origin :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CityOfOrigin"
            Width="248px"
            Text='<%# Bind("CityOfOrigin") %>'
            Enabled = "False"
            ToolTip="Value of City Of Origin."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CityOfOrigin_Display"
            Text='<%# Eval("TA_Cities1_CityName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_DestinationCity" runat="server" Text="Destination City :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DestinationCity"
            Width="248px"
            Text='<%# Bind("DestinationCity") %>'
            Enabled = "False"
            ToolTip="Value of Destination City."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DestinationCity_Display"
            Text='<%# Eval("TA_Cities14_CityName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_TaxiHired" runat="server" Text="Training Program [Residential]: :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_TaxiHired"
            Checked='<%# Bind("TaxiHired") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TrainingProgram" runat="server" Text="Training Program [NON-Residential]: :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_TrainingProgram"
            Checked='<%# Bind("TrainingProgram") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_SameDayVisit" runat="server" Text="Same Day Visit :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_SameDayVisit"
            Checked='<%# Bind("SameDayVisit") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Within25KM" runat="server" Text="Visit with in 25 KM :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Within25KM"
            Checked='<%# Bind("Within25KM") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr id="opt3" runat="server" ClientIDMode="Static">
        <td class="alignright">
          <asp:Label ID="L_SiteToAnotherSite" runat="server" Text="It is Partial TA Bill :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_SiteToAnotherSite"
            Checked='<%# Bind("SiteToAnotherSite") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OwnVehicleUsed" runat="server" Text="" />&nbsp;
        </td>
        <td>
<%--       <asp:CheckBox ID="F_OwnVehicleUsed"
            Checked='<%# Bind("OwnVehicleUsed") %>'
            CssClass = "mychk"
            Enabled='<%# Eval("HeaderEditable") %>'
            runat="server" />--%>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_PurposeOfJourney" runat="server" Text="Purpose Of Journey :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_PurposeOfJourney"
            Text='<%# Eval("PurposeOfJourney") %>'
            Width="350px"
            CssClass="dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BriefTourReport" runat="server" Text="Brief Tour Report :" />&nbsp;
        </td>
        <td>
          <asp:Label ID="F_BriefTourReport"
            Text='<%# Eval("BriefTourReport") %>'
            Width="350px"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taCH_2"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Accounts Details</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StartDateTime" runat="server" Text="Tour Start Date and Time :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_StartDateTime"
            Text='<%# Bind("StartDateTime") %>'
            ToolTip="Value of Tour Start Date and Time."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EndDateTime" runat="server" Text="Tour End Date and Time :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_EndDateTime"
            Text='<%# Bind("EndDateTime") %>'
            ToolTip="Value of Tour End Date and Time."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalClaimedAmount" runat="server" Text="Total Claimed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalClaimedAmount"
            Text='<%# Bind("TotalClaimedAmount") %>'
            ToolTip="Value of Total Claimed Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalPassedAmount" runat="server" Text="Total Passed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalPassedAmount"
            Text='<%# Bind("TotalPassedAmount") %>'
            ToolTip="Value of Total Passed Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalFinancedAmount" runat="server" Text="Total Financed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalFinancedAmount"
            Text='<%# Bind("TotalFinancedAmount") %>'
            ToolTip="Value of Total Financed Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalPayableAmount" runat="server" Text="Total Payable Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalPayableAmount"
            Text='<%# Bind("TotalPayableAmount") %>'
            ToolTip="Value of Total Payable Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            onblur= "script_taCH.validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects11_Description") %>'
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
            OnClientItemSelected="script_taCH.ACEProjectID_Selected"
            OnClientPopulating="script_taCH.ACEProjectID_Populating"
            OnClientPopulated="script_taCH.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CostCenterID" runat="server" Text="CostCenterID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taDepartments
            ID="F_CostCenterID"
            SelectedValue='<%# Bind("CostCenterID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillCurrencyID" runat="server" Text="TA Bill Currency ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_BillCurrencyID"
            SelectedValue='<%# Bind("BillCurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor [INR] :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorINR"
            Text='<%# Bind("ConversionFactorINR") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup= "taCH"
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            runat="server" />
          <asp:Button ID="cmdApply" runat="server" Text="Apply and Calculate" OnClientClick="return confirm('Apply this conversion Rate and Re-Calculate TA Bill, Pl. check TA Bill carefully before applying changed rate [INR] ?');" CommandName="cmdApply" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PrjCalcType" runat="server" Text="Project Wise Distribution Method :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taPrjCalcMethod
            ID="F_PrjCalcType"
            SelectedValue='<%# Bind("PrjCalcType") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_SanctionedLodging" runat="server" Text="Sanctioned Lodging [Per Day, If any] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SanctionedLodging"
            Text='<%# Bind("SanctionedLodging") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEESanctionedLodging"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SanctionedLodging" />
          <AJX:MaskedEditValidator 
            ID = "MEVSanctionedLodging"
            runat = "server"
            ControlToValidate = "F_SanctionedLodging"
            ControlExtender = "MEESanctionedLodging"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SanctionedDA" runat="server" Text="Sanctioned DA [Per Day, If any] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SanctionedDA"
            Text='<%# Bind("SanctionedDA") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEESanctionedDA"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SanctionedDA" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OOEReasonID" runat="server" Text="OOE Reason ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_taOOEReasons
            ID="F_OOEReasonID"
            SelectedValue='<%# Bind("OOEReasonID") %>'
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
          <asp:Label ID="L_ApprovalWFTypeID" runat="server" Text="Approval WF Type ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_taApprovalWFTypes
            ID="F_ApprovalWFTypeID"
            SelectedValue='<%# Bind("ApprovalWFTypeID") %>'
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
          <asp:Label ID="L_CalculationTypeID" runat="server" Text="Calculation Type ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCalcMethod
            ID="F_CalculationTypeID"
            SelectedValue='<%# Bind("CalculationTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taCH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OOEByAccounts" runat="server" Text="OOE By Accounts :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_OOEByAccounts"
            Checked='<%# Bind("OOEByAccounts") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Setteled" runat="server" Text="Setteled :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Setteled"
            Checked='<%# Bind("Setteled") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OOERemarks" runat="server" Text="Accounts Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OOERemarks"
            Text='<%# Bind("OOERemarks") %>'
            ToolTip="Enter Return Remarks."
            Width="350px"
            CssClass = "mytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ForwardedOn" runat="server" Text="Forwarded To Accounts On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ForwardedOn"
            Text='<%# Bind("ForwardedOn") %>'
            ToolTip="Value of Forwarded To Accounts On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VerifiedBy" runat="server" Text="Received In Accounts By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_VerifiedBy"
            Width="72px"
            Text='<%# Bind("VerifiedBy") %>'
            Enabled = "False"
            ToolTip="Value of Received In Accounts By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_VerifiedBy_Display"
            Text='<%# Eval("HRM_Employees10_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerificationRemarks" runat="server" Text="Last Action  :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VerificationRemarks"
            Text='<%# Bind("VerificationRemarks") %>'
            ToolTip="Value of Last Action ."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VerifiedOn" runat="server" Text="Last Action Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VerifiedOn"
            Text='<%# Bind("VerifiedOn") %>'
            ToolTip="Value of Last Action Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taCH_3"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Approvals</td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="Verified By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            Width="72px"
            Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("HRM_Employees7_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Verified On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ApprovalRemarks" runat="server" Text="Remarks By Verifier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovalRemarks"
            Text='<%# Bind("ApprovalRemarks") %>'
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ApprovedByCC" runat="server" Text="Approved By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedByCC"
            Width="72px"
            Text='<%# Bind("ApprovedByCC") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedByCC_Display"
            Text='<%# Eval("HRM_Employees8_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedByCCOn" runat="server" Text="Approved On  :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedByCCOn"
            Text='<%# Bind("ApprovedByCCOn") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_CCRemarks" runat="server" Text="Remarks By Approver :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CCRemarks"
            Text='<%# Bind("CCRemarks") %>'
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ApprovedBySA" runat="server" Text="Special Approval By Sanctioning Authority :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBySA"
            Width="72px"
            Text='<%# Bind("ApprovedBySA") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBySA_Display"
            Text='<%# Eval("HRM_Employees9_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedBySAOn" runat="server" Text="Special Approval On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedBySAOn"
            Text='<%# Bind("ApprovedBySAOn") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_SARemarks" runat="server" Text="Special Approval Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SARemarks"
            Text='<%# Bind("SARemarks") %>'
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taCH_4"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >ERP Ln Voucher Posting</td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_PostedBy" runat="server" Text="Posted By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PostedBy"
            Width="72px"
            Text='<%# Bind("PostedBy") %>'
            Enabled = "False"
            ToolTip="Value of Posted By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PostedBy_Display"
            Text='<%# Eval("HRM_Employees6_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PostedOn" runat="server" Text="Posted On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PostedOn"
            Text='<%# Bind("PostedOn") %>'
            ToolTip="Value of Posted On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ERPBatchNo" runat="server" Text="ERP Batch No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ERPBatchNo"
            Text='<%# Bind("ERPBatchNo") %>'
            ToolTip="Value of ERP Batch No."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ERPDocumentNo" runat="server" Text="ERP Document No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ERPDocumentNo"
            Text='<%# Bind("ERPDocumentNo") %>'
            ToolTip="Value of ERP Document No."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDFare" runat="server" Text="&nbsp;List: Fare"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDFare" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDFare"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDFare.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "taCDFare"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDFare" runat="server" AssociatedUpdatePanelID="UPNLtaCDFare" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDFare" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDFare" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCDFare"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDFare"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDFareSelectList"
      TypeName = "SIS.TA.taCDFare"
      SelectCountMethod = "taCDFareSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDFare" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDLC" runat="server" Text="&nbsp;List: Local Conveyance Expenses"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDLC" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDLC"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDLC.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "taCDLC"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDLC" runat="server" AssociatedUpdatePanelID="UPNLtaCDLC" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDLC" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDLC" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCDLC"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDLC"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDLCSelectList"
      TypeName = "SIS.TA.taCDLC"
      SelectCountMethod = "taCDLCSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDLC" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDLodging" runat="server" Text="&nbsp;List: Lodging Charges"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDLodging" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDLodging"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDLodging.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCDLodging.aspx"
      EnableExit = "false"
      ValidationGroup = "taCDLodging"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDLodging" runat="server" AssociatedUpdatePanelID="UPNLtaCDLodging" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDLodging" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDLodging" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCDLodging"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDLodging"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDLodgingSelectList"
      TypeName = "SIS.TA.taCDLodging"
      SelectCountMethod = "taCDLodgingSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDLodging" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDExpense" runat="server" Text="&nbsp;List: Other Expenses"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDExpense" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDExpense"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDExpense.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCDExpense.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "taCDExpense"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDExpense" runat="server" AssociatedUpdatePanelID="UPNLtaCDExpense" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDExpense" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDExpense" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCDExpense"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDExpense"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDExpenseSelectList"
      TypeName = "SIS.TA.taCDExpense"
      SelectCountMethod = "taCDExpenseSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDExpense" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDFinance" runat="server" Text="&nbsp;List: Source of Finance"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDFinance" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDFinance"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDFinance.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCDFinance.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "taCDFinance"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDFinance" runat="server" AssociatedUpdatePanelID="UPNLtaCDFinance" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDFinance" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDFinance" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Financed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Acknowledged Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCDFinance"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDFinance"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDFinanceSelectList"
      TypeName = "SIS.TA.taCDFinance"
      SelectCountMethod = "taCDFinanceSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDFinance" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDMileage" runat="server" Text="&nbsp;List: Mileage Claim"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDMileage" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDMileage"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDMileage.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "taCDMileage"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDMileage" runat="server" AssociatedUpdatePanelID="UPNLtaCDMileage" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDMileage" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDMileage" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCDMileage"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDMileage"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDMileageSelectList"
      TypeName = "SIS.TA.taCDMileage"
      SelectCountMethod = "taCDMileageSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDMileage" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDDriver" runat="server" Text="&nbsp;List: Driver Charges"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDDriver" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDDriver"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDDriver.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "taCDDriver"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDDriver" runat="server" AssociatedUpdatePanelID="UPNLtaCDDriver" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDDriver" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDDriver" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCDDriver"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDDriver"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDDriverSelectList"
      TypeName = "SIS.TA.taCDDriver"
      SelectCountMethod = "taCDDriverSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDDriver" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDDA" runat="server" Text="&nbsp;List: Daily Allowance"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDDA" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDDA"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDDA.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCDDA.aspx"
      EnableExit = "false"
      ValidationGroup = "taCDDA"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDDA" runat="server" AssociatedUpdatePanelID="UPNLtaCDDA" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDDA" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDDA" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaCDDA"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDDA"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDDASelectList"
      TypeName = "SIS.TA.taCDDA"
      SelectCountMethod = "taCDDASelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDDA" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaCDAccounts" runat="server" Text="&nbsp;List: Debit / Credit By Accounts"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCDAccounts" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCDAccounts"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCDAccounts.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taCDAccounts.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "taCDAccounts"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCDAccounts" runat="server" AssociatedUpdatePanelID="UPNLtaCDAccounts" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaCDAccounts" SkinID="gv_silver" runat="server" DataSourceID="ODStaCDAccounts" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks for Debit / Credit" SortExpression="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Remarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Debit/Credit Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ApprovedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ApprovedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="ApprovedOn">
          <ItemTemplate>
            <asp:Label ID="LabelApprovedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODStaCDAccounts"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCDAccounts"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCDAccountsSelectList"
      TypeName = "SIS.TA.taCDAccounts"
      SelectCountMethod = "taCDAccountsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCDAccounts" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBillPrjAmounts" runat="server" Text="&nbsp;List: Bill Project wise total"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillPrjAmounts" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillPrjAmounts"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillPrjAmounts.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "taBillPrjAmounts"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillPrjAmounts" runat="server" AssociatedUpdatePanelID="UPNLtaBillPrjAmounts" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript"> 
   var script_Percentage = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVtaBillPrjAmounts" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillPrjAmounts" DataKeyNames="TABillNo,ProjectID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Percentage" SortExpression="Percentage">
          <ItemTemplate>
          <asp:TextBox ID="F_Percentage"
            Text='<%# Bind("Percentage") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
            ValidationGroup='<%# "taBillPrjAmounts" & Container.DataItemIndex %>'
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPercentage"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Percentage" />
          <AJX:MaskedEditValidator 
            ID = "MEVPercentage"
            runat = "server"
            ControlToValidate = "F_Percentage"
            ControlExtender = "MEEPercentage"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "taBillPrjAmounts" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Amount [INR]" SortExpression="TotalAmountinINR">
          <ItemTemplate>
            <asp:Label ID="LabelTotalAmountinINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalAmountinINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Save">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Save record ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODStaBillPrjAmounts"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillPrjAmounts"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBillPrjAmountsSelectList"
      TypeName = "SIS.TA.taBillPrjAmounts"
      SelectCountMethod = "taBillPrjAmountsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBillPrjAmounts" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBillAmount" runat="server" Text="&nbsp;List: Bill Amounts"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillAmount" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillAmount"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillAmount.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "taBillAmount"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillAmount" runat="server" AssociatedUpdatePanelID="UPNLtaBillAmount" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBillAmount" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillAmount" DataKeyNames="TABillNo,ComponentID,CurrencyID,CostCenterID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COMPONENT" SortExpression="TA_Components4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ComponentID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ComponentID") %>' Text='<%# Eval("TA_Components4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CURRENCY" SortExpression="TA_Currencies5_CurrencyName">
          <ItemTemplate>
             <asp:Label ID="L_CurrencyID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("CurrencyID") %>' Text='<%# Eval("TA_Currencies5_CurrencyName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COST CENTER" SortExpression="HRM_Departments1_Description">
          <ItemTemplate>
             <asp:Label ID="L_CostCenterID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("CostCenterID") %>' Text='<%# Eval("HRM_Departments1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TOTAL" SortExpression="TotalInCurrency">
          <ItemTemplate>
            <asp:Label ID="LabelTotalInCurrency" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("TotalInCurrency") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TOTAL [INR]" SortExpression="TotalInINR">
          <ItemTemplate>
            <asp:Label ID="LabelTotalInINR" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("TotalInINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBillAmount"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillAmount"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBillAmountSelectList"
      TypeName = "SIS.TA.taBillAmount"
      SelectCountMethod = "taBillAmountSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBillAmount" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCH"
  DataObjectTypeName = "SIS.TA.taCH"
  SelectMethod = "taCHGetByID"
  UpdateMethod="UZ_taCHUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCH"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TABillNo" Name="TABillNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
