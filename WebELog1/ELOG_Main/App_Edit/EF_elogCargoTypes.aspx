<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogCargoTypes.aspx.vb" Inherits="EF_elogCargoTypes" title="Edit: Cargo Types" %>
<asp:Content ID="CPHelogCargoTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogCargoTypes" runat="server" Text="&nbsp;Edit: Cargo Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogCargoTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogCargoTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogCargoTypes"
    runat = "server" />
<asp:FormView ID="FVelogCargoTypes"
  runat = "server"
  DataKeyNames = "CargoTypeID"
  DataSourceID = "ODSelogCargoTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CargoTypeID" runat="server" ForeColor="#CC6633" Text="Cargo Type :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CargoTypeID"
            Text='<%# Bind("CargoTypeID") %>'
            ToolTip="Value of Cargo Type."
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
            ValidationGroup="elogCargoTypes"
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
            ValidationGroup = "elogCargoTypes"
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
  ID = "ODSelogCargoTypes"
  DataObjectTypeName = "SIS.ELOG.elogCargoTypes"
  SelectMethod = "elogCargoTypesGetByID"
  UpdateMethod="elogCargoTypesUpdate"
  DeleteMethod="elogCargoTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogCargoTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CargoTypeID" Name="CargoTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
