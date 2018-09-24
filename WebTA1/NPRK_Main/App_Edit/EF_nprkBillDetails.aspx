<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkBillDetails.aspx.vb" Inherits="EF_nprkBillDetails" title="Edit: Bill Details" %>
<asp:Content ID="CPHnprkBillDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkBillDetails" runat="server" Text="&nbsp;Edit: Bill Details"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkBillDetails" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkBillDetails"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkBillDetails"
    runat = "server" />
<asp:FormView ID="FVnprkBillDetails"
  runat = "server"
  DataKeyNames = "ClaimID,ApplicationID,AttachmentID"
  DataSourceID = "ODSnprkBillDetails"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr id="Tr1" runat="server" style="height:40px;">
        <td colspan="4">
          <b><asp:Label ID="Lbl_Perk" runat="server" Font-Size="Large" style="padding:10px"  Text="" /></b>
        </td>
      </tr>
      <tr id="rowDeclaration" runat="server" style="height:40px; background-color:antiquewhite">
        <td class="alignright">
          <b><asp:Label ID="Label1" runat="server" style="padding:10px"  Text="Declaration :" /></b>
        </td>
        <td colspan="3" style="padding:10px">
          <b><asp:Label ID="lblDeclaration" Font-Size="10pt" runat="server" ForeColor="#CC6633" Text="" /></b>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="rowClaimID" runat="server">
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" runat="server" ForeColor="#CC6633" Text="Claim Ref.No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ClaimRefNo"
            Text='<%# Bind("ClaimRefNo") %>'
            ToolTip="Value of Claim ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
          <asp:TextBox
            ID = "F_ClaimID"
            Width="88px"
            Text='<%# Bind("ClaimID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            style="display:none;"
            ToolTip="Value of Claim ID."
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="rowApplicationID" runat="server">
        <td class="alignright">
          <b><asp:Label ID="L_ApplicationID" runat="server" style="display:none" ForeColor="#CC6633" Text="Application ID :" /></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ApplicationID"
            Width="88px"
            Text='<%# Bind("ApplicationID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Application ID."
            style="display:none"
            Runat="Server" />
          <asp:Label
            ID = "F_ApplicationID_Display"
            Text='<%# Eval("PRK_Applications2_UserRemark") %>'
            CssClass="myLbl"
            style="display:none"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="rowAttachmentID" runat="server">
        <td class="alignright">
          <b><asp:Label ID="L_AttachmentID" runat="server" style="display:none" ForeColor="#CC6633" Text="Bill ID :" /></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AttachmentID"
            Text='<%# Bind("AttachmentID") %>'
            ToolTip="Value of Bill ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right;display:none;"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="rowBillNo" runat="server">
        <td class="alignright">
          <asp:Label ID="L_BillNo" runat="server" Text="BILL NO :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_BillNo"
            Text='<%# Bind("BillNo") %>'
            Width="168px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkBillDetails"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BILL NO."
            MaxLength="20"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBillNo"
            runat = "server"
            ControlToValidate = "F_BillNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkBillDetails"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BillDate" runat="server" Text="BILL DATE :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_BillDate"
            Text='<%# Bind("BillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkBillDetails"
            runat="server" />
          <asp:Image ID="ImageButtonBillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEBillDate"
            TargetControlID="F_BillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonBillDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEBillDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BillDate" />
        </td>
      </tr>
      <tr id="rowFromDate" runat="server">
        <td class="alignright">
          <asp:Label ID="L_FromDate" runat="server" Text="From Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_FromDate"
            Text='<%# Bind("FromDate") %>'
            Width="80px"
            onfocus = "return this.select();"
            OnTextChanged="DateChanged"
            AutoPostBack="true"
            ValidationGroup="nprkBillDetails"
            CssClass = '<%# CssClass %>'
            Enabled='<%# Enabled %>'
            runat="server" />
          <asp:Image ID="ImageButtonFromDate" runat="server" ToolTip="Click to open calendar" 
            Enabled='<%# Enabled %>'
            style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
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
        </td>
        <td class="alignright">
          <asp:Label ID="L_ToDate" runat="server" Text="To Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ToDate"
            Text='<%# Bind("ToDate") %>'
            Width="80px"
            onfocus = "return this.select();"
            ValidationGroup="nprkBillDetails"
            OnTextChanged="DateChanged"
            AutoPostBack="true"
            CssClass = '<%# CssClass %>'
            Enabled='<%# Enabled %>'
            runat="server" />
          <asp:Image ID="ImageButtonToDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEToDate"
            TargetControlID="F_ToDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonToDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEToDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ToDate" />
        </td>
      </tr>
      <tr id="rowParticulars" runat="server">
        <td class="alignright">
          <asp:Label ID="L_Particulars" runat="server" Text="Bill Details :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID="F_Particulars"
            Text='<%# Bind("Particulars") %>'
            CssClass = "mytxt"
            MaxLength="100"
            Width="250px"
            ValidationGroup = '<%# "nprkBillDetails" & Container.DataItemIndex %>'
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            Runat="Server" >
          </asp:TextBox>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="rowBillAmount" runat="server">
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Bill Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup= "nprkBillDetails"
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="rowClaimedAmount" runat="server">
        <td class="alignright">
          <asp:Label ID="L_Amount" runat="server" Text="Claimed Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            style="text-align: right"
            Width="168px"
            ValidationGroup= "nprkBillDetails"
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            CssClass = '<%# CssClass %>'
            Enabled='<%# Enabled %>'
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="rowWithDriver" runat="server">
        <td class="alignright">
          <asp:Label ID="L_WithDriver" runat="server" Text="Verify Driver Attendance :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_WithDriver"
           Checked='<%# Bind("WithDriver") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkBillDetails"
  DataObjectTypeName = "SIS.NPRK.nprkBillDetails"
  SelectMethod = "nprkBillDetailsGetByID"
  UpdateMethod="UZ_nprkBillDetailsUpdate"
  DeleteMethod="UZ_nprkBillDetailsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkBillDetails"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ClaimID" Name="ClaimID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplicationID" Name="ApplicationID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="AttachmentID" Name="AttachmentID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
