<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costDivisions.aspx.vb" Inherits="AF_costDivisions" title="Add: Divisions" %>
<asp:Content ID="CPHcostDivisions" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostDivisions" runat="server" Text="&nbsp;Add: Divisions"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostDivisions" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostDivisions"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costDivisions"
    runat = "server" />
<asp:FormView ID="FVcostDivisions"
  runat = "server"
  DataKeyNames = "DivisionID"
  DataSourceID = "ODScostDivisions"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostDivisions" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DivisionID" ForeColor="#CC6633" runat="server" Text="Division ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DivisionID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DivisionName" runat="server" Text="Division Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DivisionName"
            Text='<%# Bind("DivisionName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costDivisions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Division Name."
            MaxLength="50"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostDivisions"
  DataObjectTypeName = "SIS.COST.costDivisions"
  InsertMethod="costDivisionsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costDivisions"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
