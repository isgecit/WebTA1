<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkFinYears.aspx.vb" Inherits="AF_nprkFinYears" title="Add: Fin.Years" %>
<asp:Content ID="CPHnprkFinYears" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkFinYears" runat="server" Text="&nbsp;Add: Fin.Years"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkFinYears" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkFinYears"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "nprkFinYears"
    runat = "server" />
<asp:FormView ID="FVnprkFinYears"
  runat = "server"
  DataKeyNames = "FinYear"
  DataSourceID = "ODSnprkFinYears"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgnprkFinYears" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" ForeColor="#CC6633" runat="server" Text="Fin. Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FinYear" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkFinYears"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="40"
            Width="328px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkFinYears"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StartDate" runat="server" Text="Start Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_StartDate"
            Text='<%# Bind("StartDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="nprkFinYears"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonStartDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEStartDate"
            TargetControlID="F_StartDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonStartDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEStartDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_StartDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVStartDate"
            runat = "server"
            ControlToValidate = "F_StartDate"
            ControlExtender = "MEEStartDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkFinYears"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EndDate" runat="server" Text="End Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EndDate"
            Text='<%# Bind("EndDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="nprkFinYears"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonEndDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEEndDate"
            TargetControlID="F_EndDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonEndDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEEndDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_EndDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVEndDate"
            runat = "server"
            ControlToValidate = "F_EndDate"
            ControlExtender = "MEEEndDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkFinYears"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Status" runat="server" Text="Status :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_Status"
            SelectedValue='<%# Bind("Status") %>'
            Width="200px"
            ValidationGroup = "nprkFinYears"
            CssClass = "myddl"
            Runat="Server" >
            <asp:ListItem Value="Open">Open</asp:ListItem>
            <asp:ListItem Value="Close">Close</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVStatus"
            runat = "server"
            ControlToValidate = "F_Status"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkFinYears"
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
  ID = "ODSnprkFinYears"
  DataObjectTypeName = "SIS.NPRK.nprkFinYears"
  InsertMethod="nprkFinYearsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkFinYears"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
