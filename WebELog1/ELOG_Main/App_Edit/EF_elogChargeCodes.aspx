<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogChargeCodes.aspx.vb" Inherits="EF_elogChargeCodes" title="Edit: ELOG_ChargeCodes" %>
<asp:Content ID="CPHelogChargeCodes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogChargeCodes" runat="server" Text="&nbsp;Edit: ELOG_ChargeCodes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeCodes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogChargeCodes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogChargeCodes"
    runat = "server" />
<asp:FormView ID="FVelogChargeCodes"
  runat = "server"
  DataKeyNames = "ChargeCategoryID,ChargeCodeID"
  DataSourceID = "ODSelogChargeCodes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ChargeCategoryID" runat="server" ForeColor="#CC6633" Text="Charge Category ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ChargeCategoryID"
            Width="88px"
            Text='<%# Bind("ChargeCategoryID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Charge Category ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ChargeCategoryID_Display"
            Text='<%# Eval("ELOG_ChargeCategories1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ChargeCodeID" runat="server" ForeColor="#CC6633" Text="Charge Code ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ChargeCodeID"
            Text='<%# Bind("ChargeCodeID") %>'
            ToolTip="Value of Charge Code ID."
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
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogChargeCodes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogChargeCodes"
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
  ID = "ODSelogChargeCodes"
  DataObjectTypeName = "SIS.ELOG.elogChargeCodes"
  SelectMethod = "elogChargeCodesGetByID"
  UpdateMethod="elogChargeCodesUpdate"
  DeleteMethod="elogChargeCodesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogChargeCodes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ChargeCategoryID" Name="ChargeCategoryID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ChargeCodeID" Name="ChargeCodeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
