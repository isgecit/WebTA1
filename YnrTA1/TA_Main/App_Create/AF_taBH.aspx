<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taBH.aspx.vb" Inherits="AF_taBH" title="Add: Travel Expense Statements" %>
<asp:Content ID="CPHtaBH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBH" runat="server" Text="&nbsp;Add: Travel Expense Statements"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBH" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBH"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/TA_Main/App_Edit/EF_taBH.aspx"
    ValidationGroup = "taBH"
    runat = "server" />
<asp:FormView ID="FVtaBH"
  runat = "server"
  DataKeyNames = "TABillNo"
  DataSourceID = "ODStaBH"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaBH" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
      <table style="margin:auto;border: solid 1pt lightgrey">
        <tr>
          <td class="alignright">
            <b><asp:Label ID="L_TABillNo" ForeColor="#CC6633" runat="server" Text="TA Bill No :" /><span style="color:red">*</span></b>
          </td>
          <td>
            <asp:TextBox ID="F_TABillNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
          </td>
          <td colspan="2">
            <div id="userinfo" runat="server" style="float:right; z-index:1000; position:absolute;">
            <table style="border: solid 1pt gray">
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="Label1" ForeColor="#CC6633" runat="server" Text="* TA Category :" /></b>
                </td>
                <td >
                  <asp:Label ID="L_TACategory" Enabled="False" CssClass="mypktxt"  runat="server" Text="Not Defined" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="Label2" ForeColor="#CC6633" runat="server" Text="Verifier :" /></b>
                </td>
                <td >
                  <asp:Label ID="L_Verifier" Enabled="False" CssClass="mypktxt"  runat="server" Text="Not Defined" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="Label4" ForeColor="#CC6633" runat="server" Text="* Approver :" /></b>
                </td>
                <td >
                  <asp:Label ID="L_Approver" Enabled="False" CssClass="mypktxt"  runat="server" Text="Not Defined" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="Label6" ForeColor="#CC6633" runat="server" Text="* Sanctioning Authority :" /></b>
                </td>
                <td >
                  <asp:Label ID="L_SanctioningAuthority" Enabled="False" CssClass="mypktxt"  runat="server" Text="Not Defined" />
                </td>
              </tr>
              <tr>
                <td colspan="2" class="alignright">
                  <b><asp:Label ID="Label3" ForeColor="green" runat="server" Text="If * marked in above is NOT Defined, Pl. get it defined in system first." /></b>
                </td>
              </tr>
              <tr>
                <td colspan="2" class="alignCenter">
                  <b><asp:LinkButton ID="cmdRequest" ForeColor="black" runat="server" Text="Click here to send E-Mail to JoomlaSupport." OnClientClick="return confirm('Do you want to send E-Mail ?');" OnClick="cmdRequest_Click" /></b>
                </td>
              </tr>
            </table>
          </div>
          </td>
        </tr>
        <tr>
          <td class="alignright">
            <asp:Label ID="L_TravelTypeID" runat="server" Text="Travel Type ID :" /><span style="color:red">*</span>
          </td>
          <td colspan="3">
            <LGM:LC_taTravelTypes
              ID="F_TravelTypeID"
              SelectedValue='<%# Bind("TravelTypeID") %>'
              OrderBy="DisplayField"
              DataTextField="DisplayField"
              DataValueField="PrimaryKey"
              IncludeDefault="true"
              DefaultText="-- Select --"
              onclick="alert(this.selectedvalue);"
              Width="200px"
              CssClass="myddl"
              ValidationGroup = "taBH"
              RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
              
              Runat="Server" />
            </td>
        </tr>
        <tr>
          <td class="alignright">
            <asp:Label ID="L_CityOfOrigin" runat="server" Text="City Of Origin :" /><span style="color:red">*</span>
          </td>
          <td colspan="3">
            <asp:TextBox
              ID = "F_CityOfOrigin"
              CssClass = "myfktxt"
              Width="248px"
              Text='<%# Bind("CityOfOrigin") %>'
              AutoCompleteType = "None"
              onfocus = "return this.select();"
              ToolTip="Enter value for City Of Origin."
              ValidationGroup = "taBH"
              onblur= "script_taBH.validate_CityOfOrigin(this);"
              Runat="Server" />
            <asp:RequiredFieldValidator 
              ID = "RFVCityOfOrigin"
              runat = "server"
              ControlToValidate = "F_CityOfOrigin"
              ErrorMessage = "<div class='errorLG'>Required!</div>"
              Display = "Dynamic"
              EnableClientScript = "true"
              ValidationGroup = "taBH"
              SetFocusOnError="true" />
            <asp:Label
              ID = "F_CityOfOrigin_Display"
              Text='<%# Eval("TA_Cities1_CityName") %>'
              CssClass="myLbl"
              Runat="Server" />
            <AJX:AutoCompleteExtender
              ID="ACECityOfOrigin"
              BehaviorID="B_ACECityOfOrigin"
              ContextKey=""
              UseContextKey="true"
              ServiceMethod="CityOfOriginCompletionList"
              TargetControlID="F_CityOfOrigin"
              EnableCaching="false"
              CompletionInterval="100"
              FirstRowSelected="true"
              MinimumPrefixLength="1"
              OnClientItemSelected="script_taBH.ACECityOfOrigin_Selected"
              OnClientPopulating="script_taBH.ACECityOfOrigin_Populating"
              OnClientPopulated="script_taBH.ACECityOfOrigin_Populated"
              CompletionSetCount="10"
              CompletionListCssClass = "autocomplete_completionListElement"
              CompletionListItemCssClass = "autocomplete_listItem"
              CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
              Runat="Server" />
          </td>
        </tr>
        <tr>
          <td class="alignright">
            <asp:Label ID="L_DestinationCity" runat="server" Text="Destination City :" />&nbsp;
          </td>
          <td colspan="3">
            <asp:TextBox
              ID = "F_DestinationCity"
              CssClass = "myfktxt"
              Width="248px"
              Text='<%# Bind("DestinationCity") %>'
              AutoCompleteType = "None"
              onfocus = "return this.select();"
              ToolTip="Enter value for Destination City."
              onblur= "script_taBH.validate_DestinationCity(this);"
              Runat="Server" />
            <asp:Label
              ID = "F_DestinationCity_Display"
              Text='<%# Eval("TA_Cities14_CityName") %>'
              CssClass="myLbl"
              Runat="Server" />
            <AJX:AutoCompleteExtender
              ID="ACEDestinationCity"
              BehaviorID="B_ACEDestinationCity"
              ContextKey=""
              UseContextKey="true"
              ServiceMethod="DestinationCityCompletionList"
              TargetControlID="F_DestinationCity"
              EnableCaching="false"
              CompletionInterval="100"
              FirstRowSelected="true"
              MinimumPrefixLength="1"
              OnClientItemSelected="script_taBH.ACEDestinationCity_Selected"
              OnClientPopulating="script_taBH.ACEDestinationCity_Populating"
              OnClientPopulated="script_taBH.ACEDestinationCity_Populated"
              CompletionSetCount="10"
              CompletionListCssClass = "autocomplete_completionListElement"
              CompletionListItemCssClass = "autocomplete_listItem"
              CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
              Runat="Server" />
          </td>
        </tr>
        <tr>
        <td class="alignright">
          <asp:Label ID="L_DestinationName" runat="server" Text="Enter Destination [If NOT Found in List] :" />
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DestinationName"
            Text='<%# Bind("DestinationName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Destination Name."
            MaxLength="50"
            Width="350px"
            runat="server" />
        </td>
        </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillCurrencyID" runat="server" Text="TA Bill Currency ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_BillCurrencyID"
            SelectedValue='<%# Bind("BillCurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taBH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor [INR] :" /><span style="color:red">*</span>
        </td>
        <td>
          <script type="text/javascript">
            function dc(o, p) {
              var dec = /^-?\d+(?:\.\d{0,6})?$/;
              var v = o.value;
              if (v.match(dec)) {
                o.value = parseFloat(v).toFixed(p);
              } else {
                o.value = parseFloat('0').toFixed(p);
              }
              if (parseFloat(o.value)<=0)
                o.value='';
            }
          </script>
          <asp:TextBox ID="F_ConversionFactorINR"
            Text='<%# Bind("ConversionFactorINR") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup= "taBH"
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVConversionFactorINR"
            runat = "server"
            ControlToValidate = "F_ConversionFactorINR"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBH"
            SetFocusOnError="true" />
        </td>
      </tr>
        <tr>
          <td class="alignright">
            <asp:Label ID="L_ProjectID" runat="server" Text="Enter Project ID, if it is a Project related travel. :" />&nbsp;
          </td>
          <td colspan="4">
            <asp:TextBox
              ID = "F_ProjectID"
              CssClass = "myfktxt"
              Width="56px"
              Text='<%# Bind("ProjectID") %>'
              AutoCompleteType = "None"
              onfocus = "return this.select();"
              ToolTip="Enter value for Project ID."
              onblur= "script_taBH.validate_ProjectID(this);"
              Runat="Server" />
            <asp:Label
              ID = "F_ProjectID_Display"
              Text='<%# Eval("IDM_Projects11_Description") %>'
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
              OnClientItemSelected="script_taBH.ACEProjectID_Selected"
              OnClientPopulating="script_taBH.ACEProjectID_Populating"
              OnClientPopulated="script_taBH.ACEProjectID_Populated"
              CompletionSetCount="10"
              CompletionListCssClass = "autocomplete_completionListElement"
              CompletionListItemCssClass = "autocomplete_listItem"
              CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
              Runat="Server" />
          </td>
        </tr>
        <tr id="R_SiteName" runat="server" ClientIDMode="static" >
        <td class="alignright">
          <asp:Label ID="Label7" runat="server" Text="Posted at Site :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SiteName"
            Text='<%# Bind("SiteName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter Site Name."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVF_SiteName"
            runat = "server"
            ControlToValidate = "F_SiteName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBH"
            SetFocusOnError="true" />
        </td>
        </tr>
        <tr>
          <td class="alignright">
            <asp:Label ID="L_PurposeOfJourney" runat="server" Text="Purpose Of Journey :" /><span style="color:red">*</span>
          </td>
          <td>
            <asp:TextBox ID="F_PurposeOfJourney"
              Text='<%# Bind("PurposeOfJourney") %>'
              CssClass = "mytxt"
              onfocus = "return this.select();"
              ValidationGroup="taBH"
              onblur= "this.value=this.value.replace(/\'/g,'');"
              ToolTip="Enter value for Purpose Of Journey."
              MaxLength="500"
              Width="350px" Height="40px" TextMode="MultiLine"
              runat="server" />
            <asp:RequiredFieldValidator 
              ID = "RFVPurposeOfJourney"
              runat = "server"
              ControlToValidate = "F_PurposeOfJourney"
              ErrorMessage = "<div class='errorLG'>Required!</div>"
              Display = "Dynamic"
              EnableClientScript = "true"
              ValidationGroup = "taBH"
              SetFocusOnError="true" />
          </td>
          <td class="alignright">
            <asp:Label ID="L_BriefTourReport" runat="server" Text="Brief Tour Report :" />&nbsp;
          </td>
          <td>
            <asp:TextBox ID="F_BriefTourReport"
              Text='<%# Bind("BriefTourReport") %>'
              CssClass = "mytxt"
              onfocus = "return this.select();"
              onblur= "this.value=this.value.replace(/\'/g,'');"
              ToolTip="Enter value for Brief Tour Report."
              MaxLength="500"
              Width="350px" Height="40px" TextMode="MultiLine"
              runat="server" />
          </td>
        </tr>
      </table>
      <table style="margin:auto;border: solid 1pt lightgrey">
        <tr>
          <td>
            <table style="border: solid 1pt lightgrey">
              <tr>
                <td colspan="4" style="padding-top:10px;">
                  <asp:Label ID="lbl1" runat="server" Font-Bold="true" Font-Underline="true" Text="Select, if applicable in DOMESTIC Travel" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                      <script type="text/javascript">
                        function chkChanged(a) {
                          switch (a.id) {
                            case 'F_TaxiHired':
                              if (a.checked) {
                                var t = $get('F_TrainingProgram');
                                t.disabled = true;
                              } else {
                                var t = $get('F_TrainingProgram');
                                t.disabled = false;
                              }
                              break;
                            case 'F_TrainingProgram':
                              if (a.checked) {
                                var t = $get('F_TaxiHired');
                                t.disabled = true;
                              } else {
                                var t = $get('F_TaxiHired');
                                t.disabled = false;
                              }
                              break;
                          }
                          return true;
                        }
                      </script>
                  <asp:Label ID="L_TaxiHired" runat="server" Text="Training Program [Residential] :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_TaxiHired"
                    Checked='<%# Bind("TaxiHired") %>'
                    CssClass = "mychk"
                    ClientIDMode="Static"
                    onclick="return chkChanged(this);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_TrainingProgram" runat="server" Text="Training Program [NON-Residential] :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_TrainingProgram"
                    Checked='<%# Bind("TrainingProgram") %>'
                    CssClass = "mychk"
                    ClientIDMode="Static"
                    onclick="return chkChanged(this);"
                    runat="server" />
                </td>
              </tr>
