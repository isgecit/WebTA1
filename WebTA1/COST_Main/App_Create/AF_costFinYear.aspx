<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costFinYear.aspx.vb" Inherits="AF_costFinYear" title="Add: Financial Year" %>
<asp:Content ID="CPHcostFinYear" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostFinYear" runat="server" Text="&nbsp;Add: Financial Year"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostFinYear" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostFinYear"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "costFinYear"
    runat = "server" />
<asp:FormView ID="FVcostFinYear"
  runat = "server"
  DataKeyNames = "FinYear"
  DataSourceID = "ODScostFinYear"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostFinYear" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FinYear"
            Text='<%# Bind("FinYear") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mypktxt"
            ValidationGroup="costFinYear"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEFinYear"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FinYear" />
          <AJX:MaskedEditValidator 
            ID = "MEVFinYear"
            runat = "server"
            ControlToValidate = "F_FinYear"
            ControlExtender = "MEEFinYear"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costFinYear"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Descpription" runat="server" Text="Descpription :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Descpription"
            Text='<%# Bind("Descpription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costFinYear"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Descpription."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescpription"
            runat = "server"
            ControlToValidate = "F_Descpription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costFinYear"
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
  ID = "ODScostFinYear"
  DataObjectTypeName = "SIS.COST.costFinYear"
  InsertMethod="costFinYearInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costFinYear"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
