<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costWorkOrderTypes.aspx.vb" Inherits="AF_costWorkOrderTypes" title="Add: Work Order Types" %>
<asp:Content ID="CPHcostWorkOrderTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostWorkOrderTypes" runat="server" Text="&nbsp;Add: Work Order Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostWorkOrderTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostWorkOrderTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costWorkOrderTypes"
    runat = "server" />
<asp:FormView ID="FVcostWorkOrderTypes"
  runat = "server"
  DataKeyNames = "WorkOrderTypeID"
  DataSourceID = "ODScostWorkOrderTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostWorkOrderTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WorkOrderTypeID" ForeColor="#CC6633" runat="server" Text="Work Order Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WorkOrderTypeID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WorkOrderTypeDescription" runat="server" Text="Work Order Type Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WorkOrderTypeDescription"
            Text='<%# Bind("WorkOrderTypeDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costWorkOrderTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Work Order Type Description."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVWorkOrderTypeDescription"
            runat = "server"
            ControlToValidate = "F_WorkOrderTypeDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costWorkOrderTypes"
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
  ID = "ODScostWorkOrderTypes"
  DataObjectTypeName = "SIS.COST.costWorkOrderTypes"
  InsertMethod="costWorkOrderTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costWorkOrderTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
