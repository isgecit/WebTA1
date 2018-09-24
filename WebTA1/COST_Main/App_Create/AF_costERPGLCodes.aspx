<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costERPGLCodes.aspx.vb" Inherits="AF_costERPGLCodes" title="Add: ERP GL Codes" %>
<asp:Content ID="CPHcostERPGLCodes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostERPGLCodes" runat="server" Text="&nbsp;Add: ERP GL Codes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostERPGLCodes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostERPGLCodes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costERPGLCodes"
    runat = "server" />
<asp:FormView ID="FVcostERPGLCodes"
  runat = "server"
  DataKeyNames = "GLCode"
  DataSourceID = "ODScostERPGLCodes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostERPGLCodes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLCode" ForeColor="#CC6633" runat="server" Text="GL Code :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLCode"
            Text='<%# Bind("GLCode") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="costERPGLCodes"
            onblur= "script_costERPGLCodes.validate_GLCode(this);"
            ToolTip="Enter value for GL Code."
            MaxLength="7"
            Width="64px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGLCode"
            runat = "server"
            ControlToValidate = "F_GLCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costERPGLCodes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GLDescription" runat="server" Text="GL Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLDescription"
            Text='<%# Bind("GLDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costERPGLCodes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GL Description."
            MaxLength="50"
            Width="408px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostERPGLCodes"
  DataObjectTypeName = "SIS.COST.costERPGLCodes"
  InsertMethod="costERPGLCodesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costERPGLCodes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
