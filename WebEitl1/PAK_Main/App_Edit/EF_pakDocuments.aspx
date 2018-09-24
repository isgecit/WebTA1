<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakDocuments.aspx.vb" Inherits="EF_pakDocuments" title="Edit: Documents" %>
<asp:Content ID="CPHpakDocuments" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakDocuments" runat="server" Text="&nbsp;Edit: Documents"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakDocuments" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakDocuments"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakDocuments"
    runat = "server" />
<asp:FormView ID="FVpakDocuments"
  runat = "server"
  DataKeyNames = "DocumentNo"
  DataSourceID = "ODSpakDocuments"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DocumentNo" runat="server" ForeColor="#CC6633" Text="Document No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocumentNo"
            Text='<%# Bind("DocumentNo") %>'
            ToolTip="Value of Document No."
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
          <asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocumentID"
            Text='<%# Bind("DocumentID") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakDocuments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentID"
            runat = "server"
            ControlToValidate = "F_DocumentID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakDocuments"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentRevision" runat="server" Text="Document Revision :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocumentRevision"
            Text='<%# Bind("DocumentRevision") %>'
            Width="88px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakDocuments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document Revision."
            MaxLength="10"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentRevision"
            runat = "server"
            ControlToValidate = "F_DocumentRevision"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakDocuments"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakDocuments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakDocuments"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ExternalDocument" runat="server" Text="External Document :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ExternalDocument"
            Checked='<%# Bind("ExternalDocument") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Filename" runat="server" Text="File Name :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Filename"
            Text='<%# Bind("Filename") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File Name."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakDocuments"
  DataObjectTypeName = "SIS.PAK.pakDocuments"
  SelectMethod = "pakDocumentsGetByID"
  UpdateMethod="UZ_pakDocumentsUpdate"
  DeleteMethod="UZ_pakDocumentsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakDocuments"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocumentNo" Name="DocumentNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
