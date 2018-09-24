<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakResponsibleAgencies.aspx.vb" Inherits="EF_pakResponsibleAgencies" title="Edit: Responsible Agencies" %>
<asp:Content ID="CPHpakResponsibleAgencies" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakResponsibleAgencies" runat="server" Text="&nbsp;Edit: Responsible Agencies"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakResponsibleAgencies" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakResponsibleAgencies"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakResponsibleAgencies"
    runat = "server" />
<asp:FormView ID="FVpakResponsibleAgencies"
  runat = "server"
  DataKeyNames = "ResponsibleAgencyID"
  DataSourceID = "ODSpakResponsibleAgencies"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ResponsibleAgencyID" runat="server" ForeColor="#CC6633" Text="Responsible Agency ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ResponsibleAgencyID"
            Text='<%# Bind("ResponsibleAgencyID") %>'
            ToolTip="Value of Responsible Agency ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
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
            ValidationGroup="pakResponsibleAgencies"
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
            ValidationGroup = "pakResponsibleAgencies"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakResponsibleAgencies"
  DataObjectTypeName = "SIS.PAK.pakResponsibleAgencies"
  SelectMethod = "pakResponsibleAgenciesGetByID"
  UpdateMethod="pakResponsibleAgenciesUpdate"
  DeleteMethod="pakResponsibleAgenciesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakResponsibleAgencies"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ResponsibleAgencyID" Name="ResponsibleAgencyID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
