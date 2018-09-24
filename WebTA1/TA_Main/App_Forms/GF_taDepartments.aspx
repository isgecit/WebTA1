<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taDepartments.aspx.vb" Inherits="GF_taDepartments" title="Maintain List: Departments" %>
<asp:Content ID="CPHtaDepartments" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaDepartments" runat="server" Text="&nbsp;List: Departments"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaDepartments" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaDepartments"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taDepartments.aspx"
      EnableAdd = "False"
      ValidationGroup = "taDepartments"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaDepartments" runat="server" AssociatedUpdatePanelID="UPNLtaDepartments" DisplayAfter="100">
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
          <b><asp:Label ID="L_DepartmentHead" runat="server" Text="Department Head :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_DepartmentHead"
            CssClass = "myfktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_DepartmentHead(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DepartmentHead_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDepartmentHead"
            BehaviorID="B_ACEDepartmentHead"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DepartmentHeadCompletionList"
            TargetControlID="F_DepartmentHead"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEDepartmentHead_Selected"
            OnClientPopulating="ACEDepartmentHead_Populating"
            OnClientPopulated="ACEDepartmentHead_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BusinessHead" runat="server" Text="Business Head :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BusinessHead"
            CssClass = "myfktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_BusinessHead(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_BusinessHead_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBusinessHead"
            BehaviorID="B_ACEBusinessHead"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BusinessHeadCompletionList"
            TargetControlID="F_BusinessHead"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEBusinessHead_Selected"
            OnClientPopulating="ACEBusinessHead_Populating"
            OnClientPopulated="ACEBusinessHead_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtaDepartments" SkinID="gv_silver" runat="server" DataSourceID="ODStaDepartments" DataKeyNames="DepartmentID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department" SortExpression="DepartmentID">
          <ItemTemplate>
            <asp:Label ID="LabelDepartmentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DepartmentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department Head" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_DepartmentHead" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DepartmentHead") %>' Text='<%# Eval("HRM_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Business Head" SortExpression="HRM_Employees2_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_BusinessHead" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BusinessHead") %>' Text='<%# Eval("HRM_Employees2_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaDepartments"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taDepartments"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "taDepartmentsSelectList"
      TypeName = "SIS.TA.taDepartments"
      SelectCountMethod = "taDepartmentsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DepartmentHead" PropertyName="Text" Name="DepartmentHead" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_BusinessHead" PropertyName="Text" Name="BusinessHead" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaDepartments" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_DepartmentHead" />
    <asp:AsyncPostBackTrigger ControlID="F_BusinessHead" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
