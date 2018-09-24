<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taBillAmount.aspx.vb" Inherits="EF_taBillAmount" title="Edit: Bill Amounts" %>
<asp:Content ID="CPHtaBillAmount" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBillAmount" runat="server" Text="&nbsp;Edit: Bill Amounts"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillAmount" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBillAmount"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "taBillAmount"
    runat = "server" />
<asp:FormView ID="FVtaBillAmount"
  runat = "server"
  DataKeyNames = "TABillNo,ComponentID,CurrencyID,CostCenterID"
  DataSourceID = "ODStaBillAmount"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" runat="server" ForeColor="#CC6633" Text="TA Bill No :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TABillNo"
            Width="70px"
            Text='<%# Bind("TABillNo") %>'
            Enabled = "False"
            ToolTip="Value of TA Bill No."
            CssClass = "dmypktxt"
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
          <b><asp:Label ID="L_ComponentID" runat="server" ForeColor="#CC6633" Text="Component ID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ComponentID"
            Width="70px"
            Text='<%# Bind("ComponentID") %>'
            Enabled = "False"
            ToolTip="Value of Component ID."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ComponentID_Display"
            Text='<%# Eval("TA_Components4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CurrencyID" runat="server" ForeColor="#CC6633" Text="Currency ID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CurrencyID"
            Width="42px"
            Text='<%# Bind("CurrencyID") %>'
            Enabled = "False"
            ToolTip="Value of Currency ID."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CurrencyID_Display"
            Text='<%# Eval("TA_Currencies5_CurrencyName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CostCenterID" runat="server" ForeColor="#CC6633" Text="Cost Center ID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CostCenterID"
            Width="42px"
            Text='<%# Bind("CostCenterID") %>'
            Enabled = "False"
            ToolTip="Value of Cost Center ID."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CostCenterID_Display"
            Text='<%# Eval("HRM_Departments1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalInCurrency" runat="server" Text="Total In Currency :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TotalInCurrency"
            Text='<%# Bind("TotalInCurrency") %>'
            ToolTip="Value of Total In Currency."
            Enabled = "False"
            Width="126px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor INR :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ConversionFactorINR"
            Text='<%# Bind("ConversionFactorINR") %>'
            ToolTip="Value of Conversion Factor INR."
            Enabled = "False"
            Width="56px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CalculationTypeID" runat="server" Text="Calculation Type ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CalculationTypeID"
            Width="70px"
            Text='<%# Bind("CalculationTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Calculation Type ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CalculationTypeID_Display"
            Text='<%# Eval("TA_CalcMethod3_CalculationDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalInINR" runat="server" Text="Total In INR :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TotalInINR"
            Text='<%# Bind("TotalInINR") %>'
            ToolTip="Value of Total In INR."
            Enabled = "False"
            Width="126px"
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
  ID = "ODStaBillAmount"
  DataObjectTypeName = "SIS.TA.taBillAmount"
  SelectMethod = "taBillAmountGetByID"
  UpdateMethod="UZ_taBillAmountUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBillAmount"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TABillNo" Name="TABillNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ComponentID" Name="ComponentID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CurrencyID" Name="CurrencyID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CostCenterID" Name="CostCenterID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
