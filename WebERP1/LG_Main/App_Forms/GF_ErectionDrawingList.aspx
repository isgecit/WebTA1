<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_ErectionDrawingList.aspx.vb" Inherits="GF_ErectionDrawingList" title="List: Erection Drawing" %>
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
				<td>Project ID
				</td>
				<td><input type="text" id="F_ProjectID" maxlength="6" style="width: 76px; text-transform:uppercase" class="mytxt" />
				</td>
				<td>Released or Modified in Last [Days]
				</td>
				<td><input type="text" id="F_Days" maxlength="6" style="width: 76px" class="mytxt" value="30" />
				</td>
				<td>
					<input type="button" onclick="return script_download('F_ProjectID','F_Days');" value=" Download " />
				</td>
			</tr>
    </table>
  </td></tr></table>
  </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>
