<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_ReportTPTBill.aspx.vb" Inherits="GF_ReportTPTBill" title="Transporter Bill Report" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgDMisg" runat="server" Text="&nbsp;Report: Transporter Bill" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <asp:UpdateProgress ID="UPGSlgDMisg" runat="server" AssociatedUpdatePanelID="UPNLlgDMisg" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
       }
       function script_download(fd, td, typ) {
       	pcnt = pcnt + 1;
       	var nam = 'wdwd' + pcnt;
       	var url = self.location.href.replace('App_Forms/GF_ReportTPTBill.aspx', 'App_Downloads/RP_ReportTPTBill.aspx');
       	url = url + '?fd=' + $get(fd).value + '&td=' + $get(td).value + '&typ=' + $get(typ).value;
       	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
       	return false;
       }
    </script>
    <br />
    <br />
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FromDate" runat="server" Text="From Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FromDate"
						Text='<%# Bind("FromDate") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="ProductivityReport"
						runat="server" />
          <AJX:CalendarExtender 
            ID = "CEFromDate"
            TargetControlID="F_FromDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFromDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEFromDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_FromDate" />
					<asp:Image ID="ImageButtonFromDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
					<AJX:MaskedEditValidator 
						ID = "MEVFromDate"
						runat = "server"
						ControlToValidate = "F_FromDate"
						ControlExtender = "MEEFromDate"
						InvalidValueMessage = "Invalid value for From Date."
						EmptyValueMessage = "From Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for From Date."
						EnableClientScript = "true"
						ValidationGroup = "ProductivityReport"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ToDate" runat="server" Text="To Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ToDate"
						Text='<%# Bind("ToDate") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="ProductivityReport"
						runat="server" />
          <AJX:CalendarExtender 
            ID = "CEToDate"
            TargetControlID="F_ToDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonToDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEToDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ToDate" />
					<asp:Image ID="ImageButtonToDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
					<AJX:MaskedEditValidator 
						ID = "MEVToDate"
						runat = "server"
						ControlToValidate = "F_ToDate"
						ControlExtender = "MEEToDate"
						InvalidValueMessage = "Invalid value To Date."
						EmptyValueMessage = "To Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for To Date."
						EnableClientScript = "true"
						ValidationGroup = "ProductivityReport"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
				</tr>
				<tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" runat="server" Text="Bill Status :" /></b>
				</td>
					<td>
          <LGM:LC_erpTPTBillStatus
            ID="F_BillStatus"
            OrderBy="Sequence"
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
				<td colspan="2">
					<input type="button" onclick="return script_download('<%= F_FromDate.ClientID %>','<%= F_ToDate.ClientID %>','<%= F_BillStatus.LCClientID %>');" value=" Download " />
				</td>
			</tr>
    </table>
  </td></tr></table>
  </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>
