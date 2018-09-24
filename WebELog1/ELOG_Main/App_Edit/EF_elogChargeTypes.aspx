<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogChargeTypes.aspx.vb" Inherits="EF_elogChargeTypes" title="Edit: Charge Types" %>
<asp:Content ID="CPHelogChargeTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogChargeTypes" runat="server" Text="&nbsp;Edit: Charge Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogChargeTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogChargeTypes"
    runat = "server" />
<asp:FormView ID="FVelogChargeTypes"
  runat = "server"
  DataKeyNames = "ChargeTypeID"
  DataSourceID = "ODSelogChargeTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ChargeTypeID" runat="server" ForeColor="#CC6633" Text="Charge Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ChargeTypeID"
            Text='<%# Bind("ChargeTypeID") %>'
            ToolTip="Value of Charge Type."
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
            ValidationGroup="elogChargeTypes"
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
            ValidationGroup = "elogChargeTypes"
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
  ID = "ODSelogChargeTypes"
  DataObjectTypeName = "SIS.ELOG.elogChargeTypes"
  SelectMethod = "elogChargeTypesGetByID"
  UpdateMethod="elogChargeTypesUpdate"
  DeleteMethod="elogChargeTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogChargeTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ChargeTypeID" Name="ChargeTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
