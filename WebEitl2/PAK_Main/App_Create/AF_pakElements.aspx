<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakElements.aspx.vb" Inherits="AF_pakElements" title="Add: Elements" %>
<asp:Content ID="CPHpakElements" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakElements" runat="server" Text="&nbsp;Add: Elements"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakElements" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakElements"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakElements"
    runat = "server" />
<asp:FormView ID="FVpakElements"
  runat = "server"
  DataKeyNames = "ElementID"
  DataSourceID = "ODSpakElements"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakElements" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ElementID" ForeColor="#CC6633" runat="server" Text="Element ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ElementID"
            Text='<%# Bind("ElementID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="pakElements"
            onblur= "script_pakElements.validate_ElementID(this);"
            ToolTip="Enter value for Element ID."
            MaxLength="8"
            Width="72px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVElementID"
            runat = "server"
            ControlToValidate = "F_ElementID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakElements"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakElements"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ParentElementID" runat="server" Text="Parent Element ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ParentElementID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("ParentElementID") %>'
            AutoCompleteType = "None"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakElements"
  DataObjectTypeName = "SIS.PAK.pakElements"
  InsertMethod="UZ_pakElementsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakElements"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
