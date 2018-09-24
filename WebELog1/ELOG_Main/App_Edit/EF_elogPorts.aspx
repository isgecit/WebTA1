<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogPorts.aspx.vb" Inherits="EF_elogPorts" title="Edit: Ports" %>
<asp:Content ID="CPHelogPorts" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogPorts" runat="server" Text="&nbsp;Edit: Ports"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogPorts" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogPorts"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogPorts"
    runat = "server" />
<asp:FormView ID="FVelogPorts"
  runat = "server"
  DataKeyNames = "PortID"
  DataSourceID = "ODSelogPorts"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PortID" runat="server" ForeColor="#CC6633" Text="Port :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_PortID"
            Text='<%# Bind("PortID") %>'
            ToolTip="Value of Port."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogPorts"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogPorts"
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
  ID = "ODSelogPorts"
  DataObjectTypeName = "SIS.ELOG.elogPorts"
  SelectMethod = "elogPortsGetByID"
  UpdateMethod="elogPortsUpdate"
  DeleteMethod="elogPortsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogPorts"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PortID" Name="PortID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
