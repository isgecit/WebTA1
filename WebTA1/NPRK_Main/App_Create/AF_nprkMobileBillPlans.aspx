<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkMobileBillPlans.aspx.vb" Inherits="AF_nprkMobileBillPlans" title="Add: Bill Plan" %>
<asp:Content ID="CPHnprkMobileBillPlans" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkMobileBillPlans" runat="server" Text="&nbsp;Add: Bill Plan"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkMobileBillPlans" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkMobileBillPlans"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "nprkMobileBillPlans"
    runat = "server" />
<asp:FormView ID="FVnprkMobileBillPlans"
  runat = "server"
  DataKeyNames = "MobileBillPlanID"
  DataSourceID = "ODSnprkMobileBillPlans"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkMobileBillPlans" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_MobileBillPlanID" ForeColor="#CC6633" runat="server" Text="Mobile Bill Plan ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_MobileBillPlanID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkMobileBillPlans"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkMobileBillPlans"
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
  ID = "ODSnprkMobileBillPlans"
  DataObjectTypeName = "SIS.NPRK.nprkMobileBillPlans"
  InsertMethod="nprkMobileBillPlansInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkMobileBillPlans"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
