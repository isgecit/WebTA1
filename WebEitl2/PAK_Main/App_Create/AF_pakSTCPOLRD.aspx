<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSTCPOLRD.aspx.vb" Inherits="AF_pakSTCPOLRD" title="Add: Documents" %>
<asp:Content ID="CPHpakSTCPOLRD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSTCPOLRD" runat="server" Text="&nbsp;Add: Documents"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSTCPOLRD" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSTCPOLRD"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PAK_Main/App_Edit/EF_pakSTCPOLRD.aspx"
    ValidationGroup = "pakSTCPOLRD"
    runat = "server" />
<asp:FormView ID="FVpakSTCPOLRD"
  runat = "server"
  DataKeyNames = "SerialNo,ItemNo,UploadNo,DocSerialNo"
  DataSourceID = "ODSpakSTCPOLRD"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSTCPOLRD" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            ValidationGroup = "pakSTCPOLRD"
            onblur= "script_pakSTCPOLRD.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSTCPOLRD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO1_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSTCPOLRD.ACESerialNo_Selected"
            OnClientPopulating="script_pakSTCPOLRD.ACESerialNo_Populating"
            OnClientPopulated="script_pakSTCPOLRD.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" ForeColor="#CC6633" runat="server" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item No."
            ValidationGroup = "pakSTCPOLRD"
            onblur= "script_pakSTCPOLRD.validate_ItemNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemNo"
            runat = "server"
            ControlToValidate = "F_ItemNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSTCPOLRD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_POLine2_ItemCode") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEItemNo"
            BehaviorID="B_ACEItemNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ItemNoCompletionList"
            TargetControlID="F_ItemNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSTCPOLRD.ACEItemNo_Selected"
            OnClientPopulating="script_pakSTCPOLRD.ACEItemNo_Populating"
            OnClientPopulated="script_pakSTCPOLRD.ACEItemNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UploadNo" ForeColor="#CC6633" runat="server" Text="Upload No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UploadNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("UploadNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Upload No."
            ValidationGroup = "pakSTCPOLRD"
            onblur= "script_pakSTCPOLRD.validate_UploadNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUploadNo"
            runat = "server"
            ControlToValidate = "F_UploadNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSTCPOLRD"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_UploadNo_Display"
            Text='<%# Eval("PAK_POLineRec3_UploadNo") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUploadNo"
            BehaviorID="B_ACEUploadNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UploadNoCompletionList"
            TargetControlID="F_UploadNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSTCPOLRD.ACEUploadNo_Selected"
            OnClientPopulating="script_pakSTCPOLRD.ACEUploadNo_Populating"
            OnClientPopulated="script_pakSTCPOLRD.ACEUploadNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DocSerialNo" ForeColor="#CC6633" runat="server" Text="Document :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocSerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentID" runat="server" Text="ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentID"
            Text='<%# Bind("DocumentID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSTCPOLRD"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ID."
            MaxLength="32"
            Width="264px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSTCPOLRD"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Rev.."
            MaxLength="20"
            Width="168px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSTCPOLRD"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            Width="350px"
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
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSTCPOLRD"
  DataObjectTypeName = "SIS.PAK.pakSTCPOLRD"
  InsertMethod="UZ_pakSTCPOLRDInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSTCPOLRD"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
