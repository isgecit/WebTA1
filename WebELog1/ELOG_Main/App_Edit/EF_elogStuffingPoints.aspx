<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogStuffingPoints.aspx.vb" Inherits="EF_elogStuffingPoints" title="Edit: Stuffing Points" %>
<asp:Content ID="CPHelogStuffingPoints" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogStuffingPoints" runat="server" Text="&nbsp;Edit: Stuffing Points"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogStuffingPoints" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogStuffingPoints"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogStuffingPoints"
    runat = "server" />
<asp:FormView ID="FVelogStuffingPoints"
  runat = "server"
  DataKeyNames = "StuffingPointID"
  DataSourceID = "ODSelogStuffingPoints"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StuffingPointID" runat="server" ForeColor="#CC6633" Text="Stuffing Point :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_StuffingPointID"
            Text='<%# Bind("StuffingPointID") %>'
            ToolTip="Value of Stuffing Point."
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
            ValidationGroup="elogStuffingPoints"
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
            ValidationGroup = "elogStuffingPoints"
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
  ID = "ODSelogStuffingPoints"
  DataObjectTypeName = "SIS.ELOG.elogStuffingPoints"
  SelectMethod = "elogStuffingPointsGetByID"
  UpdateMethod="elogStuffingPointsUpdate"
  DeleteMethod="elogStuffingPointsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogStuffingPoints"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="StuffingPointID" Name="StuffingPointID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
