<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogStuffingTypes.aspx.vb" Inherits="AF_elogStuffingTypes" title="Add: Stuffing Types" %>
<asp:Content ID="CPHelogStuffingTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogStuffingTypes" runat="server" Text="&nbsp;Add: Stuffing Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogStuffingTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogStuffingTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogStuffingTypes"
    runat = "server" />
<asp:FormView ID="FVelogStuffingTypes"
  runat = "server"
  DataKeyNames = "StuffingTypeID"
  DataSourceID = "ODSelogStuffingTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogStuffingTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StuffingTypeID" ForeColor="#CC6633" runat="server" Text="Stuffing Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_StuffingTypeID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogStuffingTypes"
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
            ValidationGroup = "elogStuffingTypes"
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
  ID = "ODSelogStuffingTypes"
  DataObjectTypeName = "SIS.ELOG.elogStuffingTypes"
  InsertMethod="elogStuffingTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogStuffingTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
