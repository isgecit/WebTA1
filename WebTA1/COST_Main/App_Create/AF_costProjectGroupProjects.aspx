<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costProjectGroupProjects.aspx.vb" Inherits="AF_costProjectGroupProjects" title="Add: Project Group Projects" %>
<asp:Content ID="CPHcostProjectGroupProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectGroupProjects" runat="server" Text="&nbsp;Add: Project Group Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectGroupProjects" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectGroupProjects"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costProjectGroupProjects"
    runat = "server" />
<asp:FormView ID="FVcostProjectGroupProjects"
  runat = "server"
  DataKeyNames = "ProjectGroupID,ProjectID"
  DataSourceID = "ODScostProjectGroupProjects"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostProjectGroupProjects" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" ForeColor="#CC6633" runat="server" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project Group ID."
            ValidationGroup = "costProjectGroupProjects"
            onblur= "script_costProjectGroupProjects.validate_ProjectGroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectGroupID"
            runat = "server"
            ControlToValidate = "F_ProjectGroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectGroupProjects"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups1_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectGroupID"
            BehaviorID="B_ACEProjectGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectGroupIDCompletionList"
            TargetControlID="F_ProjectGroupID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costProjectGroupProjects.ACEProjectGroupID_Selected"
            OnClientPopulating="script_costProjectGroupProjects.ACEProjectGroupID_Populating"
            OnClientPopulated="script_costProjectGroupProjects.ACEProjectGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            ValidationGroup = "costProjectGroupProjects"
            onblur= "script_costProjectGroupProjects.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectGroupProjects"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costProjectGroupProjects.ACEProjectID_Selected"
            OnClientPopulating="script_costProjectGroupProjects.ACEProjectID_Populating"
            OnClientPopulated="script_costProjectGroupProjects.ACEProjectID_Populated"
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
  ID = "ODScostProjectGroupProjects"
  DataObjectTypeName = "SIS.COST.costProjectGroupProjects"
  InsertMethod="costProjectGroupProjectsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectGroupProjects"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
