<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costGLNatures.aspx.vb" Inherits="AF_costGLNatures" title="Add: GL Natures" %>
<asp:Content ID="CPHcostGLNatures" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostGLNatures" runat="server" Text="&nbsp;Add: GL Natures"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLNatures" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostGLNatures"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costGLNatures"
    runat = "server" />
<asp:FormView ID="FVcostGLNatures"
  runat = "server"
  DataKeyNames = "GLNatureID"
  DataSourceID = "ODScostGLNatures"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostGLNatures" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLNatureID" ForeColor="#CC6633" runat="server" Text="GL Nature ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLNatureID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GLNatureDescription" runat="server" Text="GL Nature Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLNatureDescription"
            Text='<%# Bind("GLNatureDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costGLNatures"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GL Nature Description."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGLNatureDescription"
            runat = "server"
            ControlToValidate = "F_GLNatureDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLNatures"
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
  ID = "ODScostGLNatures"
  DataObjectTypeName = "SIS.COST.costGLNatures"
  InsertMethod="costGLNaturesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costGLNatures"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