<%--              <tr>
                <td class="alignright">
                  <asp:Label ID="L_Within25KM" runat="server" Text="Visit with in 25 KM :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_Within25KM"
                    Checked='<%# Bind("Within25KM") %>'
                    CssClass = "mychk"
                    ClientIDMode="Static"
                    onclick="return chkChanged(this);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_SameDayVisit" runat="server" Text="Same Day Visit :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_SameDayVisit"
                    Checked='<%# Bind("SameDayVisit") %>'
                    CssClass = "mychk"
                    ClientIDMode="Static"
                    onclick="return chkChanged(this);"
                    runat="server" />
                </td>
              </tr>--%>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_SiteTransfer" runat="server" Text="Site To Site Visit/Transfer :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_SiteTransfer"
                   Checked='<%# Bind("SiteTransfer") %>'
                   CssClass = "mychk"
                   runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_CalculateDriverCharges" runat="server" Text="Calculate Driver Charges :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_CalculateDriverCharges"
                   Checked='<%# Bind("CalculateDriverCharges") %>'
                   CssClass = "mychk"
                   runat="server" />
                </td>
              </tr>
            </table>
          </td>
          <td style="vertical-align:top">
            <table style="border: solid 1pt lightgrey">
              <tr>
                <td colspan="4" style="padding-top:10px;">
                  <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Underline="true" Text="Select, if applicable in FOREIGN Travel/Site" />
                </td>
              </tr>
              <tr id="opt3">
                <td class="alignright">
                  <asp:Label ID="L_SiteToAnotherSite" runat="server" Text="Is it Partial TA Bill :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_SiteToAnotherSite"
                    Checked='<%# Bind("SiteToAnotherSite") %>'
                    CssClass = "mychk"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="Label8" runat="server" Text="MD Sanction Attached :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_SanctionAttached"
                    Checked='<%# Bind("SanctionAttached") %>'
                    CssClass = "mychk"
                    runat="server" />
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>

    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaBH"
  DataObjectTypeName = "SIS.TA.taBH"
  InsertMethod="UZ_taBHInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBH"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
