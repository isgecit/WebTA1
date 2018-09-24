<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_qcmRequests.aspx.vb" Inherits="GF_qcmRequests" title="Maintain List: Inspection Requests" %>
<asp:Content ID="CPHqcmRequests" ContentPlaceHolderID="cph1" runat="Server">
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelqcmRequests" runat="server" Text="&nbsp;List: Inspection Requests" Width="100%" CssClass="sis_formheading"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLqcmRequests" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLqcmRequests"
                  ToolType="lgNMGrid"
                  EditUrl="~/PAK_Main/App_Edit/EF_qcmRequests.aspx"
                  ValidationGroup="qcmRequests"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSqcmRequests" runat="server" AssociatedUpdatePanelID="UPNLqcmRequests" DisplayAfter="100">
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
                  <table style="display: none;">
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_ProjectID"
                          CssClass="myfktxt"
                          Width="62px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_ProjectID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_ProjectID_Display"
                          Text=""
                          runat="Server" />
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
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
                <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
                <asp:GridView ID="GVqcmRequests" SkinID="gv_silver" BorderColor="#A9A9A9" Width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSqcmRequests" DataKeyNames="RequestID">
                  <Columns>
                    <asp:TemplateField HeaderText="EDIT">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdEditPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle Width="30px" CssClass="alignCenter" />
                    </asp:TemplateField>
                    <%--        
                    <asp:TemplateField HeaderText="COPY">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdCopy" runat="server"  AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Copy to a new record." SkinID="copy" OnClientClick="return confirm('Copy to new request ?');" CommandName="lgCopy" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle Width="30px" CssClass="alignCenter" />
                    </asp:TemplateField>
                    --%>
                    <asp:TemplateField HeaderText="Req.ID" SortExpression="RequestID">
                      <ItemTemplate>
                        <asp:Label ID="LabelRequestID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestID") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects6_Description">
                      <ItemTemplate>
                        <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects6_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description" SortExpression="Description">
                      <ItemTemplate>
                        <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Requested Quantity" SortExpression="TotalRequestedQuantity">
                      <ItemTemplate>
                        <asp:Label ID="LabelTotalRequestedQuantity" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("NewTotalQuantity") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Requested Inspection Date" SortExpression="RequestedInspectionStartDate">
                      <ItemTemplate>
                        <asp:Label ID="LabelRequestedInspectionStartDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("RequestedInspectionStartDate") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Region" SortExpression="RegionID">
                      <ItemTemplate>
                        <asp:Label ID="LabelRegionID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("QCM_Regions12_RegionName") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Request State" SortExpression="QCM_RequestStates10_Description">
                      <ItemTemplate>
                        <asp:Label ID="L_RequestStateID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("RequestStateID") %>' Text='<%# Eval("QCM_RequestStates10_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FWD">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdForward" runat="server" Visible='<%# EVal("ForwardVisible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Forward" ToolTip="Forward for allotment." SkinID="forward" CommandName="lgFwd" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return confirm('Forward for allotment ?');" />
                        </td>
						            </tr>
						            <tr style="background-color: AntiqueWhite">
                          <td></td>
                          <td></td>
                          <td colspan="2">
                            <asp:Label ID="Label2" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("AllotmentDetails") %>'></asp:Label>
                          </td>
                          <td colspan="3">
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text='<%# Eval("ReturnDetails") %>'></asp:Label>
                          </td>
                          <td colspan="3">
                            <asp:Label ID="Label5" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("QCM_InspectionStatus11_Description") %>' Text='<%# Eval("QCM_InspectionStatus11_Description") %>'></asp:Label>
                          </td>
                        </tr>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle Width="30px" CssClass="alignCenter" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                  </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource
                  ID="ODSqcmRequests"
                  runat="server"
                  DataObjectTypeName="SIS.QCM.qcmRequests"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_qcmRequestsBySupplierSelectList"
                  TypeName="SIS.QCM.qcmRequests"
                  SelectCountMethod="UZ_qcmRequestsBySupplierSelectCount"
                  SortParameterName="OrderBy"
                  EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
                    <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                    <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </td>
            </tr>
          </table>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="GVqcmRequests" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
</asp:Content>
