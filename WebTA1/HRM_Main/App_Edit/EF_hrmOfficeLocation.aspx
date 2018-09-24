<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_hrmOfficeLocation.aspx.vb" Inherits="EF_hrmOfficeLocation" title="Edit: Office Location" %>
<asp:Content ID="CPHhrmOfficeLocation" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelhrmOfficeLocation" runat="server" Text="&nbsp;Edit: Office Location"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLhrmOfficeLocation" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLhrmOfficeLocation"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "hrmOfficeLocation"
    runat = "server" />
<asp:FormView ID="FVhrmOfficeLocation"
  runat = "server"
  DataKeyNames = "LocationID,OfficeID"
  DataSourceID = "ODShrmOfficeLocation"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationID" runat="server" ForeColor="#CC6633" Text="Location ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_LocationID"
            Width="88px"
            Text='<%# Bind("LocationID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Location ID."
            Runat="Server" />
          <asp:Label
            ID = "F_LocationID_Display"
            Text='<%# Eval("HRM_Locations1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OfficeID" runat="server" ForeColor="#CC6633" Text="Office ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_OfficeID"
            Width="88px"
            Text='<%# Bind("OfficeID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Office ID."
            Runat="Server" />
          <asp:Label
            ID = "F_OfficeID_Display"
            Text='<%# Eval("HRM_Offices2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="hrmOfficeLocation"
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
            ValidationGroup = "hrmOfficeLocation"
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
  ID = "ODShrmOfficeLocation"
  DataObjectTypeName = "SIS.HRM.hrmOfficeLocation"
  SelectMethod = "hrmOfficeLocationGetByID"
  UpdateMethod="hrmOfficeLocationUpdate"
  DeleteMethod="hrmOfficeLocationDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.HRM.hrmOfficeLocation"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="LocationID" Name="LocationID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="OfficeID" Name="OfficeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
