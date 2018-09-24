<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkSiteAllowanceClaims.aspx.vb" Inherits="AF_nprkSiteAllowanceClaims" title="Add: Claim Site Allowance" %>
<asp:Content ID="CPHnprkSiteAllowanceClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkSiteAllowanceClaims" runat="server" Text="&nbsp;Add: Claim Site Allowance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkSiteAllowanceClaims" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkSiteAllowanceClaims"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "nprkSiteAllowanceClaims"
    runat = "server" />
<asp:FormView ID="FVnprkSiteAllowanceClaims"
  runat = "server"
  DataKeyNames = "FinYear,Quarter,EmployeeID"
  DataSourceID = "ODSnprkSiteAllowanceClaims"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkSiteAllowanceClaims" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_costFinYear
            ID="F_FinYear"
            SelectedValue='<%# Bind("FinYear") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkSiteAllowanceClaims"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            onblur= "script_nprkSiteAllowanceClaims.validate_FinYear(this);"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" ForeColor="#CC6633" runat="server" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_costQuarters
            ID="F_Quarter"
            SelectedValue='<%# Bind("Quarter") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkSiteAllowanceClaims"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            onblur= "script_nprkSiteAllowanceClaims.validate_Quarter(this);"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td></td>
        <td colspan="3" class="alignleft">
          <asp:Button ID="cmdEntitlement" runat="server" Text="Get Entitlement Amount" CommandName="lgEntitlement" />
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="100"
            Width="350px"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkSiteAllowanceClaims"
  DataObjectTypeName = "SIS.NPRK.nprkSiteAllowanceClaims"
  InsertMethod="UZ_nprkSiteAllowanceClaimsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkSiteAllowanceClaims"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
