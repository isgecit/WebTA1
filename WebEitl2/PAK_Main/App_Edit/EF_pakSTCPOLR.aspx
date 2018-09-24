<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSTCPOLR.aspx.vb" Inherits="EF_pakSTCPOLR" title="Edit: Submitted for TC" %>
<asp:Content ID="CPHpakSTCPOLR" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSTCPOLR" runat="server" Text="&nbsp;Edit: Submitted for TC"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSTCPOLR" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSTCPOLR"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakSTCPOLR"
    runat = "server" />
<asp:FormView ID="FVpakSTCPOLR"
  runat = "server"
  DataKeyNames = "SerialNo,ItemNo,UploadNo"
  DataSourceID = "ODSpakSTCPOLR"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Serial No."
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO2_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" runat="server" ForeColor="#CC6633" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemNo"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Item No."
            Runat="Server" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_POLine3_ItemCode") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UploadNo" runat="server" ForeColor="#CC6633" Text="Upload No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UploadNo"
            Text='<%# Bind("UploadNo") %>'
            ToolTip="Value of Upload No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
<%--      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentCategoryID" runat="server" Text="Document Category :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_pakTCPOLRCate
            ID="F_DocumentCategoryID"
            SelectedValue='<%# Bind("DocumentCategoryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pakSTCPOLR"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>--%>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UploadRemarks" runat="server" Text="Remarks :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UploadRemarks"
            Text='<%# Bind("UploadRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSTCPOLR"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUploadRemarks"
            runat = "server"
            ControlToValidate = "F_UploadRemarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSTCPOLR"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created / Submitted By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Submitted By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created / Submitted On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Submitted On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UploadStatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UploadStatusID"
            Width="88px"
            Text='<%# Bind("UploadStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UploadStatusID_Display"
            Text='<%# Eval("PAK_POLineRecStatus5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReceiptNo" runat="server" Text="ERP Receipt No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReceiptNo"
            Text='<%# Bind("ReceiptNo") %>'
            ToolTip="Value of ERP Receipt No."
            Enabled = "False"
            Width="80px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RevisionNo" runat="server" Text="ERP Rev. No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RevisionNo"
            Text='<%# Bind("RevisionNo") %>'
            ToolTip="Value of ERP Rev. No."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakSTCPOLRD" runat="server" Text="&nbsp;List: Attached Documents"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSTCPOLRD" runat="server">
  <ContentTemplate>
<%--    <table>
      <tr>
        <td>
          <asp:Label runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Step 1: Download XL template file." ></asp:Label>
        </td>
        <td>
          <asp:Label runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Step 2: Upload document template file." ></asp:Label>
        </td>
        <td>
          <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Step 3: Upload / attach document file(s)." ></asp:Label>
        </td>
      </tr>
      <tr>
        <td style="text-align:center">
          <asp:Button ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Template File." Text="Download" OnClientClick='<%# Eval("GetDownloadLink") %>' />
        </td>
        <td style="text-align:center">
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
              <input type="file" id="F_FileUploadBulk" name="files[]" multiple="multiple" style="width: 150px" title="Browse Document Files" />
              <asp:Button ID="cmdFileUploadBulk" Text="Upload" runat="server" ToolTip="Click to upload document files." CommandName="filesUpload" CommandArgument='<%# Eval("PrimaryKey") %>' OnClientClick="showProcessingMPV();" />
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdFileUploadBulk" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
      </tr>
    </table>--%>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSTCPOLRD"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSTCPOLRD.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakSTCPOLRD.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pakSTCPOLRD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSTCPOLRD" runat="server" AssociatedUpdatePanelID="UPNLpakSTCPOLRD" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
          <script type="text/javascript">
            var pcnt = 0;
            function show_recattach(o) {
              pcnt = pcnt + 1;
              var nam = 'wTask' + pcnt;
              var url = o.getAttribute('CommandValue');
              window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
          </script>
          <script type="text/javascript">
            var pcnt = 0;
            function show_comments(o) {
              pcnt = pcnt + 1;
              var nam = 'wTask' + pcnt;
              var url = o.getAttribute('CommandValue');
              //alert(url);
              window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
          </script>
    <asp:GridView ID="GVpakSTCPOLRD" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSTCPOLRD" DataKeyNames="SerialNo,ItemNo,UploadNo,DocSerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:ImageButton ID="cmdRecDoc"  runat="server" Visible='<%# Eval("IsAdmin") %>' AlternateText="Display" ToolTip="Display Receipt Documents." SkinID="info" CommandValue='<%# Eval("GetRecAttachLink") %>' OnClientClick="return show_recattach(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Open Attachment">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Template File." SkinID="download" OnClientClick='<%# Eval("GetDownloadLink") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Document" SortExpression="DocSerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelDocSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("DocSerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rev." SortExpression="DocumentRev">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentRev" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentRev") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="DocumentDescription">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="300px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Receipt" SortExpression="ReceiptNo">
          <ItemTemplate>
            <asp:Label ID="LabelReceiptNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReceiptNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Rev" SortExpression="RevisionNo">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="ISGEC Comments">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Isgec Comments." SkinID="download" CommandValue='<%# Eval("GetCommentsLink") %>' OnClientClick="return show_comments(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakSTCPOLRD"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSTCPOLRD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakSTCPOLRDSelectList"
      TypeName = "SIS.PAK.pakSTCPOLRD"
      SelectCountMethod = "pakSTCPOLRDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UploadNo" PropertyName="Text" Name="UploadNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ItemNo" PropertyName="Text" Name="ItemNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSTCPOLRD" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSTCPOLR"
  DataObjectTypeName = "SIS.PAK.pakSTCPOLR"
  SelectMethod = "pakSTCPOLRGetByID"
  UpdateMethod="UZ_pakSTCPOLRUpdate"
  DeleteMethod="UZ_pakSTCPOLRDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSTCPOLR"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UploadNo" Name="UploadNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
