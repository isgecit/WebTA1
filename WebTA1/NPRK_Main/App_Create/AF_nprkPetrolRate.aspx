<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkPetrolRate.aspx.vb" Inherits="AF_nprkPetrolRate" title="Add: Petrol Rates" %>
<asp:Content ID="CPHnprkPetrolRate" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkPetrolRate" runat="server" Text="&nbsp;Add: Petrol Rates"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkPetrolRate" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkPetrolRate"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "nprkPetrolRate"
    runat = "server" />
<asp:FormView ID="FVnprkPetrolRate"
  runat = "server"
  DataKeyNames = "FinYear,MonthID,LocationID"
  DataSourceID = "ODSnprkPetrolRate"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkPetrolRate" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin. Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_nprkFinYears
            ID="F_FinYear"
            SelectedValue='<%# Bind("FinYear") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkPetrolRate"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_MonthID" ForeColor="#CC6633" runat="server" Text="Month ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_nprkMonths
            ID="F_MonthID"
            SelectedValue='<%# Bind("MonthID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkPetrolRate"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationID" ForeColor="#CC6633" runat="server" Text="Location ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <LGM:LC_hrmLocations
            ID="F_LocationID"
            SelectedValue='<%# Bind("LocationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkPetrolRate"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PetrolRate" runat="server" Text="Petrol Rate :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PetrolRate"
            Text='<%# Bind("PetrolRate") %>'
            Width="72px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="nprkPetrolRate"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkPetrolRate"
  DataObjectTypeName = "SIS.NPRK.nprkPetrolRate"
  InsertMethod="nprkPetrolRateInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkPetrolRate"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
