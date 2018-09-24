<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costProjectTypes.aspx.vb" Inherits="AF_costProjectTypes" title="Add: Project Types" %>
<asp:Content ID="CPHcostProjectTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectTypes" runat="server" Text="&nbsp;Add: Project Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costProjectTypes"
    runat = "server" />
<asp:FormView ID="FVcostProjectTypes"
  runat = "server"
  DataKeyNames = "ProjectTypeID"
  DataSourceID = "ODScostProjectTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostProjectTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectTypeID" ForeColor="#CC6633" runat="server" Text="Project Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectTypeID"
            Text='<%# Bind("ProjectTypeID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="costProjectTypes"
            onblur= "script_costProjectTypes.validate_ProjectTypeID(this);"
            ToolTip="Enter value for Project Type ID."
            MaxLength="10"
            Width="70px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectTypeID"
            runat = "server"
            ControlToValidate = "F_ProjectTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectTypeDescription" runat="server" Text="Project Type Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectTypeDescription"
            Text='<%# Bind("ProjectTypeDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costProjectTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Type Description."
            MaxLength="50"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostProjectTypes"
  DataObjectTypeName = "SIS.COST.costProjectTypes"
  InsertMethod="costProjectTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
