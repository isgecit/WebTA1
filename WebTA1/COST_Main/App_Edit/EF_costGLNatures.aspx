<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costGLNatures.aspx.vb" Inherits="EF_costGLNatures" title="Edit: GL Natures" %>
<asp:Content ID="CPHcostGLNatures" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostGLNatures" runat="server" Text="&nbsp;Edit: GL Natures"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLNatures" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostGLNatures"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costGLNatures"
    runat = "server" />
<asp:FormView ID="FVcostGLNatures"
  runat = "server"
  DataKeyNames = "GLNatureID"
  DataSourceID = "ODScostGLNatures"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLNatureID" runat="server" ForeColor="#CC6633" Text="GL Nature ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLNatureID"
            Text='<%# Bind("GLNatureID") %>'
            ToolTip="Value of GL Nature ID."
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
          <asp:Label ID="L_GLNatureDescription" runat="server" Text="GL Nature Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLNatureDescription"
            Text='<%# Bind("GLNatureDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costGLNatures"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GL Nature Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostGLNatures"
  DataObjectTypeName = "SIS.COST.costGLNatures"
  SelectMethod = "costGLNaturesGetByID"
  UpdateMethod="costGLNaturesUpdate"
  DeleteMethod="costGLNaturesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costGLNatures"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GLNatureID" Name="GLNatureID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
