<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costQuarters.aspx.vb" Inherits="EF_costQuarters" title="Edit: Finance Quarters" %>
<asp:Content ID="CPHcostQuarters" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostQuarters" runat="server" Text="&nbsp;Edit: Finance Quarters"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostQuarters" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostQuarters"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costQuarters"
    runat = "server" />
<asp:FormView ID="FVcostQuarters"
  runat = "server"
  DataKeyNames = "Quarter"
  DataSourceID = "ODScostQuarters"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Quarter"
            Text='<%# Bind("Quarter") %>'
            ToolTip="Value of Quarter."
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
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costQuarters"
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
            ValidationGroup = "costQuarters"
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
  ID = "ODScostQuarters"
  DataObjectTypeName = "SIS.COST.costQuarters"
  SelectMethod = "costQuartersGetByID"
  UpdateMethod="costQuartersUpdate"
  DeleteMethod="costQuartersDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costQuarters"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
