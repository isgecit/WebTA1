<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_hrmOfficeLocation.aspx.vb" Inherits="AF_hrmOfficeLocation" title="Add: Office Location" %>
<asp:Content ID="CPHhrmOfficeLocation" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelhrmOfficeLocation" runat="server" Text="&nbsp;Add: Office Location"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLhrmOfficeLocation" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLhrmOfficeLocation"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "hrmOfficeLocation"
    runat = "server" />
<asp:FormView ID="FVhrmOfficeLocation"
  runat = "server"
  DataKeyNames = "LocationID,OfficeID"
  DataSourceID = "ODShrmOfficeLocation"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsghrmOfficeLocation" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationID" ForeColor="#CC6633" runat="server" Text="Location ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_hrmLocations
            ID="F_LocationID"
            SelectedValue='<%# Bind("LocationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "hrmOfficeLocation"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OfficeID" ForeColor="#CC6633" runat="server" Text="Office ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_qcmOffices
            ID="F_OfficeID"
            SelectedValue='<%# Bind("OfficeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "hrmOfficeLocation"
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
            ValidationGroup="hrmOfficeLocation"
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
            ValidationGroup = "hrmOfficeLocation"
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
  ID = "ODShrmOfficeLocation"
  DataObjectTypeName = "SIS.HRM.hrmOfficeLocation"
  InsertMethod="hrmOfficeLocationInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.HRM.hrmOfficeLocation"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
