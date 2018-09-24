<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taOOEReasons.aspx.vb" Inherits="AF_taOOEReasons" title="Add: O. O. E. Reasons" %>
<asp:Content ID="CPHtaOOEReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaOOEReasons" runat="server" Text="&nbsp;Add: O. O. E. Reasons"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaOOEReasons" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaOOEReasons"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taOOEReasons"
    runat = "server" />
<asp:FormView ID="FVtaOOEReasons"
  runat = "server"
  DataKeyNames = "ReasonID"
  DataSourceID = "ODStaOOEReasons"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaOOEReasons" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ReasonID" ForeColor="#CC6633" runat="server" Text="Reason ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ReasonID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
            ValidationGroup="taOOEReasons"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taOOEReasons"
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
  ID = "ODStaOOEReasons"
  DataObjectTypeName = "SIS.TA.taOOEReasons"
  InsertMethod="taOOEReasonsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taOOEReasons"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
