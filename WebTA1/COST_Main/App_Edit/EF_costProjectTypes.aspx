<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costProjectTypes.aspx.vb" Inherits="EF_costProjectTypes" title="Edit: Project Types" %>
<asp:Content ID="CPHcostProjectTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectTypes" runat="server" Text="&nbsp;Edit: Project Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costProjectTypes"
    runat = "server" />
<asp:FormView ID="FVcostProjectTypes"
  runat = "server"
  DataKeyNames = "ProjectTypeID"
  DataSourceID = "ODScostProjectTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectTypeID" runat="server" ForeColor="#CC6633" Text="Project Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectTypeID"
            Text='<%# Bind("ProjectTypeID") %>'
            ToolTip="Value of Project Type ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectTypeDescription" runat="server" Text="Project Type Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectTypeDescription"
            Text='<%# Bind("ProjectTypeDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costProjectTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Type Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectTypeDescription"
            runat = "server"
            ControlToValidate = "F_ProjectTypeDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectTypes"
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
  ID = "ODScostProjectTypes"
  DataObjectTypeName = "SIS.COST.costProjectTypes"
  SelectMethod = "costProjectTypesGetByID"
  UpdateMethod="costProjectTypesUpdate"
  DeleteMethod="costProjectTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectTypeID" Name="ProjectTypeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
