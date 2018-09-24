<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakElements.aspx.vb" Inherits="EF_pakElements" title="Edit: Elements" %>
<asp:Content ID="CPHpakElements" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakElements" runat="server" Text="&nbsp;Edit: Elements"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakElements" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakElements"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakElements"
    runat = "server" />
<asp:FormView ID="FVpakElements"
  runat = "server"
  DataKeyNames = "ElementID"
  DataSourceID = "ODSpakElements"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ElementID" runat="server" ForeColor="#CC6633" Text="Element ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ElementID"
            Text='<%# Bind("ElementID") %>'
            ToolTip="Value of Element ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="72px"
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
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakElements"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakElements"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ResponsibleAgencyID" runat="server" Text="Responsible Agency ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_pakResponsibleAgencies
            ID="F_ResponsibleAgencyID"
            SelectedValue='<%# Bind("ResponsibleAgencyID") %>'
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ParentElementID" runat="server" Text="Parent Element ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ParentElementID"
            CssClass = "myfktxt"
            Text='<%# Bind("ParentElementID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Parent Element ID."
            onblur= "script_pakElements.validate_ParentElementID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ParentElementID_Display"
            Text='<%# Eval("PAK_Elements1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEParentElementID"
            BehaviorID="B_ACEParentElementID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ParentElementIDCompletionList"
            TargetControlID="F_ParentElementID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakElements.ACEParentElementID_Selected"
            OnClientPopulating="script_pakElements.ACEParentElementID_Populating"
            OnClientPopulated="script_pakElements.ACEParentElementID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ElementLevel" runat="server" Text="Element Level :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ElementLevel"
            Text='<%# Bind("ElementLevel") %>'
            ToolTip="Value of Element Level."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Prefix" runat="server" Text="Prefix :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Prefix"
            Text='<%# Bind("Prefix") %>'
            ToolTip="Value of Prefix."
            Enabled = "False"
            Width="350px" Height="40px"
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
  ID = "ODSpakElements"
  DataObjectTypeName = "SIS.PAK.pakElements"
  SelectMethod = "pakElementsGetByID"
  UpdateMethod="UZ_pakElementsUpdate"
  DeleteMethod="UZ_pakElementsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakElements"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ElementID" Name="ElementID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
