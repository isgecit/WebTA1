<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_qcmRequests.aspx.vb" Inherits="EF_qcmRequests" title="Edit: Inspection Requests" %>
<asp:Content ID="CPHqcmRequests" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelqcmRequests" runat="server" Text="&nbsp;Edit: Inspection Requests" Width="100%" CssClass="sis_formheading"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLqcmRequests" UpdateMode="conditional" ChildrenAsTriggers="false" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLqcmRequests"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            ValidationGroup="qcmRequests"
            runat="server" />
          <asp:FormView ID="FVqcmRequests"
            runat="server"
            DataKeyNames="RequestID"
            DataSourceID="ODSqcmRequests"
            DefaultMode="Edit" CssClass="sis_formview">
            <EditItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <table style="margin: auto;">
                  <td style="vertical-align: top;">
                    <table style="margin: auto; border: solid 1pt lightgrey">
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_RequestID" runat="server" ForeColor="#CC6633" Text="Request ID :" /></b>
                        </td>
                        <td>
                          <asp:TextBox ID="F_RequestID"
                            Text='<%# Bind("RequestID") %>'
                            ToolTip="Value of Request ID."
                            Enabled="False"
                            CssClass="mypktxt"
                            Width="70px"
                            Style="text-align: right"
                            runat="server" />
                        </td>
                      </tr>
                      <tr runat="server" id="r_supplier">
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" /></b>
                        </td>
                        <td>
                          <asp:TextBox
                            ID="F_SupplierID"
                            CssClass="myfktxt"
                            Width="92px"
                            Text='<%# Bind("SupplierID") %>'
                            AutoCompleteType="None"
                            onfocus="return this.select();"
                            ToolTip="Enter Supplier ID."
                            ValidationGroup="qcmRequests"
                            onblur="script_qcmRequests.validate_SupplierID(this);"
                            runat="Server" />
                         <asp:Button ID="cmdGetPO" runat="server" Text="..." ToolTip="Get PO List for supplier." CommandName="GetSupplierPO" />
                         <asp:Label
                            ID="F_SupplierID_Display"
                            Text='<%# Eval("IDM_Vendors7_Description") %>'
                            runat="Server" />
                          <asp:RequiredFieldValidator
                            ID="RFVSupplierID"
                            runat="server"
                            ControlToValidate="F_SupplierID"
                            Text="[Required!]"
                            ErrorMessage="[Required!]"
                            Display="Dynamic"
                            EnableClientScript="true"
                            ValidationGroup="qcmRequests"
                            ForeColor="Red"
                            SetFocusOnError="true" />
                          <AJX:AutoCompleteExtender
                            ID="ACESupplierID"
                            BehaviorID="B_ACESupplierID"
                            ContextKey=""
                            UseContextKey="true"
                            ServiceMethod="SupplierIDCompletionList"
                            TargetControlID="F_SupplierID"
                            EnableCaching="false"
                            CompletionInterval="100"
                            FirstRowSelected="true"
                            MinimumPrefixLength="1"
                            OnClientItemSelected="script_qcmRequests.ACESupplierID_Selected"
                            OnClientPopulating="script_qcmRequests.ACESupplierID_Populating"
                            OnClientPopulated="script_qcmRequests.ACESupplierID_Populated"
                            CompletionSetCount="10"
                            CompletionListCssClass="autocomplete_completionListElement"
                            CompletionListItemCssClass="autocomplete_listItem"
                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                            runat="Server" />
                        </td>
                      </tr>
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_CreationRemarks" runat="server" Text="Place of Inspection / Contact Details :" /></b>
                        </td>
                        <td>
                          <asp:TextBox ID="F_CreationRemarks"
                            Text='<%# Bind("CreationRemarks") %>'
                            CssClass="mytxt"
                            onfocus="return this.select();"
                            onblur="this.value=this.value.replace(/\'/g,'');"
                            ToolTip="Enter place of inspection"
                            MaxLength="500"
                            Width="350px" Height="40px" TextMode="MultiLine"
                            runat="server" />
                        </td>
                      </tr>
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_RegionID" runat="server" Text="Inspection Region :" /></b>
                        </td>
                        <td>
                          <LGM:LC_qcmRegions
                            ID="F_RegionID"
                            CssClass="myfktxt"
                            Width="170px"
                            SelectedValue='<%# Bind("RegionID") %>'
                            DataTextField="RegionName"
                            DataValueField="RegionID"
                            IncludeDefault="true"
                            DefaultText="-- Select --"
                            RequiredFieldErrorMessage="[Required!]"
                            ToolTip="Enter value for Region ID."
                            ValidationGroup="qcmRequests"
                            runat="Server" />
                        </td>
                      </tr>
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_Description" runat="server" Text="Item Description :" /></b>
                        </td>
                        <td>
                          <asp:TextBox ID="F_Description"
                            Text='<%# Bind("Description") %>'
                            CssClass="mytxt"
                            onfocus="return this.select();"
                            ValidationGroup="qcmRequests"
                            onblur="this.value=this.value.replace(/\'/g,'');"
                            ToolTip="Enter Item Description."
                            MaxLength="500"
                            Width="350px" Height="40px" TextMode="MultiLine"
                            runat="server" />
                          <asp:RequiredFieldValidator
                            ID="RFVDescription"
                            runat="server"
                            ControlToValidate="F_Description"
                            Text="[Required!]"
                            ErrorMessage="[Required!]"
                            Display="Dynamic"
                            EnableClientScript="true"
                            ValidationGroup="qcmRequests"
                            ForeColor="Red"
                            SetFocusOnError="true" />
                        </td>
                      </tr>
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_InspectionStageiD" runat="server" Text="Inspection Stage :" /></b>
                        </td>
                        <td colspan="3">
                          <LGM:LC_qcmInspectionStages
                            ID="F_InspectionStageiD"
                            SelectedValue='<%# Bind("InspectionStageiD") %>'
                            OrderBy="DisplayField"
                            DataTextField="DisplayField"
                            DataValueField="PrimaryKey"
                            IncludeDefault="true"
                            DefaultText="-- Select --"
                            Width="200px"
                            CssClass="myddl"
                            ValidationGroup="qcmRequests"
                            RequiredFieldErrorMessage="[Required!]"
                            runat="Server" />
                        </td>
                      </tr>
                      <tr>
                        <td></td>
                        <td>
                          <table style="width: 100%; margin: auto">
                            <tr>
                              <td class="alignleft">
                                <b>
                                  <asp:Label ID="L_TotalRequestedQuantity" runat="server" Text="Stage Requested Quantity" /></b>
                              </td>
                              <td class="alignCenter">
                                <b>
                                  <asp:Label ID="Label4" runat="server" Text="Final Requested Quantity" /></b>
                              </td>
                            </tr>
                            <tr>
                              <td class="alignleft">
                                <asp:TextBox ID="F_TotalRequestedQuantity"
                                  Text='<%# Bind("TotalRequestedQuantity") %>'
                                  Width="130px"
                                  CssClass="mytxt"
                                  Style="text-align: Right"
                                  MaxLength="14"
                                  onfocus="return this.select();"
                                  ValidationGroup="qcmRequests"
                                  ClientIDMode="Static"
                                  type="number"
                                  runat="server" />
                                <asp:RequiredFieldValidator
                                  ID="RFVTotalRequestedQuantity"
                                  runat="server"
                                  ControlToValidate="F_TotalRequestedQuantity"
                                  Text="Required."
                                  ErrorMessage="[Required!]"
                                  Display="Dynamic"
                                  EnableClientScript="true"
                                  ValidationGroup="qcmRequests"
                                  ForeColor="Red"
                                  ClientIDMode="Static"
                                  SetFocusOnError="true" />
                              </td>
                              <td class="alignCenter">
                                <asp:TextBox ID="F_LotSize"
                                  Text='<%# Bind("LotSize") %>'
                                  Width="130px"
                                  CssClass="mytxt"
                                  Style="text-align: Right"
                                  MaxLength="14"
                                  onfocus="return this.select();"
                                  ValidationGroup="qcmRequests"
                                  ClientIDMode="Static"
                                  type="number"
                                  runat="server" />
                                <asp:RequiredFieldValidator
                                  ID="RFVLotSize"
                                  runat="server"
                                  ControlToValidate="F_LotSize"
                                  Text="Required."
                                  ErrorMessage="[Required!]"
                                  Display="Dynamic"
                                  EnableClientScript="true"
                                  ValidationGroup="qcmRequests"
                                  ForeColor="Red"
                                  ClientIDMode="Static"
                                  SetFocusOnError="true" />
                              </td>
                            </tr>
                          </table>
                        </td>
                      </tr>
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="Label1" runat="server" Text="UOM :" /></b>
                        </td>
                        <td>
                          <asp:DropDownList
                            ID="F_UOM"
                            SelectedValue='<%# Bind("UOM") %>'
                            CssClass="myddl"
                            Width="150px"
                            runat="Server">
                            <asp:ListItem Value="">---Select---</asp:ListItem>
                            <asp:ListItem Value="Nos">Nos</asp:ListItem>
                            <asp:ListItem Value="MT">MT</asp:ListItem>
                            <asp:ListItem Value="Package">Package</asp:ListItem>
                          </asp:DropDownList>
                          <asp:RequiredFieldValidator
                            ID="RFVUOM"
                            runat="server"
                            ControlToValidate="F_UOM"
                            Text="[Required!]"
                            ErrorMessage="[Required!]"
                            Display="Dynamic"
                            EnableClientScript="true"
                            ValidationGroup="qcmRequests"
                            ForeColor="Red"
                            SetFocusOnError="true" />
                        </td>
                      </tr>
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_RequestedInspectionStartDate" runat="server" Text="Requested Inspection Start Date :" /></b>
                        </td>
                        <td>
                          <asp:TextBox ID="F_RequestedInspectionStartDate"
                            Text='<%# Bind("RequestedInspectionStartDate") %>'
                            Width="70px"
                            CssClass="mytxt"
                            ValidationGroup="qcmRequests"
                            onfocus="return this.select();"
                            runat="server" />
                          <asp:Image ID="ImageButtonRequestedInspectionStartDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: middle" ImageUrl="~/Images/cal.png" />
                          <AJX:CalendarExtender
                            ID="CERequestedInspectionStartDate"
                            TargetControlID="F_RequestedInspectionStartDate"
                            BehaviorID="startDate"
                            Format="dd/MM/yyyy"
                            runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonRequestedInspectionStartDate" />
                          <AJX:MaskedEditExtender
                            ID="MEERequestedInspectionStartDate"
                            runat="server"
                            Mask="99/99/9999"
                            MaskType="Date"
                            CultureName="en-GB"
                            MessageValidatorTip="true"
                            InputDirection="LeftToRight"
                            ErrorTooltipEnabled="true"
                            TargetControlID="F_RequestedInspectionStartDate" />
                          <AJX:MaskedEditValidator
                            ID="MEVRequestedInspectionStartDate"
                            runat="server"
                            ControlToValidate="F_RequestedInspectionStartDate"
                            ControlExtender="MEERequestedInspectionStartDate"
                            InvalidValueMessage="Invalid"
                            EmptyValueMessage="[Required!]"
                            EmptyValueBlurredText="[Required!]"
                            Display="Dynamic"
                            TooltipMessage="Enter Inspection Start Date."
                            EnableClientScript="true"
                            ValidationGroup="qcmRequests"
                            IsValidEmpty="false"
                            ForeColor="Red"
                            SetFocusOnError="true" />
                        </td>
                      </tr>
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_ClientInspectionRequired" runat="server" Text="Client Inspection Required :" /></b>
                        </td>
                        <td>
                          <asp:CheckBox ID="F_ClientInspectionRequired"
                            Checked='<%# Bind("ClientInspectionRequired") %>'
                            runat="server" />
                        </td>
                      </tr>
                      <tr>
                        <td class="alignright">
                          <b>
                            <asp:Label ID="L_ThirdPartyInspectionRequired" runat="server" Text="Third Party Inspection Required :" /></b>
                        </td>
                        <td>
                          <asp:CheckBox ID="F_ThirdPartyInspectionRequired"
                            Checked='<%# Bind("ThirdPartyInspectionRequired") %>'
                            runat="server" />
                        </td>
                      </tr>
                    </table>
                  </td>
                  <td style="vertical-align: top;">
                    <table style="margin: auto; border: solid 1pt lightgrey">
                      <tr>
                        <td>
                          <b>
                            <asp:Label ID="L_OrderNo" runat="server" Text="Select Purchase Order for Inspection" /></b>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <asp:UpdatePanel ID="uplPO" runat="server">
                            <ContentTemplate>
                              <asp:TextBox ID="F_OrderNo"
                                Text='<%# Bind("OrderNo") %>'
                                CssClass="dmytxt"
                                Enabled="False"
                                Width="350px"
                                runat="server" />
                              <asp:Repeater ID="POCheckBoxList"
                                DataSourceID="Objx"
                                runat="server">
                                <HeaderTemplate>
                                  <table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <tr>
                                    <td>
                                      <asp:CheckBox ID="chk1" runat="server" Enabled='<%# Eval("Editable") %>' Text='<%# Bind("PONo") %>' Checked='<%# Bind("Selected") %>' ValidationGroup='<%# Eval("ProjectID") %>' AutoPostBack="true" OnCheckedChanged="POSelected" />
                                    </td>
                                  </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                  </table>
                                </FooterTemplate>
                              </asp:Repeater>
                            </ContentTemplate>
                          </asp:UpdatePanel>
                          <asp:ObjectDataSource
                            ID="OBJx"
                            DataObjectTypeName="SIS.QCM.POList"
                            SelectMethod="POListDataSource"
                            UpdateMethod=""
                            DeleteMethod=""
                            OldValuesParameterFormatString="original_{0}"
                            TypeName="SIS.QCM.POList"
                            runat="server">
                            <SelectParameters>
                              <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" DefaultValue="" Type="String" />
                              <asp:ControlParameter ControlID="F_OrderNo" PropertyName="Text" Name="POs" DefaultValue="" Type="String" />
                            </SelectParameters>
                          </asp:ObjectDataSource>
                        </td>
                      </tr>
                      <tr>
                        <td>
                    <asp:UpdatePanel ID="UPNLqcmRequestFiles" runat="server">
                      <ContentTemplate>
                        <table width="100%">
                          <tr>
                            <td class="sis_formview">
                              <table id="F_Upload" runat="server" visible="<%# Editable %>">
                                <tr>
                                  <td>
                                    <asp:Label ID="L_FileUpload" runat="server" Font-Bold="true" Text="Attatch File :"></asp:Label>
                                  </td>
                                  <td style="text-align: left">
                                      <asp:FileUpload ID="F_FileUpload" runat="server" Width="100%" ToolTip="Attatch File" />
                                    </div>
                                  </td>
                                  <td>
                                    <asp:Button ID="cmdFileUpload" Text="Upload File" runat="server" ToolTip="Click to upload file." CommandName="Upload" CommandArgument="" />
                                  </td>
                                </tr>
                              </table>
                              <asp:GridView ID="GVqcmRequestFiles" ShowHeader="false" SkinID="gv_silver" BorderColor="#A9A9A9" Width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSqcmRequestFiles" DataKeyNames="RequestID,SerialNo">
                                <Columns>
                                  <asp:TemplateField>
                                    <ItemTemplate>
                                      <asp:ImageButton ID="cmdRemove" runat="server" AlternateText="Remove" Visible="<%# Editable %>" CommandName="Remove" CommandArgument='<%# Container.DataItemIndex %>' ToolTip="Click to remove." SkinID="delete" OnClientClick="return confirm('Delete attachment ?');" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="File Name" SortExpression="FileName">
                                    <ItemTemplate>
                                      <asp:LinkButton ID="LabelFileName" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("FileName") %>' OnClientClick='<%# Eval("GetDownloadLink") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                  </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                  <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No Attachment found !!!"></asp:Label>
                                </EmptyDataTemplate>
                              </asp:GridView>
                              <asp:ObjectDataSource
                                ID="ODSqcmRequestFiles"
                                runat="server"
                                DataObjectTypeName="SIS.QCM.qcmRequestFiles"
                                OldValuesParameterFormatString="original_{0}"
                                SelectMethod="qcmRequestFilesSelectList"
                                TypeName="SIS.QCM.qcmRequestFiles"
                                SelectCountMethod="qcmRequestFilesSelectCount"
                                SortParameterName="OrderBy" EnablePaging="True">
                                <SelectParameters>
                                  <asp:ControlParameter ControlID="F_RequestID" PropertyName="Text" Name="RequestID" Type="Int32" Size="10" />
                                  <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                                  <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                                </SelectParameters>
                              </asp:ObjectDataSource>
                            </td>
                          </tr>
                        </table>
                      </ContentTemplate>
                      <Triggers>
                        <asp:PostBackTrigger ControlID="GVqcmRequestFiles" />
                        <asp:PostBackTrigger ControlID="cmdFileUpload" />
                      </Triggers>
                    </asp:UpdatePanel>
                        </td>
                      </tr>
                    </table>
                  </td>
                </table>
              </div>
            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSqcmRequests"
        DataObjectTypeName="SIS.QCM.qcmRequests"
        SelectMethod="qcmRequestsGetByID"
        UpdateMethod="UZ_qcmRequestsUpdate"
        DeleteMethod="UZ_qcmRequestsDelete"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.QCM.qcmRequests"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestID" Name="RequestID" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
