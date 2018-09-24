<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakPO.aspx.vb" Inherits="EF_pakPO" title="Edit: Purchase Order" %>
<asp:Content ID="CPHpakPO" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelpakPO" runat="server" Text="&nbsp;Edit: Purchase Order"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLpakPO" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLpakPO"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            ValidationGroup="pakPO"
            runat="server" />
          <asp:FormView ID="FVpakPO"
            runat="server"
            DataKeyNames="SerialNo"
            DataSourceID="ODSpakPO"
            DefaultMode="Edit" CssClass="sis_formview">
            <EditItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <table style="margin: auto; border: solid 1pt lightgrey">
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color: red">*</span></b>
                    </td>
                    <td colspan="3">
                      <asp:TextBox ID="F_SerialNo"
                        Text='<%# Bind("SerialNo") %>'
                        ToolTip="Value of Serial No."
                        Enabled="False"
                        CssClass="mypktxt"
                        Width="88px"
                        Style="text-align: right"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_PONumber" runat="server" Text="PO Number :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_PONumber"
                        Text='<%# Bind("PONumber") %>'
                        ToolTip="Value of PO Number."
                        Enabled="False"
                        Width="88px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_PORevision" runat="server" Text="PO Revision :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_PORevision"
                        Text='<%# Bind("PORevision") %>'
                        ToolTip="Value of PO Revision."
                        Enabled="False"
                        Width="88px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_PODate" runat="server" Text="PO Date :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_PODate"
                        Text='<%# Bind("PODate") %>'
                        ToolTip="Value of PO Date."
                        Enabled="False"
                        Width="168px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_POStatusID" runat="server" Text="Status :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_POStatusID"
                        Width="88px"
                        Text='<%# Bind("POStatusID") %>'
                        Enabled="False"
                        ToolTip="Value of Status."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_POStatusID_Display"
                        Text='<%# Eval("PAK_POStatus6_Description") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_PODescription" runat="server" Text="PO Description :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_PODescription"
                        Text='<%# Bind("PODescription") %>'
                        ToolTip="Value of PO Description."
                        Enabled="False"
                        Width="350px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_BuyerID" runat="server" Text="Buyer :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_BuyerID"
                        Width="72px"
                        Text='<%# Bind("BuyerID") %>'
                        Enabled="False"
                        ToolTip="Value of Buyer."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_BuyerID_Display"
                        Text='<%# Eval("aspnet_users1_UserFullName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_SupplierID"
                        Width="80px"
                        Text='<%# Bind("SupplierID") %>'
                        Enabled="False"
                        ToolTip="Value of Supplier."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_SupplierID_Display"
                        Text='<%# Eval("VR_BusinessPartner9_BPName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_ProjectID"
                        Width="56px"
                        Text='<%# Bind("ProjectID") %>'
                        Enabled="False"
                        ToolTip="Value of Project."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_ProjectID_Display"
                        Text='<%# Eval("IDM_Projects4_Description") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_IssuedBy" runat="server" Text="Issued By :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_IssuedBy"
                        Width="72px"
                        Text='<%# Bind("IssuedBy") %>'
                        Enabled="False"
                        ToolTip="Value of Issued By."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_IssuedBy_Display"
                        Text='<%# Eval("aspnet_users2_UserFullName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_IssuedOn" runat="server" Text="Issued On :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_IssuedOn"
                        Text='<%# Bind("IssuedOn") %>'
                        ToolTip="Value of Issued On."
                        Enabled="False"
                        Width="168px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_ClosedBy" runat="server" Text="Closed By :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_ClosedBy"
                        Width="72px"
                        Text='<%# Bind("ClosedBy") %>'
                        Enabled="False"
                        ToolTip="Value of Closed By."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_ClosedBy_Display"
                        Text='<%# Eval("aspnet_users3_UserFullName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_ClosedOn" runat="server" Text="Closed On :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_ClosedOn"
                        Text='<%# Bind("ClosedOn") %>'
                        ToolTip="Value of Closed On."
                        Enabled="False"
                        Width="168px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_IssueReasonID" runat="server" Text="Reason For Creation :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <LGM:LC_pakReasons
                        ID="F_IssueReasonID"
                        SelectedValue='<%# Bind("IssueReasonID") %>'
                        OrderBy="DisplayField"
                        DataTextField="DisplayField"
                        DataValueField="PrimaryKey"
                        IncludeDefault="true"
                        DefaultText="-- Select --"
                        Width="200px"
                        CssClass="myddl"
                        ValidationGroup="pakPO"
                        RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_PortID" runat="server" Text="Port ID :" />
                    </td>
                    <td colspan="3">
                      <LGM:LC_elogPorts
                        ID="F_PortID"
                        SelectedValue='<%# Bind("PortID") %>'
                        OrderBy="DisplayField"
                        DataTextField="DisplayField"
                        DataValueField="PrimaryKey"
                        IncludeDefault="true"
                        DefaultText="-- Select --"
                        Width="200px"
                        CssClass="myddl"
                        Runat="Server" />
                      </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_ISGECRemarks" runat="server" Text="ISGEC Remarks :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_ISGECRemarks"
                        Text='<%# Bind("ISGECRemarks") %>'
                        Width="350px" Height="40px" TextMode="MultiLine"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for ISGEC Remarks."
                        MaxLength="500"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_SupplierRemarks" runat="server" Text="Supplier Remarks :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_SupplierRemarks"
                        Text='<%# Bind("SupplierRemarks") %>'
                        ToolTip="Value of Supplier Remarks."
                        Enabled="False"
                        Width="350px" Height="40px" TextMode="MultiLine"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                </table>
              </div>
              <fieldset class="ui-widget-content page">
                <legend>
                  <asp:Label ID="LabelpakPOBOM" runat="server" Text="&nbsp;List: PO Item"></asp:Label>
                </legend>
                <div class="pagedata">
                  <asp:UpdatePanel ID="UPNLpakPOBOM" runat="server">
                    <ContentTemplate>
                      <table width="100%">
                        <tr>
                          <td>
                            <asp:Panel ID="Panel1" runat="server" Visible='<%# DUListVisible %>' class="file_upload" Style="width: auto; margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px">

                              <table>
                                <tr>
                                  <td colspan="4">
                                    <asp:Label ID="errMsg" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
                                  </td>
                                </tr>
                                <tr>
                                  <td><b>Upload Template</b></td>
                                  <td></td>
                                  <td>
                                    <asp:FileUpload ID="F_FileUpload" runat="server" Width="180px" ToolTip="Upload Item Template" />
                                  </td>
                                  <td>
                                    <asp:Button ID="cmdFileUpload" OnClientClick="return this.style.display='none';true;" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                                  </td>
                                </tr>
                              </table>
                            </asp:Panel>
                          </td>
                        </tr>
                        <tr>
                          <td class="sis_formview">
                            <LGM:ToolBar0
                              ID="TBLpakPOBOM"
                              ToolType="lgNMGrid"
                              EditUrl="~/PAK_Main/App_Edit/EF_pakPOBOM.aspx"
                              EnableAdd="False"
                              EnableExit="false"
                              ValidationGroup="pakPOBOM"
                              runat="server" />
                            <asp:UpdateProgress ID="UPGSpakPOBOM" runat="server" AssociatedUpdatePanelID="UPNLpakPOBOM" DisplayAfter="100">
                              <ProgressTemplate>
                                <span style="color: #ff0033">Loading...</span>
                              </ProgressTemplate>
                            </asp:UpdateProgress>
                            <script type="text/javascript">
                              var pcnt = 0;
                              function print_report(o) {
                                pcnt = pcnt + 1;
                                var nam = 'wTask' + pcnt;
                                var url = self.location.href.replace('App_Edit/EF_', 'App_Print/RP_');
                                url = url + '&pk=' + o.alt;
                                window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
                                return false;
                              }
                            </script>
                            <asp:GridView ID="GVpakPOBOM" SkinID="gv_silver" runat="server" DataSourceID="ODSpakPOBOM" DataKeyNames="SerialNo,BOMNo">
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
                                <asp:TemplateField HeaderText="Get XL">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Template File." SkinID="download" OnClientClick='<%# Eval("GetDownloadLink") %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BOM No" SortExpression="BOMNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelBOMNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BOMNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item No" SortExpression="ItemNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Element" SortExpression="PAK_Elements5_Description">
                                  <ItemTemplate>
                                    <asp:Label ID="L_ElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ElementID") %>' Text='<%# Eval("PAK_Elements5_Description") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISGEC Remarks" SortExpression="ISGECRemarks">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelISGECRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ISGECRemarks") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="" />
                                  <HeaderStyle HorizontalAlign="Left" CssClass="" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier Remarks" SortExpression="SupplierRemarks">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelSupplierRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierRemarks") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="" />
                                  <HeaderStyle CssClass="" HorizontalAlign="Left" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DELETE">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete Package from PO" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""ALL BOM Item Details will also be DELETED ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                              ID="ODSpakPOBOM"
                              runat="server"
                              DataObjectTypeName="SIS.PAK.pakPOBOM"
                              OldValuesParameterFormatString="original_{0}"
                              SelectMethod="UZ_pakPOBOMSelectList"
                              TypeName="SIS.PAK.pakPOBOM"
                              SelectCountMethod="pakPOBOMSelectCount"
                              SortParameterName="OrderBy" EnablePaging="True">
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
                      <asp:AsyncPostBackTrigger ControlID="GVpakPOBOM" EventName="PageIndexChanged" />
                      <asp:PostBackTrigger ControlID="cmdFileUpload" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </fieldset>
              <asp:Panel ID="pnlDUList" runat="server" Visible='<%# DUListVisible %>'>
                <fieldset class="ui-widget-content page" id="fsUnlinked" runat="server">
                  <legend>
                    <asp:Label ID="LabelpakUItems" runat="server" Text="&nbsp;List: Unlinked Items"></asp:Label>
                  </legend>
                  <div class="pagedata">
                    <asp:UpdatePanel ID="UPNLpakUItems" runat="server">
                      <ContentTemplate>
                        <table width="100%">
                          <tr>
                            <td class="sis_formview">
                              <LGM:ToolBar0
                                ID="TBLpakUItems"
                                ToolType="lgNMGrid"
                                EditUrl="~/PAK_Main/App_Edit/EF_pakUItems.aspx"
                                EnableAdd="False"
                                EnableExit="false"
                                ValidationGroup="pakUItems"
                                runat="server" />
                              <asp:UpdateProgress ID="UPGSpakUItems" runat="server" AssociatedUpdatePanelID="UPNLpakUItems" DisplayAfter="100">
                                <ProgressTemplate>
                                  <span style="color: #ff0033">Loading...</span>
                                </ProgressTemplate>
                              </asp:UpdateProgress>
                              <asp:GridView ID="GVpakUItems" SkinID="gv_silver" runat="server" DataSourceID="ODSpakUItems" DataKeyNames="ItemNo">
                                <Columns>
                                  <asp:TemplateField HeaderText="EDIT">
                                    <ItemTemplate>
                                      <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="alignCenter" />
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Item No" SortExpression="ItemNo">
                                    <ItemTemplate>
                                      <asp:Label ID="LabelItemNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ItemNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="alignCenter" />
                                    <HeaderStyle CssClass="alignCenter" Width="40px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
                                    <ItemTemplate>
                                      <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="" />
                                    <HeaderStyle CssClass="" Width="100px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
                                    <ItemTemplate>
                                      <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="" />
                                    <HeaderStyle CssClass="" Width="100px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Element ID" SortExpression="PAK_Elements3_Description">
                                    <ItemTemplate>
                                      <asp:Label ID="L_ElementID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ElementID") %>' Text='<%# Eval("PAK_Elements3_Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                    <ItemTemplate>
                                      <asp:Label ID="LabelActive" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="alignCenter" />
                                    <HeaderStyle CssClass="" Width="50px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="ADD In PO">
                                    <ItemTemplate>
                                      <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Add DU in PO" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Add DU in PO ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                                ID="ODSpakUItems"
                                runat="server"
                                DataObjectTypeName="SIS.PAK.pakUItems"
                                OldValuesParameterFormatString="original_{0}"
                                SelectMethod="UZ_pakUItemsSelectList"
                                TypeName="SIS.PAK.pakUItems"
                                SelectCountMethod="pakUItemsSelectCount"
                                SortParameterName="OrderBy" EnablePaging="True">
                                <SelectParameters>
                                  <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="String" Size="10" />
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
                        <asp:AsyncPostBackTrigger ControlID="GVpakUItems" EventName="PageIndexChanged" />
                      </Triggers>
                    </asp:UpdatePanel>
                  </div>
                </fieldset>
              </asp:Panel>
            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSpakPO"
        DataObjectTypeName="SIS.PAK.pakPO"
        SelectMethod="pakPOGetByID"
        UpdateMethod="UZ_pakPOUpdate"
        DeleteMethod="UZ_pakPODelete"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.PAK.pakPO"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
