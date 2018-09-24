<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkPetrolRate.aspx.vb" Inherits="EF_nprkPetrolRate" title="Edit: Petrol Rates" %>
<asp:Content ID="CPHnprkPetrolRate" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkPetrolRate" runat="server" Text="&nbsp;Edit: Petrol Rates"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkPetrolRate" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkPetrolRate"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkPetrolRate"
    runat = "server" />
<asp:FormView ID="FVnprkPetrolRate"
  runat = "server"
  DataKeyNames = "FinYear,MonthID,LocationID"
  DataSourceID = "ODSnprkPetrolRate"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin. Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin. Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("PRK_FinYears2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_MonthID" runat="server" ForeColor="#CC6633" Text="Month ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_MonthID"
            Width="88px"
            Text='<%# Bind("MonthID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Month ID."
            Runat="Server" />
          <asp:Label
            ID = "F_MonthID_Display"
            Text='<%# Eval("PRK_Months3_MonthName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationID" runat="server" ForeColor="#CC6633" Text="Location ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_LocationID"
            Width="88px"
            Text='<%# Bind("LocationID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Location ID."
            Runat="Server" />
          <asp:Label
            ID = "F_LocationID_Display"
            Text='<%# Eval("HRM_Locations1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PetrolRate" runat="server" Text="Petrol Rate :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PetrolRate"
            Text='<%# Bind("PetrolRate") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
            ValidationGroup= "nprkPetrolRate"
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPetrolRate"
            runat = "server"
            mask = "999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PetrolRate" />
          <AJX:MaskedEditValidator 
            ID = "MEVPetrolRate"
            runat = "server"
            ControlToValidate = "F_PetrolRate"
            ControlExtender = "MEEPetrolRate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkPetrolRate"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
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
  ID = "ODSnprkPetrolRate"
  DataObjectTypeName = "SIS.NPRK.nprkPetrolRate"
  SelectMethod = "nprkPetrolRateGetByID"
  UpdateMethod="nprkPetrolRateUpdate"
  DeleteMethod="nprkPetrolRateDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkPetrolRate"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MonthID" Name="MonthID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="LocationID" Name="LocationID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
