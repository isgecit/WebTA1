<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_GenerateMonthlyEntitlements.aspx.vb" Inherits="GF_GenerateMonthlyEntitlements" title="Generate Entitlements" %>
<asp:Content ID="CPHnprkStatus" ContentPlaceHolderID="cph1" runat="Server">
  <% Server.ScriptTimeout = 36000 %>
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelnprkStatus" runat="server" Text="&nbsp;Generate Entitlements & Utilities"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLnprkStatus" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLnprkStatus"
                  ToolType="lgNReport"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSnprkStatus" runat="server" AssociatedUpdatePanelID="UPNLnprkStatus" DisplayAfter="100">
                  <ProgressTemplate>
                    <span style="color: #ff0033">Loading...</span>
                  </ProgressTemplate>
                </asp:UpdateProgress>
                <div id="frmdiv" class="ui-widget-content minipage">

                  <table style="margin-left: 30px; border: solid 1pt lightgrey">
                    <tr>
                      <td>
                        <b>1.</b>
                      </td>
                      <td style="min-width: 180px">
                        <b>Monthly Entitlements</b>
                      </td>
                      <td>Select Month
                      </td>
                      <td>
                        <asp:DropDownList
                          ID="F_Qtr"
                          runat="server"
                          ClientIDMode="Static"
                          Width="120px" ValidationGroup="PrkEntitlements" CssClass="mytxt">
                          <asp:ListItem Value="4" Text="1-Quarter" />
                          <asp:ListItem Value="7" Text="2-Quarter" />
                          <asp:ListItem Value="10" Text="3-Quarter" />
                          <asp:ListItem Value="1" Text="4-Quarter" />
                        </asp:DropDownList>
                      </td>
                      <td>
                        <b>PERK</b>
                      </td>
                      <td>
                        <LGM:LC_nprkPerks
                          ID="LC_PerkID1"
                          OrderBy="Description"
                          DataTextField="Description"
                          DataValueField="PerkID"
                          IncludeDefault="true"
                          DefaultText="-- Select --"
                          AutoPostBack="false"
                          Runat="Server" />
                      </td>
                      <td colspan="6">
                        <asp:Button
                          ID="CmdGenerate"
                          runat="server"
                          ValidationGroup="PrkEntitlements"
                          Text="Generate" OnClientClick="return confirm('Generate Entitlements ?')" CssClass="mytxt" /></td>
                    </tr>
                  </table>
                  <br />
                  <table style="margin-left: 30px; border: solid 1pt lightgrey">
                    <tr>
                      <td>
                        <b>2.</b>
                      </td>
                      <td style="min-width: 180px"><b>Employee's Entitlements</b>
                      </td>
                      <td>Card No.
                      </td>
                      <td>
                        <asp:TextBox
                          ID="T_CardNo2"
                          Text="0340"
                          runat="server"
                          MaxLength="8"
                          Width="70px"
                          CssClass="mytxt"
                          ValidationGroup="report2">
                        </asp:TextBox>
                      </td>
                      <td>From Month
                      </td>
                      <td>
                        <asp:DropDownList
                          ID="F_Qtr1"
                          runat="server"
                          ClientIDMode="Static"
                          Width="120px" ValidationGroup="PrkEntitlements" CssClass="mytxt">
                          <asp:ListItem Value="4" Text="1-Quarter" />
                          <asp:ListItem Value="7" Text="2-Quarter" />
                          <asp:ListItem Value="10" Text="3-Quarter" />
                          <asp:ListItem Value="1" Text="4-Quarter" />
                        </asp:DropDownList>
                      </td>
                      <td>
                        <b>PERK</b>
                      </td>
                      <td>
                        <LGM:LC_nPrkPerks
                          ID="LC_PerkID2"
                          Runat="Server"
                          AutoPostBack="false"
                          DataTextField="Description"
                          DataValueField="PerkID"
                          DefaultText="-- Select --"
                          IncludeDefault="true"
                          OrderBy="Description" />
                      </td>
                      <td>
                        <asp:Button ID="Cmd2Generate" runat="server" CssClass="mytxt" OnClientClick="return confirm('Generate Employee Entitlements ?')" Text="Generate" ValidationGroup="report2" />
                      </td>

                    </tr>
                  </table>
                  <br />
                  <table style="margin-left: 30px; border: solid 1pt lightgrey">
                    <tr>
                      <td>
                        <b>3.</b>
                      </td>
                      <td style="min-width: 180px"><b>Generate Entitlements</b>
                      </td>
                      <td>From Card No.</td>
                      <td>
                        <asp:TextBox ID="F_CardNo3" runat="server" MaxLength="8" Width="70px" CssClass="mytxt">0340</asp:TextBox>
                      </td>
                      <td>To Card No.
                      </td>
                      <td>
                        <asp:TextBox
                          ID="T_CardNo3"
                          Text="0340"
                          runat="server"
                          MaxLength="8"
                          Width="70px"
                          CssClass="mytxt">
                        </asp:TextBox>
                      </td>
                      <td>Quarter
                      </td>
                      <td>
                        <asp:DropDownList
                          ID="F_Qtr2"
                          runat="server"
                          ClientIDMode="Static"
                          Width="120px" ValidationGroup="PrkEntitlements" CssClass="mytxt">
                          <asp:ListItem Value="4" Text="1-Quarter" />
                          <asp:ListItem Value="7" Text="2-Quarter" />
                          <asp:ListItem Value="10" Text="3-Quarter" />
                          <asp:ListItem Value="1" Text="4-Quarter" />
                        </asp:DropDownList>
                      </td>
                      <td>
                        <asp:Button
                          ID="Cmd3Generate"
                          runat="server"
                          ValidationGroup="report3"
                          Text="Generate"
                          CssClass="mytxt"
                          OnClientClick="return confirm('Generate Entitlements ?')" />
                      </td>
                    </tr>
                  </table>
                  <br />
                  <table style="margin-left: 30px; border: solid 1pt lightgrey">
                    <tr>
                      <td>
                        <b>4.</b>
                      </td>
                      <td style="min-width: 180px"><b>Close Financial Year</b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_CardNo4" runat="server" ClientIDMode="static" MaxLength="8" Width="70px" CssClass="mytxt">0340</asp:TextBox>
                      </td>
                      <td>
                        <script type="text/javascript">
                          var pcnt = 0;
                          function download_ClosingPayable(x) {
                            if (confirm('Close current financial year ?')) {
                              var emp = $get(x).value;
                              pcnt = pcnt + 1;
                              var nam = 'wTask' + pcnt;
                              var url = self.location.href + '?closefinyear=zaq12wsxcde3&emp=' + emp;
                              window.open(url, nam, 'left=20,top=20,width=100,height=70,toolbar=1,resizable=1,scrollbars=1');
                            }
                            return false;
                          }
                          function download_DeleteClosing(x) {
                            if (confirm('Delete Closing Balance Record ?')) {
                              var emp = $get(x).value;
                              pcnt = pcnt + 1;
                              var nam = 'wTask' + pcnt;
                              var url = self.location.href + '?closefinyear=3edcxsw21qaz&emp=' + emp;
                              window.open(url, nam, 'left=20,top=20,width=100,height=70,toolbar=1,resizable=1,scrollbars=1');
                            }
                            return false;
                          }
                        </script>
                        <asp:Button ID="CmdOPBTransfer" runat="server" CssClass="mytxt" OnClientClick="return download_ClosingPayable('F_CardNo4');" Text="CLOSE FINANCIAL YEAR" />
                        </td>
                      <td>
                        <asp:Button ID="cmdDelClosing" runat="server" CssClass="mytxt" OnClientClick="return download_DeleteClosing('F_CardNo4');" Text="DELETE CLOSING RECORD" />
                      </td>
                    </tr>
                  </table>
                  <br />



                  <table id="tblProgress">
                    <tr>
                      <td>Emp</td>
                      <td>Sts</td>
                    </tr>
                  </table>
                </div>
              </td>
            </tr>
          </table>
          <input type="button" value="generate Ent" disabled="disabled" onclick="return gen_mon();" />
          <script type="text/javascript">
            var empStr, aEmp;
            var iEmp = -1;
            var aEmpLen = 0;
            var mn;
            var pr;
            var table = document.getElementById('tblProgress');
            function gen_mon() {
              mn = $get('F_Mon').value;
              pr = $get('<%=LC_PerkID1.LCClientID%>').value;
          iEmp = -1;
          aEmpLin = 0;
          PageMethods.getEmpList('', s_empList, s_empList);

        }
        function s_empList(r) {
          aEmp = r.split('|');
          aEmpLen = aEmp.length;
          var row = table.insertRow(0);
          var cell1 = row.insertCell(0);
          var cell2 = row.insertCell(1);
          cell1.innerHTML = 'Total Emp';
          cell2.innerHTML = aEmpLen;
          setInterval('generateEntitlement()', 1000);
        }
        function generateEntitlement() {
          iEmp++;
          PageMethods.generateEntitlement(aEmp[iEmp] + ',' + mn + ',' + pr, onSuccess, onError);
        }
        function onSuccess(r) {
          var p = r.split('|');
          var row = table.insertRow(0);
          var cell1 = row.insertCell(0);
          var cell2 = row.insertCell(1);
          cell1.innerHTML = p[0];
          cell2.innerHTML = p[1] + ' => ' + iEmp;
          if (iEmp < aEmpLen)
            setInterval('generateEntitlement()', 1000);
        }
        function onError(r) {
          var p = r.split('|');
          var row = table.insertRow(0);
          var cell1 = row.insertCell(0);
          var cell2 = row.insertCell(1);
          cell1.innerHTML = p[0];
          cell2.innerHTML = p[1];
          if (confirm('Error, Stop Process ? :' + iEmp)) {
          }
          else {
            if (iEmp < aEmpLen)
              setInterval('generateEntitlement()', 1000);
          }
        }
          </script>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="CmdGenerate" EventName="Click" />
          <asp:AsyncPostBackTrigger ControlID="Cmd2Generate" EventName="Click" />
          <asp:AsyncPostBackTrigger ControlID="Cmd3Generate" EventName="Click" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>
