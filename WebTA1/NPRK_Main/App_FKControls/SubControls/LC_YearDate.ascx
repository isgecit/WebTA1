<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_YearDate.ascx.vb" Inherits="LC_YearDate" %>
<asp:UpdatePanel ID="UPNLyearDate" runat="server" >
  <ContentTemplate>
    <table>
      <tr>
        <td>
          <asp:TextBox ID="F_Today"
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="nprkYearDate"
            AutoPostBack="true"
            runat="server" />
          <asp:Image ID="butYearDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEYearDate"
            TargetControlID="F_Today"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="butYearDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEYearDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Today" />
          <AJX:MaskedEditValidator 
            ID = "MEVYearDate"
            runat = "server"
            ControlToValidate = "F_Today"
            ControlExtender = "MEEYearDate"
            EmptyValueBlurredText = "*"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkYearDate"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td>
          <LGM:LC_nprkFinYears
            ID="F_FinYears" 
            OrderBy="FinYear"
            Width="80px"
            DataTextField="FinYear"
            DataValueField="FinYear"
            IncludeDefault="False"
						ValidationGroup = "nprkYearDate"
            autopostback="true"
            RequiredFieldErrorMessage = "*"
            runat="server" />
        </td>
      </tr>
    </table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="F_Today" EventName="TextChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_FinYears" EventName="SelectedIndexChanged" />
  </Triggers>
</asp:UpdatePanel>

