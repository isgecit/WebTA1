<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costWorkOrderTypes.aspx.vb" Inherits="EF_costWorkOrderTypes" title="Edit: Work Order Types" %>
<asp:Content ID="CPHcostWorkOrderTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostWorkOrderTypes" runat="server" Text="&nbsp;Edit: Work Order Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostWorkOrderTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostWorkOrderTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costWorkOrderTypes"
    runat = "server" />
<asp:FormView ID="FVcostWorkOrderTypes"
  runat = "server"
  DataKeyNames = "WorkOrderTypeID"
  DataSourceID = "ODScostWorkOrderTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WorkOrderTypeID" runat="server" ForeColor="#CC6633" Text="Work Order Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WorkOrderTypeID"
            Text='<%# Bind("WorkOrderTypeID") %>'
            ToolTip="Value of Work Order Type ID."
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
          <asp:Label ID="L_WorkOrderTypeDescription" runat="server" Text="Work Order Type Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WorkOrderTypeDescription"
            Text='<%# Bind("WorkOrderTypeDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costWorkOrderTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Work Order Type Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostWorkOrderTypes"
  DataObjectTypeName = "SIS.COST.costWorkOrderTypes"
  SelectMethod = "costWorkOrderTypesGetByID"
  UpdateMethod="costWorkOrderTypesUpdate"
  DeleteMethod="costWorkOrderTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costWorkOrderTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="WorkOrderTypeID" Name="WorkOrderTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
