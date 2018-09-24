<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costProjectsIputApproval.aspx.vb" Inherits="EF_costProjectsIputApproval" title="Edit: Approve Projects Input" %>
<asp:Content ID="CPHcostProjectsIputApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectsIputApproval" runat="server" Text="&nbsp;Edit: Approve Projects Input"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectsIputApproval" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectsIputApproval"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_costProjectsIputApproval.aspx?pk="
    ValidationGroup = "costProjectsIputApproval"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVcostProjectsIputApproval"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter"
  DataSourceID = "ODScostProjectsIputApproval"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectGroupID"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project Group ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups4_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            Width="88px"
            Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("COST_ProjectInputStatus5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear3_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Quarter."
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyGOV" runat="server" Text="Currency [Total Order Value] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CurrencyGOV"
            Width="56px"
            Text='<%# Bind("CurrencyGOV") %>'
            Enabled = "False"
            ToolTip="Value of Currency [Total Order Value]."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CurrencyGOV_Display"
            Text='<%# Eval("TA_Currencies8_CurrencyName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GroupOrderValue" runat="server" Text="Total Order Value :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GroupOrderValue"
            Text='<%# Bind("GroupOrderValue") %>'
            ToolTip="Value of Total Order Value."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CFforGOV" runat="server" Text="Conversion Factor [Total Order Value] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CFforGOV"
            Text='<%# Bind("CFforGOV") %>'
            ToolTip="Value of Conversion Factor [Total Order Value]."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GroupOrderValueINR" runat="server" Text="Total Order Value [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GroupOrderValueINR"
            Text='<%# Bind("GroupOrderValueINR") %>'
            ToolTip="Value of Total Order Value [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyPR" runat="server" Text="Currency for Project Input :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CurrencyPR"
            Width="56px"
            Text='<%# Bind("CurrencyPR") %>'
            Enabled = "False"
            ToolTip="Value of Currency for Project Input."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CurrencyPR_Display"
            Text='<%# Eval("TA_Currencies9_CurrencyName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectRevenue" runat="server" Text="Project Revenue :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectRevenue"
            Text='<%# Bind("ProjectRevenue") %>'
            ToolTip="Value of Project Revenue."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectMargin" runat="server" Text="Project Margin :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectMargin"
            Text='<%# Bind("ProjectMargin") %>'
            ToolTip="Value of Project Margin."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ExportIncentive" runat="server" Text="Export Incentive :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ExportIncentive"
            Text='<%# Bind("ExportIncentive") %>'
            ToolTip="Value of Export Incentive."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CFforPR" runat="server" Text="Conversion Factor for Project Input :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CFforPR"
            Text='<%# Bind("CFforPR") %>'
            ToolTip="Value of Conversion Factor for Project Input."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectRevenueINR" runat="server" Text="Project Revenue [INR] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectRevenueINR"
            Text='<%# Bind("ProjectRevenueINR") %>'
            ToolTip="Value of Project Revenue [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectMarginINR" runat="server" Text="Project Margin [INR] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectMarginINR"
            Text='<%# Bind("ProjectMarginINR") %>'
            ToolTip="Value of Project Margin [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ExportIncentiveINR" runat="server" Text="Export Incentive [INR] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ExportIncentiveINR"
            Text='<%# Bind("ExportIncentiveINR") %>'
            ToolTip="Value of Export Incentive [INR]."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostProjectsIputApproval"
  DataObjectTypeName = "SIS.COST.costProjectsIputApproval"
  SelectMethod = "costProjectsIputApprovalGetByID"
  UpdateMethod="costProjectsIputApprovalUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectsIputApproval"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
