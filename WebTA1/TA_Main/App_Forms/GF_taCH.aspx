<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_taCH.aspx.vb" Inherits="GF_taCH" title="Maintain List: Travel Expense Statements" %>
<asp:Content ID="CPHtaCH" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaCH" runat="server" Text="&nbsp;List: Travel Expense Statements"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaCH" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaCH"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taCH.aspx"
      EnableAdd = "False"
      ValidationGroup = "taCH"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaCH" runat="server" AssociatedUpdatePanelID="UPNLtaCH" DisplayAfter="100">
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
          <b><asp:Label ID="Label1" runat="server" Text="TA Bill No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_TABillNo"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            AutoPostBack="true"
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            Runat="Server" />
        </td>
      </tr>

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
          <b><asp:Label ID="L_EmployeeID" runat="server" Text="Employee ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            CssClass = "myfktxt"
            Width="72px"
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
        var url = self.location.href.replace('App_Forms/GF_taCH','App_Print/RP_taBH');
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
      function show_holdnotes(url) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVtaCH" SkinID="gv_silver" runat="server" DataSourceID="ODStaCH" DataKeyNames="TABillNo">
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
        <asp:TemplateField HeaderText="Employee ID" SortExpression="HRM_Employees5_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_EmployeeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("EmployeeID") %>' Text='<%# Eval("HRM_Employees5_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
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
        <asp:TemplateField HeaderText="HOLD">
          <ItemTemplate>
            <asp:ImageButton ID="cmdHold" ValidationGroup='<%# "Hold" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("HoldWFVisible") %>' Enabled='<%# EVal("HoldWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Hold" SkinID="Hold" OnClientClick='<%# "return Page_ClientValidate(""Hold" & Container.DataItemIndex & """) && confirm(""Hold record ?"");" %>' CommandName="HoldWF" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:ImageButton ID="cmdReminder" ValidationGroup='<%# "Hold" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ReminderVisible") %>' Enabled='<%# EVal("HoldWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Send Reminder" SkinID="email" CommandValue='<%# Eval("GetNotesLink") %>' OnClientClick="return show_notes(this);" CommandName="Reminder" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UN-HOLD">
          <ItemTemplate>
            <asp:ImageButton ID="cmdUnlock" ValidationGroup='<%# "Unlock" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("UnlockWFVisible") %>' Enabled='<%# EVal("UnlockWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Unlock" SkinID="Unlock" OnClientClick='<%# "return Page_ClientValidate(""Unlock" & Container.DataItemIndex & """) && confirm(""Unlock record ?"");" %>' CommandName="UnlockWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REC-DOC">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Receive" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Receive record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RETURN">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PROCESSED">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Processed" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Processed record ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AUTO VCH">
          <ItemTemplate>
            <asp:Panel runat="server" ID="PostPnl" Visible='<%# Eval("PostPnlVisible") %>' style="width:200px;background-color:antiquewhite;border:solid 1pt pink" >
              <table>
                <tr>
                  <td class="alignright">
                    <b><asp:Label ID="L_VCHOn" runat="server" Text="Voucher Date :" />&nbsp;</b>
                  </td>
                  <td>
                    <asp:TextBox ID="F_VCHOn"
                      Text='<%# Bind("VCHOn") %>'
                      Width="90px" 
                      CssClass = "mytxt"
                      runat="server" />
                    <asp:Image ID="ImageButtonVCHOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
                    <AJX:CalendarExtender 
                      ID = "CEVCHOn"
                      TargetControlID="F_VCHOn"
                      Format="dd/MM/yyyy"
                      runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonVCHOn" />
                    <AJX:MaskedEditExtender 
                      ID = "MEEVCHOn"
                      runat = "server"
                      mask = "99/99/9999"
                      MaskType="Date"
                      CultureName = "en-GB"
                      MessageValidatorTip="true"
                      InputDirection="LeftToRight"
                      ErrorTooltipEnabled="true"
                      TargetControlID="F_VCHOn" />
                  </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b><asp:Label ID="Label2" runat="server" Text="Deptt. :" />&nbsp;</b>
                  </td>
                  <td >
                    <LGM:LC_taDepartments
                      ID="F_Dept"
                      SelectedValue='<%# Bind("DepartmentID") %>'
                      OrderBy="Code"
                      DataTextField="DisplayField"
                      DataValueField="PrimaryKey"
                      IncludeDefault="true"
                      DefaultText="-- Select --"
                      Width="150px"
                      CssClass="myddl"
                      Runat="Server" />
                    </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b><asp:Label ID="Label3" runat="server" Text="Cost Center :" />&nbsp;</b>
                  </td>
                  <td >
                    <LGM:LC_taDepartments
                      ID="F_CC"
                      SelectedValue='<%# Bind("CostCenterID") %>'
                      OrderBy="Code"
                      DataTextField="DisplayField"
                      DataValueField="PrimaryKey"
                      IncludeDefault="true"
                      DefaultText="-- Select --"
                      Width="150px"
                      CssClass="myddl"
                      Runat="Server" />
                    </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b><asp:Label ID="Label4" runat="server" Text="Element :" />&nbsp;</b>
                  </td>
                  <td>
                    <asp:DropDownList
                      id="F_Element"
                      runat="server"
                      CssClass="myddl"
                      width="90">
                      <asp:ListItem Value="99080500" Text="99080500"></asp:ListItem>
                      <asp:ListItem Value="99080200" Text="99080200"></asp:ListItem>
                      <asp:ListItem Value="99020500" Text="99020500"></asp:ListItem>
                      <asp:ListItem Value="99250100" Text="99250100"></asp:ListItem>
                    </asp:DropDownList>
                  </td>
                </tr>
                <tr>
                  <td class="alignCenter">
                    <asp:ImageButton ID="vcmdCancel" ValidationGroup='<%# "Cancel" & Container.DataItemIndex %>' CausesValidation="true" runat="server"  AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Cancel" SkinID="Cancel" OnClientClick='<%# "return Page_ClientValidate(""Cancel" & Container.DataItemIndex & """) && confirm(""Cancel Posting ?"");" %>' CommandName="CancelPost" CommandArgument='<%# Container.DataItemIndex %>' />
                  </td>
                  <td class="alignCenter">
                    <asp:ImageButton ID="vcmdSave" ValidationGroup='<%# "Save" & Container.DataItemIndex %>' CausesValidation="true" runat="server"  AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save" SkinID="Save" OnClientClick='<%# "return Page_ClientValidate(""Save" & Container.DataItemIndex & """) && confirm(""Post Voucher ?"");" %>' CommandName="SavePost" CommandArgument='<%# Container.DataItemIndex %>' />
                  </td>
                  </tr>
              </table>
            </asp:Panel>
            <asp:ImageButton ID="cmdPostWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("PostWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Post ERP Voucher" SkinID="post" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Post ERP Voucher ?"");" %>' CommandName="PostWF" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Label ID="L_vchBatch" runat="server" Text='<%# Eval("VCHBatch") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MANNUAL VCH">
          <ItemTemplate>
            <asp:Panel runat="server" ID="UpdatePnl" Visible='<%# Eval("UpdateEntryVisible") %>' style="width:200px;background-color:antiquewhite;border:solid 1pt pink" >
              <table>
                <tr>
                  <td class="alignright">
                    <b><asp:Label ID="L_VoucherType" runat="server" Text="Voucher Type :" />&nbsp;</b>
                  </td>
                  <td>
                    <asp:TextBox ID="F_VoucherType"
                      Text='<%# Bind("VoucherType") %>'
                      Width="40px" 
                      CssClass = "mytxt"
                      onfocus = "return this.select();"
                      MaxLength="3"
                      ValidationGroup='<%# "Save" & Container.DataItemIndex %>'
                      runat="server" />
                    <asp:RequiredFieldValidator 
                      ID = "RFVVoucherType"
                      runat = "server"
                      ControlToValidate = "F_VoucherType"
                      ErrorMessage = "<div class='errorLG'>Required!</div>"
                      Display = "Dynamic"
                      EnableClientScript = "true"
                      ValidationGroup='<%# "Save" & Container.DataItemIndex %>'
                      SetFocusOnError="true" />
                  </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b><asp:Label ID="L_VoucherNo" runat="server" Text="Voucher No. :" />&nbsp;</b>
                  </td>
                  <td>
                    <asp:TextBox ID="F_VoucherNo"
                      Text='<%# Bind("VoucherNo") %>'
                      Width="80px" 
                      CssClass = "mytxt"
                      onfocus = "return this.select();"
                      MaxLength="8"
                      ValidationGroup='<%# "Save" & Container.DataItemIndex %>'
                      runat="server" />
                    <asp:RequiredFieldValidator 
                      ID = "RFVVoucherNo"
                      runat = "server"
                      ControlToValidate = "F_VoucherNo"
                      ErrorMessage = "<div class='errorLG'>Required!</div>"
                      Display = "Dynamic"
                      EnableClientScript = "true"
                      ValidationGroup='<%# "Save" & Container.DataItemIndex %>'
                      ValidationExpression="\d+"
                      SetFocusOnError="true" />
                  </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b><asp:Label ID="L_VoucherCompany" runat="server" Text="ERP Company :" />&nbsp;</b>
                  </td>
                  <td>
                    <asp:DropDownList 
                      ID="F_VoucherCompany"
                      SelectedValue='<%# Bind("VoucherCompany") %>'
                      Width="60px" 
                      CssClass = "mytxt"
                      ValidationGroup='<%# "Save" & Container.DataItemIndex %>'
                      runat="server" >
                      <asp:ListItem Selected="True" Value="" Text="---Select---"></asp:ListItem>
                      <asp:ListItem Value="200" Text="200"></asp:ListItem>
                      <asp:ListItem Value="210" Text="210"></asp:ListItem>
                      <asp:ListItem Value="220" Text="220"></asp:ListItem>
                      <asp:ListItem Value="230" Text="230"></asp:ListItem>
                      <asp:ListItem Value="240" Text="240"></asp:ListItem>
                      <asp:ListItem Value="290" Text="290"></asp:ListItem>
                      <asp:ListItem Value="400" Text="400"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator 
                      ID = "RFVVoucherCompany"
                      runat = "server"
                      ControlToValidate = "F_VoucherCompany"
                      ErrorMessage = "<div class='errorLG'>Required!</div>"
                      Display = "Dynamic"
                      EnableClientScript = "true"
                      ValidationGroup='<%# "Save" & Container.DataItemIndex %>'
                      SetFocusOnError="true" />
                  </td>
                </tr>
                <tr>
                  <td class="alignCenter">
                    <asp:ImageButton ID="ucmdCancel" ValidationGroup='<%# "Cancel" & Container.DataItemIndex %>' CausesValidation="true" runat="server"  AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Cancel" SkinID="Cancel" OnClientClick='<%# "return Page_ClientValidate(""Cancel" & Container.DataItemIndex & """) && confirm(""Cancel record ?"");" %>' CommandName="CancelWF" CommandArgument='<%# Container.DataItemIndex %>' />
                  </td>
                  <td class="alignCenter">
                    <asp:ImageButton ID="ucmdSave" ValidationGroup='<%# "Save" & Container.DataItemIndex %>' CausesValidation="true" runat="server"  AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save" SkinID="Save" OnClientClick='<%# "return Page_ClientValidate(""Save" & Container.DataItemIndex & """) && confirm(""Update record ?"");" %>' CommandName="SaveWF" CommandArgument='<%# Container.DataItemIndex %>' />
                  </td>
                  </tr>
              </table>
            </asp:Panel>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Update Voucher Details" SkinID="fastedit" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Update Voucher Details ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Label ID="L_ERPBatchNo" runat="server" Text='<%# Eval("ERPBatchNo") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UPD-GST" SortExpression="">
          <ItemTemplate>
            <asp:ImageButton ID="cmdLock" ValidationGroup='<%# "Lock" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("LockWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Update GST Data." SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Lock" & Container.DataItemIndex & """) && confirm(""Update GST Data ?"");" %>' CommandName="LockWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODStaCH"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taCH"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taCHSelectList"
      TypeName = "SIS.TA.taCH"
      SelectCountMethod = "taCHSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_EmployeeID" PropertyName="Text" Name="EmployeeID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_DestinationCity" PropertyName="Text" Name="DestinationCity" Type="String" Size="30" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_BillStatusID" PropertyName="Text" Name="BillStatusID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_TravelTypeID" PropertyName="SelectedValue" Name="TravelTypeID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaCH" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_EmployeeID" />
    <asp:AsyncPostBackTrigger ControlID="F_DestinationCity" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_BillStatusID" />
    <asp:AsyncPostBackTrigger ControlID="F_TravelTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_TABillNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
