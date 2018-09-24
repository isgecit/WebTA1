<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costQProjects.aspx.vb" Inherits="EF_costQProjects" title="Edit: Quarter Projects" %>
<asp:Content ID="CPHcostQProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostQProjects" runat="server" Text="&nbsp;Edit: Quarter Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostQProjects" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostQProjects"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costQProjects"
    runat = "server" />
<asp:FormView ID="FVcostQProjects"
  runat = "server"
  DataKeyNames = "ProjectID,FinYear,Quarter"
  DataSourceID = "ODScostQProjects"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="488px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costQProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="60"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            SetFocusOnError="true" />
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
            Text='<%# Eval("COST_FinYear2_Descpription") %>'
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
            Text='<%# Eval("COST_Quarters4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectTypeID" runat="server" Text="Project Type ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_costProjectTypes
            ID="F_ProjectTypeID"
            SelectedValue='<%# Bind("ProjectTypeID") %>'
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
          <asp:Label ID="L_WorkOrderTypeID" runat="server" Text="Work Order Type ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_costWorkOrderTypes
            ID="F_WorkOrderTypeID"
            SelectedValue='<%# Bind("WorkOrderTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costQProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="Division ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_costDivisions
            ID="F_DivisionID"
            SelectedValue='<%# Bind("DivisionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costQProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costQProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CFforPOV" runat="server" Text="Conversion Factor :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CFforPOV"
            Text='<%# Bind("CFforPOV") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "costQProjects"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECFforPOV"
            runat = "server"
            mask = "99999999.999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CFforPOV" />
          <AJX:MaskedEditValidator 
            ID = "MEVCFforPOV"
            runat = "server"
            ControlToValidate = "F_CFforPOV"
            ControlExtender = "MEECFforPOV"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectOrderValue" runat="server" Text="Project Order Value :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ProjectOrderValue"
            Text='<%# Bind("ProjectOrderValue") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
            ValidationGroup= "costQProjects"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectOrderValue"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectOrderValue" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectOrderValue"
            runat = "server"
            ControlToValidate = "F_ProjectOrderValue"
            ControlExtender = "MEEProjectOrderValue"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectOrderValueINR" runat="server" Text="Projec tOrder Value [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectOrderValueINR"
            Text='<%# Bind("ProjectOrderValueINR") %>'
            ToolTip="Value of Projec tOrder Value [INR]."
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
          <asp:Label ID="L_ProjectCost" runat="server" Text="Project Cost :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ProjectCost"
            Text='<%# Bind("ProjectCost") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
            ValidationGroup= "costQProjects"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectCost"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectCost" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectCost"
            runat = "server"
            ControlToValidate = "F_ProjectCost"
            ControlExtender = "MEEProjectCost"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectCostINR" runat="server" Text="Projec Cost [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectCostINR"
            Text='<%# Bind("ProjectCostINR") %>'
            ToolTip="Value of Projec Cost [INR]."
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
          <asp:Label ID="L_MarginCurrentYear" runat="server" Text="Margin Current Year :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MarginCurrentYear"
            Text='<%# Bind("MarginCurrentYear") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEMarginCurrentYear"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MarginCurrentYear" />
          <AJX:MaskedEditValidator 
            ID = "MEVMarginCurrentYear"
            runat = "server"
            ControlToValidate = "F_MarginCurrentYear"
            ControlExtender = "MEEMarginCurrentYear"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MarginCurrentYearINR" runat="server" Text="Margin Current Year [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MarginCurrentYearINR"
            Text='<%# Bind("MarginCurrentYearINR") %>'
            ToolTip="Value of Margin Current Year [INR]."
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
          <asp:Label ID="L_WarrantyPercentage" runat="server" Text="Warranty Percentage :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WarrantyPercentage"
            Text='<%# Bind("WarrantyPercentage") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
            ValidationGroup= "costQProjects"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEWarrantyPercentage"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_WarrantyPercentage" />
          <AJX:MaskedEditValidator 
            ID = "MEVWarrantyPercentage"
            runat = "server"
            ControlToValidate = "F_WarrantyPercentage"
            ControlExtender = "MEEWarrantyPercentage"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostQProjects"
  DataObjectTypeName = "SIS.COST.costQProjects"
  SelectMethod = "costQProjectsGetByID"
  UpdateMethod="UZ_costQProjectsUpdate"
  DeleteMethod="UZ_costQProjectsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costQProjects"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
