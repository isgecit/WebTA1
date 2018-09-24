<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogStuffingTypes.aspx.vb" Inherits="EF_elogStuffingTypes" title="Edit: Stuffing Types" %>
<asp:Content ID="CPHelogStuffingTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogStuffingTypes" runat="server" Text="&nbsp;Edit: Stuffing Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogStuffingTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogStuffingTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogStuffingTypes"
    runat = "server" />
<asp:FormView ID="FVelogStuffingTypes"
  runat = "server"
  DataKeyNames = "StuffingTypeID"
  DataSourceID = "ODSelogStuffingTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StuffingTypeID" runat="server" ForeColor="#CC6633" Text="Stuffing Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_StuffingTypeID"
            Text='<%# Bind("StuffingTypeID") %>'
            ToolTip="Value of Stuffing Type."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogStuffingTypes"
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
            ValidationGroup = "elogStuffingTypes"
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
  ID = "ODSelogStuffingTypes"
  DataObjectTypeName = "SIS.ELOG.elogStuffingTypes"
  SelectMethod = "elogStuffingTypesGetByID"
  UpdateMethod="elogStuffingTypesUpdate"
  DeleteMethod="elogStuffingTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogStuffingTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="StuffingTypeID" Name="StuffingTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
