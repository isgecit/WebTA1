<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakPakTypes.aspx.vb" Inherits="AF_pakPakTypes" title="Add: Package Types" %>
<asp:Content ID="CPHpakPakTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakPakTypes" runat="server" Text="&nbsp;Add: Package Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakPakTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakPakTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakPakTypes"
    runat = "server" />
<asp:FormView ID="FVpakPakTypes"
  runat = "server"
  DataKeyNames = "PackTypeID"
  DataSourceID = "ODSpakPakTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakPakTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PackTypeID" ForeColor="#CC6633" runat="server" Text="Pack Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PackTypeID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakPakTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakPakTypes"
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
  ID = "ODSpakPakTypes"
  DataObjectTypeName = "SIS.PAK.pakPakTypes"
  InsertMethod="pakPakTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakPakTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
