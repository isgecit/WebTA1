<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSPOBIDocuments.aspx.vb" Inherits="AF_pakSPOBIDocuments" title="Add: S-PO Item Documents" %>
<asp:Content ID="CPHpakSPOBIDocuments" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSPOBIDocuments" runat="server" Text="&nbsp;Add: S-PO Item Documents"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSPOBIDocuments" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSPOBIDocuments"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PAK_Main/App_Edit/EF_pakSPOBIDocuments.aspx"
    ValidationGroup = "pakSPOBIDocuments"
    runat = "server" />
<asp:FormView ID="FVpakSPOBIDocuments"
  runat = "server"
  DataKeyNames = "SerialNo,BOMNo,ItemNo,DocNo"
  DataSourceID = "ODSpakSPOBIDocuments"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSPOBIDocuments" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            ValidationGroup = "pakSPOBIDocuments"
            onblur= "script_pakSPOBIDocuments.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSPOBIDocuments"
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
            OnClientItemSelected="script_pakSPOBIDocuments.ACESerialNo_Selected"
            OnClientPopulating="script_pakSPOBIDocuments.ACESerialNo_Populating"
            OnClientPopulated="script_pakSPOBIDocuments.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_BOMNo" ForeColor="#CC6633" runat="server" Text="BOM No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BOMNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for BOM No."
            ValidationGroup = "pakSPOBIDocuments"
            onblur= "script_pakSPOBIDocuments.validate_BOMNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBOMNo"
            runat = "server"
            ControlToValidate = "F_BOMNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSPOBIDocuments"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_POBOM3_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBOMNo"
            BehaviorID="B_ACEBOMNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BOMNoCompletionList"
            TargetControlID="F_BOMNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSPOBIDocuments.ACEBOMNo_Selected"
            OnClientPopulating="script_pakSPOBIDocuments.ACEBOMNo_Populating"
            OnClientPopulated="script_pakSPOBIDocuments.ACEBOMNo_Populated"
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
        <td>
          <asp:TextBox
            ID = "F_ItemNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item No."
            ValidationGroup = "pakSPOBIDocuments"
            onblur= "script_pakSPOBIDocuments.validate_ItemNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemNo"
            runat = "server"
            ControlToValidate = "F_ItemNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSPOBIDocuments"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_POBItems2_ItemDescription") %>'
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
            OnClientItemSelected="script_pakSPOBIDocuments.ACEItemNo_Selected"
            OnClientPopulating="script_pakSPOBIDocuments.ACEItemNo_Populating"
            OnClientPopulated="script_pakSPOBIDocuments.ACEItemNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_DocNo" ForeColor="#CC6633" runat="server" Text="Doc No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_DocNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocumentID"
            Text='<%# Bind("DocumentID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSPOBIDocuments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentID"
            runat = "server"
            ControlToValidate = "F_DocumentID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSPOBIDocuments"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentRevision" runat="server" Text="Document Revision :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocumentRevision"
            Text='<%# Bind("DocumentRevision") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSPOBIDocuments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document Revision."
            MaxLength="10"
            Width="88px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDocumentRevision"
            runat = "server"
            ControlToValidate = "F_DocumentRevision"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSPOBIDocuments"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentName" runat="server" Text="Document Name :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocumentName"
            Text='<%# Bind("DocumentName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document Name."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileName" runat="server" Text="File Name :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File Name."
            MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSPOBIDocuments"
  DataObjectTypeName = "SIS.PAK.pakSPOBIDocuments"
  InsertMethod="UZ_pakSPOBIDocumentsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSPOBIDocuments"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
