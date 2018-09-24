<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costERPGLCodes.aspx.vb" Inherits="EF_costERPGLCodes" title="Edit: ERP GL Codes" %>
<asp:Content ID="CPHcostERPGLCodes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostERPGLCodes" runat="server" Text="&nbsp;Edit: ERP GL Codes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostERPGLCodes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostERPGLCodes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costERPGLCodes"
    runat = "server" />
<asp:FormView ID="FVcostERPGLCodes"
  runat = "server"
  DataKeyNames = "GLCode"
  DataSourceID = "ODScostERPGLCodes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLCode" runat="server" ForeColor="#CC6633" Text="GL Code :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLCode"
            Text='<%# Bind("GLCode") %>'
            ToolTip="Value of GL Code."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="64px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GLDescription" runat="server" Text="GL Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLDescription"
            Text='<%# Bind("GLDescription") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costERPGLCodes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GL Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGLDescription"
            runat = "server"
            ControlToValidate = "F_GLDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costERPGLCodes"
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
  ID = "ODScostERPGLCodes"
  DataObjectTypeName = "SIS.COST.costERPGLCodes"
  SelectMethod = "costERPGLCodesGetByID"
  UpdateMethod="costERPGLCodesUpdate"
  DeleteMethod="costERPGLCodesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costERPGLCodes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GLCode" Name="GLCode" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
