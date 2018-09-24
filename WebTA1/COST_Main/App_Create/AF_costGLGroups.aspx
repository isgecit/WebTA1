<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costGLGroups.aspx.vb" Inherits="AF_costGLGroups" title="Add: GL Groups" %>
<asp:Content ID="CPHcostGLGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostGLGroups" runat="server" Text="&nbsp;Add: GL Groups"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLGroups" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostGLGroups"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/COST_Main/App_Edit/EF_costGLGroups.aspx"
    ValidationGroup = "costGLGroups"
    runat = "server" />
<asp:FormView ID="FVcostGLGroups"
  runat = "server"
  DataKeyNames = "GLGroupID"
  DataSourceID = "ODScostGLGroups"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostGLGroups" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLGroupID" ForeColor="#CC6633" runat="server" Text="GL Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLGroupID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GLNatureID" runat="server" Text="GL Nature ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_costGLNatures
            ID="F_GLNatureID"
            SelectedValue='<%# Bind("GLNatureID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costGLGroups"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GLGroupDescriptions" runat="server" Text="GL Group Descriptions :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLGroupDescriptions"
            Text='<%# Bind("GLGroupDescriptions") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costGLGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GL Group Descriptions."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGLGroupDescriptions"
            runat = "server"
            ControlToValidate = "F_GLGroupDescriptions"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLGroups"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CostGLGroupID" runat="server" Text="Cost GL Group ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CostGLGroupID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("CostGLGroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Cost GL Group ID."
            onblur= "script_costGLGroups.validate_CostGLGroupID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CostGLGroupID_Display"
            Text='<%# Eval("COST_vGLGroups2_GLGroupDescriptions") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECostGLGroupID"
            BehaviorID="B_ACECostGLGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CostGLGroupIDCompletionList"
            TargetControlID="F_CostGLGroupID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costGLGroups.ACECostGLGroupID_Selected"
            OnClientPopulating="script_costGLGroups.ACECostGLGroupID_Populating"
            OnClientPopulated="script_costGLGroups.ACECostGLGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Sequence" runat="server" Text="Sequence :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Sequence"
            Text='<%# Bind("Sequence") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mytxt"
            ValidationGroup="costGLGroups"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEESequence"
            runat = "server"
            mask = "99999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Sequence" />
          <AJX:MaskedEditValidator 
            ID = "MEVSequence"
            runat = "server"
            ControlToValidate = "F_Sequence"
            ControlExtender = "MEESequence"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLGroups"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostGLGroups"
  DataObjectTypeName = "SIS.COST.costGLGroups"
  InsertMethod="costGLGroupsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costGLGroups"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
