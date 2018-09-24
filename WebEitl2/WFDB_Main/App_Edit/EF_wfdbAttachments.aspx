<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_wfdbAttachments.aspx.vb" Inherits="EF_wfdbAttachments" title="Edit: Attachments" %>
<asp:Content ID="CPHwfdbAttachments" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelwfdbAttachments" runat="server" Text="&nbsp;Edit: Attachments"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLwfdbAttachments" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLwfdbAttachments"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "wfdbAttachments"
    runat = "server" />
<asp:FormView ID="FVwfdbAttachments"
  runat = "server"
  DataKeyNames = "t_indx,t_dcid"
  DataSourceID = "ODSwfdbAttachments"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_drid" runat="server" Text="t_drid :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_drid"
            Text='<%# Bind("t_drid") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_drid."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_drid"
            runat = "server"
            ControlToValidate = "F_t_drid"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_t_dcid" runat="server" ForeColor="#CC6633" Text="t_dcid :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_t_dcid"
            Text='<%# Bind("t_dcid") %>'
            ToolTip="Value of t_dcid."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_hndl" runat="server" Text="t_hndl :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_hndl"
            Text='<%# Bind("t_hndl") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_hndl."
            MaxLength="200"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_hndl"
            runat = "server"
            ControlToValidate = "F_t_hndl"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_t_indx" runat="server" ForeColor="#CC6633" Text="t_indx :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_t_indx"
            Text='<%# Bind("t_indx") %>'
            ToolTip="Value of t_indx."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_prcd" runat="server" Text="t_prcd :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_prcd"
            Text='<%# Bind("t_prcd") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_prcd."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_prcd"
            runat = "server"
            ControlToValidate = "F_t_prcd"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_fnam" runat="server" Text="t_fnam :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_fnam"
            Text='<%# Bind("t_fnam") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_fnam."
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_fnam"
            runat = "server"
            ControlToValidate = "F_t_fnam"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_lbcd" runat="server" Text="t_lbcd :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_lbcd"
            Text='<%# Bind("t_lbcd") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_lbcd."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_lbcd"
            runat = "server"
            ControlToValidate = "F_t_lbcd"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_atby" runat="server" Text="t_atby :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_atby"
            Text='<%# Bind("t_atby") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_atby."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_atby"
            runat = "server"
            ControlToValidate = "F_t_atby"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_aton" runat="server" Text="t_aton :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_aton"
            Text='<%# Bind("t_aton") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            runat="server" />
          <asp:Image ID="ImageButtont_aton" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEt_aton"
            TargetControlID="F_t_aton"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtont_aton" />
          <AJX:MaskedEditExtender 
            ID = "MEEt_aton"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_t_aton" />
          <AJX:MaskedEditValidator 
            ID = "MEVt_aton"
            runat = "server"
            ControlToValidate = "F_t_aton"
            ControlExtender = "MEEt_aton"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_Refcntd" runat="server" Text="t_Refcntd :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_Refcntd"
            Text='<%# Bind("t_Refcntd") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup= "wfdbAttachments"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEt_Refcntd"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_t_Refcntd" />
          <AJX:MaskedEditValidator 
            ID = "MEVt_Refcntd"
            runat = "server"
            ControlToValidate = "F_t_Refcntd"
            ControlExtender = "MEEt_Refcntd"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_Refcntu" runat="server" Text="t_Refcntu :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_Refcntu"
            Text='<%# Bind("t_Refcntu") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup= "wfdbAttachments"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEt_Refcntu"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_t_Refcntu" />
          <AJX:MaskedEditValidator 
            ID = "MEVt_Refcntu"
            runat = "server"
            ControlToValidate = "F_t_Refcntu"
            ControlExtender = "MEEt_Refcntu"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSwfdbAttachments"
  DataObjectTypeName = "SIS.WFDB.wfdbAttachments"
  SelectMethod = "UZ_wfdbAttachmentsGetByID"
  UpdateMethod="UZ_wfdbAttachmentsUpdate"
  DeleteMethod="UZ_wfdbAttachmentsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.WFDB.wfdbAttachments"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_indx" Name="t_indx" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_dcid" Name="t_dcid" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
