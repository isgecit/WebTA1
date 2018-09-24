<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costGLGroups.aspx.vb" Inherits="EF_costGLGroups" title="Edit: GL Groups" %>
<asp:Content ID="CPHcostGLGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostGLGroups" runat="server" Text="&nbsp;Edit: GL Groups"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLGroups" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostGLGroups"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costGLGroups"
    runat = "server" />
<asp:FormView ID="FVcostGLGroups"
  runat = "server"
  DataKeyNames = "GLGroupID"
  DataSourceID = "ODScostGLGroups"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLGroupID" runat="server" ForeColor="#CC6633" Text="GL Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLGroupID"
            Text='<%# Bind("GLGroupID") %>'
            ToolTip="Value of GL Group ID."
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GLGroupDescriptions" runat="server" Text="GL Group Descriptions :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLGroupDescriptions"
            Text='<%# Bind("GLGroupDescriptions") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costGLGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GL Group Descriptions."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CostGLGroupID" runat="server" Text="Cost GL Group ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CostGLGroupID"
            CssClass = "myfktxt"
            Text='<%# Bind("CostGLGroupID") %>'
            AutoCompleteType = "None"
            Width="88px"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Sequence" runat="server" Text="Sequence :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Sequence"
            Text='<%# Bind("Sequence") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup= "costGLGroups"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelcostGLGroupGLs" runat="server" Text="&nbsp;List: GL Group GLs"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLGroupGLs" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostGLGroupGLs"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costGLGroupGLs.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costGLGroupGLs.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "costGLGroupGLs"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostGLGroupGLs" runat="server" AssociatedUpdatePanelID="UPNLcostGLGroupGLs" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostGLGroupGLs" SkinID="gv_silver" runat="server" DataSourceID="ODScostGLGroupGLs" DataKeyNames="GLGroupID,GLCode">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Group ID" SortExpression="COST_GLGroups1_GLGroupDescriptions">
          <ItemTemplate>
             <asp:Label ID="L_GLGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GLGroupID") %>' Text='<%# Eval("COST_GLGroups1_GLGroupDescriptions") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Code [ERP]" SortExpression="COST_ERPGLCodes2_GLDescription">
          <ItemTemplate>
             <asp:Label ID="L_GLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GLCode") %>' Text='<%# Eval("COST_ERPGLCodes2_GLDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Effective Start Date" SortExpression="EffectiveStartDate">
          <ItemTemplate>
            <asp:Label ID="LabelEffectiveStartDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EffectiveStartDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Effective End Date" SortExpression="EffectiveEndDate">
          <ItemTemplate>
            <asp:Label ID="LabelEffectiveEndDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EffectiveEndDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostGLGroupGLs"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costGLGroupGLs"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costGLGroupGLsSelectList"
      TypeName = "SIS.COST.costGLGroupGLs"
      SelectCountMethod = "costGLGroupGLsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_GLGroupID" PropertyName="Text" Name="GLGroupID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostGLGroupGLs" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostGLGroups"
  DataObjectTypeName = "SIS.COST.costGLGroups"
  SelectMethod = "costGLGroupsGetByID"
  UpdateMethod="costGLGroupsUpdate"
  DeleteMethod="costGLGroupsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costGLGroups"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GLGroupID" Name="GLGroupID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
