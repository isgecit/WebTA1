<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costProjects.aspx.vb" Inherits="EF_costProjects" title="Edit: Projects" %>
<asp:Content ID="CPHcostProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjects" runat="server" Text="&nbsp;Edit: Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjects" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjects"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "costProjects"
    runat = "server" />
<asp:FormView ID="FVcostProjects"
  runat = "server"
  DataKeyNames = "ProjectID"
  DataSourceID = "ODScostProjects"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectID"
            Text='<%# Bind("ProjectID") %>'
            ToolTip="Value of Project ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="56px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="488px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costProjects"
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
            ValidationGroup = "costProjects"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WorkOrderTypeID" runat="server" Text="Work Order Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
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
            ValidationGroup = "costProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="Division :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
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
            ValidationGroup = "costProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency for Project Value :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
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
            ValidationGroup = "costProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectOrderValue" runat="server" Text="Project Order Value in Selected Currency :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectOrderValue"
            Text='<%# Bind("ProjectOrderValue") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
            ValidationGroup= "costProjects"
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
            ValidationGroup = "costProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectCost" runat="server" Text="Project Cost in Selected Currency :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectCost"
            Text='<%# Bind("ProjectCost") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
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
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CFforPOV" runat="server" Text="Conversion Factor [INR] :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CFforPOV"
            Text='<%# Bind("CFforPOV") %>'
            style="text-align: right"
            Width="120px"
            CssClass = "mytxt"
            ValidationGroup= "costProjects"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECFforPOV"
            runat = "server"
            mask = "99999999.9999"
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
            ValidationGroup = "costProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectOrderValueINR" runat="server" Text="Project Order Value INR :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:Label ID="F_ProjectOrderValueINR"
            Text='<%# Bind("ProjectOrderValueINR") %>'
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectCostINR" runat="server" Text="Project Cost INR :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:Label ID="F_ProjectCostINR"
            Text='<%# Bind("ProjectCostINR") %>'
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WarrantyPercentage" runat="server" Text="Warranty Percentage [INR] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WarrantyPercentage"
            Text='<%# Bind("WarrantyPercentage") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
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
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MarginCurrentYear" runat="server" Text="Margin Current Year in Selected Currency :" />&nbsp;
        </td>
        <td colspan="3">
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
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MarginCurrentYearINR" runat="server" Text="Margin Current Year INR :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:Label ID="F_MarginCurrentYearINR"
            Text='<%# Bind("MarginCurrentYearINR") %>'
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
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
  ID = "ODScostProjects"
  DataObjectTypeName = "SIS.COST.costProjects"
  SelectMethod = "costProjectsGetByID"
  UpdateMethod="UZ_costProjectsUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjects"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
