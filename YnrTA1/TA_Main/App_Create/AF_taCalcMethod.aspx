<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taCalcMethod.aspx.vb" Inherits="AF_taCalcMethod" title="Add: Calculation Method" %>
<asp:Content ID="CPHtaCalcMethod" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCalcMethod" runat="server" Text="&nbsp;Add: Calculation Method"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCalcMethod" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCalcMethod"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taCalcMethod"
    runat = "server" />
<asp:FormView ID="FVtaCalcMethod"
  runat = "server"
  DataKeyNames = "CalculationTypeID"
  DataSourceID = "ODStaCalcMethod"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaCalcMethod" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CalculationTypeID" ForeColor="#CC6633" runat="server" Text="Calculation Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CalculationTypeID"
            Text='<%# Bind("CalculationTypeID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="taCalcMethod"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Calculation Type ID."
            MaxLength="10"
            Width="70px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCalculationTypeID"
            runat = "server"
            ControlToValidate = "F_CalculationTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCalcMethod"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CalculationDescription" runat="server" Text="Calculation Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CalculationDescription"
            Text='<%# Bind("CalculationDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCalcMethod"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Calculation Description."
            MaxLength="50"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCalcMethod"
  DataObjectTypeName = "SIS.TA.taCalcMethod"
  InsertMethod="taCalcMethodInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCalcMethod"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
