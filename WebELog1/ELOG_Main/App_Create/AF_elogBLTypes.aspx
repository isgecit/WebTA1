<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogBLTypes.aspx.vb" Inherits="AF_elogBLTypes" title="Add: BL Types" %>
<asp:Content ID="CPHelogBLTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogBLTypes" runat="server" Text="&nbsp;Add: BL Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogBLTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogBLTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogBLTypes"
    runat = "server" />
<asp:FormView ID="FVelogBLTypes"
  runat = "server"
  DataKeyNames = "BLTypeID"
  DataSourceID = "ODSelogBLTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogBLTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BLTypeID" ForeColor="#CC6633" runat="server" Text="BL Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_BLTypeID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogBLTypes"
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
            ValidationGroup = "elogBLTypes"
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
  ID = "ODSelogBLTypes"
  DataObjectTypeName = "SIS.ELOG.elogBLTypes"
  InsertMethod="elogBLTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogBLTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
