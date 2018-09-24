<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakUnitSets.aspx.vb" Inherits="AF_pakUnitSets" title="Add: Unit Sets" %>
<asp:Content ID="CPHpakUnitSets" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakUnitSets" runat="server" Text="&nbsp;Add: Unit Sets"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakUnitSets" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakUnitSets"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakUnitSets"
    runat = "server" />
<asp:FormView ID="FVpakUnitSets"
  runat = "server"
  DataKeyNames = "UnitSetID"
  DataSourceID = "ODSpakUnitSets"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakUnitSets" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UnitSetID" ForeColor="#CC6633" runat="server" Text="Unit Set ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UnitSetID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakUnitSets"
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
            ValidationGroup = "pakUnitSets"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BaseUnitID" runat="server" Text="Base Unit ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_pakUnits
            ID="F_BaseUnitID"
            SelectedValue='<%# Bind("BaseUnitID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakUnitSets"
  DataObjectTypeName = "SIS.PAK.pakUnitSets"
  InsertMethod="pakUnitSetsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakUnitSets"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
