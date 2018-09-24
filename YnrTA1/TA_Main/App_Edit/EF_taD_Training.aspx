<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taD_Training.aspx.vb" Inherits="EF_taD_Training" title="Edit: Training Program DA" %>
<asp:Content ID="CPHtaD_Training" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaD_Training" runat="server" Text="&nbsp;Edit: Training Program DA"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaD_Training" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaD_Training"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taD_Training"
    runat = "server" />
<asp:FormView ID="FVtaD_Training"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODStaD_Training"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
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
          <asp:Label ID="L_Bord_Lodg_DA_Percent" runat="server" Text="Percentage of DA [Boarding and Lodging Provided] :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Bord_Lodg_DA_Percent"
            Text='<%# Bind("Bord_Lodg_DA_Percent") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="taD_Training"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEBord_Lodg_DA_Percent"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Bord_Lodg_DA_Percent" />
          <AJX:MaskedEditValidator 
            ID = "MEVBord_Lodg_DA_Percent"
            runat = "server"
            ControlToValidate = "F_Bord_Lodg_DA_Percent"
            ControlExtender = "MEEBord_Lodg_DA_Percent"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taD_Training"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Lodg_DA_Percent" runat="server" Text="Percentage of DA [Only Lodging Provided] :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Lodg_DA_Percent"
            Text='<%# Bind("Lodg_DA_Percent") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="taD_Training"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEELodg_DA_Percent"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Lodg_DA_Percent" />
          <AJX:MaskedEditValidator 
            ID = "MEVLodg_DA_Percent"
            runat = "server"
            ControlToValidate = "F_Lodg_DA_Percent"
            ControlExtender = "MEELodg_DA_Percent"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taD_Training"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FromDate" runat="server" Text="From Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FromDate"
            Text='<%# Bind("FromDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taD_Training"
            runat="server" />
          <asp:Image ID="ImageButtonFromDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFromDate"
            TargetControlID="F_FromDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFromDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEFromDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FromDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVFromDate"
            runat = "server"
            ControlToValidate = "F_FromDate"
            ControlExtender = "MEEFromDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taD_Training"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TillDate" runat="server" Text="Till Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TillDate"
            Text='<%# Bind("TillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taD_Training"
            runat="server" />
          <asp:Image ID="ImageButtonTillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETillDate"
            TargetControlID="F_TillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTillDate" />
          <AJX:MaskedEditExtender 
            ID = "MEETillDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TillDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVTillDate"
            runat = "server"
            ControlToValidate = "F_TillDate"
            ControlExtender = "MEETillDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taD_Training"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Active"
            Checked='<%# Bind("Active") %>'
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
  ID = "ODStaD_Training"
  DataObjectTypeName = "SIS.TA.taD_Training"
  SelectMethod = "taD_TrainingGetByID"
  UpdateMethod="taD_TrainingUpdate"
  DeleteMethod="taD_TrainingDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taD_Training"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
