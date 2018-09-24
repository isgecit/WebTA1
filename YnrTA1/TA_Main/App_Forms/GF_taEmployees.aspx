<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_taEmployees.aspx.vb" Inherits="GF_taEmployees" title="Maintain List: Employees" %>
<asp:Content ID="CPHtaEmployees" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaEmployees" runat="server" Text="&nbsp;List: Employees"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaEmployees" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaEmployees"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taEmployees.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taEmployees.aspx"
      ValidationGroup = "taEmployees"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaEmployees" runat="server" AssociatedUpdatePanelID="UPNLtaEmployees" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_CompanyID" runat="server" Text="Company :" /></b>
        </td>
        <td>
          <LGM:LC_qcmCompanies
            ID="F_C_CompanyID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CompanyID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_DivisionID" runat="server" Text="Division :" /></b>
        </td>
        <td>
          <LGM:LC_taDivisions
            ID="F_C_DivisionID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DivisionID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_DepartmentID" runat="server" Text="Department :" /></b>
        </td>
        <td>
          <LGM:LC_taDepartments
            ID="F_C_DepartmentID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DepartmentID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_DesignationID" runat="server" Text="Designation :" /></b>
        </td>
        <td>
          <LGM:LC_qcmDesignations
            ID="F_C_DesignationID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DesignationID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_C_OfficeID" runat="server" Text="Location :" /></b>
        </td>
        <td>
          <LGM:LC_qcmOffices
            ID="F_C_OfficeID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="OfficeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" /></b>
        </td>
        <td>
          <LGM:LC_taCategories
            ID="F_CategoryID"
            OrderBy="cmba"
            DataTextField="cmba"
            DataValueField="CategoryID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtaEmployees" SkinID="gv_silver" runat="server" DataSourceID="ODStaEmployees" DataKeyNames="CardNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="CardNo">
          <ItemTemplate>
            <asp:Label ID="LabelCardNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CardNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee Name" SortExpression="EmployeeName">
          <ItemTemplate>
            <asp:Label ID="LabelEmployeeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EmployeeName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department" SortExpression="HRM_Departments2_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DepartmentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DepartmentID") %>' Text='<%# Eval("HRM_Departments2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation" SortExpression="HRM_Designations3_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DesignationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DesignationID") %>' Text='<%# Eval("HRM_Designations3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Division" SortExpression="HRM_Divisions5_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DivisionID") %>' Text='<%# Eval("HRM_Divisions5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category ID" SortExpression="TA_Categories8_cmba">
          <ItemTemplate>
             <asp:Label ID="L_CategoryID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("CategoryID") %>' Text='<%# Eval("TA_Categories8_cmba") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approver" SortExpression="HRM_Employees19_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_TAApprover" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("TAApprover") %>' Text='<%# Eval("HRM_Employees19_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Un-Block">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Un-Block User" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Un Block User ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PW-Reset">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reset Password to Employee Code" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Reset password to emp. code ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaEmployees"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taEmployees"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taEmployeesSelectList"
      TypeName = "SIS.TA.taEmployees"
      SelectCountMethod = "taEmployeesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_C_DepartmentID" PropertyName="SelectedValue" Name="C_DepartmentID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_C_DesignationID" PropertyName="SelectedValue" Name="C_DesignationID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_C_DivisionID" PropertyName="SelectedValue" Name="C_DivisionID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_CategoryID" PropertyName="SelectedValue" Name="CategoryID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_C_OfficeID" PropertyName="SelectedValue" Name="C_OfficeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_C_CompanyID" PropertyName="SelectedValue" Name="C_CompanyID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaEmployees" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DepartmentID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DesignationID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DivisionID" />
    <asp:AsyncPostBackTrigger ControlID="F_CategoryID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_OfficeID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_CompanyID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
