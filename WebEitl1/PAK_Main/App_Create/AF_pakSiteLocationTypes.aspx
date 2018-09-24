<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakSiteLocationTypes.aspx.vb" Inherits="AF_pakSiteLocationTypes" title="Add: Site Location Types" %>
<asp:Content ID="CPHpakSiteLocationTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSiteLocationTypes" runat="server" Text="&nbsp;Add: Site Location Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteLocationTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSiteLocationTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakSiteLocationTypes"
    runat = "server" />
<asp:FormView ID="FVpakSiteLocationTypes"
  runat = "server"
  DataKeyNames = "LocationTypeID"
  DataSourceID = "ODSpakSiteLocationTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakSiteLocationTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationTypeID" ForeColor="#CC6633" runat="server" Text="Location Type :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_LocationTypeID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
            ValidationGroup="pakSiteLocationTypes"
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
            ValidationGroup = "pakSiteLocationTypes"
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
  ID = "ODSpakSiteLocationTypes"
  DataObjectTypeName = "SIS.PAK.pakSiteLocationTypes"
  InsertMethod="pakSiteLocationTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSiteLocationTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
