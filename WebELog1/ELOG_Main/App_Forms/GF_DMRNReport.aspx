<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_DMRNReport.aspx.vb" Inherits="GF_DMRNReport" title="Detention MRN Report" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
  <div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server">
  <ContentTemplate>
    <h1><font color="Blue">Site Receipt Report</font></h1>
  
    <table width="100%"><tr><td class="auto-style1"> 
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
       function script_download(typ) {
       	pcnt = pcnt + 1;
       	var nam = 'wdwd' + pcnt;
       	var url = self.location.href.replace('App_Forms/GF_DMRNReport.aspx', 'App_Downloads/DMRNReport.aspx');
       	url = url + '?typ=' + $get(typ).value;
       	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
       	return false;
       }
    </script>
    <br />
      &nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="lbl_Project" runat="server" Text="ProjectID:" Font-Bold="True"></asp:Label>
      &nbsp;
      <asp:TextBox ID="Txt_ProjectID" runat="server" BackColor="#99CCFF" Width="77px"></asp:TextBox>
    <br />
 
				<tr>
          
				<td colspan="2">
          <br />
				  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input type="button" onclick="return script_download('<%= Txt_ProjectID.ClientID %>');" value="Download" />
				</td>

			</tr>
      
    </table>
  </td></tr></table>
  </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphMain">
  <style type="text/css">
  .auto-style1 {
    margin-left: 40px;
  }
</style>
</asp:Content>

