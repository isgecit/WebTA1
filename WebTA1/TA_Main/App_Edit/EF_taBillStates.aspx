<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taBillStates.aspx.vb" Inherits="EF_taBillStates" title="Edit: Bill States" %>
<asp:Content ID="CPHtaBillStates" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBillStates" runat="server" Text="&nbsp;Edit: Bill States"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillStates" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBillStates"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taBillStates"
    runat = "server" />
<asp:FormView ID="FVtaBillStates"
  runat = "server"
  DataKeyNames = "BillStatusID"
  DataSourceID = "ODStaBillStates"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BillStatusID" runat="server" ForeColor="#CC6633" Text="Bill Status ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_BillStatusID"
            Text='<%# Bind("BillStatusID") %>'
            ToolTip="Value of Bill Status ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBillStates"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaBillStates"
  DataObjectTypeName = "SIS.TA.taBillStates"
  SelectMethod = "taBillStatesGetByID"
  UpdateMethod="taBillStatesUpdate"
  DeleteMethod="taBillStatesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBillStates"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BillStatusID" Name="BillStatusID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
