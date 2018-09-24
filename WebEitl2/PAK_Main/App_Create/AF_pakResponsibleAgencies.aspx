<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakResponsibleAgencies.aspx.vb" Inherits="AF_pakResponsibleAgencies" title="Add: Responsible Agencies" %>
<asp:Content ID="CPHpakResponsibleAgencies" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakResponsibleAgencies" runat="server" Text="&nbsp;Add: Responsible Agencies"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakResponsibleAgencies" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakResponsibleAgencies"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakResponsibleAgencies"
    runat = "server" />
<asp:FormView ID="FVpakResponsibleAgencies"
  runat = "server"
  DataKeyNames = "ResponsibleAgencyID"
  DataSourceID = "ODSpakResponsibleAgencies"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakResponsibleAgencies" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ResponsibleAgencyID" ForeColor="#CC6633" runat="server" Text="Responsible Agency ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ResponsibleAgencyID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
            ValidationGroup="pakResponsibleAgencies"
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
            ValidationGroup = "pakResponsibleAgencies"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ExternalAgency" runat="server" Text="External Agency :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ExternalAgency"
           Checked='<%# Bind("ExternalAgency") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakResponsibleAgencies"
  DataObjectTypeName = "SIS.PAK.pakResponsibleAgencies"
  InsertMethod="pakResponsibleAgenciesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakResponsibleAgencies"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
