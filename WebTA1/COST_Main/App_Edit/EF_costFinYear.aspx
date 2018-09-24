<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costFinYear.aspx.vb" Inherits="EF_costFinYear" title="Edit: Financial Year" %>
<asp:Content ID="CPHcostFinYear" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostFinYear" runat="server" Text="&nbsp;Edit: Financial Year"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostFinYear" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostFinYear"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costFinYear"
    runat = "server" />
<asp:FormView ID="FVcostFinYear"
  runat = "server"
  DataKeyNames = "FinYear"
  DataSourceID = "ODScostFinYear"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FinYear"
            Text='<%# Bind("FinYear") %>'
            ToolTip="Value of Fin Year."
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
          <asp:Label ID="L_Descpription" runat="server" Text="Descpription :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Descpription"
            Text='<%# Bind("Descpription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costFinYear"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Descpription."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescpription"
            runat = "server"
            ControlToValidate = "F_Descpription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costFinYear"
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
  ID = "ODScostFinYear"
  DataObjectTypeName = "SIS.COST.costFinYear"
  SelectMethod = "costFinYearGetByID"
  UpdateMethod="costFinYearUpdate"
  DeleteMethod="costFinYearDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costFinYear"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
