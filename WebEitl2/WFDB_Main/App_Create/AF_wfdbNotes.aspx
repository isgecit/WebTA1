<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_wfdbNotes.aspx.vb" Inherits="AF_wfdbNotes" title="Add: Notes" %>
<asp:Content ID="CPHwfdbNotes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelwfdbNotes" runat="server" Text="&nbsp;Add: Notes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLwfdbNotes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLwfdbNotes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "wfdbNotes"
    runat = "server" />
<asp:FormView ID="FVwfdbNotes"
  runat = "server"
  DataKeyNames = "IndexValue,NotesId"
  DataSourceID = "ODSwfdbNotes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgwfdbNotes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IndexValue" ForeColor="#CC6633" runat="server" Text="IndexValue :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IndexValue"
            Text='<%# Bind("IndexValue") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndexValue."
            MaxLength="200"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIndexValue"
            runat = "server"
            ControlToValidate = "F_IndexValue"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbNotes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Title" runat="server" Text="Title :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Title"
            Text='<%# Bind("Title") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Title."
            MaxLength="4000"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTitle"
            runat = "server"
            ControlToValidate = "F_Title"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbNotes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="4000"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbNotes"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SendEmailTo" runat="server" Text="SendEmailTo :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SendEmailTo"
            Text='<%# Bind("SendEmailTo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SendEmailTo."
            MaxLength="4000"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSendEmailTo"
            runat = "server"
            ControlToValidate = "F_SendEmailTo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbNotes"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSwfdbNotes"
  DataObjectTypeName = "SIS.WFDB.wfdbNotes"
  InsertMethod="UZ_wfdbNotesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.WFDB.wfdbNotes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
