<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_DrawingList.aspx.vb" Inherits="GF_DrawingList" title="List: Drawing" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgDMisg" runat="server" Text="&nbsp;List: BaaN Document" Width="100%" CssClass="sis_formheading"></asp:Label>
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
       function script_download(fprj, tprj,pfix) {
       	pcnt = pcnt + 1;
       	var nam = 'wdwd' + pcnt;
       	var url = self.location.href.replace('App_Forms/GF_DrawingList.aspx', 'App_Download/DocumentList.aspx');
       	url = url + '?fprj=' + $get(fprj).value + '&tprj=' + $get(tprj).value + '&fdt=' + $get('<%= F_FromDate.ClientID %>').value + '&tdt=' + $get('<%= F_ToDate.ClientID %>').value + '&pfix=' + $get(pfix).value;
       	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
       	return false;
       }
    </script>

    <br />
    <br />
    <table>
			<tr>
				<td>From Project ID
				</td>
				<td><input type="text" id="F_ProjectID" maxlength="6" style="width: 76px; text-transform:uppercase" class="mytxt" />
				</td>
			</tr>
			
			<tr>
				<td>To Project ID
				</td>
				<td><input type="text" id="T_ProjectID" maxlength="6" style="width: 76px; text-transform:uppercase" class="mytxt" />
				</td>
			</tr>
    	<tr>
				<td class="alignright">
					<b>
					<asp:Label ID="L_FromDate" runat="server" Text="From Date :" />
					</b>
				</td>
				<td>
					<asp:TextBox ID="F_FromDate" runat="server" CssClass="mytxt" onfocus="return this.select();" Text='<%# Bind("FromDate") %>' ValidationGroup="ProductivityReport" Width="70px" />
					<AJX:CalendarExtender ID="CEFromDate" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="ImageButtonFromDate" TargetControlID="F_FromDate" />
					<AJX:MaskedEditExtender ID="MEEFromDate" runat="server" CultureName="en-GB" ErrorTooltipEnabled="true" InputDirection="LeftToRight" mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="F_FromDate" />
					<asp:Image ID="ImageButtonFromDate" runat="server" ImageUrl="~/Images/cal.png" style="cursor: pointer; vertical-align:bottom" ToolTip="Click to open calendar" />
					<AJX:MaskedEditValidator ID="MEVFromDate" runat="server" ControlExtender="MEEFromDate" ControlToValidate="F_FromDate" Display="Dynamic" EmptyValueBlurredText="[Required!]" EmptyValueMessage="From Date is required." EnableClientScript="true" InvalidValueMessage="Invalid value for From Date." IsValidEmpty="false" SetFocusOnError="true" TooltipMessage="Enter value for From Date." ValidationGroup="ProductivityReport" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b>
					<asp:Label ID="L_ToDate" runat="server" Text="To Date :" />
					</b>
				</td>
				<td>
					<asp:TextBox ID="F_ToDate" runat="server" CssClass="mytxt" onfocus="return this.select();" Text='<%# Bind("ToDate") %>' ValidationGroup="ProductivityReport" Width="70px" />
					<AJX:CalendarExtender ID="CEToDate" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="ImageButtonToDate" TargetControlID="F_ToDate" />
					<AJX:MaskedEditExtender ID="MEEToDate" runat="server" CultureName="en-GB" ErrorTooltipEnabled="true" InputDirection="LeftToRight" mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="F_ToDate" />
					<asp:Image ID="ImageButtonToDate" runat="server" ImageUrl="~/Images/cal.png" style="cursor: pointer; vertical-align:bottom" ToolTip="Click to open calendar" />
					<AJX:MaskedEditValidator ID="MEVToDate" runat="server" ControlExtender="MEEToDate" ControlToValidate="F_ToDate" Display="Dynamic" EmptyValueBlurredText="[Required!]" EmptyValueMessage="To Date is required." EnableClientScript="true" InvalidValueMessage="Invalid value To Date." IsValidEmpty="false" SetFocusOnError="true" TooltipMessage="Enter value for To Date." ValidationGroup="ProductivityReport" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b>
					<asp:Label ID="Label1" runat="server" Text="Project Prefix :" />
					</b>
				</td>
				<td>
					<input type="text" id="F_Prefix"  style="width: 76px; text-transform:uppercase" class="mytxt" value="SG,SE,JS,SS" />
				</td>
			</tr>
			<tr>
				<td colspan="2">
					<input type="button" onclick="return script_download('F_ProjectID','T_ProjectID','F_Prefix');" value=" Download " />
				</td>
			</tr>
    </table>
  </td></tr></table>
  </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>
