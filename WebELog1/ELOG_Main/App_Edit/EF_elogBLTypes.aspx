<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogBLTypes.aspx.vb" Inherits="EF_elogBLTypes" title="Edit: BL Types" %>
<asp:Content ID="CPHelogBLTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogBLTypes" runat="server" Text="&nbsp;Edit: BL Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogBLTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogBLTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogBLTypes"
    runat = "server" />
<asp:FormView ID="FVelogBLTypes"
  runat = "server"
  DataKeyNames = "BLTypeID"
  DataSourceID = "ODSelogBLTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BLTypeID" runat="server" ForeColor="#CC6633" Text="BL Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_BLTypeID"
            Text='<%# Bind("BLTypeID") %>'
            ToolTip="Value of BL Type."
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
            ValidationGroup="elogBLTypes"
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
            ValidationGroup = "elogBLTypes"
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
  ID = "ODSelogBLTypes"
  DataObjectTypeName = "SIS.ELOG.elogBLTypes"
  SelectMethod = "elogBLTypesGetByID"
  UpdateMethod="elogBLTypesUpdate"
  DeleteMethod="elogBLTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogBLTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BLTypeID" Name="BLTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
