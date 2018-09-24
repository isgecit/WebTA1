<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkMobileBillPlans.aspx.vb" Inherits="EF_nprkMobileBillPlans" title="Edit: Bill Plan" %>
<asp:Content ID="CPHnprkMobileBillPlans" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkMobileBillPlans" runat="server" Text="&nbsp;Edit: Bill Plan"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkMobileBillPlans" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkMobileBillPlans"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkMobileBillPlans"
    runat = "server" />
<asp:FormView ID="FVnprkMobileBillPlans"
  runat = "server"
  DataKeyNames = "MobileBillPlanID"
  DataSourceID = "ODSnprkMobileBillPlans"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_MobileBillPlanID" runat="server" ForeColor="#CC6633" Text="Mobile Bill Plan ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_MobileBillPlanID"
            Text='<%# Bind("MobileBillPlanID") %>'
            ToolTip="Value of Mobile Bill Plan ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkMobileBillPlans"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkMobileBillPlans"
  DataObjectTypeName = "SIS.NPRK.nprkMobileBillPlans"
  SelectMethod = "nprkMobileBillPlansGetByID"
  UpdateMethod="nprkMobileBillPlansUpdate"
  DeleteMethod="nprkMobileBillPlansDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkMobileBillPlans"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MobileBillPlanID" Name="MobileBillPlanID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
