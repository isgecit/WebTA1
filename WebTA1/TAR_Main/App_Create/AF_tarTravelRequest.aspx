<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_tarTravelRequest.aspx.vb" Inherits="AF_tarTravelRequest" title="Add: Travel Request" %>
<asp:Content ID="CPHtarTravelRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltarTravelRequest" runat="server" Text="&nbsp;Add: Travel Request"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtarTravelRequest" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtarTravelRequest"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "tarTravelRequest"
    runat = "server" />
<asp:FormView ID="FVtarTravelRequest"
  runat = "server"
  DataKeyNames = "RequestID"
  DataSourceID = "ODStarTravelRequest"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtarTravelRequest" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" ForeColor="#CC6633" runat="server" Text="Request ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3" style="vertical-align:top;">
          <asp:TextBox ID="F_RequestID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TravelTypeID" runat="server" Text="Travel Type :" /><span style="color:red">*</span>
        </td>
        <td >
          <LGM:LC_taTravelTypes
            ID="F_TravelTypeID"
            SelectedValue='<%# Bind("TravelTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "tarTravelRequest"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="Label10" runat="server" Text="Sanction Type :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:DropDownList
            ID="F_SanctionType"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "tarTravelRequest"
            runat="server">
            <asp:ListItem Text="Individual" Value="IDIVIDUAL"></asp:ListItem>
            <asp:ListItem Text="Group" Value="GROUP"></asp:ListItem>
          </asp:DropDownList>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4" style="text-align:center;background-color:gainsboro;height:24px;">
          <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="TRAVELLER(s) DETAILS" />&nbsp;
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequestedFor" runat="server" Text="Individual :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RequestedFor"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("RequestedFor") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Change it, If Requested For Other Employee."
            onblur= "script_tarTravelRequest.validate_RequestedFor(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_RequestedFor_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERequestedFor"
            BehaviorID="B_ACERequestedFor"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequestedForCompletionList"
            TargetControlID="F_RequestedFor"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_tarTravelRequest.ACERequestedFor_Selected"
            OnClientPopulating="script_tarTravelRequest.ACERequestedFor_Populating"
            OnClientPopulated="script_tarTravelRequest.ACERequestedFor_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          <br />
          <asp:Label ID="Label4" runat="server" ForeColor="red" Text="[Change It, If Requested For Any Other Employee.]" />&nbsp;
        </td>
        <td class="alignright">
          <asp:Label ID="L_RequestedForEmployees" runat="server" Text="Co-Travellers :" />&nbsp;
        </td>
        <td style="vertical-align:top;">
          <asp:TextBox ID="F_RequestedForEmployees"
            Text='<%# Bind("RequestedForEmployees") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter Employee Names."
            MaxLength="250"
            Width="350px"
            runat="server" />
          <br />
          <asp:Label ID="Label5" runat="server" ForeColor="red" Text="[Provide the names of Co-Travellers, If their budget is included in this request.]" />&nbsp;
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4" style="text-align:center;background-color:gainsboro;height:24px;">
          <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="PROJECT CODE or COST CENTER is Mandatory input from where budget is to be consumed." />&nbsp;
        </td>
      </tr>
      <tr>
        <td class="alignright" style="vertical-align:top;">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project Code :" />&nbsp;<span style="color:red">*</span>
        </td>
        <td style="vertical-align:top;">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Project Code"
            onblur= "script_tarTravelRequest.validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects9_Description") %>'
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
            OnClientItemSelected="script_tarTravelRequest.ACEProjectID_Selected"
            OnClientPopulating="script_tarTravelRequest.ACEProjectID_Populating"
            OnClientPopulated="script_tarTravelRequest.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          <br />
          <asp:Label ID="Label6" runat="server" Text="OR" Font-Size="12" Font-Bold="True" />&nbsp;
        </td>
        <td style="text-align:right;vertical-align:top;">
          <asp:Label ID="L_ProjectManagerID" runat="server" Text="Project Manager :" />&nbsp;
        </td>
        <td style="vertical-align:top;">
          <asp:TextBox
            ID = "F_ProjectManagerID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("ProjectManagerID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter Project Manager Employee Code."
            onblur= "script_tarTravelRequest.validate_ProjectManagerID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectManagerID_Display"
            Text='<%# Eval("aspnet_users7_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectManagerID"
            BehaviorID="B_ACEProjectManagerID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectManagerIDCompletionList"
            TargetControlID="F_ProjectManagerID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_tarTravelRequest.ACEProjectManagerID_Selected"
            OnClientPopulating="script_tarTravelRequest.ACEProjectManagerID_Populating"
            OnClientPopulated="script_tarTravelRequest.ACEProjectManagerID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          <br />
          <asp:Label ID="Label1" runat="server" Text="[Project related Travel Request will go to Project Manager to provide<br/>sufficient sanction in ERP, if budget is NOT available.]" ForeColor="red" />&nbsp;
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CostCenterID" runat="server" Text="Cost Center :" />&nbsp;<span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taDepartments
            ID="F_CostCenterID"
            SelectedValue='<%# Bind("CostCenterID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TravelStartDate" runat="server" Text="Travel Start Date :" />
        </td>
        <td>
          <asp:TextBox ID="F_TravelStartDate"
            Text='<%# Bind("TravelStartDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="tarTravelRequest"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonTravelStartDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETravelStartDate"
            TargetControlID="F_TravelStartDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTravelStartDate" />
          <AJX:MaskedEditExtender 
            ID = "MEETravelStartDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TravelStartDate" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TravelFinishDate" runat="server" Text="Travel Finish Date :" />
        </td>
        <td>
          <asp:TextBox ID="F_TravelFinishDate"
            Text='<%# Bind("TravelFinishDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="tarTravelRequest"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonTravelFinishDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETravelFinishDate"
            TargetControlID="F_TravelFinishDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTravelFinishDate" />
          <AJX:MaskedEditExtender 
            ID = "MEETravelFinishDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TravelFinishDate" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TravelItinerary" runat="server" Text="Travel Itinerary :" />
        </td>
        <td style="vertical-align:top;">
          <asp:TextBox ID="F_TravelItinerary"
            Text='<%# Bind("TravelItinerary") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tarTravelRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter Travel Itinerary."
            MaxLength="500"
            Width="350px" Height="50px" TextMode="MultiLine"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Purpose" runat="server" Text="Purpose of Visit:" />
        </td>
        <td>
          <asp:TextBox ID="F_Purpose"
            Text='<%# Bind("Purpose") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tarTravelRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Purpose."
            MaxLength="500"
            Width="350px" Height="45px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td></td>
        <td colspan="3" style="vertical-align:top;">
          <asp:Label ID="label2ex" runat="server" ForeColor="gray" Text="Ex. Travel Itinrary:" Font-Underline="true"></asp:Label>
          <asp:Label ID="label2" runat="server" ForeColor="gray" Text="01/04/2018 Noida-Mumbai, 02/04/2018 Mumbai-Pune, 03/04/2018 Pune-Noida"></asp:Label>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4" style="text-align:center;background-color:gainsboro;height:24px;">
          <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Travel Budget Inclusive of FARE, LODGING, DA, CONVEYANCE etc. in INR" />&nbsp;
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Button ID="cmdHelp" runat="server" BackColor="gold" Text="Click here to View TA Entitlement Sheet" />
        </td>
        <td class="alignright"  style="vertical-align:top;padding-top:6px;">
          <asp:Label ID="L_TotalRequestedAmount" runat="server" Font-Bold="true" Text="Requested Budget :" /><span style="color:red">*</span>
        </td>
        <td>
          <script type="text/javascript">
            function validate_tots(o, p) {
              o.value = o.value.replace(new RegExp('_', 'g'), '');
              var dec = /^\d+(?:\.\d{0,6})?$/;
              var v = o.value;
              if (v.match(dec)) {
                o.value = parseFloat(v).toFixed(p);
              } else {
                o.value = parseFloat('0').toFixed(p);
              }
              var aVal = o.id.split('_F_');
              var Prefix = aVal[0] + '_F_';
              var TotalRequestedAmount = $get(Prefix + 'TotalRequestedAmount');
              var Add1Amount = $get(Prefix + 'Add1Amount');
              var Add2Amount = $get(Prefix + 'Add2Amount');
              var Add3Amount = $get(Prefix + 'Add3Amount');
              var Add4Amount = $get(Prefix + 'Add4Amount');
              var Add5Amount = $get(Prefix + 'Add5Amount');
              var TotalRequestedAmountINR = $get(Prefix + 'TotalRequestedAmountINR');
              try {
                TotalRequestedAmountINR.value = (parseFloat(TotalRequestedAmount.value) + parseFloat(Add1Amount.value) + parseFloat(Add2Amount.value) + parseFloat(Add3Amount.value) + parseFloat(Add4Amount.value) + parseFloat(Add5Amount.value)).toFixed(2);
              } catch (e) { }
            }
          </script>
          <asp:TextBox ID="F_TotalRequestedAmount"
            Text='<%# Bind("TotalRequestedAmount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="tarTravelRequest"
            MaxLength="20"
            onfocus = "return this.select();"
            onblur="return validate_tots(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4" style="text-align:center;background-color:gainsboro;height:24px;">
          <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Special Travel Budget (if any)" />&nbsp;
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Add1AmountDescription" runat="server" Text="Description [1] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add1AmountDescription"
            Text='<%# Bind("Add1AmountDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Add1AmountDescription."
            MaxLength="150"
            Width="350px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Add1Amount" runat="server" Text="Additional Budget [1] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add1Amount"
            Text='<%# Bind("Add1Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            onblur="return validate_tots(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Add2AmountDescription" runat="server" Text="Description [2] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add2AmountDescription"
            Text='<%# Bind("Add2AmountDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Add2AmountDescription."
            MaxLength="150"
            Width="350px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Add2Amount" runat="server" Text="Additional Budget [2] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add2Amount"
            Text='<%# Bind("Add2Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            onblur="return validate_tots(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Add3AmountDescription" runat="server" Text="Description [3] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add3AmountDescription"
            Text='<%# Bind("Add3AmountDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Add3AmountDescription."
            MaxLength="150"
            Width="350px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Add3Amount" runat="server" Text="Additional Budget [3] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add3Amount"
            Text='<%# Bind("Add3Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            onblur="return validate_tots(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Add4AmountDescription" runat="server" Text="Description [4] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add4AmountDescription"
            Text='<%# Bind("Add4AmountDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Add4AmountDescription."
            MaxLength="150"
            Width="350px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Add4Amount" runat="server" Text="Additional Budget [4] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add4Amount"
            Text='<%# Bind("Add4Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            onblur="return validate_tots(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Add5AmountDescription" runat="server" Text="Description [5] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add5AmountDescription"
            Text='<%# Bind("Add5AmountDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Add5AmountDescription."
            MaxLength="150"
            Width="350px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Add5Amount" runat="server" Text="Additional Budget [5] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Add5Amount"
            Text='<%# Bind("Add5Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="20"
            onfocus = "return this.select();"
            onblur="return validate_tots(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td></td>
        <td></td>
        <td class="alignright">
          <asp:Label ID="L_TotalRequestedAmountINR" runat="server" Font-Bold="True" Text="TOTAL Requested Budget :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalRequestedAmountINR"
            Text='<%# Bind("TotalRequestedAmountINR") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey"></td></tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStarTravelRequest"
  DataObjectTypeName = "SIS.TAR.tarTravelRequest"
  InsertMethod="UZ_tarTravelRequestInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TAR.tarTravelRequest"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
