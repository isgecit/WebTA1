<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogShipmentModes.aspx.vb" Inherits="AF_elogShipmentModes" title="Add: Shipment Modes" %>
<asp:Content ID="CPHelogShipmentModes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogShipmentModes" runat="server" Text="&nbsp;Add: Shipment Modes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogShipmentModes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogShipmentModes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogShipmentModes"
    runat = "server" />
<asp:FormView ID="FVelogShipmentModes"
  runat = "server"
  DataKeyNames = "ShipmentModeID"
  DataSourceID = "ODSelogShipmentModes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogShipmentModes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ShipmentModeID" ForeColor="#CC6633" runat="server" Text="Shipment Mode :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ShipmentModeID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogShipmentModes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogShipmentModes"
  DataObjectTypeName = "SIS.ELOG.elogShipmentModes"
  InsertMethod="elogShipmentModesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogShipmentModes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
