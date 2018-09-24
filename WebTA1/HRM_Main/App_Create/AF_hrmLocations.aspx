<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_hrmLocations.aspx.vb" Inherits="AF_hrmLocations" title="Add: Locations" %>
<asp:Content ID="CPHhrmLocations" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelhrmLocations" runat="server" Text="&nbsp;Add: Locations"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLhrmLocations" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLhrmLocations"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/HRM_Main/App_Edit/EF_hrmLocations.aspx"
    ValidationGroup = "hrmLocations"
    runat = "server" />
<asp:FormView ID="FVhrmLocations"
  runat = "server"
  DataKeyNames = "LocationID"
  DataSourceID = "ODShrmLocations"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsghrmLocations" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationID" ForeColor="#CC6633" runat="server" Text="Location ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_LocationID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
            ValidationGroup="hrmLocations"
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
            ValidationGroup = "hrmLocations"
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
  ID = "ODShrmLocations"
  DataObjectTypeName = "SIS.HRM.hrmLocations"
  InsertMethod="hrmLocationsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.HRM.hrmLocations"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
