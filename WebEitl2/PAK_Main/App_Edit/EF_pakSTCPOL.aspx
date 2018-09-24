<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSTCPOL.aspx.vb" Inherits="EF_pakSTCPOL" title="Edit: PO Items" %>
<asp:Content ID="CPHpakSTCPOL" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelpakSTCPOL" runat="server" Text="&nbsp;Edit: PO Items"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLpakSTCPOL" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLpakSTCPOL"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnableDelete="False"
            ValidationGroup="pakSTCPOL"
            runat="server" />
          <asp:FormView ID="FVpakSTCPOL"
            runat="server"
            DataKeyNames="SerialNo,ItemNo"
            DataSourceID="ODSpakSTCPOL"
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
                      <asp:TextBox
                        ID="F_SerialNo"
                        Width="88px"
                        Text='<%# Bind("SerialNo") %>'
                        CssClass="mypktxt"
                        Enabled="False"
                        ToolTip="Value of Serial No."
                        runat="Server" />
                      <asp:Label
                        ID="F_SerialNo_Display"
                        Text='<%# Eval("PAK_PO2_PODescription") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ItemNo" runat="server" ForeColor="#CC6633" Text="Item No :" /><span style="color: red">*</span></b>
                    </td>
                    <td colspan="3">
                      <asp:TextBox ID="F_ItemNo"
                        Text='<%# Bind("ItemNo") %>'
                        ToolTip="Value of Item No."
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
                      <asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_ItemCode"
                        Text='<%# Bind("ItemCode") %>'
                        ToolTip="Value of Item Code."
                        Enabled="False"
                        Width="384px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_ItemDescription" runat="server" Text="Description :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_ItemDescription"
                        Text='<%# Bind("ItemDescription") %>'
                        ToolTip="Value of Description."
                        Enabled="False"
                        Width="350px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_ItemQuantity" runat="server" Text="Quantity :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_ItemQuantity"
                        Text='<%# Bind("ItemQuantity") %>'
                        ToolTip="Value of Quantity."
                        Enabled="False"
                        Width="168px"
                        CssClass="dmytxt"
                        Style="text-align: right"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_ItemUnit" runat="server" Text="Unit :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_ItemUnit"
                        Text='<%# Bind("ItemUnit") %>'
                        ToolTip="Value of Unit."
                        Enabled="False"
                        Width="32px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                  </tr>
                  <%--      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemPrice" runat="server" Text="Price :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemPrice"
            Text='<%# Bind("ItemPrice") %>'
            ToolTip="Value of Price."
            Enabled = "False"
            Width="176px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemAmount" runat="server" Text="Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemAmount"
            Text='<%# Bind("ItemAmount") %>'
            ToolTip="Value of Amount."
            Enabled = "False"
            Width="176px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>--%>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_ItemElement" runat="server" Text="Element :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_ItemElement"
                        Width="72px"
                        Text='<%# Bind("ItemElement") %>'
                        Enabled="False"
                        ToolTip="Value of Element."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_ItemElement_Display"
                        Text='<%# Eval("IDM_WBS1_Description") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_ItemStatusID" runat="server" Text="Status :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_ItemStatusID"
                        Width="88px"
                        Text='<%# Bind("ItemStatusID") %>'
                        Enabled="False"
                        ToolTip="Value of Status."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_ItemStatusID_Display"
                        Text='<%# Eval("PAK_POLineStatus3_Description") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                </table>
              </div>
              <fieldset class="ui-widget-content page">
                <legend>
                  <asp:Label ID="LabelpakSTCPOLR" runat="server" Text="&nbsp;List: Submitted for TC"></asp:Label>
                </legend>
                <div class="pagedata">
                  <asp:UpdatePanel ID="UPNLpakSTCPOLR" runat="server">
                    <ContentTemplate>
                      <%--    <table>
      <tr>
        <td style="display:none">
          <asp:Label runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Step 2: Upload document template file." ></asp:Label>
        </td>
        <td>
          <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Upload / attach document file(s)." ></asp:Label>
        </td>
      </tr>
      <tr>
        <td style="text-align:center;display:none">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <asp:FileUpload ID="F_FileUpload" runat="server" Width="150px" ToolTip="Browse Item Template" />
              <asp:Button ID="cmdFileUpload" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="tmplUpload" CommandArgument='<%# Eval("PrimaryKey") %>' />
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdFileUpload" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
        <td style="text-align:center">
          <asp:UpdatePanel ID="UpdatePanelBulk" runat="server">
            <ContentTemplate>
              <input type="file" id="F_FileUploadBulk" name="files[]" multiple="multiple" style="width: 250px" title="Browse Document Files" />
              <asp:Button ID="cmdFileUploadBulk" Text="Upload" runat="server" ToolTip="Click to upload document files." CommandName="filesUpload" CommandArgument='<%# Eval("PrimaryKey") %>' OnClientClick="showProcessingMPV();" />
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdFileUploadBulk" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
      </tr>
    </table>--%>
                      <table width="100%">
                        <tr>
                          <td class="sis_formview">
                            <LGM:ToolBar0
                              ID="TBLpakSTCPOLR"
                              ToolType="lgNMGrid"
                              EditUrl="~/PAK_Main/App_Edit/EF_pakSTCPOLR.aspx"
                              AddUrl="~/PAK_Main/App_Edit/EF_pakSTCPOL.aspx"
                              AddPostBack="True"
                              EnableExit="false"
                              ValidationGroup="pakSTCPOLR"
                              runat="server" />
                            <asp:UpdateProgress ID="UPGSpakSTCPOLR" runat="server" AssociatedUpdatePanelID="UPNLpakSTCPOLR" DisplayAfter="100">
                              <ProgressTemplate>
                                <span style="color: #ff0033">Loading...</span>
                              </ProgressTemplate>
                            </asp:UpdateProgress>
                            <script type="text/javascript">
                              var pcnt = 0;
                              function copy_attach(x) {
                                pcnt = pcnt + 1;
                                var nam = 'wTask' + pcnt;
                                //alert(url);
                                window.open(x, nam, 'left=20,top=20,width=80,height=80,toolbar=1,resizable=1,scrollbars=1');
                                return false;
                              }
                            </script>
                            <asp:GridView ID="GVpakSTCPOLR" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSTCPOLR" DataKeyNames="SerialNo,ItemNo,UploadNo">
                              <Columns>
                                <asp:TemplateField HeaderText="EDIT">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                    <asp:ImageButton ID="cmdCopyDoc" runat="server" Visible='<%# Eval("IsAdmin") %>' AlternateText="Copy" OnClientClick="return confirm('Pl. ensure that documents were not copied first before RE-COPY.');" ToolTip="Re-Copy Documents to Receipt." SkinID="Copy" CommandName="lgCopy" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <%--        <asp:TemplateField HeaderText="Get Tmpl.">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Template File." SkinID="download" OnClientClick='<%# Eval("GetDownloadLink") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Upload No" SortExpression="UploadNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelUploadNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("UploadNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document Category" SortExpression="PAK_POLineRecCategory4_Description">
                                  <ItemTemplate>
                                    <asp:Label ID="L_DocumentCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DocumentCategoryID") %>' Text='<%# Eval("PAK_POLineRecCategory4_Description") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created / Submitted On" SortExpression="CreatedOn">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="" Width="90px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ERP Receipt No" SortExpression="ReceiptNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelReceiptNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReceiptNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="" />
                                  <HeaderStyle CssClass="" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ERP Rev. No" SortExpression="RevisionNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="PAK_POLineRecStatus5_Description">
                                  <ItemTemplate>
                                    <asp:Label ID="L_UploadStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UploadStatusID") %>' Text='<%# Eval("PAK_POLineRecStatus5_Description") %>'></asp:Label>
