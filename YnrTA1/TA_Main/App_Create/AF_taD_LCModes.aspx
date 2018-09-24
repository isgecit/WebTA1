<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taD_LCModes.aspx.vb" Inherits="AF_taD_LCModes" title="Add: Category Wise L C Modes" %>
<asp:Content ID="CPHtaD_LCModes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaD_LCModes" runat="server" Text="&nbsp;Add: Category Wise L C Modes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaD_LCModes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaD_LCModes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taD_LCModes"
    runat = "server" />
<asp:FormView ID="FVtaD_LCModes"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODStaD_LCModes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaD_LCModes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryID" runat="server" Text="Category ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taCategories
            ID="F_CategoryID"
            SelectedValue='<%# Bind("CategoryID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taD_LCModes"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_LCModeID" runat="server" Text="Local Conveyance ModeID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taLCModes
            ID="F_LCModeID"
            SelectedValue='<%# Bind("LCModeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taD_LCModes"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EntitlementText" runat="server" Text="Entitlement Text :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EntitlementText"
            Text='<%# Bind("EntitlementText") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taD_LCModes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Entitlement Text."
            MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVEntitlementText"
            runat = "server"
            ControlToValidate = "F_EntitlementText"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taD_LCModes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FromDate" runat="server" Text="From Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FromDate"
            Text='<%# Bind("FromDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taD_LCModes"
            onfocus = "return this.select();"
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
            ValidationGroup = "taD_LCModes"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TillDate" runat="server" Text="Till Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TillDate"
            Text='<%# Bind("TillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taD_LCModes"
            onfocus = "return this.select();"
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
            ValidationGroup = "taD_LCModes"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaD_LCModes"
  DataObjectTypeName = "SIS.TA.taD_LCModes"
  InsertMethod="taD_LCModesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taD_LCModes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
