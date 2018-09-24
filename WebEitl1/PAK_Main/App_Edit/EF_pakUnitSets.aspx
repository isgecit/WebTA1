<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakUnitSets.aspx.vb" Inherits="EF_pakUnitSets" title="Edit: Unit Sets" %>
<asp:Content ID="CPHpakUnitSets" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakUnitSets" runat="server" Text="&nbsp;Edit: Unit Sets"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakUnitSets" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakUnitSets"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakUnitSets"
    runat = "server" />
<asp:FormView ID="FVpakUnitSets"
  runat = "server"
  DataKeyNames = "UnitSetID"
  DataSourceID = "ODSpakUnitSets"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UnitSetID" runat="server" ForeColor="#CC6633" Text="Unit Set ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UnitSetID"
            Text='<%# Bind("UnitSetID") %>'
            ToolTip="Value of Unit Set ID."
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
            ValidationGroup="pakUnitSets"
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
            ValidationGroup = "pakUnitSets"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakUnitSets"
  DataObjectTypeName = "SIS.PAK.pakUnitSets"
  SelectMethod = "pakUnitSetsGetByID"
  UpdateMethod="pakUnitSetsUpdate"
  DeleteMethod="pakUnitSetsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakUnitSets"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UnitSetID" Name="UnitSetID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
