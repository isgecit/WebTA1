<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_taBH.aspx.vb" Inherits="GF_taBH" title="Maintain List: Travel Expense Statements" %>
<asp:Content ID="CPHtaBH" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaBH" runat="server" Text="&nbsp;List: Travel Expense Statements"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBH" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBH"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBH.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBH.aspx?skip=1"
      ValidationGroup = "taBH"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBH" runat="server" AssociatedUpdatePanelID="UPNLtaBH" DisplayAfter="100">
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
          <b><asp:Label ID="L_BillStatusID" runat="server" Text="Bill Status :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BillStatusID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_BillStatusID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_BillStatusID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBillStatusID"
            BehaviorID="B_ACEBillStatusID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BillStatusIDCompletionList"
            TargetControlID="F_BillStatusID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEBillStatusID_Selected"
            OnClientPopulating="ACEBillStatusID_Populating"
            OnClientPopulated="ACEBillStatusID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
            Width="248px"
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
            CompletionSetCount="10"
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
            Width="56px"
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
            CompletionSetCount="10"
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
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <script type="text/javascript">
      var pcnt = 0;
      function show_notes(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = o.getAttribute('CommandValue');
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVtaBH" SkinID="gv_silver" runat="server" DataSourceID="ODStaBH" DataKeyNames="TABillNo">
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
        <asp:TemplateField HeaderText="NOTE">
          <ItemTemplate>
            <asp:ImageButton ID="cmdNotes" runat="server" AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="View/reply Notes in TA Bill" SkinID="notes" CommandValue='<%# Eval("GetNotesLink") %>' OnClientClick="return show_notes(this);" CommandArgument='<%# Container.DataItemIndex %>' />
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
        <asp:TemplateField HeaderText="Destination City" SortExpression="TA_Cities14_CityName">
          <ItemTemplate>
             <asp:Label ID="L_DestinationCity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DestinationCity") %>' Text='<%# Eval("TA_Cities14_CityName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects11_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects11_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
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
<%--        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Budget">
          <ItemTemplate>
            <asp:ImageButton ID="cmdBudget" runat="server" AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="Check Project Budget" SkinID="info" CommandName="BudgetWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""If PROJECT related Travel, then check Available Budget First. Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField >
          <ItemTemplate>
						</td></tr>
						<tr style="background-color:AntiqueWhite; color:DeepPink">
              <td colspan="5"></td>
              <td colspan="7">
                <asp:Label ID="LabelNotification" runat="server" Text='<%# Eval("Notification") %>'></asp:Label>
              </td>
						</tr>
          </ItemTemplate>
          <HeaderStyle Width="10px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBH"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBH"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBHSelectList"
      TypeName = "SIS.TA.taBH"
      SelectCountMethod = "taBHSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DestinationCity" PropertyName="Text" Name="DestinationCity" Type="String" Size="30" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_BillStatusID" PropertyName="Text" Name="BillStatusID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_TravelTypeID" PropertyName="SelectedValue" Name="TravelTypeID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBH" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_DestinationCity" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_BillStatusID" />
    <asp:AsyncPostBackTrigger ControlID="F_TravelTypeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
