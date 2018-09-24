<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taApprovalWFTypes.aspx.vb" Inherits="EF_taApprovalWFTypes" title="Edit: Approval WF Types" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Edit: Approval WF Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaApprovalWFTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taApprovalWFTypes"
    runat = "server" />
<asp:FormView ID="FVtaApprovalWFTypes"
  runat = "server"
  DataKeyNames = "WFTypeID"
  DataSourceID = "ODStaApprovalWFTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WFTypeID" runat="server" ForeColor="#CC6633" Text="WF Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WFTypeID"
            Text='<%# Bind("WFTypeID") %>'
            ToolTip="Value of WF Type ID."
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
          <asp:Label ID="L_WFTypeDescription" runat="server" Text="WF Type Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WFTypeDescription"
            Text='<%# Bind("WFTypeDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taApprovalWFTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for WF Type Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVWFTypeDescription"
            runat = "server"
            ControlToValidate = "F_WFTypeDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taApprovalWFTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequiredDivisionHeadApproval" runat="server" Text="Required Division Head Approval :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_RequiredDivisionHeadApproval"
            Checked='<%# Bind("RequiredDivisionHeadApproval") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequiredMDApproval" runat="server" Text="Required MD Approval :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_RequiredMDApproval"
            Checked='<%# Bind("RequiredMDApproval") %>'
            CssClass = "mychk"
            runat="server" />
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
  ID = "ODStaApprovalWFTypes"
  DataObjectTypeName = "SIS.TA.taApprovalWFTypes"
  SelectMethod = "taApprovalWFTypesGetByID"
  UpdateMethod="taApprovalWFTypesUpdate"
  DeleteMethod="taApprovalWFTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taApprovalWFTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="WFTypeID" Name="WFTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
