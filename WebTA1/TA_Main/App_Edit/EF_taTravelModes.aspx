<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taTravelModes.aspx.vb" Inherits="EF_taTravelModes" title="Edit: Travel Modes" %>
<asp:Content ID="CPHtaTravelModes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaTravelModes" runat="server" Text="&nbsp;Edit: Travel Modes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaTravelModes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaTravelModes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taTravelModes"
    runat = "server" />
<asp:FormView ID="FVtaTravelModes"
  runat = "server"
  DataKeyNames = "ModeID"
  DataSourceID = "ODStaTravelModes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ModeID" runat="server" ForeColor="#CC6633" Text="Mode ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ModeID"
            Text='<%# Bind("ModeID") %>'
            ToolTip="Value of Mode ID."
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
          <asp:Label ID="L_ModeName" runat="server" Text="Travel Mode Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ModeName"
            Text='<%# Bind("ModeName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taTravelModes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Travel Mode Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVModeName"
            runat = "server"
            ControlToValidate = "F_ModeName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taTravelModes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Sequence" runat="server" Text="Sequence :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Sequence"
            Text='<%# Bind("Sequence") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="taTravelModes"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEESequence"
            runat = "server"
            mask = "9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Sequence" />
          <AJX:MaskedEditValidator 
            ID = "MEVSequence"
            runat = "server"
            ControlToValidate = "F_Sequence"
            ControlExtender = "MEESequence"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taTravelModes"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OutOfSequence" runat="server" Text="Out Of Sequence :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_OutOfSequence"
            Checked='<%# Bind("OutOfSequence") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UnderMilageClaim" runat="server" Text="Under Milage Claim :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_UnderMilageClaim"
            Checked='<%# Bind("UnderMilageClaim") %>'
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
  ID = "ODStaTravelModes"
  DataObjectTypeName = "SIS.TA.taTravelModes"
  SelectMethod = "taTravelModesGetByID"
  UpdateMethod="UZ_taTravelModesUpdate"
  DeleteMethod="UZ_taTravelModesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taTravelModes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ModeID" Name="ModeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
