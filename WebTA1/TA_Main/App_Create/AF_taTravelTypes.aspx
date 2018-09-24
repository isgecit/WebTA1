<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taTravelTypes.aspx.vb" Inherits="AF_taTravelTypes" title="Add: Travel Types" %>
<asp:Content ID="CPHtaTravelTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaTravelTypes" runat="server" Text="&nbsp;Add: Travel Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaTravelTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaTravelTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taTravelTypes"
    runat = "server" />
<asp:FormView ID="FVtaTravelTypes"
  runat = "server"
  DataKeyNames = "TravelTypeID"
  DataSourceID = "ODStaTravelTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaTravelTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TravelTypeID" ForeColor="#CC6633" runat="server" Text="Travel Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_TravelTypeID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TravelTypeDescription" runat="server" Text="Travel Type Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_TravelTypeDescription"
            Text='<%# Bind("TravelTypeDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taTravelTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Travel Type Description."
            MaxLength="50"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaTravelTypes"
  DataObjectTypeName = "SIS.TA.taTravelTypes"
  InsertMethod="UZ_taTravelTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taTravelTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
