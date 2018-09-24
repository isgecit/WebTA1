<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkUnLinkedSAClaims.aspx.vb" Inherits="EF_nprkUnLinkedSAClaims" title="Edit: Pending Claims" %>
<asp:Content ID="CPHnprkUnLinkedSAClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkUnLinkedSAClaims" runat="server" Text="&nbsp;Edit: Pending Claims"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkUnLinkedSAClaims" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkUnLinkedSAClaims"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "nprkUnLinkedSAClaims"
    runat = "server" />
<asp:FormView ID="FVnprkUnLinkedSAClaims"
  runat = "server"
  DataKeyNames = "FinYear,Quarter,EmployeeID"
  DataSourceID = "ODSnprkUnLinkedSAClaims"
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
          <asp:Label ID="L_Entitled1Days" runat="server" Text="Entitled Days [1] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Entitled1Days"
            Text='<%# Bind("Entitled1Days") %>'
            ToolTip="Value of Entitled Days [1]."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Entitled2Days" runat="server" Text="Entitled Days [2] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Entitled2Days"
            Text='<%# Bind("Entitled2Days") %>'
            ToolTip="Value of Entitled Days [2]."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled3Days" runat="server" Text="Entitled Days [3] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Entitled3Days"
            Text='<%# Bind("Entitled3Days") %>'
            ToolTip="Value of Entitled Days [3]."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Applied1Days" runat="server" Text="Applied Days [1] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Applied1Days"
            Text='<%# Bind("Applied1Days") %>'
            ToolTip="Value of Applied Days [1]."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Applied2Days" runat="server" Text="Applied Days [2] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Applied2Days"
            Text='<%# Bind("Applied2Days") %>'
            ToolTip="Value of Applied Days [2]."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Applied3Days" runat="server" Text="Applied Days [3] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Applied3Days"
            Text='<%# Bind("Applied3Days") %>'
            ToolTip="Value of Applied Days [3]."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserRemarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UserRemarks"
            Text='<%# Bind("UserRemarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px"
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
  ID = "ODSnprkUnLinkedSAClaims"
  DataObjectTypeName = "SIS.NPRK.nprkUnLinkedSAClaims"
  SelectMethod = "nprkUnLinkedSAClaimsGetByID"
  UpdateMethod="UZ_nprkUnLinkedSAClaimsUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkUnLinkedSAClaims"
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
