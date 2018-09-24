<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_clpReport.aspx.vb" Inherits="GF_clpReport" title="CLP Report" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
<style type = "text/css" >
.grpHD{
  color:#000000;
    font-size:12px;

 }
.colHD{background-color:silver;
  border: 1pt solid #333333;
  color:#000000;
  font-size:12px;
}
.rowHD
{  font-family: Tahoma;
  font-size:11px;
  border: solid 1pt black;
  }
  .rowHD:hover
  {
  	background-color:Yellow;
  }
</style>

<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgDMisg" runat="server" Text="&nbsp;CLP Report" Width="100%" CssClass="sis_formheading"></asp:Label>
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
       function script_download(id, dy, id1) {
       	pcnt = pcnt + 1;
       	var nam = 'wdwd' + pcnt;
       	var url = self.location.href.replace('App_Forms/GF_ErectionDrawingList.aspx', 'App_Download/ErectionDocumentList.aspx');
       	url = url + '?id=' + $get(id).value + '&dy=' + $get(dy).value;
       	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
       	return false;
       }
    </script>

    <br />
    <br />
    <table>
			<tr>
				<td><b>Project ID</b>
				</td>
				<td><asp:TextBox AutoPostBack="true" runat="server" id="F_ProjectID" maxlength="6" style="width: 76px; text-transform:uppercase" class="mytxt" />
				</td>
				<td>
					<asp:DropDownList ID="F_BaseLineID" runat="server" style="width:150px" CssClass="myddl">
					</asp:DropDownList>
				</td>
				<td><b>
				Activities to be completed in next Days (+ / -)		</b>	</td>
				<td>
					<asp:TextBox ID="F_days" runat="server" Width="50px" MaxLength="5" Text="0" CssClass="mytxt" />
				</td>
				<td><b>
				Function</b></td>
				<td>
					<asp:DropDownList ID="F_Function" runat="server" Width="80px" CssClass="myddl" >
					<asp:ListItem Selected="True" Value="" Text="ALL" />
					<asp:ListItem Value="1" Text="Engineering" />
					<asp:ListItem Value="2" Text="Indenting" />
					<asp:ListItem Value="3" Text="Ordering" />
					<asp:ListItem Value="4" Text="Despatch" />
					<asp:ListItem Value="5" Text="Erection" />
					</asp:DropDownList>
				</td>
				<td><asp:Button ID="cmdGetCLP" runat="server" Text="Get CLP from ERP-LN" />
				</td>
			</tr>
    </table>
  </td></tr></table>
<asp:Panel ID="pnlCLP" runat="server" >
</asp:Panel>
  </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>
