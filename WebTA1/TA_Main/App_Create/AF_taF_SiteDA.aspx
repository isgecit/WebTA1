<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taF_SiteDA.aspx.vb" Inherits="AF_taF_SiteDA" title="Add: Category Wise Foreign Site DA" %>
<asp:Content ID="CPHtaF_SiteDA" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaF_SiteDA" runat="server" Text="&nbsp;Add: Category Wise Foreign Site DA"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaF_SiteDA" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaF_SiteDA"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taF_SiteDA"
    runat = "server" />
<asp:FormView ID="FVtaF_SiteDA"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODStaF_SiteDA"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaF_SiteDA" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "taF_SiteDA"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" class="groupHeader" >Technical: Contractual Employee</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Cont_Tech_Bord_DA" runat="server" Text="DA [ Boarding Provided by Co. or Client ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Cont_Tech_Bord_DA"
            Text='<%# Bind("Cont_Tech_Bord_DA") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECont_Tech_Bord_DA"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Cont_Tech_Bord_DA" />
          <AJX:MaskedEditValidator 
            ID = "MEVCont_Tech_Bord_DA"
            runat = "server"
            ControlToValidate = "F_Cont_Tech_Bord_DA"
            ControlExtender = "MEECont_Tech_Bord_DA"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Cont_Tech_DA" runat="server" Text="DA [Technical]  :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Cont_Tech_DA"
            Text='<%# Bind("Cont_Tech_DA") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECont_Tech_DA"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Cont_Tech_DA" />
          <AJX:MaskedEditValidator 
            ID = "MEVCont_Tech_DA"
            runat = "server"
            ControlToValidate = "F_Cont_Tech_DA"
            ControlExtender = "MEECont_Tech_DA"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" class="groupHeader" >Non Technical: Contractual Employee</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Cont_NonT_Bord_DA" runat="server" Text="DA [ Boarding Provided by Co. or Client ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Cont_NonT_Bord_DA"
            Text='<%# Bind("Cont_NonT_Bord_DA") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECont_NonT_Bord_DA"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Cont_NonT_Bord_DA" />
          <AJX:MaskedEditValidator 
            ID = "MEVCont_NonT_Bord_DA"
            runat = "server"
            ControlToValidate = "F_Cont_NonT_Bord_DA"
            ControlExtender = "MEECont_NonT_Bord_DA"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Cont_NonT_DA" runat="server" Text="DA [Non Technical] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Cont_NonT_DA"
            Text='<%# Bind("Cont_NonT_DA") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECont_NonT_DA"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Cont_NonT_DA" />
          <AJX:MaskedEditValidator 
            ID = "MEVCont_NonT_DA"
            runat = "server"
            ControlToValidate = "F_Cont_NonT_DA"
            ControlExtender = "MEECont_NonT_DA"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" class="groupHeader" >Permanent Employee</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Perm_Bord_DA" runat="server" Text="DA [ Boarding Provided by Co. or Client ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Perm_Bord_DA"
            Text='<%# Bind("Perm_Bord_DA") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPerm_Bord_DA"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Perm_Bord_DA" />
          <AJX:MaskedEditValidator 
            ID = "MEVPerm_Bord_DA"
            runat = "server"
            ControlToValidate = "F_Perm_Bord_DA"
            ControlExtender = "MEEPerm_Bord_DA"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Perm_DA" runat="server" Text="DA :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Perm_DA"
            Text='<%# Bind("Perm_DA") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPerm_DA"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Perm_DA" />
          <AJX:MaskedEditValidator 
            ID = "MEVPerm_DA"
            runat = "server"
            ControlToValidate = "F_Perm_DA"
            ControlExtender = "MEEPerm_DA"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FromDate" runat="server" Text="From Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_FromDate"
            Text='<%# Bind("FromDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taF_SiteDA"
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
            ValidationGroup = "taF_SiteDA"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TillDate" runat="server" Text="Till Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_TillDate"
            Text='<%# Bind("TillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taF_SiteDA"
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
            ValidationGroup = "taF_SiteDA"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Active"
           Checked='<%# Bind("Active") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaF_SiteDA"
  DataObjectTypeName = "SIS.TA.taF_SiteDA"
  InsertMethod="taF_SiteDAInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taF_SiteDA"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
