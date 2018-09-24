<%@ Page Language="VB" AutoEventWireup="false" CodeFile="temp.aspx.vb" Inherits="TA_Main_App_Create_temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="SHORTCUT ICON" type="image/x-icon" runat="server" href="~/isgec.ico" />
  <link rel="stylesheet" href="/../UserRights/Menu/Menu.css" />
  <script type="text/javascript" src="/../UserRights/jquery/jquery.js"></script>
  <link rel="stylesheet" href="/../UserRights/jquery/themes/smoothness/jquery-ui.css" />
  <script type="text/javascript" src="/../UserRights/jquery/jquery-ui.js"></script>
  <script type="text/javascript">
    $(function () {
      $(".page").resizable();
    });
  </script>

</head>
<body>
    <form id="form1" runat="server">
  <ASP:ScriptManager ID="ToolkitScriptManager1" EnableScriptGlobalization="true" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="3600" EnableScriptLocalization="True" ScriptMode="Auto">
    <Scripts>
        <asp:ScriptReference Path="/../UserRights/jquery/webkit.js" />
    </Scripts>
  </ASP:ScriptManager>
    <div>
        <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td>
          <b><asp:Label ID="L_TABillNo" ForeColor="#CC6633" runat="server" Text="TA Bill No" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TABillNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("TABillNo") %>'
            AutoCompleteType = "None"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td>
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      </table>
      <table>
        <tr>
        <td>
          <asp:Label ID="L_City1Text" runat="server" Text="From Place" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:Label ID="L_City2Text" runat="server" Text="To Place" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:Label ID="L_Date1Time" runat="server" Text="Date" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:Label ID="L_ModeLCID" runat="server" Text="Mode" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_ModeText" runat="server" Text="Other Mode" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_AirportToHotel" runat="server" Text="Airport To Hotel" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_AirportToClientLocation" runat="server" Text="Airport To Client Location" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_HotelToAirport" runat="server" Text="Hotel To Airport" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_AmountRateOU" runat="server" Text="Claimed Amount" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency*" />
        </td>
        <td>
          <asp:Label ID="L_CurrencyMain" runat="server" Text="Main Currency of TA Bill" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_ConversionFactorOU" runat="server" Text="Conversion Factor Main Currency" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks" />&nbsp;
        </td>

        </tr>
        <tr>
        <td>
          <asp:TextBox ID="F_City1Text"
            Text='<%# Bind("City1Text") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBDLC"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for From Place."
            MaxLength="100"
            Width="50px" 
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCity1Text"
            runat = "server"
            ControlToValidate = "F_City1Text"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDLC"
            SetFocusOnError="true" />
        </td>
        <td>
          <asp:TextBox ID="F_City2Text"
            Text='<%# Bind("City2Text") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBDLC"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for To Place."
            MaxLength="100"
            Width="50px" 
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCity2Text"
            runat = "server"
            ControlToValidate = "F_City2Text"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDLC"
            SetFocusOnError="true" />
        </td>
        <td>
          <asp:TextBox ID="F_Date1Time"
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taBDLC"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonDate1Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate1Time"
            TargetControlID="F_Date1Time"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate1Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate1Time"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Date1Time" />
          <AJX:MaskedEditValidator 
            ID = "MEVDate1Time"
            runat = "server"
            ControlToValidate = "F_Date1Time"
            ControlExtender = "MEEDate1Time"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDLC"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td>
          <LGM:LC_taLCModes
            ID="F_ModeLCID"
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="50px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td>
          <asp:TextBox ID="F_ModeText"
            Text='<%# Bind("ModeText") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Conveyance Mode [ If not found in List ]."
            MaxLength="100"
            Width="50px" 
            runat="server" />
        </td>
        <td>
          <asp:CheckBox ID="F_AirportToHotel"
           CssClass = "mychk"
           runat="server" />
        </td>
        <td>
          <asp:CheckBox ID="F_AirportToClientLocation"
           CssClass = "mychk"
           runat="server" />
        </td>
        <td>
          <asp:CheckBox ID="F_HotelToAirport"
           CssClass = "mychk"
           runat="server" />
        </td>
        <td>
          <asp:TextBox ID="F_AmountRateOU"
            Text='<%# Bind("AmountRateOU") %>'
            Width="88px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmountRateOU"
            runat = "server"
            mask = "99999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_AmountRateOU" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmountRateOU"
            runat = "server"
            ControlToValidate = "F_AmountRateOU"
            ControlExtender = "MEEAmountRateOU"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
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
            Width="50px"
            CssClass="myddl"
            ValidationGroup = "taBDLC"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td>
          <asp:Label ID="F_CurrencyMain"
            Text='<%# Bind("CurrencyMain") %>'
            Width="88px"
            CssClass = "mytxt"
            runat="server" />
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorOU"
            Text='<%# Bind("ConversionFactorOU") %>'
            style="text-align: right"
            Width="100px"
            CssClass = "mytxt"
            ValidationGroup= "taBDLC"
            MaxLength="13"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEConversionFactorOU"
            runat = "server"
            mask = "999999.999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ConversionFactorOU" />
          <AJX:MaskedEditValidator 
            ID = "MEVConversionFactorOU"
            runat = "server"
            ControlToValidate = "F_ConversionFactorOU"
            ControlExtender = "MEEConversionFactorOU"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBDLC"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="50px" 
            runat="server" />
        </td>

        </tr>
      </table>

    </div>
    </form>
</body>
</html>
