<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taPrjCalcMethod.aspx.vb" Inherits="AF_taPrjCalcMethod" title="Add: Project wise calculation method" %>
<asp:Content ID="CPHtaPrjCalcMethod" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaPrjCalcMethod" runat="server" Text="&nbsp;Add: Project wise calculation method"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaPrjCalcMethod" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaPrjCalcMethod"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taPrjCalcMethod"
    runat = "server" />
<asp:FormView ID="FVtaPrjCalcMethod"
  runat = "server"
  DataKeyNames = "ProjectCalcID"
  DataSourceID = "ODStaPrjCalcMethod"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaPrjCalcMethod" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectCalcID" ForeColor="#CC6633" runat="server" Text="Calculation Type  :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectCalcID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Calculation Method :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taPrjCalcMethod"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Calculation Method."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taPrjCalcMethod"
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
  ID = "ODStaPrjCalcMethod"
  DataObjectTypeName = "SIS.TA.taPrjCalcMethod"
  InsertMethod="taPrjCalcMethodInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taPrjCalcMethod"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
