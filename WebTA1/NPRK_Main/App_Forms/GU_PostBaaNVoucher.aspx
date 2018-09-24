<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GU_PostBaaNVoucher.aspx.vb" Inherits="PostBaaNVoucher" title="IJT: Post BaaN Voucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelPrkLedger" runat="server" Text="&nbsp;Post Voucher in BaaN"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <table style="width:100%; margin:auto"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType="lgWMSGrid"
      EnableAdd="False"
      EnableSearch="false"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Processing...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <table style="width:auto; margin:auto">
      <tr>
        <td id="tdPost" runat="server" style="vertical-align: top; border-bottom: #33ccff 1pt solid;">
          <table>
            <tr>
              <td >
                <asp:Label ID="Label1" runat="server" Text="Data Date" /></td>
              <td >
          <asp:TextBox 
            ID="DataDate" 
            Text="01/11/2008"
            runat="server" 
            MaxLength="10" 
            AutoPostBack="true"
            Width="70px" CssClass="mytxt" />
            <asp:Image ID="Img1" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CalendarExtenderDataDate"
            TargetControlID="DataDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="Img1" />
		      <AJX:MaskedEditExtender 
			      ID = "MaskedEditExtenderDataDate"
			      runat = "server"
			      mask = "99/99/9999"
			      MaskType="Date"
			      CultureName="en-GB"
			      MessageValidatorTip="true"
			      InputDirection="LeftToRight"
			      ErrorTooltipEnabled="true"
			      TargetControlID="DataDate" />
		      <AJX:MaskedEditValidator 
			      ID = "MaskedEditValidatorDataDate"
			      runat = "server"
			      ControlToValidate = "DataDate"
			      ControlExtender = "MaskedEditExtenderDataDate"
			      InvalidValueMessage = "Invalid Date."
			      EmptyValueMessage = "Data Date is required."
			      EmptyValueBlurredText = "[Required!]"
			      Display = "Dynamic"
			      TooltipMessage = "Enter value for Data Date."
			      EnableClientScript = "true"
			      MinimumValueBlurredText="Data date should be in Financial Year."
			      MinimumValueMessage="Not Allowed."
			      MaximumValueBlurredMessage="Data Date should be less than current date."
			      MaximumValueMessage="Not Allowed."
			      IsValidEmpty = "false"
			      SetFocusOnError="true" 
			      ErrorMessage="MaskedEditValidatorDataDate" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top">
                <asp:Label ID="LabelVoucherSeries" runat="server" Text="Voucher Series" /></td>
              <td>
					      <asp:TextBox ID="TextBoxVoucherSeries"
						      Text="34"
						      runat="server"
						      ValidationGroup="PostBaaNVoucher"
						      MaxLength="2"
                  Width="30px"
                  CssClass="mytxt"
						      style="text-align: right" />
					      <AJX:MaskedEditExtender 
						      ID = "MaskedEditExtenderVoucherSeries"
						      runat = "server"
						      mask = "99"
						      AcceptNegative="None"
						      MaskType="Number"
						      MessageValidatorTip="true"
						      InputDirection="RightToLeft"
						      ErrorTooltipEnabled="true"
						      TargetControlID="TextBoxVoucherSeries" />
					      <AJX:MaskedEditValidator 
						      ID = "MaskedEditValidatorVoucherSeries"
						      runat = "server"
						      ControlToValidate = "TextBoxVoucherSeries"
						      ControlExtender = "MaskedEditExtenderVoucherSeries"
						      InvalidValueMessage = "Invalid value."
						      EmptyValueMessage = "Voucher Series is required."
						      EmptyValueBlurredText = "[Required!]"
						      Display = "Dynamic"
						      TooltipMessage = "Enter Voucher Series."
						      EnableClientScript = "true"
						      ValidationGroup = "PostBaaNVoucher"
						      IsValidEmpty = "false"
						      MinimumValue = "1"
						      MinimumValueBlurredText = "Should be greater than ZERO."
						      MinimumValueMessage = "Voucher Series should be greater than zero."
						      SetFocusOnError="true" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top">
                Voucher Date</td>
              <td>
                <asp:TextBox 
                  ID="VoucherDate" 
                  Text="01/11/2008"
                  runat="server" 
                  MaxLength="10" 
                  AutoPostBack="true"
                  ValidationGroup = "PostBaaNVoucher"
                  Width="70px" CssClass="mytxt" />
                  <asp:Image ID="ImageButton1" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
                <AJX:CalendarExtender 
                  ID = "CalendarExtenderVoucherDate"
                  TargetControlID="VoucherDate"
                  Format="dd/MM/yyyy"
                  runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButton1" />
                <AJX:MaskedEditExtender 
			            ID = "MaskedEditExtenderVoucherDate"
			            runat = "server"
			            mask = "99/99/9999"
			            MaskType="Date"
			            CultureName="en-GB"
			            MessageValidatorTip="true"
			            InputDirection="LeftToRight"
			            ErrorTooltipEnabled="true"
			            TargetControlID="VoucherDate" />
                <AJX:MaskedEditValidator 
			            ID = "MaskedEditValidatorVoucherDate"
			            runat = "server"
			            ControlToValidate = "VoucherDate"
			            ControlExtender = "MaskedEditExtenderVoucherDate"
			            InvalidValueMessage = "Invalid Date."
			            EmptyValueMessage = "Voucher Date is required."
			            EmptyValueBlurredText = "[Required!]"
			            Display = "Dynamic"
			            TooltipMessage = "Enter value for Voucher Date."
			            EnableClientScript = "true"
                  ValidationGroup = "PostBaaNVoucher"
			            MinimumValueBlurredText="Voucher date should be in Financial Year."
			            MinimumValueMessage="Not Allowed."
			            MaximumValueBlurredMessage="Voucher should be less than current date."
			            MaximumValueMessage="Not Allowed."
			            IsValidEmpty = "false"
			            SetFocusOnError="true" 
			            ErrorMessage="MaskedEditValidatorVoucherDate" />
			        </td>
            </tr>
            <tr>
              <td style="vertical-align: top">
                <asp:Label ID="LabelReference" runat="server" Text="Reference" /></td>
              <td>
 					      <asp:TextBox ID="TextBoxReference"
						      Text="Web Paid Perks Reimbursement"
                  CssClass="mytxt"
						      runat="server"
						      ValidationGroup="PostBaaNVoucher"
                  ToolTip="Enter reference."
                  Width="194px"
						      MaxLength="100" />
					      <AJX:TextBoxWatermarkExtender 
						      ID = "TextBoxWatermarkExtenderReference"
						      runat = "server"
                  WatermarkText="[Enter Reference]"
						      TargetControlID="TextBoxReference" />
					      <asp:RequiredFieldValidator 
						      ID = "RequiredFieldValidatorReference"
						      runat = "server"
						      ControlToValidate = "TextBoxReference"
						      Text = "Reference is required."
						      ErrorMessage = "[Required!]"
						      Display = "Dynamic"
						      EnableClientScript = "true"
						      ValidationGroup = "PostBaaNVoucher"
						      SetFocusOnError="true" />
              </td>
            </tr>
            <tr>
              <td style="vertical-align: top">
                <asp:Label ID="Label2" runat="server" Text="Select Vouchers" /></td>
              <td style="border-top: #33ccff 1pt solid">
                <table>
                  <tr>
                    <td>
                      <asp:CheckBox ID="chkCash24" runat="server" Text="Cash Payment-Sec 24" /></td>
                    <td>
                      <asp:CheckBox ID="chkCheque" runat="server" Text="Cheque Payments" /></td>
                  </tr>
                  <tr>
                    <td>
                      <asp:CheckBox ID="chkCash63" runat="server" Text="Cash Payments-Sec 63" /></td>
                    <td>
                      <asp:CheckBox ID="chkImprest" runat="server" Text="Imprest Credits" /></td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr>
              <td style="border-top: #33ccff 1pt solid;">
              </td>
              <td style="border-top: #33ccff 1pt solid">
                <asp:Button 
                  ID="CmdPost" 
                  runat="server" 
                  ValidationGroup="PostBaaNVoucher"
                  OnClick="CmdPost_Click" 
                  OnClientClick="return confirm('Post Voucher in BaaN ?')" 
                  ToolTip="Post in BaaN" CssClass="mytxt" ForeColor="Green" Text="Post in BaaN" /></td>
            </tr>
          </table>
        </td>
        <td id="tdError" runat="server" style="vertical-align: top; border-right: #33ccff 1pt solid; border-bottom: #33ccff 1pt solid;">
          <table>
            <tr>
              <td colspan="2">
                <asp:Table ID="tblErr" runat="server" BackColor="#FFE0C0" BorderColor="#FF8080" BorderStyle="Solid" BorderWidth="1pt">
                </asp:Table>
              </td>
            </tr>
            <tr>
              <td>
          <asp:Button ID="CmdCancel" runat="server" ToolTip="Cancel" Visible="False" CssClass="mytxt" ForeColor="#C00000" Text="Cancel" /></td>
              <td>
          <asp:Button ID="CmdContinue" runat="server" ToolTip="Continue" Visible="False" CssClass="mytxt" ForeColor="Green" Text="Continue" /></td>
            </tr>
          </table>
        </td>
      </tr>
      <tr><td colspan="2" style="vertical-align: top; text-align: center">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="DocumentID" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" ShowFooter="true">
      <Columns>
        <asp:TemplateField HeaderText="Doc.ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" CssClass="alignright" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Employee" SortExpression="PRK_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelEmployeeID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Eval("PRK_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Perk" SortExpression="PRK_Perks5_Description">
          <ItemTemplate>
             <asp:Label ID="LabelPerkID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Eval("PRK_Perks5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tran Type" SortExpression="TranType">
          <ItemTemplate>
            <asp:Label ID="LabelTranType" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("TranType") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tran Date" SortExpression="TranDate">
          <ItemTemplate>
            <asp:Label ID="LabelTranDate" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("TranDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value" SortExpression="Value">
          <ItemTemplate>
            <asp:Label ID="LabelValue" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" CssClass="alignright" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="UOM">
          <ItemTemplate>
            <asp:Label ID="LabelUOM" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" CssClass="alignright" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="PRK_Employees2_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LabelCreatedBy" ForeColor='<%# Eval("ForeColor") %>' runat="server" ToolTip='<%# Eval("CreatedBy") %>' Text='<%# Eval("PRK_Employees2_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Apl.ID" SortExpression="ApplicationID">
          <ItemTemplate>
            <asp:Label ID="LabelApplicationID" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("ApplicationID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="50px" CssClass="alignright" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Batch" SortExpression="BatchNo">
          <ItemTemplate>
            <asp:Label ID="LabelBatchNo" ForeColor='<%# Eval("ForeColor") %>' runat="server" Text='<%# Bind("BatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="50px" CssClass="alignright" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
      <RowStyle BackColor="PaleGoldenrod" />
      <PagerStyle BackColor="DarkGoldenrod" Font-Bold="True" HorizontalAlign="Center" />
      <HeaderStyle BackColor="DarkGoldenrod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" />
      <AlternatingRowStyle BackColor="Bisque" />
      <FooterStyle BackColor="#C04000" Font-Bold="true" ForeColor="Blue" />
    </asp:GridView>
    </td>
    </tr>
    </table>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nPrkLedger"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "GetDisplayLedgerToBePosted"
      TypeName = "SIS.NPRK.nPrkLedger"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="VoucherDate" PropertyName="Text" Name="TranDate" Type="DateTime" Size="10" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="VoucherDate" />
    <asp:AsyncPostBackTrigger ControlID="CmdPost" />
    <asp:AsyncPostBackTrigger ControlID="CmdContinue" />
    <asp:AsyncPostBackTrigger ControlID="CmdCancel" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>

