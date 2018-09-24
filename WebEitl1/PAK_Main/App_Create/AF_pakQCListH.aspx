<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakQCListH.aspx.vb" Inherits="AF_pakQCListH" title="Add: Quality Clearance" %>
<asp:Content ID="CPHpakQCListH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakQCListH" runat="server" Text="&nbsp;Add: Quality Clearance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakQCListH" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakQCListH"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PAK_Main/App_Edit/EF_pakQCListH.aspx"
    ValidationGroup = "pakQCListH"
    runat = "server" />
<asp:FormView ID="FVpakQCListH"
  runat = "server"
  DataKeyNames = "SerialNo,QCLNo"
  DataSourceID = "ODSpakQCListH"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakQCListH" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "pakQCListH"
            onblur= "script_pakQCListH.validate_SerialNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSerialNo"
            runat = "server"
            ControlToValidate = "F_SerialNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakQCListH"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO2_PODescription") %>'
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
            OnClientItemSelected="script_pakQCListH.ACESerialNo_Selected"
            OnClientPopulating="script_pakQCListH.ACESerialNo_Populating"
            OnClientPopulated="script_pakQCListH.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_QCLNo" ForeColor="#CC6633" runat="server" Text="QC List No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_QCLNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierRef" runat="server" Text="Description :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierRef"
            Text='<%# Bind("SupplierRef") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakQCListH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRemarks"
            runat = "server"
            ControlToValidate = "F_Remarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakQCListH"
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
  ID = "ODSpakQCListH"
  DataObjectTypeName = "SIS.PAK.pakQCListH"
  InsertMethod="pakQCListHInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakQCListH"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
