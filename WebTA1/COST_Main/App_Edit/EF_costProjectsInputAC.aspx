<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costProjectsInputAC.aspx.vb" Inherits="EF_costProjectsInputAC" title="Edit: Projects Input Data" %>
<asp:Content ID="CPHcostProjectsInputAC" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectsInputAC" runat="server" Text="&nbsp;Edit: Projects Input Data"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectsInputAC" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectsInputAC"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "costProjectsInputAC"
    runat = "server" />
<asp:FormView ID="FVcostProjectsInputAC"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter"
  DataSourceID = "ODScostProjectsInputAC"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectGroupID"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project Group ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups4_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            Width="88px"
            Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("COST_ProjectInputStatus5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear3_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Quarter."
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyGOV" runat="server" Text="Currency [Total Order Value] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CurrencyGOV"
            Width="56px"
            Text='<%# Bind("CurrencyGOV") %>'
            Enabled = "False"
            ToolTip="Value of Currency [Total Order Value]."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CurrencyGOV_Display"
            Text='<%# Eval("TA_Currencies8_CurrencyName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GroupOrderValue" runat="server" Text="Total Order Value :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GroupOrderValue"
            Text='<%# Bind("GroupOrderValue") %>'
            ToolTip="Value of Total Order Value."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CFforGOV" runat="server" Text="Conversion Factor [Total Order Value] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CFforGOV"
            Text='<%# Bind("CFforGOV") %>'
            ToolTip="Value of Conversion Factor [Total Order Value]."
            Enabled = "False"
            Width="120px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GroupOrderValueINR" runat="server" Text="Total Order Value [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GroupOrderValueINR"
            Text='<%# Bind("GroupOrderValueINR") %>'
            ToolTip="Value of Total Order Value [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyPR" runat="server" Text="Currency for Project Input :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CurrencyPR"
            Width="56px"
            Text='<%# Bind("CurrencyPR") %>'
            Enabled = "False"
            ToolTip="Value of Currency for Project Input."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CurrencyPR_Display"
            Text='<%# Eval("TA_Currencies9_CurrencyName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CFforPR" runat="server" Text="Conversion Factor [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CFforPR"
            Text='<%# Bind("CFforPR") %>'
            ToolTip="Value of Conversion Factor [INR]."
            Enabled = "False"
            Width="120px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectRevenue" runat="server" Text="Project Revenue :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectRevenue"
            Text='<%# Bind("ProjectRevenue") %>'
            ToolTip="Value of Project Revenue."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectRevenueINR" runat="server" Text="Project Revenue [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectRevenueINR"
            Text='<%# Bind("ProjectRevenueINR") %>'
            ToolTip="Value of Project Revenue [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectMargin" runat="server" Text="Project Margin :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectMargin"
            Text='<%# Bind("ProjectMargin") %>'
            ToolTip="Value of Project Margin."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectMarginINR" runat="server" Text="Project Margin [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectMarginINR"
            Text='<%# Bind("ProjectMarginINR") %>'
            ToolTip="Value of Project Margin [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ExportIncentive" runat="server" Text="Export Incentive :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ExportIncentive"
            Text='<%# Bind("ExportIncentive") %>'
            ToolTip="Value of Export Incentive."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ExportIncentiveINR" runat="server" Text="Export Incentive [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ExportIncentiveINR"
            Text='<%# Bind("ExportIncentiveINR") %>'
            ToolTip="Value of Export Incentive [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
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
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
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
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverRemarks" runat="server" Text="Approver Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            ToolTip="Value of Approver Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            Width="72px"
            Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            ToolTip="Value of Approved By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            ToolTip="Value of Approved On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyPRByAC" runat="server" Text="Currency for Project Input By AC :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_CurrencyPRByAC"
            SelectedValue='<%# Bind("CurrencyPRByAC") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costProjectsInputAC"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_CFforPRByAC" runat="server" Text="Conversion Factor for Project Input By AC :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CFforPRByAC"
            Text='<%# Bind("CFforPRByAC") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
            ValidationGroup= "costProjectsInputAC"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECFforPRByAC"
            runat = "server"
            mask = "99999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CFforPRByAC" />
          <AJX:MaskedEditValidator 
            ID = "MEVCFforPRByAC"
            runat = "server"
            ControlToValidate = "F_CFforPRByAC"
            ControlExtender = "MEECFforPRByAC"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInputAC"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectRevenueByAC" runat="server" Text="Project Revenue By AC :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ProjectRevenueByAC"
            Text='<%# Bind("ProjectRevenueByAC") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "costProjectsInputAC"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectRevenueByAC"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectRevenueByAC" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectRevenueByAC"
            runat = "server"
            ControlToValidate = "F_ProjectRevenueByAC"
            ControlExtender = "MEEProjectRevenueByAC"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInputAC"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectRevenueByACINR" runat="server" Text="Project Revenue By AC [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectRevenueByACINR"
            Text='<%# Bind("ProjectRevenueByACINR") %>'
            ToolTip="Value of Project Revenue By AC [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectMarginByAC" runat="server" Text="Project Margin By AC :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ProjectMarginByAC"
            Text='<%# Bind("ProjectMarginByAC") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "costProjectsInputAC"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectMarginByAC"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectMarginByAC" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectMarginByAC"
            runat = "server"
            ControlToValidate = "F_ProjectMarginByAC"
            ControlExtender = "MEEProjectMarginByAC"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInputAC"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectMarginByACINR" runat="server" Text="Project Margin By AC [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectMarginByACINR"
            Text='<%# Bind("ProjectMarginByACINR") %>'
            ToolTip="Value of Project Margin By AC [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ExportIncentiveByAC" runat="server" Text="Export Incentive By AC :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ExportIncentiveByAC"
            Text='<%# Bind("ExportIncentiveByAC") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEExportIncentiveByAC"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ExportIncentiveByAC" />
          <AJX:MaskedEditValidator 
            ID = "MEVExportIncentiveByAC"
            runat = "server"
            ControlToValidate = "F_ExportIncentiveByAC"
            ControlExtender = "MEEExportIncentiveByAC"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ExportIncentiveByACINR" runat="server" Text="Export Incentive By AC [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ExportIncentiveByACINR"
            Text='<%# Bind("ExportIncentiveByACINR") %>'
            ToolTip="Value of Export Incentive By AC [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CFforBalanceCalculationByAC" runat="server" Text="Conversion Factor for Balance Calculation in Cost Sheet :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CFforBalanceCalculationByAC"
            Text='<%# Bind("CFforBalanceCalculationByAC") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
            ValidationGroup= "costProjectsInputAC"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECFforBalanceCalculationByAC"
            runat = "server"
            mask = "99999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CFforBalanceCalculationByAC" />
          <AJX:MaskedEditValidator 
            ID = "MEVCFforBalanceCalculationByAC"
            runat = "server"
            ControlToValidate = "F_CFforBalanceCalculationByAC"
            ControlExtender = "MEECFforBalanceCalculationByAC"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectsInputAC"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReceiverRemarks" runat="server" Text="Receiver Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ReceiverRemarks"
            Text='<%# Bind("ReceiverRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Receiver Remarks."
            MaxLength="250"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReceivedBy" runat="server" Text="Received By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceivedBy"
            Width="72px"
            Text='<%# Bind("ReceivedBy") %>'
            Enabled = "False"
            ToolTip="Value of Received By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ReceivedBy_Display"
            Text='<%# Eval("aspnet_users7_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ReceivedOn" runat="server" Text="Received On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReceivedOn"
            Text='<%# Bind("ReceivedOn") %>'
            ToolTip="Value of Received On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelcostProjectInputFiles" runat="server" Text="&nbsp;List: Project Input Attachment"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectInputFiles" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostProjectInputFiles"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costProjectInputFiles.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "costProjectInputFiles"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostProjectInputFiles" runat="server" AssociatedUpdatePanelID="UPNLcostProjectInputFiles" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostProjectInputFiles" SkinID="gv_silver" runat="server" DataSourceID="ODScostProjectInputFiles" DataKeyNames="ProjectGroupID,FinYear,Quarter,SerialNo">
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
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Name" SortExpression="FileName">
          <ItemTemplate>
            <asp:Label ID="LabelFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileName") %>'></asp:Label>
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
      ID = "ODScostProjectInputFiles"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costProjectInputFiles"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costProjectInputFilesSelectList"
      TypeName = "SIS.COST.costProjectInputFiles"
      SelectCountMethod = "costProjectInputFilesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="Text" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="Text" Name="Quarter" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostProjectInputFiles" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostProjectsInputAC"
  DataObjectTypeName = "SIS.COST.costProjectsInputAC"
  SelectMethod = "costProjectsInputACGetByID"
  UpdateMethod="UZ_costProjectsInputACUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectsInputAC"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
