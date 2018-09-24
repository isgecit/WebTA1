<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taDepartments.aspx.vb" Inherits="EF_taDepartments" title="Edit: Departments" %>
<asp:Content ID="CPHtaDepartments" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaDepartments" runat="server" Text="&nbsp;Edit: Departments"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaDepartments" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaDepartments"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "taDepartments"
    runat = "server" />
<asp:FormView ID="FVtaDepartments"
  runat = "server"
  DataKeyNames = "DepartmentID"
  DataSourceID = "ODStaDepartments"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DepartmentID" runat="server" ForeColor="#CC6633" Text="Department :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DepartmentID"
            Text='<%# Bind("DepartmentID") %>'
            ToolTip="Value of Department."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="42px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="210px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taDepartments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="30"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taDepartments"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DepartmentHead" runat="server" Text="Department Head :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DepartmentHead"
            CssClass = "myfktxt"
            Text='<%# Bind("DepartmentHead") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Department Head."
            onblur= "script_taDepartments.validate_DepartmentHead(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DepartmentHead_Display"
            Text='<%# Eval("HRM_Employees1_EmployeeName") %>'
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDepartmentHead"
            BehaviorID="B_ACEDepartmentHead"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DepartmentHeadCompletionList"
            TargetControlID="F_DepartmentHead"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taDepartments.ACEDepartmentHead_Selected"
            OnClientPopulating="script_taDepartments.ACEDepartmentHead_Populating"
            OnClientPopulated="script_taDepartments.ACEDepartmentHead_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BusinessHead" runat="server" Text="Business Head :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_BusinessHead"
            CssClass = "myfktxt"
            Text='<%# Bind("BusinessHead") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Business Head."
            onblur= "script_taDepartments.validate_BusinessHead(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_BusinessHead_Display"
            Text='<%# Eval("HRM_Employees2_EmployeeName") %>'
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBusinessHead"
            BehaviorID="B_ACEBusinessHead"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BusinessHeadCompletionList"
            TargetControlID="F_BusinessHead"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taDepartments.ACEBusinessHead_Selected"
            OnClientPopulating="script_taDepartments.ACEBusinessHead_Populating"
            OnClientPopulated="script_taDepartments.ACEBusinessHead_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
  ID = "ODStaDepartments"
  DataObjectTypeName = "SIS.TA.taDepartments"
  SelectMethod = "taDepartmentsGetByID"
  UpdateMethod="taDepartmentsUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taDepartments"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DepartmentID" Name="DepartmentID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
