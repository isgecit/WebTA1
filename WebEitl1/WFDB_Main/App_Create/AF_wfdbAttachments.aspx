<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_wfdbAttachments.aspx.vb" Inherits="AF_wfdbAttachments" title="Add: Attachments" %>
<asp:Content ID="CPHwfdbAttachments" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelwfdbAttachments" runat="server" Text="&nbsp;Add: Attachments"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLwfdbAttachments" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLwfdbAttachments"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "wfdbAttachments"
    runat = "server" />
<asp:FormView ID="FVwfdbAttachments"
  runat = "server"
  DataKeyNames = "t_indx,t_dcid"
  DataSourceID = "ODSwfdbAttachments"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgwfdbAttachments" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_indx" ForeColor="#CC6633" runat="server" Text="t_indx :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_t_indx"
            Text='<%# Bind("t_indx") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_indx."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_indx"
            runat = "server"
            ControlToValidate = "F_t_indx"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbAttachments"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_prcd" runat="server" Text="t_prcd :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_prcd"
            Text='<%# Bind("t_prcd") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_prcd."
            MaxLength="50"
            Width="408px"
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
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_fnam" runat="server" Text="t_fnam :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_fnam"
            Text='<%# Bind("t_fnam") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_fnam."
            MaxLength="250"
            Width="350px"
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
        <td class="alignright">
          <asp:Label ID="L_t_lbcd" runat="server" Text="t_lbcd :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_lbcd"
            Text='<%# Bind("t_lbcd") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_lbcd."
            MaxLength="50"
            Width="408px"
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
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_atby" runat="server" Text="t_atby :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_atby"
            Text='<%# Bind("t_atby") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_atby."
            MaxLength="50"
            Width="408px"
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
        <td class="alignright">
          <asp:Label ID="L_t_aton" runat="server" Text="t_aton :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_aton"
            Text='<%# Bind("t_aton") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="wfdbAttachments"
            onfocus = "return this.select();"
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
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSwfdbAttachments"
  DataObjectTypeName = "SIS.WFDB.wfdbAttachments"
  InsertMethod="UZ_wfdbAttachmentsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.WFDB.wfdbAttachments"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
