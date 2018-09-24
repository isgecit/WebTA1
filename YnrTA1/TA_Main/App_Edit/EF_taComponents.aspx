<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taComponents.aspx.vb" Inherits="EF_taComponents" title="Edit: Bill Components" %>
<asp:Content ID="CPHtaComponents" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaComponents" runat="server" Text="&nbsp;Edit: Bill Components"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaComponents" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaComponents"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taComponents"
    runat = "server" />
<asp:FormView ID="FVtaComponents"
  runat = "server"
  DataKeyNames = "ComponentID"
  DataSourceID = "ODStaComponents"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ComponentID" runat="server" ForeColor="#CC6633" Text="Component ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ComponentID"
            Text='<%# Bind("ComponentID") %>'
            ToolTip="Value of Component ID."
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
            ValidationGroup="taComponents"
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
            ValidationGroup = "taComponents"
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
  ID = "ODStaComponents"
  DataObjectTypeName = "SIS.TA.taComponents"
  SelectMethod = "taComponentsGetByID"
  UpdateMethod="taComponentsUpdate"
  DeleteMethod="taComponentsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taComponents"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ComponentID" Name="ComponentID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
