<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakUnits.aspx.vb" Inherits="EF_pakUnits" title="Edit: Units" %>
<asp:Content ID="CPHpakUnits" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakUnits" runat="server" Text="&nbsp;Edit: Units"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakUnits" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakUnits"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakUnits"
    runat = "server" />
<asp:FormView ID="FVpakUnits"
  runat = "server"
  DataKeyNames = "UnitID"
  DataSourceID = "ODSpakUnits"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UnitID" runat="server" ForeColor="#CC6633" Text="Unit ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UnitID"
            Text='<%# Bind("UnitID") %>'
            ToolTip="Value of Unit ID."
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
            ValidationGroup="pakUnits"
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
            ValidationGroup = "pakUnits"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UnitSetID" runat="server" Text="Unit Set ID :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_pakUnitSets
            ID="F_UnitSetID"
            SelectedValue='<%# Bind("UnitSetID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactor" runat="server" Text="Conversion Factor to Unit Set Base Unit :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ConversionFactor"
            Text='<%# Bind("ConversionFactor") %>'
            style="text-align: right"
            Width="216px"
            CssClass = "mytxt"
            MaxLength="26"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEConversionFactor"
            runat = "server"
            mask = "999999999999999999.99999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ConversionFactor" />
          <AJX:MaskedEditValidator 
            ID = "MEVConversionFactor"
            runat = "server"
            ControlToValidate = "F_ConversionFactor"
            ControlExtender = "MEEConversionFactor"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
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
  ID = "ODSpakUnits"
  DataObjectTypeName = "SIS.PAK.pakUnits"
  SelectMethod = "pakUnitsGetByID"
  UpdateMethod="pakUnitsUpdate"
  DeleteMethod="pakUnitsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakUnits"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UnitID" Name="UnitID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
