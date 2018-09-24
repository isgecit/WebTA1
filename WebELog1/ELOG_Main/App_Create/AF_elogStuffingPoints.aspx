<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogStuffingPoints.aspx.vb" Inherits="AF_elogStuffingPoints" title="Add: Stuffing Points" %>
<asp:Content ID="CPHelogStuffingPoints" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogStuffingPoints" runat="server" Text="&nbsp;Add: Stuffing Points"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogStuffingPoints" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogStuffingPoints"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogStuffingPoints"
    runat = "server" />
<asp:FormView ID="FVelogStuffingPoints"
  runat = "server"
  DataKeyNames = "StuffingPointID"
  DataSourceID = "ODSelogStuffingPoints"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogStuffingPoints" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StuffingPointID" ForeColor="#CC6633" runat="server" Text="Stuffing Point :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_StuffingPointID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogStuffingPoints"
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
            ValidationGroup = "elogStuffingPoints"
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
  ID = "ODSelogStuffingPoints"
  DataObjectTypeName = "SIS.ELOG.elogStuffingPoints"
  InsertMethod="elogStuffingPointsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogStuffingPoints"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
