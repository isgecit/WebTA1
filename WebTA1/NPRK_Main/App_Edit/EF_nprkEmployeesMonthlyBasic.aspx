<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkEmployeesMonthlyBasic.aspx.vb" Inherits="EF_nprkEmployeesMonthlyBasic" title="Edit: Employee MonthlyData" %>
<asp:Content ID="CPHnprkEmployeesMonthlyBasic" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkEmployeesMonthlyBasic" runat="server" Text="&nbsp;Edit: Employee MonthlyData"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkEmployeesMonthlyBasic" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkEmployeesMonthlyBasic"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkEmployeesMonthlyBasic"
    runat = "server" />
<asp:FormView ID="FVnprkEmployeesMonthlyBasic"
  runat = "server"
  DataKeyNames = "RecordID"
  DataSourceID = "ODSnprkEmployeesMonthlyBasic"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecordID" runat="server" ForeColor="#CC6633" Text="ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RecordID"
            Text='<%# Bind("RecordID") %>'
            ToolTip="Value of ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_EmployeeID"
            Width="88px"
            Text='<%# Bind("EmployeeID") %>'
            Enabled = "False"
            ToolTip="Value of Employee."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("PRK_Employees1_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SalMonth" runat="server" Text="Salary Month :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SalMonth"
            Text='<%# Bind("SalMonth") %>'
            ToolTip="Value of Salary Month."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SalYear" runat="server" Text="Salary Year :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SalYear"
            Text='<%# Bind("SalYear") %>'
            ToolTip="Value of Salary Year."
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
          <asp:Label ID="L_NetBasic" runat="server" Text="Paid Basic :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_NetBasic"
            Text='<%# Bind("NetBasic") %>'
            ToolTip="Value of Paid Basic."
            Enabled = "False"
            Width="104px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FinYear" runat="server" Text="Fin. Year :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FinYear"
            Text='<%# Bind("FinYear") %>'
            ToolTip="Value of Fin. Year."
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
          <asp:Label ID="L_CategoryID" runat="server" Text="Category :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CategoryID"
            Text='<%# Bind("CategoryID") %>'
            ToolTip="Value of Category."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label3" runat="server" Text="With Driver :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_WithDriver"
            Checked='<%# Bind("WithDriver") %>'
            Enabled="false"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PostedAt" runat="server" Text="PostedAt :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PostedAt"
            Text='<%# Bind("PostedAt") %>'
            ToolTip="Value of PostedAt."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleType" runat="server" Text="VehicleType :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleType"
            Text='<%# Bind("VehicleType") %>'
            ToolTip="Value of VehicleType."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ESI" runat="server" Text="ESI :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ESI"
            Checked='<%# Bind("ESI") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ESIAmount" runat="server" Text="ESI Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ESIAmount"
            Text='<%# Bind("ESIAmount") %>'
            ToolTip="Value of ESI Amount."
            Enabled = "False"
            Width="104px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaintenanceAllowed" runat="server" Text="Maintenance Allowed :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_MaintenanceAllowed"
            Checked='<%# Bind("MaintenanceAllowed") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TWInSalary" runat="server" Text="TW In Salary :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_TWInSalary"
            Checked='<%# Bind("TWInSalary") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MobileLimit" runat="server" Text="Mobile Limit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MobileLimit"
            Text='<%# Bind("MobileLimit") %>'
            ToolTip="Value of Mobile Limit."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MobileWithInternet" runat="server" Text="Mobile With Internet :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_MobileWithInternet"
            Checked='<%# Bind("MobileWithInternet") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_LandlineLimit" runat="server" Text="Landline Limit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_LandlineLimit"
            Text='<%# Bind("LandlineLimit") %>'
            ToolTip="Value of Landline Limit."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MobileBillPlanID" runat="server" Text="Mobile Bill Plan :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_MobileBillPlanID"
            Width="88px"
            Text='<%# Bind("MobileBillPlanID") %>'
            Enabled = "False"
            ToolTip="Value of Mobile Bill Plan."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_MobileBillPlanID_Display"
            Text='<%# Eval("PRK_MobileBillPlans2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
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
  ID = "ODSnprkEmployeesMonthlyBasic"
  DataObjectTypeName = "SIS.NPRK.nprkEmployeesMonthlyBasic"
  SelectMethod = "nprkEmployeesMonthlyBasicGetByID"
  UpdateMethod="UZ_nprkEmployeesMonthlyBasicUpdate"
  DeleteMethod="UZ_nprkEmployeesMonthlyBasicDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkEmployeesMonthlyBasic"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecordID" Name="RecordID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
