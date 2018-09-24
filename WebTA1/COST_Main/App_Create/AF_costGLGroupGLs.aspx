<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costGLGroupGLs.aspx.vb" Inherits="AF_costGLGroupGLs" title="Add: GL Group GLs" %>
<asp:Content ID="CPHcostGLGroupGLs" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostGLGroupGLs" runat="server" Text="&nbsp;Add: GL Group GLs"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLGroupGLs" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostGLGroupGLs"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costGLGroupGLs"
    runat = "server" />
<asp:FormView ID="FVcostGLGroupGLs"
  runat = "server"
  DataKeyNames = "GLGroupID,GLCode"
  DataSourceID = "ODScostGLGroupGLs"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostGLGroupGLs" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLGroupID" ForeColor="#CC6633" runat="server" Text="GL Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_GLGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("GLGroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for GL Group ID."
            ValidationGroup = "costGLGroupGLs"
            onblur= "script_costGLGroupGLs.validate_GLGroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGLGroupID"
            runat = "server"
            ControlToValidate = "F_GLGroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLGroupGLs"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_GLGroupID_Display"
            Text='<%# Eval("COST_GLGroups1_GLGroupDescriptions") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEGLGroupID"
            BehaviorID="B_ACEGLGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="GLGroupIDCompletionList"
            TargetControlID="F_GLGroupID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costGLGroupGLs.ACEGLGroupID_Selected"
            OnClientPopulating="script_costGLGroupGLs.ACEGLGroupID_Populating"
            OnClientPopulated="script_costGLGroupGLs.ACEGLGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLCode" ForeColor="#CC6633" runat="server" Text="GL Code [ERP] :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_GLCode"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("GLCode") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for GL Code [ERP]."
            ValidationGroup = "costGLGroupGLs"
            onblur= "script_costGLGroupGLs.validate_GLCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGLCode"
            runat = "server"
            ControlToValidate = "F_GLCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLGroupGLs"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_GLCode_Display"
            Text='<%# Eval("COST_ERPGLCodes2_GLDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEGLCode"
            BehaviorID="B_ACEGLCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="GLCodeCompletionList"
            TargetControlID="F_GLCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costGLGroupGLs.ACEGLCode_Selected"
            OnClientPopulating="script_costGLGroupGLs.ACEGLCode_Populating"
            OnClientPopulated="script_costGLGroupGLs.ACEGLCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EffectiveStartDate" runat="server" Text="Effective Start Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EffectiveStartDate"
            Text='<%# Bind("EffectiveStartDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="costGLGroupGLs"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonEffectiveStartDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEEffectiveStartDate"
            TargetControlID="F_EffectiveStartDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonEffectiveStartDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEEffectiveStartDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_EffectiveStartDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVEffectiveStartDate"
            runat = "server"
            ControlToValidate = "F_EffectiveStartDate"
            ControlExtender = "MEEEffectiveStartDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLGroupGLs"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EffectiveEndDate" runat="server" Text="Effective End Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EffectiveEndDate"
            Text='<%# Bind("EffectiveEndDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="costGLGroupGLs"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonEffectiveEndDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEEffectiveEndDate"
            TargetControlID="F_EffectiveEndDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonEffectiveEndDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEEffectiveEndDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_EffectiveEndDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVEffectiveEndDate"
            runat = "server"
            ControlToValidate = "F_EffectiveEndDate"
            ControlExtender = "MEEEffectiveEndDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLGroupGLs"
            IsValidEmpty = "false"
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
  ID = "ODScostGLGroupGLs"
  DataObjectTypeName = "SIS.COST.costGLGroupGLs"
  InsertMethod="costGLGroupGLsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costGLGroupGLs"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
