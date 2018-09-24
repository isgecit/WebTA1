<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taPrjCalcMethod.aspx.vb" Inherits="EF_taPrjCalcMethod" title="Edit: Project wise calculation method" %>
<asp:Content ID="CPHtaPrjCalcMethod" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaPrjCalcMethod" runat="server" Text="&nbsp;Edit: Project wise calculation method"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaPrjCalcMethod" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaPrjCalcMethod"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "taPrjCalcMethod"
    runat = "server" />
<asp:FormView ID="FVtaPrjCalcMethod"
  runat = "server"
  DataKeyNames = "ProjectCalcID"
  DataSourceID = "ODStaPrjCalcMethod"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectCalcID" runat="server" ForeColor="#CC6633" Text="Calculation Type  :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectCalcID"
            Text='<%# Bind("ProjectCalcID") %>'
            ToolTip="Value of Calculation Type ."
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
          <asp:Label ID="L_Description" runat="server" Text="Calculation Method :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taPrjCalcMethod"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Calculation Method."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaPrjCalcMethod"
  DataObjectTypeName = "SIS.TA.taPrjCalcMethod"
  SelectMethod = "taPrjCalcMethodGetByID"
  UpdateMethod="taPrjCalcMethodUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taPrjCalcMethod"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectCalcID" Name="ProjectCalcID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
