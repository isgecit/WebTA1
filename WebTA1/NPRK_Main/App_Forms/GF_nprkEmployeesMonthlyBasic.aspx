<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_nprkEmployeesMonthlyBasic.aspx.vb" Inherits="GF_nprkEmployeesMonthlyBasic" title="Maintain List: Employee MonthlyData" %>
<asp:Content ID="CPHnprkEmployeesMonthlyBasic" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelnprkEmployeesMonthlyBasic" runat="server" Text="&nbsp;List: Employee MonthlyData"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkEmployeesMonthlyBasic" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkEmployeesMonthlyBasic"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkEmployeesMonthlyBasic.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkEmployeesMonthlyBasic.aspx"
      ValidationGroup = "nprkEmployeesMonthlyBasic"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkEmployeesMonthlyBasic" runat="server" AssociatedUpdatePanelID="UPNLnprkEmployeesMonthlyBasic" DisplayAfter="100">
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
          <b><asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_EmployeeID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEmployeeID"
            BehaviorID="B_ACEEmployeeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EmployeeIDCompletionList"
            TargetControlID="F_EmployeeID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEmployeeID_Selected"
            OnClientPopulating="ACEEmployeeID_Populating"
            OnClientPopulated="ACEEmployeeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td>
    <table>
			<tr>
        <td>
         <asp:Label ID="LabelFASBasicForMonth" runat="server" Font-Bold="true"	Text="Get Paid Basic For the Month"></asp:Label>
        </td>
				<td>
					<asp:Button ID="Button04" Text="Apr" runat="server" CssClass="mytxt" CommandArgument="04" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button05" Text="May" runat="server" CssClass="mytxt" CommandArgument="05" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button06" Text="Jun" runat="server" CssClass="mytxt" CommandArgument="06" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button07" Text="Jul" runat="server" CssClass="mytxt" CommandArgument="07" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button08" Text="Aug" runat="server" CssClass="mytxt" CommandArgument="08" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button09" Text="Sep" runat="server" CssClass="mytxt" CommandArgument="09" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button10" Text="Oct" runat="server" CssClass="mytxt" CommandArgument="10" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button11" Text="Nov" runat="server" CssClass="mytxt" CommandArgument="11" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button12" Text="Dec" runat="server" CssClass="mytxt" CommandArgument="12" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button01" Text="Jan" runat="server" CssClass="mytxt" CommandArgument="01" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button02" Text="Feb" runat="server" CssClass="mytxt" CommandArgument="02" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Button ID="Button03" Text="Mar" runat="server" CssClass="mytxt" CommandArgument="03" OnClick="cmdImport_Basic" />
				</td>
				<td>
					<asp:Label ID="L_UpdateEmp" runat="server" Font-Bold="true" Text="Update Emp.Info From PERKS:"></asp:Label>
				</td>
				<td>
					<asp:CheckBox ID="F_UpdateEmp" runat="server" />
				</td>
			</tr>
    </table>

        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVnprkEmployeesMonthlyBasic" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkEmployeesMonthlyBasic" DataKeyNames="RecordID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="RecordID">
          <ItemTemplate>
            <asp:Label ID="LabelRecordID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RecordID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee" SortExpression="PRK_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_EmployeeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("EmployeeID") %>' Text='<%# Eval("PRK_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Salary Month" SortExpression="SalMonth">
          <ItemTemplate>
            <asp:Label ID="LabelSalMonth" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SalMonth") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Salary Year" SortExpression="SalYear">
          <ItemTemplate>
            <asp:Label ID="LabelSalYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SalYear") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Paid Basic" SortExpression="NetBasic">
          <ItemTemplate>
            <asp:Label ID="LabelNetBasic" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NetBasic") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fin. Year" SortExpression="FinYear">
          <ItemTemplate>
            <asp:Label ID="LabelFinYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FinYear") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category" SortExpression="CategoryID">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ESI Amount" SortExpression="ESIAmount">
          <ItemTemplate>
            <asp:Label ID="LabelESIAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ESIAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Mobile Limit" SortExpression="MobileLimit">
          <ItemTemplate>
            <asp:Label ID="LabelMobileLimit" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MobileLimit") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Landline Limit" SortExpression="LandlineLimit">
          <ItemTemplate>
            <asp:Label ID="LabelLandlineLimit" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LandlineLimit") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkEmployeesMonthlyBasic"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkEmployeesMonthlyBasic"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkEmployeesMonthlyBasicSelectList"
      TypeName = "SIS.NPRK.nprkEmployeesMonthlyBasic"
      SelectCountMethod = "nprkEmployeesMonthlyBasicSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_EmployeeID" PropertyName="Text" Name="EmployeeID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkEmployeesMonthlyBasic" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_EmployeeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
