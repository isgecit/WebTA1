<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taBillPrjAmounts.aspx.vb" Inherits="EF_taBillPrjAmounts" title="Edit: Bill Project wise total" %>
<asp:Content ID="CPHtaBillPrjAmounts" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBillPrjAmounts" runat="server" Text="&nbsp;Edit: Bill Project wise total"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillPrjAmounts" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBillPrjAmounts"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "taBillPrjAmounts"
    runat = "server" />
<asp:FormView ID="FVtaBillPrjAmounts"
  runat = "server"
  DataKeyNames = "TABillNo,ProjectID"
  DataSourceID = "ODStaBillPrjAmounts"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" runat="server" ForeColor="#CC6633" Text="TA Bill No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TABillNo"
            Width="70px"
            Text='<%# Bind("TABillNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of TA Bill No."
            Runat="Server" />
          <asp:Label
            ID = "F_TABillNo_Display"
            Text='<%# Eval("TA_Bills2_PurposeOfJourney") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:Label
            ID = "F_ProjectID"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Percentage" runat="server" Text="Percentage :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Percentage"
            Text='<%# Bind("Percentage") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="taBillPrjAmounts"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPercentage"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Percentage" />
          <AJX:MaskedEditValidator 
            ID = "MEVPercentage"
            runat = "server"
            ControlToValidate = "F_Percentage"
            ControlExtender = "MEEPercentage"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBillPrjAmounts"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalAmountinINR" runat="server" Text="Total Amount [INR] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:Label ID="F_TotalAmountinINR"
            Text='<%# Bind("TotalAmountinINR") %>'
            CssClass = "dmytxt"
            style="text-align: right"
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
  ID = "ODStaBillPrjAmounts"
  DataObjectTypeName = "SIS.TA.taBillPrjAmounts"
  SelectMethod = "taBillPrjAmountsGetByID"
  UpdateMethod="UZ_taBillPrjAmountsUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBillPrjAmounts"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TABillNo" Name="TABillNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
