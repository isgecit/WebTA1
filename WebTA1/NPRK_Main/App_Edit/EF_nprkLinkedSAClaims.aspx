<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkLinkedSAClaims.aspx.vb" Inherits="EF_nprkLinkedSAClaims" title="Edit: Selected Claims" %>
<asp:Content ID="CPHnprkLinkedSAClaims" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkLinkedSAClaims" runat="server" Text="&nbsp;Edit: Selected Claims"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkLinkedSAClaims" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkLinkedSAClaims"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkLinkedSAClaims"
    runat = "server" />
<asp:FormView ID="FVnprkLinkedSAClaims"
  runat = "server"
  DataKeyNames = "FinYear,Quarter,EmployeeID"
  DataSourceID = "ODSnprkLinkedSAClaims"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear3_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="Label1" ForeColor="#CC6633" runat="server" Text="Advice No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_AdviceNo"
            Width="88px"
            Text='<%# Bind("AdviceNo") %>'
            Enabled = "False"
            CssClass = "dmypktxt"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Quarter."
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_EmployeeID" runat="server" ForeColor="#CC6633" Text="Employee :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            Width="72px"
            Text='<%# Bind("EmployeeID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Employee."
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("HRM_Employees5_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled1Days" runat="server" Text="Entitled Days [1] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled1Days"
            Text='<%# Bind("Entitled1Days") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled1Days"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled1Days" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled1Days"
            runat = "server"
            ControlToValidate = "F_Entitled1Days"
            ControlExtender = "MEEEntitled1Days"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled2Days" runat="server" Text="Entitled Days [2] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled2Days"
            Text='<%# Bind("Entitled2Days") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled2Days"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled2Days" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled2Days"
            runat = "server"
            ControlToValidate = "F_Entitled2Days"
            ControlExtender = "MEEEntitled2Days"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled3Days" runat="server" Text="Entitled Days [3] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled3Days"
            Text='<%# Bind("Entitled3Days") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled3Days"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled3Days" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled3Days"
            runat = "server"
            ControlToValidate = "F_Entitled3Days"
            ControlExtender = "MEEEntitled3Days"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled1Amount" runat="server" Text="Entitled Amount [1] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled1Amount"
            Text='<%# Bind("Entitled1Amount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled1Amount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled1Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled1Amount"
            runat = "server"
            ControlToValidate = "F_Entitled1Amount"
            ControlExtender = "MEEEntitled1Amount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled2Amount" runat="server" Text="Entitled Amount [2] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled2Amount"
            Text='<%# Bind("Entitled2Amount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled2Amount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled2Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled2Amount"
            runat = "server"
            ControlToValidate = "F_Entitled2Amount"
            ControlExtender = "MEEEntitled2Amount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Entitled3Amount" runat="server" Text="Entitled Amount [3] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Entitled3Amount"
            Text='<%# Bind("Entitled3Amount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEEntitled3Amount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Entitled3Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVEntitled3Amount"
            runat = "server"
            ControlToValidate = "F_Entitled3Amount"
            ControlExtender = "MEEEntitled3Amount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverRemarks" runat="server" Text="Accounts Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Accounts Remarks."
            MaxLength="100"
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
  ID = "ODSnprkLinkedSAClaims"
  DataObjectTypeName = "SIS.NPRK.nprkLinkedSAClaims"
  SelectMethod = "nprkLinkedSAClaimsGetByID"
  UpdateMethod="UZ_nprkLinkedSAClaimsUpdate"
  DeleteMethod="UZ_nprkLinkedSAClaimsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkLinkedSAClaims"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="EmployeeID" Name="EmployeeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
