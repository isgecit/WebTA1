<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costAdjustmentEntry.aspx.vb" Inherits="EF_costAdjustmentEntry" title="Edit: Adjustment Entry" %>
<asp:Content ID="CPHcostAdjustmentEntry" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostAdjustmentEntry" runat="server" Text="&nbsp;Edit: Adjustment Entry"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostAdjustmentEntry" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostAdjustmentEntry"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costAdjustmentEntry"
    runat = "server" />
<asp:FormView ID="FVcostAdjustmentEntry"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,Revision,AdjustmentSerialNo"
  DataSourceID = "ODScostAdjustmentEntry"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectGroupID"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project Group ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups6_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin. Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin. Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear5_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_Quarter"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Quarter."
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Revision" runat="server" ForeColor="#CC6633" Text="Revision :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Revision"
            Text='<%# Bind("Revision") %>'
            ToolTip="Value of Revision."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AdjustmentSerialNo" runat="server" ForeColor="#CC6633" Text="Adjustment Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AdjustmentSerialNo"
            Text='<%# Bind("AdjustmentSerialNo") %>'
            ToolTip="Value of Adjustment Serial No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects8_Description") %>'
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
            OnClientItemSelected="script_costAdjustmentEntry.ACEProjectID_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACEProjectID_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACEProjectID_Populated"
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
          <asp:Label ID="L_CrGLCode" runat="server" Text="Cr. GL Code :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CrGLCode"
            CssClass = "myfktxt"
            Text='<%# Bind("CrGLCode") %>'
            AutoCompleteType = "None"
            Width="64px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Cr. GL Code."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_CrGLCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCrGLCode"
            runat = "server"
            ControlToValidate = "F_CrGLCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_CrGLCode_Display"
            Text='<%# Eval("COST_ERPGLCodes3_GLDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECrGLCode"
            BehaviorID="B_ACECrGLCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CrGLCodeCompletionList"
            TargetControlID="F_CrGLCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costAdjustmentEntry.ACECrGLCode_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACECrGLCode_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACECrGLCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DrGLCode" runat="server" Text="Dr. GL Code :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_DrGLCode"
            CssClass = "myfktxt"
            Text='<%# Bind("DrGLCode") %>'
            AutoCompleteType = "None"
            Width="64px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Dr. GL Code."
            ValidationGroup = "costAdjustmentEntry"
            onblur= "script_costAdjustmentEntry.validate_DrGLCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDrGLCode"
            runat = "server"
            ControlToValidate = "F_DrGLCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_DrGLCode_Display"
            Text='<%# Eval("COST_ERPGLCodes4_GLDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDrGLCode"
            BehaviorID="B_ACEDrGLCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DrGLCodeCompletionList"
            TargetControlID="F_DrGLCode"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_costAdjustmentEntry.ACEDrGLCode_Selected"
            OnClientPopulating="script_costAdjustmentEntry.ACEDrGLCode_Populating"
            OnClientPopulated="script_costAdjustmentEntry.ACEDrGLCode_Populated"
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
          <asp:Label ID="L_Amount" runat="server" Text="Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "costAdjustmentEntry"
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
            ValidationGroup = "costAdjustmentEntry"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Active"
            Checked='<%# Bind("Active") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costAdjustmentEntry"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRemarks"
            runat = "server"
            ControlToValidate = "F_Remarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costAdjustmentEntry"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
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
  ID = "ODScostAdjustmentEntry"
  DataObjectTypeName = "SIS.COST.costAdjustmentEntry"
  SelectMethod = "costAdjustmentEntryGetByID"
  UpdateMethod="UZ_costAdjustmentEntryUpdate"
  DeleteMethod="UZ_costAdjustmentEntryDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costAdjustmentEntry"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Revision" Name="Revision" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="AdjustmentSerialNo" Name="AdjustmentSerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
