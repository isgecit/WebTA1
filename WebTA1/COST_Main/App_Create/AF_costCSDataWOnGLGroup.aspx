<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costCSDataWOnGLGroup.aspx.vb" Inherits="AF_costCSDataWOnGLGroup" title="Add: CS Data WO and GL Group wise" %>
<asp:Content ID="CPHcostCSDataWOnGLGroup" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostCSDataWOnGLGroup" runat="server" Text="&nbsp;Add: CS Data WO and GL Group wise"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostCSDataWOnGLGroup" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostCSDataWOnGLGroup"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costCSDataWOnGLGroup"
    runat = "server" />
<asp:FormView ID="FVcostCSDataWOnGLGroup"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,Revision,WorkOrderTypeID,GLGroupID"
  DataSourceID = "ODScostCSDataWOnGLGroup"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostCSDataWOnGLGroup" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" ForeColor="#CC6633" runat="server" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project Group ID."
            ValidationGroup = "costCSDataWOnGLGroup"
            onblur= "script_costCSDataWOnGLGroup.validate_ProjectGroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectGroupID"
            runat = "server"
            ControlToValidate = "F_ProjectGroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups4_ProjectGroupDescription") %>'
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
            OnClientItemSelected="script_costCSDataWOnGLGroup.ACEProjectGroupID_Selected"
            OnClientPopulating="script_costCSDataWOnGLGroup.ACEProjectGroupID_Populating"
            OnClientPopulated="script_costCSDataWOnGLGroup.ACEProjectGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin.Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Fin.Year."
            ValidationGroup = "costCSDataWOnGLGroup"
            onblur= "script_costCSDataWOnGLGroup.validate_FinYear(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFinYear"
            runat = "server"
            ControlToValidate = "F_FinYear"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear2_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFinYear"
            BehaviorID="B_ACEFinYear"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FinYearCompletionList"
            TargetControlID="F_FinYear"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costCSDataWOnGLGroup.ACEFinYear_Selected"
            OnClientPopulating="script_costCSDataWOnGLGroup.ACEFinYear_Populating"
            OnClientPopulated="script_costCSDataWOnGLGroup.ACEFinYear_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" ForeColor="#CC6633" runat="server" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Quarter."
            ValidationGroup = "costCSDataWOnGLGroup"
            onblur= "script_costCSDataWOnGLGroup.validate_Quarter(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVQuarter"
            runat = "server"
            ControlToValidate = "F_Quarter"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEQuarter"
            BehaviorID="B_ACEQuarter"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="QuarterCompletionList"
            TargetControlID="F_Quarter"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costCSDataWOnGLGroup.ACEQuarter_Selected"
            OnClientPopulating="script_costCSDataWOnGLGroup.ACEQuarter_Populating"
            OnClientPopulated="script_costCSDataWOnGLGroup.ACEQuarter_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_Revision" ForeColor="#CC6633" runat="server" Text="Revision :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_Revision"
            Text='<%# Bind("Revision") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="costCSDataWOnGLGroup"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEERevision"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Revision" />
          <AJX:MaskedEditValidator 
            ID = "MEVRevision"
            runat = "server"
            ControlToValidate = "F_Revision"
            ControlExtender = "MEERevision"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WorkOrderTypeID" ForeColor="#CC6633" runat="server" Text="Work Order Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <LGM:LC_costWorkOrderTypes
            ID="F_WorkOrderTypeID"
            SelectedValue='<%# Bind("WorkOrderTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costCSDataWOnGLGroup"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <b><asp:Label ID="L_GLGroupID" ForeColor="#CC6633" runat="server" Text="GL Group :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_GLGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("GLGroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for GL Group."
            ValidationGroup = "costCSDataWOnGLGroup"
            onblur= "script_costCSDataWOnGLGroup.validate_GLGroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGLGroupID"
            runat = "server"
            ControlToValidate = "F_GLGroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_GLGroupID_Display"
            Text='<%# Eval("COST_GLGroups3_GLGroupDescriptions") %>'
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
            OnClientItemSelected="script_costCSDataWOnGLGroup.ACEGLGroupID_Selected"
            OnClientPopulating="script_costCSDataWOnGLGroup.ACEGLGroupID_Populating"
            OnClientPopulated="script_costCSDataWOnGLGroup.ACEGLGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CrAmount" runat="server" Text="CrAmount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CrAmount"
            Text='<%# Bind("CrAmount") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costCSDataWOnGLGroup"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECrAmount"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CrAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVCrAmount"
            runat = "server"
            ControlToValidate = "F_CrAmount"
            ControlExtender = "MEECrAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DrAmount" runat="server" Text="DrAmount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DrAmount"
            Text='<%# Bind("DrAmount") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costCSDataWOnGLGroup"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEDrAmount"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DrAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVDrAmount"
            runat = "server"
            ControlToValidate = "F_DrAmount"
            ControlExtender = "MEEDrAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Amount" runat="server" Text="Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costCSDataWOnGLGroup"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmount"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmount"
            runat = "server"
            ControlToValidate = "F_Amount"
            ControlExtender = "MEEAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostCSDataWOnGLGroup"
  DataObjectTypeName = "SIS.COST.costCSDataWOnGLGroup"
  InsertMethod="UZ_costCSDataWOnGLGroupInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costCSDataWOnGLGroup"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