<%--                                    <asp:Label ID="Label1" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title="Download ISGEC Comments from attached documents." Text='<%# Eval("ShowERPStatus") %>'></asp:Label>--%>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Attatch Documents">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdAttach" runat="server" Visible='<%# Eval("AttachVisible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Attach documents to be submitted to ISGEC." SkinID="attach" OnClientClick='<%# Eval("GetAttachLink") %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISGEC Comments">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# Eval("CommentsVisible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Isgec Comments." SkinID="download" OnClientClick='<%# Eval("GetCommentsLink") %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REVISE">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdRevise" ValidationGroup="Revise" OnClientClick="return confirm('Create new revision of receipt to resubmit updated document ?');" runat="server" Visible='<%# Eval("ReviseVisible") %>' AlternateText="Revise" ToolTip="Click to create New revision of Receipt." SkinID="revise" CommandName="lgRevise" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submit Data to ISGEC">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>
                              </Columns>
                              <EmptyDataTemplate>
                                <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                              </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource
                              ID="ODSpakSTCPOLR"
                              runat="server"
                              DataObjectTypeName="SIS.PAK.pakSTCPOLR"
                              OldValuesParameterFormatString="original_{0}"
                              SelectMethod="pakSTCPOLRSelectList"
                              TypeName="SIS.PAK.pakSTCPOLR"
                              SelectCountMethod="pakSTCPOLRSelectCount"
                              SortParameterName="OrderBy" EnablePaging="True">
                              <SelectParameters>
                                <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
                                <asp:ControlParameter ControlID="F_ItemNo" PropertyName="Text" Name="ItemNo" Type="Int32" Size="10" />
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
                      <asp:AsyncPostBackTrigger ControlID="GVpakSTCPOLR" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </fieldset>
            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSpakSTCPOL"
        DataObjectTypeName="SIS.PAK.pakSTCPOL"
        SelectMethod="pakSTCPOLGetByID"
        UpdateMethod="pakSTCPOLUpdate"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.PAK.pakSTCPOL"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
