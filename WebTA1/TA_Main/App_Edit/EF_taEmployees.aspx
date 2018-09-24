<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taEmployees.aspx.vb" Inherits="EF_taEmployees" title="Edit: Employees" %>
<asp:Content ID="CPHtaEmployees" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaEmployees" runat="server" Text="&nbsp;Edit: Employees"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaEmployees" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaEmployees"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taEmployees"
    EnableDelete="false"
    runat = "server" />
<asp:FormView ID="FVtaEmployees"
  runat = "server"
  DataKeyNames = "CardNo"
  DataSourceID = "ODStaEmployees"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="Card No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox ID="F_CardNo"
            Text='<%# Bind("CardNo") %>'
            ToolTip="Value of Card No."
            Enabled = "False"
            Width="72px"
            CssClass = "dmypktxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EmployeeName" runat="server" Text="Employee Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_EmployeeName"
            Text='<%# Bind("EmployeeName") %>'
            ToolTip="Value of Employee Name."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_CompanyID" runat="server" Text="Company :" />&nbsp;
        </td>
        <td>
          <LGM:LC_qcmCompanies
            ID="F_C_CompanyID"
            SelectedValue='<%# Bind("C_CompanyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_C_DivisionID" runat="server" Text="Division :" />&nbsp;
        </td>
        <td>
          <LGM:LC_taDivisions
            ID="F_C_DivisionID"
            SelectedValue='<%# Bind("C_DivisionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DepartmentID" runat="server" Text="Department :" />&nbsp;
        </td>
        <td>
          <LGM:LC_taDepartments
            ID="F_C_DepartmentID"
            SelectedValue='<%# Bind("C_DepartmentID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_C_DesignationID" runat="server" Text="Designation :" />&nbsp;
        </td>
        <td>
          <LGM:LC_qcmDesignations
            ID="F_C_DesignationID"
            SelectedValue='<%# Bind("C_DesignationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_OfficeID" runat="server" Text="Location :" />&nbsp;
        </td>
        <td>
          <LGM:LC_qcmOffices
            ID="F_C_OfficeID"
            SelectedValue='<%# Bind("C_OfficeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_TAVerifier" runat="server" Text="Verifier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TAVerifier"
            Text='<%# Bind("TAVerifier") %>'
            Width="72px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Verifier."
            MaxLength="8"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TAApprover" runat="server" Text="Approver :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TAApprover"
            Text='<%# Bind("TAApprover") %>'
            Width="72px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Approver."
            MaxLength="8"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TASanctioningAuthority" runat="server" Text="Sanctioning Authority :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TASanctioningAuthority"
            Text='<%# Bind("TASanctioningAuthority") %>'
            Width="72px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Sanctioning Authority."
            MaxLength="8"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="Label1" runat="server" Text="TA Bill Self Approval :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_TASelfApproval"
            Checked='<%# Bind("TASelfApproval") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label2" runat="server" Text="Site Allowance Approver :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SiteAllowanceApprover"
            Text='<%# Bind("SiteAllowanceApprover") %>'
            Width="72px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="8"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_taCategories
            ID="F_CategoryID"
            SelectedValue='<%# Bind("CategoryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_EMailID" runat="server" Text="E-Mail-ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_EMailID"
            Text='<%# Bind("EMailID") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for E-Mail-ID."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Contractual" runat="server" Text="Contractual :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Contractual"
            Checked='<%# Bind("Contractual") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_NonTechnical" runat="server" Text="NonTechnical :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_NonTechnical"
            Checked='<%# Bind("NonTechnical") %>'
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
  ID = "ODStaEmployees"
  DataObjectTypeName = "SIS.TA.taEmployees"
  SelectMethod = "taEmployeesGetByID"
  UpdateMethod="taEmployeesUpdate"
  DeleteMethod=""
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taEmployees"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
