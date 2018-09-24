<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkRules.aspx.vb" Inherits="EF_nprkRules" title="Edit: Perk Rules" %>
<asp:Content ID="CPHnprkRules" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkRules" runat="server" Text="&nbsp;Edit: Perk Rules"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkRules" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkRules"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkRules"
    runat = "server" />
<asp:FormView ID="FVnprkRules"
  runat = "server"
  DataKeyNames = "RuleID"
  DataSourceID = "ODSnprkRules"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RuleID" runat="server" ForeColor="#CC6633" Text="Rule ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RuleID"
            Text='<%# Bind("RuleID") %>'
            ToolTip="Value of Rule ID."
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
          <asp:Label ID="L_PerkID" runat="server" Text="Perk Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_nprkPerks
            ID="F_PerkID"
            SelectedValue='<%# Bind("PerkID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkRules"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryID" runat="server" Text="Category :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_nprkCategories
            ID="F_CategoryID"
            SelectedValue='<%# Bind("CategoryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkRules"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EffectiveDate" runat="server" Text="Effective Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EffectiveDate"
            Text='<%# Bind("EffectiveDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkRules"
            runat="server" />
          <asp:Image ID="ImageButtonEffectiveDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEEffectiveDate"
            TargetControlID="F_EffectiveDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonEffectiveDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEEffectiveDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_EffectiveDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVEffectiveDate"
            runat = "server"
            ControlToValidate = "F_EffectiveDate"
            ControlExtender = "MEEEffectiveDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkRules"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PercentageOfBasic" runat="server" Text="Percentage Of Basic :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_PercentageOfBasic"
            Checked='<%# Bind("PercentageOfBasic") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Percentage" runat="server" Text="Percentage :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Percentage"
            Text='<%# Bind("Percentage") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPercentage"
            runat = "server"
            mask = "999999.99"
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
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FixedValue" runat="server" Text="Fixed Value :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FixedValue"
            Text='<%# Bind("FixedValue") %>'
            style="text-align: right"
            Width="104px"
            CssClass = "mytxt"
            ValidationGroup= "nprkRules"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEFixedValue"
            runat = "server"
            mask = "9999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FixedValue" />
          <AJX:MaskedEditValidator 
            ID = "MEVFixedValue"
            runat = "server"
            ControlToValidate = "F_FixedValue"
            ControlExtender = "MEEFixedValue"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkRules"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PostedAt" runat="server" Text="Posted At :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_PostedAt"
            SelectedValue='<%# Bind("PostedAt") %>'
            CssClass = "myddl"
            Width="200px"
            ValidationGroup = "nprkRules"
            Runat="Server" >
            <asp:ListItem Value="None">None</asp:ListItem>
            <asp:ListItem Value="Office">Office</asp:ListItem>
            <asp:ListItem Value="Site">Site</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVPostedAt"
            runat = "server"
            ControlToValidate = "F_PostedAt"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkRules"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VehicleType" runat="server" Text="Vehicle Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_VehicleType"
            SelectedValue='<%# Bind("VehicleType") %>'
            CssClass = "myddl"
            Width="200px"
            ValidationGroup = "nprkRules"
            Runat="Server" >
            <asp:ListItem Value="None">None</asp:ListItem>
            <asp:ListItem Value="Car">Car</asp:ListItem>
            <asp:ListItem Value="TwoWheeler">TwoWheeler</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVVehicleType"
            runat = "server"
            ControlToValidate = "F_VehicleType"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkRules"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InSalary" runat="server" Text="In Salary :" />&nbsp;
        </td>
        <td >
          <asp:CheckBox ID="F_InSalary"
           Checked='<%# Bind("InSalary") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label3" runat="server" Text="With Driver :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_WithDriver"
            Checked='<%# Bind("WithDriver") %>'
            CssClass = "mychk"
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
  ID = "ODSnprkRules"
  DataObjectTypeName = "SIS.NPRK.nprkRules"
  SelectMethod = "nprkRulesGetByID"
  UpdateMethod="nprkRulesUpdate"
  DeleteMethod="nprkRulesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkRules"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RuleID" Name="RuleID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
