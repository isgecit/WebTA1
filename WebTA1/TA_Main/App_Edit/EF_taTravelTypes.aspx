<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taTravelTypes.aspx.vb" Inherits="EF_taTravelTypes" title="Edit: Travel Types" %>
<asp:Content ID="CPHtaTravelTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaTravelTypes" runat="server" Text="&nbsp;Edit: Travel Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaTravelTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaTravelTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taTravelTypes"
    runat = "server" />
<asp:FormView ID="FVtaTravelTypes"
  runat = "server"
  DataKeyNames = "TravelTypeID"
  DataSourceID = "ODStaTravelTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TravelTypeID" runat="server" ForeColor="#CC6633" Text="Travel Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_TravelTypeID"
            Text='<%# Bind("TravelTypeID") %>'
            ToolTip="Value of Travel Type ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TravelTypeDescription" runat="server" Text="Travel Type Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_TravelTypeDescription"
            Text='<%# Bind("TravelTypeDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taTravelTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Travel Type Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTravelTypeDescription"
            runat = "server"
            ControlToValidate = "F_TravelTypeDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taTravelTypes"
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
  ID = "ODStaTravelTypes"
  DataObjectTypeName = "SIS.TA.taTravelTypes"
  SelectMethod = "taTravelTypesGetByID"
  UpdateMethod="UZ_taTravelTypesUpdate"
  DeleteMethod="taTravelTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taTravelTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TravelTypeID" Name="TravelTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
