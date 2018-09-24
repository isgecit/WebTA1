<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taOOEReasons.aspx.vb" Inherits="EF_taOOEReasons" title="Edit: O. O. E. Reasons" %>
<asp:Content ID="CPHtaOOEReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaOOEReasons" runat="server" Text="&nbsp;Edit: O. O. E. Reasons"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaOOEReasons" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaOOEReasons"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taOOEReasons"
    runat = "server" />
<asp:FormView ID="FVtaOOEReasons"
  runat = "server"
  DataKeyNames = "ReasonID"
  DataSourceID = "ODStaOOEReasons"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ReasonID" runat="server" ForeColor="#CC6633" Text="Reason ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ReasonID"
            Text='<%# Bind("ReasonID") %>'
            ToolTip="Value of Reason ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
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
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taOOEReasons"
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
            ValidationGroup = "taOOEReasons"
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
  ID = "ODStaOOEReasons"
  DataObjectTypeName = "SIS.TA.taOOEReasons"
  SelectMethod = "taOOEReasonsGetByID"
  UpdateMethod="taOOEReasonsUpdate"
  DeleteMethod="taOOEReasonsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taOOEReasons"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ReasonID" Name="ReasonID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
