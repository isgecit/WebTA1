<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costFinYearProjects.aspx.vb" Inherits="EF_costFinYearProjects" title="Edit: Manage Projects" %>
<asp:Content ID="CPHcostFinYearProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostFinYearProjects" runat="server" Text="&nbsp;Edit: Manage Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostFinYearProjects" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostFinYearProjects"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_costFinYearProjects.aspx?pk="
    ValidationGroup = "costFinYearProjects"
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
<asp:FormView ID="FVcostFinYearProjects"
  runat = "server"
  DataKeyNames = "FinYear,Quarter,ProjectID"
  DataSourceID = "ODScostFinYearProjects"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin. Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin. Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear1_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
            Text='<%# Eval("COST_Quarters2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Descpription" runat="server" Text="Descpription :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Descpription"
            Text='<%# Bind("Descpription") %>'
            ToolTip="Value of Descpription."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IndividualGroup" runat="server" Text="Individual Group :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_IndividualGroup"
            Checked='<%# Bind("IndividualGroup") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IndividualGroupID" runat="server" Text="Individual Group ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_IndividualGroupID"
            Width="88px"
            Text='<%# Bind("IndividualGroupID") %>'
            Enabled = "False"
            ToolTip="Value of Individual Group ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_IndividualGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups7_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CombinedGroup" runat="server" Text="Combined Group :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_CombinedGroup"
            Checked='<%# Bind("CombinedGroup") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CombinedGroupID" runat="server" Text="Combined Group ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CombinedGroupID"
            Width="88px"
            Text='<%# Bind("CombinedGroupID") %>'
            Enabled = "False"
            ToolTip="Value of Combined Group ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CombinedGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups6_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Blocked" runat="server" Text="Blocked :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Blocked"
            Checked='<%# Bind("Blocked") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BlockingRemarks" runat="server" Text="Blocking Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BlockingRemarks"
            Text='<%# Bind("BlockingRemarks") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Blocking Remarks."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EntryConfirmed" runat="server" Text="Entry Confirmed :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_EntryConfirmed"
            Checked='<%# Bind("EntryConfirmed") %>'
            CssClass = "mychk"
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
  ID = "ODScostFinYearProjects"
  DataObjectTypeName = "SIS.COST.costFinYearProjects"
  SelectMethod = "costFinYearProjectsGetByID"
  UpdateMethod="UZ_costFinYearProjectsUpdate"
  DeleteMethod="costFinYearProjectsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costFinYearProjects"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
