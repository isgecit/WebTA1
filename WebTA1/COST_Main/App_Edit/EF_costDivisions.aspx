<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costDivisions.aspx.vb" Inherits="EF_costDivisions" title="Edit: Divisions" %>
<asp:Content ID="CPHcostDivisions" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostDivisions" runat="server" Text="&nbsp;Edit: Divisions"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostDivisions" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostDivisions"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costDivisions"
    runat = "server" />
<asp:FormView ID="FVcostDivisions"
  runat = "server"
  DataKeyNames = "DivisionID"
  DataSourceID = "ODScostDivisions"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DivisionID" runat="server" ForeColor="#CC6633" Text="Division ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DivisionID"
            Text='<%# Bind("DivisionID") %>'
            ToolTip="Value of Division ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DivisionName" runat="server" Text="Division Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DivisionName"
            Text='<%# Bind("DivisionName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costDivisions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Division Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDivisionName"
            runat = "server"
            ControlToValidate = "F_DivisionName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costDivisions"
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
  ID = "ODScostDivisions"
  DataObjectTypeName = "SIS.COST.costDivisions"
  SelectMethod = "costDivisionsGetByID"
  UpdateMethod="costDivisionsUpdate"
  DeleteMethod="costDivisionsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costDivisions"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DivisionID" Name="DivisionID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
