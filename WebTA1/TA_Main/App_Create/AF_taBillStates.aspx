<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taBillStates.aspx.vb" Inherits="AF_taBillStates" title="Add: Bill States" %>
<asp:Content ID="CPHtaBillStates" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBillStates" runat="server" Text="&nbsp;Add: Bill States"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillStates" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBillStates"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taBillStates"
    runat = "server" />
<asp:FormView ID="FVtaBillStates"
  runat = "server"
  DataKeyNames = "BillStatusID"
  DataSourceID = "ODStaBillStates"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaBillStates" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BillStatusID" ForeColor="#CC6633" runat="server" Text="Bill Status ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_BillStatusID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBillStates"
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
            ValidationGroup = "taBillStates"
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
  ID = "ODStaBillStates"
  DataObjectTypeName = "SIS.TA.taBillStates"
  InsertMethod="taBillStatesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBillStates"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
