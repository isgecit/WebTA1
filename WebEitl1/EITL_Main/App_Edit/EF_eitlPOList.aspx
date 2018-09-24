<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlPOList.aspx.vb" Inherits="EF_eitlPOList" title="Update: Despatch Details" %>

<asp:Content ID="CPHeitlPOList" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabeleitlPOList" runat="server" Text="&nbsp;Update: Despatch Details against Purchase Order"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLeitlPOList" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0 ID="TBLeitlPOList" ToolType="lgNMEdit" UpdateAndStay="False" EnableSave="false" EnableDelete="False" EnablePrint="True" PrintUrl="../App_Print/RP_eitlPOList.aspx?pk=" ValidationGroup="eitlPOList" runat="server" />
          <script type="text/javascript">
            var pcnt = 0;
            function print_report(o) {
              pcnt = pcnt + 1;
              var nam = 'wTask' + pcnt;
              var url = self.location.href.replace('App_Edit/EF_eitlPOList.aspx', 'App_Print/RP_eitlPOList.aspx');
              url = url + '?pk=' + o.alt;
              url = o.alt;
              window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
          </script>
          <asp:FormView ID="FVeitlPOList" runat="server" DataKeyNames="SerialNo" DataSourceID="ODSeitlPOList" DefaultMode="Edit" CssClass="sis_formview">
            <EditItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <div style="vertical-align: middle; height: 200px; width: 60%; margin: 10px auto 10px auto; float: left" class="ui-widget-content ui-corner-all">
                  <h3 class="ui-widget-header ui-corner-all" style="margin: 0; padding: 0.4em; text-align: center;">
                    Purchase Order Detail</h3>
                  <table style="margin: auto">
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_SerialNo" Text='<%# Bind("SerialNo") %>' ToolTip="Value of Serial No." Enabled="False" CssClass="mypktxt" Width="70px" Style="text-align: right" runat="server" />
                      </td>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_PONumber" runat="server" Text="PO Number :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_PONumber" Text='<%# Bind("PONumber") %>' ToolTip="Value of PO Number." Enabled="False" Width="70px" CssClass="dmytxt" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_PORevision" runat="server" Text="PO Revision :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_PORevision" Text='<%# Bind("PORevision") %>' ToolTip="Value of PO Revision." Enabled="False" Width="70px" CssClass="dmytxt" runat="server" />
                      </td>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_PODate" runat="server" Text="PO Date :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_PODate" Text='<%# Bind("PODate") %>' ToolTip="Value of PO Date." Enabled="False" Width="140px" CssClass="dmytxt" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_SupplierID" Width="63px" Text='<%# Bind("SupplierID") %>' Enabled="False" ToolTip="Value of Supplier." CssClass="dmyfktxt" runat="Server" />
                        <asp:Label ID="F_SupplierID_Display" Text='<%# Eval("EITL_Suppliers5_SupplierName") %>' runat="Server" />
                      </td>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_ProjectID" Width="42px" Text='<%# Bind("ProjectID") %>' Enabled="False" ToolTip="Value of Project." CssClass="dmyfktxt" runat="Server" />
                        <asp:Label ID="F_ProjectID_Display" Text='<%# Eval("IDM_Projects6_Description") %>' runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_DivisionID" runat="server" Text="Division :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_DivisionID" Text='<%# Bind("DivisionID") %>' ToolTip="Value of Division." Enabled="False" Width="70px" CssClass="dmytxt" runat="server" />
                      </td>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_BuyerID" runat="server" Text="Buyer :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_BuyerID" Width="56px" Text='<%# Bind("BuyerID") %>' Enabled="False" ToolTip="Value of Buyer." CssClass="dmyfktxt" runat="Server" />
                        <asp:Label ID="F_BuyerID_Display" Text='<%# Eval("aspnet_Users1_UserFullName") %>' runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_POStatusID" runat="server" Text="POStatus :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_POStatusID" Width="70px" Text='<%# Bind("POStatusID") %>' Enabled="False" ToolTip="Value of POStatus." CssClass="dmyfktxt" runat="Server" />
                        <asp:Label ID="F_POStatusID_Display" Text='<%# Eval("EITL_POStatus4_Description") %>' runat="Server" />
                      </td>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_IssuedBy" runat="server" Text="Issued By :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_IssuedBy" Width="56px" Text='<%# Bind("IssuedBy") %>' Enabled="False" ToolTip="Value of Issued By." CssClass="dmyfktxt" runat="Server" />
                        <asp:Label ID="F_IssuedBy_Display" Text='<%# Eval("aspnet_Users3_UserFullName") %>' runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_IssuedOn" runat="server" Text="Issued On :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_IssuedOn" Text='<%# Bind("IssuedOn") %>' ToolTip="Value of Issued On." Enabled="False" Width="140px" CssClass="dmytxt" runat="server" />
                      </td>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_ClosedBy" runat="server" Text="Closed By :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_ClosedBy" Width="56px" Text='<%# Bind("ClosedBy") %>' Enabled="False" ToolTip="Value of Closed By." CssClass="dmyfktxt" runat="Server" />
                        <asp:Label ID="F_ClosedBy_Display" Text='<%# Eval("aspnet_Users2_UserFullName") %>' runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_ClosedOn" runat="server" Text="Closed On :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_ClosedOn" Text='<%# Bind("ClosedOn") %>' ToolTip="Value of Closed On." Enabled="False" Width="140px" CssClass="dmytxt" runat="server" />
                      </td>
                      <td>
                      </td>
                      <td>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="4">
                      </td>
                    </tr>
                  </table>
                </div>
                <div style="vertical-align: middle; height: 200px; width: 39%; margin: 10px auto 10px auto; float: right" class="ui-widget-content ui-corner-all">
                  <h3 class="ui-widget-header ui-corner-all" style="margin: 0; padding: 0.4em; text-align: center;">
                    Bulk Upload Items & Documents Through Template Excel File</h3>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Step 1: Upload item template file." ></asp:Label>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                      <div id="F_Upload" runat="server" style="width: 90%; margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px" class="file_upload" visible="<%# Editable %>">
                        <table>
                        <tr>
                        <td>
                        <input type="text" id="fileName" style="width: 185px" class="file_input_textbox" readonly="readonly">
                        </td>
                        <td>
                        <div class="file_input_div">
                          <input type="button" value="Search" class="file_input_button" />
                          <asp:FileUpload ID="F_FileUpload" runat="server" Width="80px" class="file_input_hidden" onchange="document.getElementById('fileName').value = this.value;" ToolTip="Upload Item Template" />
                        </div>
                        </td>
                        <td>
                        <asp:Button ID="cmdFileUpload" CssClass="file_upload_button" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                        </td>
                        </tr>
                        </table>
                      </div>
                      <asp:Label runat="server" ID="errMsg" ForeColor="Red" Text="" />
                    </ContentTemplate>
                    <Triggers>
                      <asp:PostBackTrigger ControlID="cmdFileUpload" />
                    </Triggers>
                  </asp:UpdatePanel>
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Step 2: Upload document file(s)." ></asp:Label>
                  <asp:UpdatePanel ID="UpdatePanelBulk" runat="server">
                    <ContentTemplate>
                    <div id="F_Upload1" runat="server" style="width: 90%; margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px" class="file_upload" visible="<%# Editable %>">
                        <table>
                        <tr>
                        <td>
                          <input type="file" id="F_FileUploadBulk" name="files[]" multiple style="width:280px"  onchange="document.getElementById('fileNameBulk').value = this.value;"" title="Browse Document Files" />
                        </td>
                        <td>
                         <asp:Button ID="cmdFileUploadBulk" CssClass="file_upload_button" Text="Upload" runat="server" ToolTip="Click to upload document files." CommandName="Upload" CommandArgument="" OnClientClick="showProcessingMPV();" />
                        </td>
                        <td>
                        </td>
                        </tr>
                        </table>
                      </div>
                    </ContentTemplate>
                    <Triggers>
                      <asp:PostBackTrigger ControlID="cmdFileUploadBulk" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </div>
              <fieldset class="ui-widget-content page">
                <legend>
                  <asp:Label ID="LabeleitlPOItemList" runat="server" Text="&nbsp;Item List"></asp:Label>
                </legend>
                <div class="pagedata">
                  <asp:UpdatePanel ID="UPNLeitlPOItemList" runat="server">
                    <ContentTemplate>
                      <table width="100%">
                        <tr>
                          <td class="sis_formview">
                            <LGM:ToolBar0 ID="TBLeitlPOItemList" ToolType="lgNMGrid" EditUrl="~/EITL_Main/App_Edit/EF_eitlPOItemList.aspx" AddUrl="~/EITL_Main/App_Create/AF_eitlPOItemList.aspx" AddPostBack="True" EnableExit="false" ValidationGroup="eitlPOItemList" runat="server" />
                            <asp:UpdateProgress ID="UPGSeitlPOItemList" runat="server" AssociatedUpdatePanelID="UPNLeitlPOItemList" DisplayAfter="100">
                              <ProgressTemplate>
                                <span style="color: #ff0033">Loading...</span>
                              </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:GridView ID="GVeitlPOItemList" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlPOItemList" DataKeyNames="SerialNo,ItemLineNo">
                              <Columns>
                                <asp:TemplateField HeaderText="Edit">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Line No" SortExpression="ItemLineNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelItemLineNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemLineNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="300px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UOM" SortExpression="EITL_Units6_Description">
                                  <ItemTemplate>
                                    <asp:Label ID="L_UOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOM") %>' Text='<%# Eval("EITL_Units6_Description") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle CssClass="alignright" />
                                  <ItemStyle CssClass="alignright" />
                                  <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Weight In KG" SortExpression="WeightInKG">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelWeightInKG" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WeightInKG") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle CssClass="alignright" />
                                  <ItemStyle CssClass="alignright" />
                                  <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Linked Document" SortExpression="EITL_PODocumentList3_DocumentID">
                                  <ItemTemplate>
                                    <asp:Label ID="L_DocumentLineNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DocumentLineNo") %>' Text='<%# Eval("EITL_PODocumentList3_DocumentID") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ready To Despatch" SortExpression="ReadyToDespatch">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelReadyToDespatch" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReadyToDespatch") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VR Execution No" SortExpression="VR_ExecutionNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelVR_ExecutionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VR_ExecutionNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle CssClass="alignright" />
                                  <ItemStyle CssClass="alignright" />
                                  <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                              </Columns>
                              <EmptyDataTemplate>
                                <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                              </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ODSeitlPOItemList" runat="server" DataObjectTypeName="SIS.EITL.eitlPOItemList" OldValuesParameterFormatString="original_{0}" SelectMethod="eitlPOItemListSelectList" TypeName="SIS.EITL.eitlPOItemList" SelectCountMethod="eitlPOItemListSelectCount" SortParameterName="OrderBy" EnablePaging="True">
                              <SelectParameters>
                                <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
                                <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                                <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                              </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                          </td>
                        </tr>
                      </table>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVeitlPOItemList" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </fieldset>
              <fieldset class="ui-widget-content page">
                <legend>
                  <asp:Label ID="LabeleitlPODocumentList" runat="server" Text="&nbsp;Documents List"></asp:Label>
                </legend>
                <div class="pagedata">
                  <asp:UpdatePanel ID="UPNLeitlPODocumentList" runat="server">
                    <ContentTemplate>
                      <table width="100%">
                        <tr>
                          <td class="sis_formview">
                            <LGM:ToolBar0 ID="TBLeitlPODocumentList" ToolType="lgNMGrid" EditUrl="~/EITL_Main/App_Edit/EF_eitlPODocumentList.aspx" AddUrl="~/EITL_Main/App_Create/AF_eitlPODocumentList.aspx?skip=1" AddPostBack="True" EnableExit="false" ValidationGroup="eitlPODocumentList" runat="server" />
                            <asp:UpdateProgress ID="UPGSeitlPODocumentList" runat="server" AssociatedUpdatePanelID="UPNLeitlPODocumentList" DisplayAfter="100">
                              <ProgressTemplate>
                                <span style="color: #ff0033">Loading...</span>
                              </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:GridView ID="GVeitlPODocumentList" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlPODocumentList" DataKeyNames="SerialNo,DocumentLineNo">
                              <Columns>
                                <asp:TemplateField HeaderText="Edit">
                                  <ItemTemplate>
                                     <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document Line No" SortExpression="DocumentLineNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDocumentLineNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentLineNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document ID" SortExpression="DocumentID">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revision No" SortExpression="RevisionNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="300px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ready To Despatch" SortExpression="ReadyToDespatch">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelReadyToDespatch" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReadyToDespatch") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                              </Columns>
                              <EmptyDataTemplate>
                                <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                              </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ODSeitlPODocumentList" runat="server" DataObjectTypeName="SIS.EITL.eitlPODocumentList" OldValuesParameterFormatString="original_{0}" SelectMethod="eitlPODocumentListSelectList" TypeName="SIS.EITL.eitlPODocumentList" SelectCountMethod="eitlPODocumentListSelectCount" SortParameterName="OrderBy" EnablePaging="True">
                              <SelectParameters>
                                <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
                                <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                                <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                              </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                          </td>
                        </tr>
                      </table>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVeitlPODocumentList" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </fieldset>
              <br />
            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource ID="ODSeitlPOList" DataObjectTypeName="SIS.EITL.eitlPOList" SelectMethod="eitlPOListGetByID" UpdateMethod="eitlPOListUpdate" OldValuesParameterFormatString="original_{0}" TypeName="SIS.EITL.eitlPOList" runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
