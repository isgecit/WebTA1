<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkEmployees.aspx.vb" Inherits="AF_nprkEmployees" title="Add: Perks Employees" %>
<asp:Content ID="CPHnprkEmployees" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkEmployees" runat="server" Text="&nbsp;Add: Perks Employees"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkEmployees" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkEmployees"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "nprkEmployees"
    runat = "server" />
<asp:FormView ID="FVnprkEmployees"
  runat = "server"
  DataKeyNames = "EmployeeID"
  DataSourceID = "ODSnprkEmployees"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkEmployees" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_EmployeeID" ForeColor="#CC6633" runat="server" Text="Employee ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EmployeeID"
            Text='<%# Bind("EmployeeID") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="nprkEmployees"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEmployeeID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_EmployeeID" />
          <AJX:MaskedEditValidator 
            ID = "MEVEmployeeID"
            runat = "server"
            ControlToValidate = "F_EmployeeID"
            ControlExtender = "MEEEmployeeID"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkEmployees"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CardNo" runat="server" Text="Card No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CardNo"
            Text='<%# Bind("CardNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkEmployees"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Card No."
            MaxLength="8"
            Width="72px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCardNo"
            runat = "server"
            ControlToValidate = "F_CardNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkEmployees"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EmployeeName" runat="server" Text="Employee Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EmployeeName"
            Text='<%# Bind("EmployeeName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkEmployees"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Employee Name."
            MaxLength="40"
            Width="328px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVEmployeeName"
            runat = "server"
            ControlToValidate = "F_EmployeeName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkEmployees"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" /><span style="color:red">*</span>
        </td>
        <td>
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
            ValidationGroup = "nprkEmployees"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_Basic" runat="server" Text="Basic :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Basic"
            Text='<%# Bind("Basic") %>'
            Width="104px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="nprkEmployees"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEBasic"
            runat = "server"
            mask = "9999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Basic" />
          <AJX:MaskedEditValidator 
            ID = "MEVBasic"
            runat = "server"
            ControlToValidate = "F_Basic"
            ControlExtender = "MEEBasic"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkEmployees"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DOJ" runat="server" Text="DOJ :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DOJ"
            Text='<%# Bind("DOJ") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="nprkEmployees"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonDOJ" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDOJ"
            TargetControlID="F_DOJ"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDOJ" />
          <AJX:MaskedEditExtender 
            ID = "MEEDOJ"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DOJ" />
          <AJX:MaskedEditValidator 
            ID = "MEVDOJ"
            runat = "server"
            ControlToValidate = "F_DOJ"
            ControlExtender = "MEEDOJ"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkEmployees"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DOR" runat="server" Text="DOR :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DOR"
            Text='<%# Bind("DOR") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonDOR" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDOR"
            TargetControlID="F_DOR"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDOR" />
          <AJX:MaskedEditExtender 
            ID = "MEEDOR"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DOR" />
          <AJX:MaskedEditValidator 
            ID = "MEVDOR"
            runat = "server"
            ControlToValidate = "F_DOR"
            ControlExtender = "MEEDOR"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PostedAt" runat="server" Text="Posted At :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:DropDownList
            ID="F_PostedAt"
            SelectedValue='<%# Bind("PostedAt") %>'
            Width="200px"
            ValidationGroup = "nprkEmployees"
            CssClass = "myddl"
            Runat="Server" >
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
            ValidationGroup = "nprkEmployees"
            SetFocusOnError="true" />
         </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleType" runat="server" Text="Vehicle Type :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:DropDownList
            ID="F_VehicleType"
            SelectedValue='<%# Bind("VehicleType") %>'
            Width="200px"
            ValidationGroup = "nprkEmployees"
            CssClass = "myddl"
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
            ValidationGroup = "nprkEmployees"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaintenanceAllowed" runat="server" Text="Maintenance Allowed :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_MaintenanceAllowed"
           Checked='<%# Bind("MaintenanceAllowed") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TWInSalary" runat="server" Text="TW In Salary :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_TWInSalary"
           Checked='<%# Bind("TWInSalary") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ESI" runat="server" Text="ESI :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ESI"
           Checked='<%# Bind("ESI") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label3" runat="server" Text="DO NOT GENRATE ENTITLEMENT :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Active"
           Checked='<%# Bind("Active") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Department" runat="server" Text="Department :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Department"
            Text='<%# Bind("Department") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Department."
            MaxLength="30"
            Width="248px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Company" runat="server" Text="Company :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Company"
            Text='<%# Bind("Company") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Company."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MobileLimit" runat="server" Text="MobileLimit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MobileLimit"
            Text='<%# Bind("MobileLimit") %>'
            Width="72px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEMobileLimit"
            runat = "server"
            mask = "99999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MobileLimit" />
          <AJX:MaskedEditValidator 
            ID = "MEVMobileLimit"
            runat = "server"
            ControlToValidate = "F_MobileLimit"
            ControlExtender = "MEEMobileLimit"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MobileWithInternet" runat="server" Text="MobileWithInternet :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_MobileWithInternet"
           Checked='<%# Bind("MobileWithInternet") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MobileBillPlanID" runat="server" Text="MobileBillPlanID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_nprkMobileBillPlans
            ID="F_MobileBillPlanID"
            SelectedValue='<%# Bind("MobileBillPlanID") %>'
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
          <asp:Label ID="L_LandlineLimit" runat="server" Text="LandlineLimit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_LandlineLimit"
            Text='<%# Bind("LandlineLimit") %>'
            Width="72px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEELandlineLimit"
            runat = "server"
            mask = "99999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_LandlineLimit" />
          <AJX:MaskedEditValidator 
            ID = "MEVLandlineLimit"
            runat = "server"
            ControlToValidate = "F_LandlineLimit"
            ControlExtender = "MEELandlineLimit"
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
          <asp:Label ID="Label1" runat="server" Text="Vehicle Owned By Employee :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_VehicleOwnedByEmployee"
            Checked='<%# Bind("VehicleOwnedByEmployee") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label2" runat="server" Text="With Driver :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_WithDriver"
            Checked='<%# Bind("WithDriver") %>'
            CssClass = "mychk"
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
  ID = "ODSnprkEmployees"
  DataObjectTypeName = "SIS.NPRK.nprkEmployees"
  InsertMethod="UZ_nprkEmployeesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkEmployees"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
