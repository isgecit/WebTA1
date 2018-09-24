<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="LGDefault" title="Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<%--<div style=" width:100%; text-align:center">
<asp:Label ID="defaultHeading" runat="server" Text="TRAVEL BILL MANAGEMENT SYSTEM" style="color: #000099; font-family: 'BankGothic Md BT'; font-size: xx-large; text-decoration: underline;" />
</div>
  <asp:HyperLink NavigateUrl="~/TA Bill Entry Process Ver_1.pdf" ID="helpLink" runat="server" Text="TA Bill Entry HELP" ForeColor="Red" Font-Bold="true" Font-Size="Medium" />
  <asp:FileUpload ID="F_ProjectGroup" runat="server"  /> <asp:Button ID="cmdUpdatePrg" runat="server" Text="Submit" />
--%>

    <script type="text/javascript">
      var pcnt = 0;
      function show_entitlement() {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var tmp = self.location.href;
        var url = '';
        if (tmp.indexOf('Default') >= 0)
          url = self.location.href.replace('Default', 'NPRK_Main/App_Print/RP_nprkUserEntitlementSheet');
        else
          url = tmp + 'NPRK_Main/App_Print/RP_nprkUserEntitlementSheet.aspx';
        window.open(url, nam, 'left=20,top=20,width=770,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
      function show_perkref() {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var tmp = self.location.href;
        var url = '';
        if (tmp.indexOf('Default') >= 0)
          url = self.location.href.replace('Default', 'NPRK_Main/App_Print/RP_tempES');
        else
          url = tmp + 'NPRK_Main/App_Print/RP_tempES.aspx';
        window.open(url, nam, 'left=20,top=20,width=770,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
      function show_imprest(x) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = 'http://' + self.location.host + '/WebImp1/EmployeeImprest.aspx?empId=' + x ;
        window.open(url, nam, 'left=20,top=20,width=900,height=600,toolbar=0,resizable=1,scrollbars=1,addressbar=0,titlebar=0,location=0,title=xyz');
        return false;
      }
    </script>
<div style="float:left">
<%= abcd %>
</div>
</asp:Content>

