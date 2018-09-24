<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSTCPOLRD.aspx.vb" Inherits="EF_pakSTCPOLRD" title="Edit: Documents" %>
<asp:Content ID="CPHpakSTCPOLRD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSTCPOLRD" runat="server" Text="&nbsp;Edit: Documents"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSTCPOLRD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSTCPOLRD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakSTCPOLRD"
    runat = "server" />
<asp:FormView ID="FVpakSTCPOLRD"
  runat = "server"
  DataKeyNames = "SerialNo,ItemNo,UploadNo,DocSerialNo"
  DataSourceID = "ODSpakSTCPOLRD"
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
            Text='<%# Eval("PAK_PO1_PODescription") %>'
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
            Text='<%# Eval("PAK_POLine2_ItemCode") %>'
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
          <asp:TextBox
            ID = "F_UploadNo"
            Width="88px"
            Text='<%# Bind("UploadNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Upload No."
            Runat="Server" />
          <asp:Label
            ID = "F_UploadNo_Display"
            Text='<%# Eval("PAK_POLineRec3_UploadNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DocSerialNo" runat="server" ForeColor="#CC6633" Text="Document :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocSerialNo"
            Text='<%# Bind("DocSerialNo") %>'
            ToolTip="Value of Document."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentID" runat="server" Text="ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentID"
            Text='<%# Bind("DocumentID") %>'
            Width="264px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSTCPOLRD"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ID."
            MaxLength="32"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentID"
            runat = "server"
            ControlToValidate = "F_DocumentID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSTCPOLRD"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DocumentRev" runat="server" Text="Rev. :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentRev"
            Text='<%# Bind("DocumentRev") %>'
            Width="168px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSTCPOLRD"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Rev.."
            MaxLength="20"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentRev"
            runat = "server"
            ControlToValidate = "F_DocumentRev"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSTCPOLRD"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentDescription" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentDescription"
            Text='<%# Bind("DocumentDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSTCPOLRD"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentDescription"
            runat = "server"
            ControlToValidate = "F_DocumentDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSTCPOLRD"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label1" runat="server" Text="Attach Document :" /><span style="color:red">*</span>
        </td>
        <td>
          <script type="text/javascript">
            var pcnt = 0;
            function show_attach(o) {
              pcnt = pcnt + 1;
              var nam = 'wTask' + pcnt;
              var url = o.getAttribute('CommandValue');
              //alert(url);
              window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
          </script>
          <asp:Button ID="cmdAttach" runat="server" CommandValue='<%# Eval("GetAttachLink") %>' Text="Attachment" OnClientClick="return show_attach(this);" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReceiptNo" runat="server" Text="ERP Receipt :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReceiptNo"
            Text='<%# Bind("ReceiptNo") %>'
            ToolTip="Value of ERP Receipt."
            Enabled = "False"
            Width="80px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RevisionNo" runat="server" Text="ERP Rev :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RevisionNo"
            Text='<%# Bind("RevisionNo") %>'
            ToolTip="Value of ERP Rev."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
<%--      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileName" runat="server" Text="File Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            ToolTip="Value of File Name."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td></td>
        <td></td>
      </tr>--%>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSTCPOLRD"
  DataObjectTypeName = "SIS.PAK.pakSTCPOLRD"
  SelectMethod = "pakSTCPOLRDGetByID"
  UpdateMethod="UZ_pakSTCPOLRDUpdate"
  DeleteMethod="UZ_pakSTCPOLRDDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSTCPOLRD"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UploadNo" Name="UploadNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocSerialNo" Name="DocSerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
