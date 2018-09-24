<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogShipmentModes.aspx.vb" Inherits="EF_elogShipmentModes" title="Edit: Shipment Modes" %>
<asp:Content ID="CPHelogShipmentModes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogShipmentModes" runat="server" Text="&nbsp;Edit: Shipment Modes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogShipmentModes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogShipmentModes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogShipmentModes"
    runat = "server" />
<asp:FormView ID="FVelogShipmentModes"
  runat = "server"
  DataKeyNames = "ShipmentModeID"
  DataSourceID = "ODSelogShipmentModes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ShipmentModeID" runat="server" ForeColor="#CC6633" Text="Shipment Mode :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ShipmentModeID"
            Text='<%# Bind("ShipmentModeID") %>'
            ToolTip="Value of Shipment Mode."
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
            ValidationGroup="elogShipmentModes"
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
            ValidationGroup = "elogShipmentModes"
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
  ID = "ODSelogShipmentModes"
  DataObjectTypeName = "SIS.ELOG.elogShipmentModes"
  SelectMethod = "elogShipmentModesGetByID"
  UpdateMethod="elogShipmentModesUpdate"
  DeleteMethod="elogShipmentModesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogShipmentModes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ShipmentModeID" Name="ShipmentModeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
