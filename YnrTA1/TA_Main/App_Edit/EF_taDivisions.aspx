<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taDivisions.aspx.vb" Inherits="EF_taDivisions" title="Edit: Divisions" %>
<asp:Content ID="CPHtaDivisions" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaDivisions" runat="server" Text="&nbsp;Edit: Divisions"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaDivisions" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaDivisions"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taDivisions"
    runat = "server" />
<asp:FormView ID="FVtaDivisions"
  runat = "server"
  DataKeyNames = "DivisionID"
  DataSourceID = "ODStaDivisions"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DivisionID" runat="server" ForeColor="#CC6633" Text="DivisionID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_DivisionID"
            Text='<%# Bind("DivisionID") %>'
            ToolTip="Value of DivisionID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="42px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taDivisions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taDivisions"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DivisionHead" runat="server" Text="Division Head :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DivisionHead"
            CssClass = "myfktxt"
            Text='<%# Bind("DivisionHead") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Division Head."
            onblur= "script_taDivisions.validate_DivisionHead(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DivisionHead_Display"
            Text='<%# Eval("HRM_Employees1_EmployeeName") %>'
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDivisionHead"
            BehaviorID="B_ACEDivisionHead"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DivisionHeadCompletionList"
            TargetControlID="F_DivisionHead"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taDivisions.ACEDivisionHead_Selected"
            OnClientPopulating="script_taDivisions.ACEDivisionHead_Populating"
            OnClientPopulated="script_taDivisions.ACEDivisionHead_Populated"
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
          <asp:Label ID="L_ERP_EU" runat="server" Text="ERP Enterprice Unit :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ERP_EU"
            Text='<%# Bind("ERP_EU") %>'
            Width="70px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ERP Enterprice Unit."
            MaxLength="10"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ERP_Div" runat="server" Text="ERP Division :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ERP_Div"
            Text='<%# Bind("ERP_Div") %>'
            Width="70px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ERP Division."
            MaxLength="10"
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
  ID = "ODStaDivisions"
  DataObjectTypeName = "SIS.TA.taDivisions"
  SelectMethod = "taDivisionsGetByID"
  UpdateMethod="taDivisionsUpdate"
  DeleteMethod="taDivisionsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taDivisions"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DivisionID" Name="DivisionID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
