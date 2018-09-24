<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taCalcMethod.aspx.vb" Inherits="EF_taCalcMethod" title="Edit: Calculation Method" %>
<asp:Content ID="CPHtaCalcMethod" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCalcMethod" runat="server" Text="&nbsp;Edit: Calculation Method"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCalcMethod" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCalcMethod"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taCalcMethod"
    runat = "server" />
<asp:FormView ID="FVtaCalcMethod"
  runat = "server"
  DataKeyNames = "CalculationTypeID"
  DataSourceID = "ODStaCalcMethod"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CalculationTypeID" runat="server" ForeColor="#CC6633" Text="Calculation Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CalculationTypeID"
            Text='<%# Bind("CalculationTypeID") %>'
            ToolTip="Value of Calculation Type ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CalculationDescription" runat="server" Text="Calculation Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CalculationDescription"
            Text='<%# Bind("CalculationDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCalcMethod"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Calculation Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCalculationDescription"
            runat = "server"
            ControlToValidate = "F_CalculationDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCalcMethod"
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
  ID = "ODStaCalcMethod"
  DataObjectTypeName = "SIS.TA.taCalcMethod"
  SelectMethod = "taCalcMethodGetByID"
  UpdateMethod="taCalcMethodUpdate"
  DeleteMethod="taCalcMethodDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCalcMethod"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CalculationTypeID" Name="CalculationTypeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
