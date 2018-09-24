<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkSiteAllowanceClaims.aspx.vb" Inherits="EF_nprkSiteAllowanceClaims" title="Edit: Claim Site Allowance" %>
<asp:Content ID="CPHnprkSiteAllowanceClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkSiteAllowanceClaims" runat="server" Text="&nbsp;Edit: Claim Site Allowance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkSiteAllowanceClaims" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkSiteAllowanceClaims"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkSiteAllowanceClaims"
    runat = "server" />
<asp:FormView ID="FVnprkSiteAllowanceClaims"
  runat = "server"
  DataKeyNames = "FinYear,Quarter,EmployeeID"
  DataSourceID = "ODSnprkSiteAllowanceClaims"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
            Text='<%# Eval("COST_Quarters4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled1Amount" runat="server" Text="Entitled Amount for 1st Month of Quarter :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled1Amount"
            Text='<%# Bind("Entitled1Amount") %>'
            Enabled = "False"
            ToolTip="Value of Entitled Amount for 1st Month of Quarter."
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: Right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled2Amount" runat="server" Text="Entitled Amount for 2nd Month of Quarter :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled2Amount"
            Text='<%# Bind("Entitled2Amount") %>'
            Enabled = "False"
            ToolTip="Value of Entitled Amount for 2nd Month of Quarter."
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: Right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled3Amount" runat="server" Text="Entitled Amount for 3rd Month of Quarter :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled3Amount"
            Text='<%# Bind("Entitled3Amount") %>'
            Enabled = "False"
            ToolTip="Value of Entitled Amount for 3rd Month of Quarter."
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: Right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalEntitledAmount" runat="server" Text="Total Entitled Amount of Quarter :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TotalEntitledAmount"
            Text='<%# Bind("TotalEntitledAmount") %>'
            Enabled = "False"
            ToolTip="Value of Total Entitled Amount of Quarter."
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: Right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserRemarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UserRemarks"
            Text='<%# Bind("UserRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="100"
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
  ID = "ODSnprkSiteAllowanceClaims"
  DataObjectTypeName = "SIS.NPRK.nprkSiteAllowanceClaims"
  SelectMethod = "nprkSiteAllowanceClaimsGetByID"
  UpdateMethod="UZ_nprkSiteAllowanceClaimsUpdate"
  DeleteMethod="UZ_nprkSiteAllowanceClaimsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkSiteAllowanceClaims"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="EmployeeID" Name="EmployeeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
