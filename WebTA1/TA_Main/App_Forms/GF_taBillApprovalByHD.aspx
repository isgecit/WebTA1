<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taBillApprovalByHD.aspx.vb" Inherits="GF_taBillApprovalByHD" title="Maintain List: Verify TA Bill" %>
<asp:Content ID="CPHtaBillApprovalByHD" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaBillApprovalByHD" runat="server" Text="&nbsp;List: Verify TA Bill"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillApprovalByHD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillApprovalByHD"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillApprovalByHD.aspx"
      EnableAdd = "False"
      ValidationGroup = "taBillApprovalByHD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillApprovalByHD" runat="server" AssociatedUpdatePanelID="UPNLtaBillApprovalByHD" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" runat="server" Text="TA Bill No :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_TABillNo"
            Text=""
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETABillNo"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TABillNo" />
          <AJX:MaskedEditValidator 
            ID = "MEVTABillNo"
            runat = "server"
            ControlToValidate = "F_TABillNo"
            ControlExtender = "MEETABillNo"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_EmployeeID" runat="server" Text="Employee ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            CssClass = "myfktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_EmployeeID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEmployeeID"
            BehaviorID="B_ACEEmployeeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EmployeeIDCompletionList"
            TargetControlID="F_EmployeeID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEmployeeID_Selected"
            OnClientPopulating="ACEEmployeeID_Populating"
            OnClientPopulated="ACEEmployeeID_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Width="42px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectID_Selected"
            OnClientPopulating="ACEProjectID_Populating"
            OnClientPopulated="ACEProjectID_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BillStatusID" runat="server" Text="Bill Status :" /></b>
        </td>
        <td>
          <asp:DropDownList
            ID = "F_BillStatusID"
            CssClass = "myfktxt"
            Width="200px"
            AutoPostBack="true"
            Runat="Server" >
            <asp:ListItem Selected="True" Value="10" Text="Under Verification"></asp:ListItem>
            <asp:ListItem Value="0" Text="Verified By Me"></asp:ListItem>
          </asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TravelTypeID" runat="server" Text="Travel Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_taTravelTypes
            ID="F_TravelTypeID"
            SelectedValue=""
            OrderBy="TravelTypeDescription"
            DataTextField="TravelTypeDescription"
            DataValueField="TravelTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DestinationCity" runat="server" Text="Destination City :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_DestinationCity"
            CssClass = "myfktxt"
            Width="210px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_DestinationCity(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DestinationCity_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDestinationCity"
            BehaviorID="B_ACEDestinationCity"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DestinationCityCompletionList"
            TargetControlID="F_DestinationCity"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEDestinationCity_Selected"
            OnClientPopulating="ACEDestinationCity_Populating"
            OnClientPopulated="ACEDestinationCity_Populated"
            CompletionSetCount="20"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_taBillApprovalByHD.aspx', 'App_Print/RP_taBH.aspx');
        url = url + '?pk=' + o.alt + '&warn=1';
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <script type="text/javascript"> 
   var script_ApprovalRemarks = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVtaBillApprovalByHD" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillApprovalByHD" DataKeyNames="TABillNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TA No." SortExpression="TABillNo">
          <ItemTemplate>
            <asp:Label ID="LabelTABillNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TABillNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee ID" SortExpression="HRM_Employees5_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_EmployeeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("EmployeeID") %>' Text='<%# Eval("HRM_Employees5_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Purpose Of Journey" SortExpression="PurposeOfJourney">
          <ItemTemplate>
            <asp:Label ID="LabelPurposeOfJourney" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PurposeOfJourney") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="TotalClaimedAmount">
          <ItemTemplate>
            <asp:Label ID="LabelTotalClaimedAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalClaimedAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payable Amount" SortExpression="TotalPayableAmount">
          <ItemTemplate>
            <asp:Label ID="LabelTotalPayableAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalPayableAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Status" SortExpression="TA_BillStates16_Description">
          <ItemTemplate>
             <asp:Label ID="L_BillStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BillStatusID") %>' Text='<%# Eval("TA_BillStates16_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="ApprovalRemarks">
          <ItemTemplate>
          <asp:TextBox ID="F_ApprovalRemarks"
            Text='<%# Bind("ApprovalRemarks") %>'
            Width="300px" 
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter Remarks."
            MaxLength="500"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Verify">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Verify" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Verify record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reject">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reject" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Reject record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBillApprovalByHD"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillApprovalByHD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBillApprovalByHDSelectList"
      TypeName = "SIS.TA.taBillApprovalByHD"
      SelectCountMethod = "taBillApprovalByHDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_EmployeeID" PropertyName="Text" Name="EmployeeID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_BillStatusID" PropertyName="SelectedValue" Name="BillStatusID" Type="Int32" Size="10" DefaultValue="10" />
        <asp:ControlParameter ControlID="F_DestinationCity" PropertyName="Text" Name="DestinationCity" Type="String" Size="30" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_TravelTypeID" PropertyName="SelectedValue" Name="TravelTypeID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBillApprovalByHD" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_TABillNo" />
    <asp:AsyncPostBackTrigger ControlID="F_EmployeeID" />
    <asp:AsyncPostBackTrigger ControlID="F_BillStatusID" />
    <asp:AsyncPostBackTrigger ControlID="F_DestinationCity" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_TravelTypeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
