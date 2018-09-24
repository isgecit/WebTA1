<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogChargeCodes.aspx.vb" Inherits="AF_elogChargeCodes" title="Add: ELOG_ChargeCodes" %>
<asp:Content ID="CPHelogChargeCodes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogChargeCodes" runat="server" Text="&nbsp;Add: ELOG_ChargeCodes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogChargeCodes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogChargeCodes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogChargeCodes"
    runat = "server" />
<asp:FormView ID="FVelogChargeCodes"
  runat = "server"
  DataKeyNames = "ChargeCategoryID,ChargeCodeID"
  DataSourceID = "ODSelogChargeCodes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogChargeCodes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ChargeCategoryID" ForeColor="#CC6633" runat="server" Text="Charge Category ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_elogChargeCategories
            ID="F_ChargeCategoryID"
            SelectedValue='<%# Bind("ChargeCategoryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogChargeCodes"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ChargeCodeID" ForeColor="#CC6633" runat="server" Text="Charge Code ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ChargeCodeID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
            ValidationGroup="elogChargeCodes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogChargeCodes"
  DataObjectTypeName = "SIS.ELOG.elogChargeCodes"
  InsertMethod="elogChargeCodesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogChargeCodes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
