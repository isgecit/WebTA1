<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taApprovalWFTypes.aspx.vb" Inherits="AF_taApprovalWFTypes" title="Add: Approval WF Types" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Add: Approval WF Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaApprovalWFTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taApprovalWFTypes"
    runat = "server" />
<asp:FormView ID="FVtaApprovalWFTypes"
  runat = "server"
  DataKeyNames = "WFTypeID"
  DataSourceID = "ODStaApprovalWFTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaApprovalWFTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WFTypeID" ForeColor="#CC6633" runat="server" Text="WF Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WFTypeID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WFTypeDescription" runat="server" Text="WF Type Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WFTypeDescription"
            Text='<%# Bind("WFTypeDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taApprovalWFTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for WF Type Description."
            MaxLength="50"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaApprovalWFTypes"
  DataObjectTypeName = "SIS.TA.taApprovalWFTypes"
  InsertMethod="taApprovalWFTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taApprovalWFTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
