<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogChargeTypes.aspx.vb" Inherits="AF_elogChargeTypes" title="Add: Charge Types" %>
<asp:Content ID="CPHelogChargeTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogChargeTypes" runat="server" Text="&nbsp;Add: Charge Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogChargeTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogChargeTypes"
    runat = "server" />
<asp:FormView ID="FVelogChargeTypes"
  runat = "server"
  DataKeyNames = "ChargeTypeID"
  DataSourceID = "ODSelogChargeTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogChargeTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ChargeTypeID" ForeColor="#CC6633" runat="server" Text="Charge Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ChargeTypeID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogChargeTypes"
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
            ValidationGroup = "elogChargeTypes"
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
  ID = "ODSelogChargeTypes"
  DataObjectTypeName = "SIS.ELOG.elogChargeTypes"
  InsertMethod="elogChargeTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogChargeTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
