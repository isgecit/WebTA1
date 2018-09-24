<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costQProjects.aspx.vb" Inherits="AF_costQProjects" title="Add: Quarter Projects" %>
<asp:Content ID="CPHcostQProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostQProjects" runat="server" Text="&nbsp;Add: Quarter Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostQProjects" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostQProjects"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costQProjects"
    runat = "server" />
<asp:FormView ID="FVcostQProjects"
  runat = "server"
  DataKeyNames = "ProjectID,FinYear,Quarter"
  DataSourceID = "ODScostQProjects"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostQProjects" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            ValidationGroup = "costQProjects"
            onblur= "script_costQProjects.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects6_Description") %>'
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
            OnClientItemSelected="script_costQProjects.ACEProjectID_Selected"
            OnClientPopulating="script_costQProjects.ACEProjectID_Populating"
            OnClientPopulated="script_costQProjects.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costQProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="60"
            Width="488px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <LGM:LC_costFinYear
            ID="F_FinYear"
            SelectedValue='<%# Bind("FinYear") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costQProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" ForeColor="#CC6633" runat="server" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <LGM:LC_costQuarters
            ID="F_Quarter"
            SelectedValue='<%# Bind("Quarter") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costQProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectTypeID" runat="server" Text="Project Type ID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_costProjectTypes
            ID="F_ProjectTypeID"
            SelectedValue='<%# Bind("ProjectTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_WorkOrderTypeID" runat="server" Text="Work Order Type ID :" /><span style="color:red">*</span>
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
            ValidationGroup = "costQProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="Division ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_costDivisions
            ID="F_DivisionID"
            SelectedValue='<%# Bind("DivisionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costQProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costQProjects"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CFforPOV" runat="server" Text="Conversion Factor :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CFforPOV"
            Text='<%# Bind("CFforPOV") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costQProjects"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECFforPOV"
            runat = "server"
            mask = "99999999.999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CFforPOV" />
          <AJX:MaskedEditValidator 
            ID = "MEVCFforPOV"
            runat = "server"
            ControlToValidate = "F_CFforPOV"
            ControlExtender = "MEECFforPOV"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectOrderValue" runat="server" Text="Project Order Value :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectOrderValue"
            Text='<%# Bind("ProjectOrderValue") %>'
            Width="120px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costQProjects"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectOrderValue"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectOrderValue" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectOrderValue"
            runat = "server"
            ControlToValidate = "F_ProjectOrderValue"
            ControlExtender = "MEEProjectOrderValue"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectCost" runat="server" Text="Project Cost :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectCost"
            Text='<%# Bind("ProjectCost") %>'
            Width="120px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costQProjects"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEProjectCost"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ProjectCost" />
          <AJX:MaskedEditValidator 
            ID = "MEVProjectCost"
            runat = "server"
            ControlToValidate = "F_ProjectCost"
            ControlExtender = "MEEProjectCost"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MarginCurrentYear" runat="server" Text="Margin Current Year :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_MarginCurrentYear"
            Text='<%# Bind("MarginCurrentYear") %>'
            Width="120px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="14"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEMarginCurrentYear"
            runat = "server"
            mask = "999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MarginCurrentYear" />
          <AJX:MaskedEditValidator 
            ID = "MEVMarginCurrentYear"
            runat = "server"
            ControlToValidate = "F_MarginCurrentYear"
            ControlExtender = "MEEMarginCurrentYear"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WarrantyPercentage" runat="server" Text="Warranty Percentage :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WarrantyPercentage"
            Text='<%# Bind("WarrantyPercentage") %>'
            Width="72px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="costQProjects"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEWarrantyPercentage"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_WarrantyPercentage" />
          <AJX:MaskedEditValidator 
            ID = "MEVWarrantyPercentage"
            runat = "server"
            ControlToValidate = "F_WarrantyPercentage"
            ControlExtender = "MEEWarrantyPercentage"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costQProjects"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
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
  ID = "ODScostQProjects"
  DataObjectTypeName = "SIS.COST.costQProjects"
  InsertMethod="UZ_costQProjectsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costQProjects"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
