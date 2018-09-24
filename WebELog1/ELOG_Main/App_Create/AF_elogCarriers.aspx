<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogCarriers.aspx.vb" Inherits="AF_elogCarriers" title="Add: Carriers" %>
<asp:Content ID="CPHelogCarriers" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogCarriers" runat="server" Text="&nbsp;Add: Carriers"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogCarriers" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogCarriers"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogCarriers"
    runat = "server" />
<asp:FormView ID="FVelogCarriers"
  runat = "server"
  DataKeyNames = "CarrierID"
  DataSourceID = "ODSelogCarriers"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogCarriers" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CarrierID" ForeColor="#CC6633" runat="server" Text="Carrier ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CarrierID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ShipmentModeID" runat="server" Text="Shipment Mode ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogShipmentModes
            ID="F_ShipmentModeID"
            SelectedValue='<%# Bind("ShipmentModeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogCarriers"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
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
            ValidationGroup="elogCarriers"
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
            ValidationGroup = "elogCarriers"
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
  ID = "ODSelogCarriers"
  DataObjectTypeName = "SIS.ELOG.elogCarriers"
  InsertMethod="elogCarriersInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogCarriers"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
